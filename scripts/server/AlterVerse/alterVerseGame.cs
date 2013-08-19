/*
   alterVerseGame.cs
   
   implements the gametype functionality for a alterVerse game
   when run as a dedicated server
   
   Guy Allard 2010
   Eric PL Smith 2010
*/

function AlterVerseGame::onMissionLoaded(%game)
{
   $Server::MissionType = "AlterVerse";
   parent::onMissionLoaded(%game);
}

function AlterVerseGame::initGameVars(%game)
{
   //-----------------------------------------------------------------------------
   // What kind of "player" is spawned is either controlled directly by the
   // SpawnSphere or it defaults back to the values set here. This also controls
   // which SimGroups to attempt to select the spawn sphere's from by walking down
   // the list of SpawnGroups till it finds a valid spawn object.
   // These override the values set in core/scripts/server/spawn.cs
   //-----------------------------------------------------------------------------
   $Game::defaultPlayerClass = "Player";
   $Game::defaultPlayerDataBlock = "DefaultPlayerData";
   $Game::defaultPlayerSpawnGroups = "PlayerSpawnPoints PlayerDropPoints";

   //-----------------------------------------------------------------------------
   // What kind of "camera" is spawned is either controlled directly by the
   // SpawnSphere or it defaults back to the values set here. This also controls
   // which SimGroups to attempt to select the spawn sphere's from by walking down
   // the list of SpawnGroups till it finds a valid spawn object.
   // These override the values set in core/scripts/server/spawn.cs
   //-----------------------------------------------------------------------------
   $Game::defaultCameraClass = "Camera";
   $Game::defaultCameraDataBlock = "Observer";
   $Game::defaultCameraSpawnGroups = "CameraSpawnPoints PlayerSpawnPoints PlayerDropPoints";

   // Set the gameplay parameters
   %game.duration = "";
   %game.endgameScore = 20;
   %game.endgamePause = 10;
   $Game::EndGameScore = 20;
}

function AlterVerseGame::startGame(%game)
{
   parent::startGame(%game);
}

function AlterVerseGame::endGame(%game)
{
   parent::endGame(%game);
}

function AlterVerseGame::onGameDurationEnd()
{
   // Inform the client the game is over
   for (%clientIndex = 0; %clientIndex < ClientGroup.getCount(); %clientIndex++)
   {
      %cl = ClientGroup.getObject(%clientIndex);
      commandToClient(%cl, 'GameEnd');
   }
   parent::onGameDurationEnd();
}

