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

   %dbUserID = %Results.id;
   %dbUserName = %Results.citizen_name;
   %dbSubscribe = %Results.subscribe;//epls
   %dbCMDesi = %Results.CMDesi;//epls
   %client.dbUserID = %dbUserID;
   
   %pwd = %Results.password;
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
   %incVisits = %client.transfering ? "" : ", NumVisits=NumVisits+1";
   if(!DB::Update("AVPlayers",
   /*SET*/        "IP='"@NextToken(%client.getAddress(),"",":")@"', "@
                  "LastSeen=NOW()"@
                  %incVisits,
   /*WHERE*/      "ID='"@%dbUserID@"'"))
   {
      // need to create an entry
      if(!DB::Insert("AVPlayers",
      /*SET*/        "id, IP, NumVisits, LastSeen, Arns, Inventory",
      /*VALUES*/     "'"@%dbUserID@"', "@
                     "'"@NextToken(%client.getAddress(),"",":")@"', "@
                     "'1', 'NOW()', '3000',''"))
      {
         return("oops - could not create player record!");
      }
   }

   // now mark the user as logged-in
   DB::Update("AVUserLogin",
   /*SET*/    "currentServerId='"@$AlterVerse::serverId@"', "@
              "nextServerId=''",
   /*WHERE*/  "id='"@%dbUserID@"'");

   // finally, create the script object that will track the players stats
   %client.createPersistantStats(%dbUserID, %dbUserName);
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

   // and we're through!
   echo(%client SPC %netAddress SPC %name SPC "successfully authenticated.");
      
   return "";
}

function GameConnection::DisconnectUser(%client)
{
   echo("Finalizing client database entries for "@%client.pData.dbName@", ID"@%client.pData.dbID);
   %playTime = ((getSimTime() / 1000) - %client.joinTime) / 60;
   if ( $Server::DB::Remote )
   {
      %args = "uID=" @ %client.pData.dbID;
      remoteDBCommand("DisconnectUser", %args, %client);
   }
   else
      DB::Update("AVUserLogin", "currentServerId=''", "id='"@%client.pData.dbID@"'");
   //DB::SprocNoRet("sp_StatsPlayTime", "'" @ %client.pData.dbID @ "','" @ %playTime @ "'");
   //%client.writeAllPersistantStats(); 
   %client.deletePersistantStats();
}
