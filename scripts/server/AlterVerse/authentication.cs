/*
   authentication.cs
   AlterVerse specific client authentication and loading

   Mars 2013
*/

function GameConnection::AuthenticateUser(%client)
{
   echo("Authenticating " @ %client.nameBase @ ", " @ %client.conHash);
   if ( $Server::DB::Remote )
   {
      %args = "svrID="@$AlterVerse::serverId;
      %args = %args @ "&uName=" @ %client.nameBase;
      %args = %args @ "&uHash=" @ %client.conHash;
      %args = %args @ "&isTrans=" @ %client.transfering;
      %args = %args @ "&uAddr=" @ NextToken(%client.getAddress(),"",":");
      %args = %args @ "&sOwner=" @ $AlterVerse::serverOwner;
      %args = %args @ "&avSet=" @ $AlterVerse::AvSet;
      remoteDBCommand("AuthenticateUser", %args, %client);
      return "";
   }

   // create a version of the name enclosed with double quotes as many (but not
   // all!) of the names in the database are like this
   %name = %client.nameBase;
   %name2 = "\""@%name@"\"";

   // now get the id, password and hashKey for this user
   %Results = DB::Select("nuke_users.user_id, "@
                         "nuke_users.username, "@
                         "nuke_users.user_password, "@
                         "nuke_users.subscribe, "@
                         "nuke_users.CMDesi, "@
                         "AVUserLogin.sessionKey", 
   /*FROM*/              "nuke_users, AVUserLogin", 
   /*WHERE*/             "(nuke_users.username = '" @ %name @"' OR nuke_users.username = '" @ %name2 @ "') "@
                         "AND (AVUserLogin.id = nuke_users.user_id)");
   
   // check that the user exists, and is unique
   if(%Results.getNumRows() == 0)
   {
      %Results.delete();
      return("oops - cannot find username!");
   }
   else if(%Results.getNumRows() > 1)
      echo("oops - username is not unique!");

   %dbUserID = %Results.user_id;
   %dbUserName = %Results.username;
   %dbSubscribe = %Results.subscribe;//epls
   %dbCMDesi = %Results.CMDesi;//epls
   %client.dbUserID = %dbUserID;
   
   %pwd = %Results.user_password;
   %key = %Results.sessionKey;
   %Results.delete();
   
   // hash the stored password with the session key
   %pwdCheck = getStringMD5(%pwd @ %key);
   
   // and check that this matches what the client sent us
   if(%pwdCheck !$= %client.conHash)
      return("oops - could not authenticate!");

   // if this is the first time that the client has played, then there will
   // not yet be an entry in the players table for them, so we need to create it
   // otherwise we update it
   %needsRecord = true;
   %result = DB::Select("HP_current, skulls, Arns, lastWeapon, Inventory",
                        "AVPlayers", "ID='"@%dbUserID@"'");
   if(%result.getNumRows() > 0)
   {
      %client.health = %result.HP_current;
      %client.skullLevel = %result.skulls;
      %client.arns = %result.Arns;
      %client.lastWeapon = %result.lastWeapon;
      %inventory = %result.Inventory;
      %needsRecord = false;
   }
   %result.Delete();

   if ( %needsRecord )
   {
      if(!DB::Insert("AVPlayers",
      /*SET*/        "id, IP, NumVisits, LastSeen, skulls, Arns, lastWeapon, Inventory",
      /*VALUES*/     "'"@%dbUserID@"', "@
                     "'"@NextToken(%client.getAddress(),"",":")@"', "@
                     "'1', 'NOW()', '1', '3000','',''"))
      {
         return("oops - could not create player record!");
      }
      %client.health = 300;
      %client.skullLevel = 1;
      %client.arns = 3000;
      %client.lastWeapon = "";
      %inventory = "";
   }
   else
   {
      %incVisits = %client.transfering ? "" : ", NumVisits=NumVisits+1";
      DB::Update("AVPlayers",
      /*SET*/        "IP='"@NextToken(%client.getAddress(),"",":")@"', "@
                     "LastSeen=NOW()"@
                     %incVisits,
      /*WHERE*/      "ID='"@%dbUserID@"'");
   }

   // now mark the user as logged-in
   DB::Update("AVUserLogin",
   /*SET*/    "currentServerId='"@$AlterVerse::serverId@"', "@
              "nextServerId=''",
   /*WHERE*/  "id='"@%dbUserID@"'");

   // finally, create the script object that will track the players stats
   %client.createPersistantStats(%dbUserID, %dbUserName, %inventory);
   %client.joinTime = getSimTime() / 1000;

   // set the players subscription information
   %client.subscribe = false;
   %client.CMDesi = "";
   if ( %dbSubscribe )
   {
      %client.subscribe = true;
      if ( %dbCMDesi !$= "" )
         %client.CMDesi = %dbCMDesi;
      echo(">>> Player is SUBSCRIBER:" SPC %name SPC "as" SPC %client.CMDesi);
   }

   // Get the players build rights
   if ( $AlterVerse::serverOwner $= %dbUserID )
      %client.buildRights = 1;
   else
   {
      %result = DB::Select("buildRights",
      /*FROM*/             "AVBuildRights",
      /*WHERE*/            "ownerID='" @ $AlterVerse::serverOwner @
                           "' AND playerID='" @ %dbUserID @ "'");
      if(%result.getNumRows() > 0)
         %client.buildRights = %result.buildRights;
      else
         %client.buildRights = 0;
      %result.delete();
   }

   // Get the players gender, clan and avatar setup
   %client.GetPlayerSettings();

   // and we're through!
   echo(%client SPC %netAddress SPC %name SPC "successfully authenticated.");
      
   // Let the chat server know that the user is on this level
   %count = ClientGroup.getCount();
   serverChat.sendGameCmd("addusr", $AlterVerse::serverId, %client.dbUserID,
      %count, %client.CMDesi);

   return "";
}