// onConnectRequest
// performs the authentication for the connecting client
function AlterVerseGame::onConnectRequest(%game, %client, %netAddress, %name, %passwordHash, %spawnSphere, %isTransfer)
{
   // final client login check
   %retString = Parent::onConnectRequest(%game, %client, %netAddress, %name, %passwordHash, %spawnSphere, %isTransfer);
   if(%retString !$= "")
      return %retString;

   // AlterVerse Script Modification (MAR) - Authentication bypass >>>
   // Skip the authentication if running a dev build in design mode      
   if ( isDevBuild() && $DesignMode )
   {
      %client.team = $pref::Player::TeamNum;
      %client.clanID = $pref::Player::ClanID;
      return "";
   }
   // AlterVerse Script Modification (MAR) - Authentication bypass <<<
      
   // create a version of the name enclosed with double quotes as many (but not all!) of the names
   // in the database are like this   
   %name2 = "\""@%name@"\"";
   
   // now get the id, password and hashKey for this user
   %Results = DB::Select("citizen_one.id, "@
                         "citizen_one.citizen_name, "@
                         "citizen_one.password, "@
                         //"isNull(citizen_one.citizen_number,0) as citizen_number, "@
                         "isNull(citizen_one.subscribe,0) as subscribe, "@//epls
                         "isNull(citizen_one.CMDesi,'') as CMDesi, "@//epls
                         "T3D_userLogin.sessionKey", 
   /*FROM*/              "citizen_one, T3D_userLogin", 
   /*WHERE*/             "(citizen_one.citizen_name = '" @ %name @"' OR citizen_one.citizen_name = '" @ %name2 @ "') "@
                         "AND (T3D_userLogin.id = citizen_one.id)");
   
   // check that the user exists, and is unique   
   if(%Results.getNumRows() == 0)
   {
      %Results.delete();
      return("oops - cannot find username!");
   }
   else if(%Results.getNumRows() > 1)
      //return("oops - username is not unique!");
      echo("oops - username is not unique!");
   
   %dbUserID = %Results.id;
   %dbUserName = %Results.citizen_name;
   %dbCitizenNumber = %Results.citizen_number;
   %dbSubscribe = %Results.subscribe;//epls
   %dbCMDesi = %Results.CMDesi;//epls
   %client.dbUserID = %dbUserID;
   
   %pwd = %Results.password;
   %key = %Results.sessionKey;
   %Results.delete();
   
   // hash the stored password with the session key
   %pwdCheck = getStringMD5(%pwd @ %key);
   
   // and check that this matches what the client sent us
   if(%pwdCheck !$= %passwordHash)
      return("oops - could not authenticate!");
   
   //epls For some reason, this causes a HEAP CORRUPTION error   
   //if(DB::Fetch("banned", "Players", "ID='"@%dbUserID@"'") $= "1")
   //   return("oops - you are banned!");
   
   // if this server does not allow initial logins, then make sure that this
   // player is allowed to connect to us and is not currently connected to
   // another server
   if(!$AlterVerse::allowInitialLogin)
   {
      %Results = DB::Select("T3D_serverList.serverAddress",
      /*FROM*/              "T3D_serverList, T3D_userLogin",
      /*WHERE*/             "T3D_userLogin.id='"@%dbUserID@"' "@
                            "AND T3D_serverList.serverId = T3D_userLogin.nextServerId "@
                            "AND NOT EXISTS "@
                            "(SELECT * FROM T3D_serverList WHERE T3D_serverList.serverId = T3D_UserLogin.currentServerId)");
    
      if(%Results.getNumRows() == 0)
      {
         %Results.delete();  
         return("oops - could not authenticate!");
      }
         
      if(%Results.serverAddress !$= $AlterVerse::serverAddress)
      {
         %results.delete();
         return("oops - not allowed to connect to that server!");
      }
      %Results.delete();
   }
   
   // if this is the first time that the client has played, then there will
   // not yet be an entry in the players table for them, so we need to create it
   // otherwise we update it
   %incVisits = %isTransfer ? "" : ", NumVisits=NumVisits+1";
   if(!DB::Update("Players",
   /*SET*/        "IP='"@NextToken(%client.getAddress(),"",":")@"', "@
                  "LastSeen=GetDate()"@
                  %incVisits,
   /*WHERE*/      "ID='"@%dbUserID@"'"))
   {
      // need to create an entry
      if(!DB::Insert("Players",
      /*SET*/        "id, name, IP, coins, Inventory",
      /*VALUES*/     "'"@%dbUserID@"', "@
                     "'"@%dbUserName@"', "@
                     "'"@NextToken(%client.getAddress(),"",":")@"', "@
                     //"'"@%dbCitizenNumber@"',"@
                     "'arn:3000',"@
                     "''"))
      {
         return("oops - could not create player record!");
      }
   }
   
   // now mark the user as logged-in
   DB::Update("T3D_UserLogin",
   /*SET*/    "currentServerId='"@$AlterVerse::serverId@"', "@
              "nextServerId=''",
   /*WHERE*/  "id='"@%dbUserID@"'");
   
   // finally, create the script object that will track the players stats
   %client.createPersistantStats(%dbUserID, %dbUserName);
   %client.joinTime = getSimTime() / 1000;
   
   // Make sure this user has stat records created.
   DB::SprocNoRet("sp_StatsMakeRecords", "'" @ %dbUserID @ "'");
   
   // AlterVerse Script Modification (MAR) - Clan IDs >>>
   // Get the players current clan affiliation
   %game.getClanID(%client, %dbUserID);
   // AlterVerse Script Modification (MAR) - Clan IDs <<<
   
   //epls
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
   //epls end
   
   // and we're through!
   echo(%client SPC %netAddress SPC %name SPC "successfully authenticated.");
      
   return "";
}

// onConnect is run after onConnectRequest has been accepted
function AlterVerseGame::onConnect(%game, %client, %name, %hash, %spawnPoint)
{
   // set the desired spawnpoint for the player if sent
   %client.spawnPoint = %spawnPoint;
      
   // initialize the persistant stats for this player
   %client.registerPersistantStat("health", "HP_current");
   %client.registerPersistantStat("skulls", "skulls");
   %client.registerPersistantStat("inventory", "Inventory");//epls
   %client.registerPersistantStat("coins", "coins");//epls
   %client.registerPersistantStat("lastweapon", "lastweapon");//epls
   %client.readAllPersistantStats();   
   // AlterVerse <<
   
   // then do the normal torque stuff
   Parent::onConnect(%game, %client, %name, %hash, %spawnPoint);
}

function AlterVerseGame::onClientEnterGame(%game, %client)
{
   parent::onClientEnterGame(%game, %client);
   
   // update the skull hud
   %client.updateClientSkullLevel();
   //%client.updateClientInventory();
   //%client.storeInventoryTimer = %client.schedule(30000, storeInventory);
}

function AlterVerseGame::onClientLeaveGame(%game, %client)
{
   //cancel(%client.storeInventoryTimer);

   if(isObject(%client.player))
   {
      if ( %client.player.needsDBSynch )
         %client.player.updateInventoryString(true);
      %client.setPersistantStat("inventory", %client.player.inventoryString);
      %client.setPersistantStat("lastweapon", %client.player.lastweapon);
   }

   if( isObject(%client.horse) )
      %client.horse.delete();

   Parent::onClientLeaveGame(%game, %client);

   if(isObject(%client.pData))
   {
      error("Finalizing client database entries for "@%client.pData.dbName@", ID"@%client.pData.dbID);
      DB::Update("T3D_UserLogin", "currentServerId=''", "id='"@%client.pData.dbID@"'");
      %game.cleanInventory(%client);
      %playTime = ((getSimTime() / 1000) - %client.joinTime) / 60;
      DB::SprocNoRet("sp_StatsPlayTime", "'" @ %client.pData.dbID @ "','" @ %playTime @ "'");
      %client.writeAllPersistantStats(); 
      %client.deletePersistantStats();
   }
}

function AlterVerseGame::preparePlayer(%game, %client)
{
   // use spawnpoint from server transfer if specified
   if(isObject(%client.spawnPoint))
   {
      %playerSpawnPoint = %client.spawnPoint;
      %client.spawnPoint = "";
   }
   else
   {
      %playerSL = %client.getPersistantStat("skulls");
      if ( (%playerSL $= "") && isDevBuild() && $DesignMode )
         %playerSL = 3;

      if ( (%playerSL < 3) && isObject(BogSphere) )
         %playerSpawnPoint = BogSphere;
      else if ( (%playerSL > 2) && isObject($Server::ClanSpawn[%client.team]) )
         %playerSpawnPoint = $Server::ClanSpawn[%client.team];
      else if(isObject(spawnsphere001))
         %playerSpawnPoint = spawnsphere001;
      else
         %playerSpawnPoint = pickPlayerSpawnPoint($Game::DefaultPlayerSpawnGroups);
   }
      
   %client.removeItems = %playerSpawnPoint.removeItems;
   //echo("REMOVEITEMS" SPC %client.removeItems);
   %game.spawnPlayer(%client, %playerSpawnPoint);
   
   // set the players health (remember, 100% damageLevel = 0 health)
   if(isObject(%client.player))
   {
      %maxDamage = %client.player.getDatablock().maxDamage;
      %health = %client.getPersistantStat("health");
      if(%health <= 0)
         %health = %maxDamage;
      %damageLevel = %maxDamage - %health;
      %client.player.setDamageLevel(%damageLevel);
      %client.player.newlyAdded = false;
   }
   
   // Starting equipment
   %game.loadOut(%client);

   //AISK Changes: Start
      //Give the client and player a team
      if (%client.team $= "")
        %client.team = 1;
   
      //Set the player's team based on the client's team
      %client.player.team = %client.team;
   
      //Put the player in a SimSet with its teammates
      TeamSimSets(%client.player, %client.player.team);
      //AISK Changes: End
}

function AlterVerseGame::spawnPlayer(%game, %client, %spawnPoint)
{
   Parent::spawnPlayer(%game, %client, %spawnPoint);
   // start the schedule that decreases the players health over time
   %client.scheduleHealthDecrease(); 
   //%client.storeInventoryTimer = %client.schedule(30000, storeInventory); 
}

// Determine if this client has reached the $Game::EndGameScore limit,
// and if so then cycle the game.
function AlterVerseGame::checkScore(%game, %client)
{
   //echo("score: "@ %client.score @"  "@ %game.endgameScore @" "@ $Game::EndGameScore);
   //if (%client.score >= %game.endgameScore)
   //   cycleGame();
}