function GameConnection::DisconnectUser(%client)
{
   echo("Finalizing client database entries for "@%client.pData.dbName);
   %playTime = ((getSimTime() / 1000) - %client.joinTime) / 60;
   %inventory = %client.getInventoryString();
   if ( $Server::DB::Remote )
   {
      %inventory = strreplace(%inventory, "\t", "|");
      %args = "uID=" @ %client.pData.dbID;
      %args = %args @ "&uNW=" @ %client.netWorth;
      %args = %args @ "&hlth=" @ %client.health;
      %args = %args @ "&wpn=" @ %client.lastWeapon;
      %args = %args @ "&ptm=" @ %playTime;
      %args = %args @ "&inv=" @ %inventory;
      remoteDBCommand("DisconnectUser", %args, %client);
   }
   else
   {
      DB::Update("AVPlayers", "HP_current='" @ %client.health @ "', " @
                              "lastWeapon='" @ %client.lastWeapon @ "', " @
                              "Inventory='" @ %inventory @ "'", 
                              "ID='"@%client.pData.dbID@"'");
      %client.writeNetWorth(true);
      DB::Update("AVUserLogin", "currentServerId=''", "id='"@%client.pData.dbID@"'");
   }

   %client.deletePersistantStats();

   // Tell chat server to remove them from the local list
   %count = ClientGroup.getCount() - 1; // They still show in the group, so subtract 1
   if ( isObject(serverChat) )
      serverChat.sendGameCmd("remusr", $AlterVerse::serverId,
            %client.dbUserID, %count);

}

function GameConnection::GetPlayerSettings(%client)
{  // Get the players gender, clan, homeworld and avatar setup

   // Get the users homeworld and gender from nuke_bbxdata_data
   // Homeworld is field_id 10, Gender is  is field_id 11
   %results = DB::Select("xdata_value", "nuke_bbxdata_data", "field_id = '10' AND user_id = '" @ %client.dbUserID @"'");
   %client.Homeworld = (%results.getNumRows() > 0) ? %results.xdata_value : "Unknown";
   %results.Delete();
   %results = DB::Select("xdata_value", "nuke_bbxdata_data", "field_id = '11' AND user_id = '" @ %client.dbUserID @"'");
   %client.Gender = (%results.getNumRows() > 0) ? %results.xdata_value : "Male";
   %results.Delete();

   // Now find a clan ID
   %results = DB::Select("Clan_id, Clan_role_id", "AVClanMembers", "user_id = " @ %client.dbUserID);
   if ( %results.getNumRows() > 0 )
   {
      %client.clanID = %results.Clan_id;
      %client.clanRole = (%results.Clan_role_id $= "") ? "0" : %results.Clan_role_id;
   }
   else
   {  // No member entry found, see if this user is a clan leader
      %results.Delete();
      %results = DB::Select("id", "AVClans", "owner_user_id = " @ %client.dbUserID @ " AND active=b'1'");
      if ( %results.getNumRows() > 0 )
      {
         %client.clanID = %results.id;
         %client.clanRole = -1;  // No role ID for leaders
      }
      else
      {  // No entry found so they're a renegade
         %client.clanID = 0;
         %client.clanRole = -1;  // No roles for renegades
      }
   }
   %results.Delete();
   %index = $Server::ClanData.teams.getIndexFromKey(%client.clanID);
   %client.team = $Server::ClanData.teams.getValue(%index);

   // Now get the players avatar setup
   %fieldName = $AlterVerse::AvSet @ %client.Gender;
   %results = DB::Select(%fieldName, "AvatarSetup", "user_id = " @ %client.dbUserID);
   if ( %results.getNumRows() > 0 )
   {
      %evalStr = %client @ ".avOptions = " @ %results @ "." @ %fieldName @ ";";
      echo("Evaluating " @ %evalStr);
      eval(%evalStr);
   }
   else
   {  // They've never saved an avatar setup, get them the default
      %client.avOptions = ( %client.Gender $= "Male" ) ?
         MalePlayerData.DefaultSetup[%client.Homeworld] :
         FemalePlayerData.DefaultSetup[%client.Homeworld];

      if ( %client.avOptions $= "" )
         %client.avOptions = (%client.Gender $= "Male") ? 
            MalePlayerData.DefaultSetup : FemalePlayerData.DefaultSetup;
   }
   echo( %client.Gender @ " from " @ %client.Homeworld SPC 
      $Server::ClanData.clan[%client.team] @ " Clan, Team=" @ %client.team);
}