function AlterVerseGame::onDeath(%game, %client, %sourceObject, %sourceClient, %damageType, %damLoc)
{
   //cancel(%client.storeInventoryTimer);
   parent::onDeath(%game, %client, %sourceObject, %sourceClient, %damageType, %damLoc);
   %game.checkScore(%sourceClient);
}

// AlterVerse Script Modification (MAR) - Clan IDs >>>
// Get the players current clan affiliation
function AlterVerseGame::getClanID(%game, %client, %dbUserID)
{  // Look for an entry in the clan_members table for this user
   %results = DB::Select("Clan_id, Clan_role_id", "Clan_members", "user_id = " @ %dbUserID);
   
   if ( %results.getNumRows() > 0 )
   {  // Entry was found so assign to a team
      %client.clanID = %results.Clan_id;
      %client.clanRole = (%results.Clan_role_id $= "") ? "0" : %results.Clan_role_id;
      %results.Delete();
      %index = $Server::ClanData.teams.getIndexFromKey(%client.clanID);
      %client.team = $Server::ClanData.teams.getValue(%index);
      if ( %client.team < 2 )
         %client.team = 2;
   }
   else
   {  // No member entry found, see if this user is a clan leader
      %results = DB::Select("id", "Clan", "owner_user_id = " @ %dbUserID);
      
      if ( %results.getNumRows() > 0 )
      {  // Entry was found so assign to a team
         %client.clanID = %results.id;
         %results.Delete();
         %client.clanRole = -1;  // No role ID for leaders
         %index = $Server::ClanData.teams.getIndexFromKey(%client.clanID);
         %client.team = $Server::ClanData.teams.getValue(%index);
         if ( %client.team < 2 )
            %client.team = 2;
      }
      else
      {  // No entry found so randomly assign to a clan
         %index = getRandom(2, $Server::ClanData.teams.count() - 1);
         %client.clanID = $Server::ClanData.teams.getKey(%index);
         %client.team = $Server::ClanData.teams.getValue(%index);
         %client.clanRole = 0;
         echo("Player randomly assigned to " @ $Server::ClanData.clan[%client.team] @ " clan.");

         if(!DB::Insert("Clan_members",
         /*SET*/        "Clan_id, user_id",
         /*VALUES*/     "'"@%client.clanID@"', '"@%dbUserID@"'"))
         {
            error("oops - could not add client to the Clan_members table!");
         }
      }
   }
}

// Find all team spawnspheres in the mission
function AlterVerseGame::GetTeamSpawns(%game)
{  // Spawnpoints are created as a global script array for fastest access
   %game.FindTeamSpawns(MissionGroup);
}

function AlterVerseGame::FindTeamSpawns(%game, %group)
{
   %numObjects = %group.getCount();
   for (%i = 0; %i < %numObjects; %i++)
   {
      %obj = %group.getObject(%i);
      %objClass = %obj.getClassName();
      if ( %objClass $= "SimGroup" )
         %game.FindTeamSpawns( %obj );
      else
      {  // Object, so see if it's a spawnsphere.
         if ( %objClass $= "SpawnSphere" )
         {
            if ( %obj.team !$= "" )
               $Server::ClanSpawn[%obj.team] = %obj;
         }
      }
   }
}
// AlterVerse Script Modification (MAR) - Clan IDs <<<

function AlterVerseGame::cleanInventory(%game, %client)
{  // Remove any inventory items that can't be taken off a server
   if ($ServerName $= "Magellan")
   {  // The XR75 and Bolts can not be taken off the magellan
      %oldInv = %client.getPersistantStat("inventory");
      echo("Old Inventory: " @ %oldInv);

      %cnt = getFieldCount(%oldInv);
      %newInv = "";
      for ( %i = 0; %i < %cnt; %i++ )
      {
         %item = getField(%oldInv, %i);
         %id = getWord(%item,0);
         if ((%id !$= XR75Weapon.ItemID) && (%id !$= XRBoltsAmmo.ItemID))
         {
            if ( %newInv !$= "" )
               %newInv = %newInv @ "\t";
            %newInv = %newInv @ %item;
         }
      }

      %client.setPersistantStat("inventory", %newInv);
      echo("New Inventory: " @ %newInv);
   }
}
