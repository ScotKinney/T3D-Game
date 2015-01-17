function remoteDBCommand(%command, %params, %flag)
{
   if ( !isObject($AlterVerse::DBComm) )
      makeDBComm();

   %queueStr = %flag @ "|" @ %command @ "|" @ %params;
   DBComm.commandID += 1;
   DBComm.push_back(DBComm.commandID, %queueStr);

   if ( $pref::MarsMachine )
      echo("!!!Queueing Command #" @ DBComm.commandID @ ", Flag: " @ %flag @ ", " @ %command @ "&" @ %params);

   if ( !DBComm.commandPending )
      DBComm.sendNext();
}

function makeDBComm()
{
   // Don't let this go into the server group or it will get deleted before 
   // the command to unregister the server has processed
   %oldGroup = $instantGroup;
   $instantGroup = 0;

   $AlterVerse::DBComm = new ArrayObject(DBComm)
   {
      commandID = 0;
      commandPending = false;
   };

   $instantGroup = %oldGroup;
}

function DBComm::sendNext(%this)
{
   if ( %this.count() <= 0 )
      return;

   %commID = %this.getKey(0);
   %queueStr = %this.getValue(0);
   %this.pop_front();
   %this.commandPending = true;

   %flag = getBarWord(%queueStr, 0);
   %command = getBarWord(%queueStr, 1);
   %params = getSubStr(%queueStr, (strlen(%flag) + strlen(%command) + 2), -1);

   // The HTTP object will delete itself when the command is processed or the
   // connection is closed.
   %oldGroup = $instantGroup;
   $instantGroup = 0;
   %request = new HTTPObject() {
      class = "remoteDBData";
      status = "failure";
      message = "";
      command = %command;
      commID = %commID;
      flag = %flag;  // Any generic flag data needed by the response processor
   };
   $instantGroup = %oldGroup;

   %argStr = "Cmnd=" @ %command;
   if ( %params !$= "" )
      %argStr = %argStr @ "&" @ %params;
   %request.get( $serverPath, "/private_web/" @ "getServerData.php", %argStr );
   if ( $pref::MarsMachine )
      echo("!!!Sending Command #" @ %commID @ ", ID: " @ %request @ ", " @ %argStr);
}

function DBComm::cleanUpObj(%this, %lastObj)
{
   if ( $pref::MarsMachine )
      echo("!!!Cleaning Up Command #" @ %lastObj.commID @ ", ID: " @ %lastObj @ ", " @ %lastObj.status);

   %lastObj.delete();
   %this.commandPending = false;
   %this.sendNext();
}

function remoteDBData::process( %this )
{
   switch$( %this.status )
   {
      case "success":
         %this.handleDBResult(%this);
      default:
         echo(%this.message);
   }
   if ( isObject(DBComm) )
      DBComm.schedule(0, cleanUpObj, %this);
}

function remoteDBData::handleDBResult( %this )
{
   switch$( %this.command )
   {
      case "RegisterServer":
         %this.saveRegistrationData();
      case "RemoveServer":
         %this.serverRemoved();
      case "AuthenticateUser":
         %this.saveAuthenticationData();
      case "MoveUser":
         %this.moveUserTo();
      case "GetClanData":
         %this.fillClanTable();
      case "AssignRights":
         %this.updateRights();
      case "TransferArn":
         %this.arnsTransfered();

      // The following commands need no return processing
      case "DisconnectUser":
      case "ServerPing":
      case "SetArn":
      case "SetNetWorth":
      case "SetLockLevel":

      default:
         echo("Valid command with no handler??? (" @ %this.command @ ")");
   }
}

function remoteDBData::saveRegistrationData( %this )
{
   $AlterVerse::serverId = %this.serverID;
   $AlterVerse::serverName = %this.serverName;
   $Pref::Server::Name = %this.serverName;
   $AlterVerse::ownerName = %this.ownerName;

   // If we have a local client connected, authenticate them now
   if ( isObject(LocalClientConnection) )
   {
      echo("Authenticating local client");
      LocalClientConnection.schedule(10, "AuthenticateUser");
   }

   // we will perform a heartbeat in 90 seconds
   $heartbeatSchedule = schedule(90000, 0, alterVerseServerHeartbeat);
   echo("Server registered with database.");
   ConnectToChat();
}

function remoteDBData::saveAuthenticationData( %this )
{
   %client = %this.flag;
   if ( %this.dbID $= "0" )
   {  // There was an authentication error
      commandToClient(%client, 'AuthError', %this.message);
      return;
   }

   %client.dbUserID = %this.dbID;
   %client.subscribe = %this.dbSubscribe;
   %client.CMDesi = %this.dbCMDesi;
   %client.isDev = %this.isDev;
   %client.health = %this.health;
   %client.skullLevel = %this.skullLevel;
   %client.arns = %this.wealth;
   %client.lastWeapon[0] = $AlterVerse::ItemNames[getWord(%this.weapon, 0)];
   %client.lastWeapon[1] = $AlterVerse::ItemNames[getWord(%this.weapon, 1)];
   if ( %client.inGame )
   {
      %client.createPersistantStats(%this.dbID, %this.dbUserName, %this.inventory);
      if ( isObject(%client.player) )
         %client.player.AVResetWpnState();
   }
   else
   {
      %client.startInv = %this.inventory;
      %client.createPersistantStats(%this.dbID, %this.dbUserName, "");
   }
   %client.buildRights = %this.rights;
   %client.Homeworld = %this.homeworld;
   %client.Gender = %this.gender;
   %client.clanID = %this.clanID;
   %client.clanRole = %this.clanRole;
   %client.avOptions = %this.avOpts;

   %index = $Server::ClanData.teams.getIndexFromKey(%client.clanID);
   %client.team = $Server::ClanData.teams.getValue(%index);

   if ( %client.avOptions $= "" )
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

   if ( isObject(%client.player) )
      %client.player.setAvOptions(%client.avOptions);

   // Let the chat server know that the user is on this level
   %count = ClientGroup.getCount();
   serverChat.sendGameCmd("addusr", $AlterVerse::serverId, %client.dbUserID,
      %count, %client.CMDesi);

}

function remoteDBData::moveUserTo( %this )
{
   %client = %this.flag;
   if ( %this.canTP $= "0" )
   {  // Error looking up target server data
      %client.teleDest = "";
      return;
   }

   // Play any teleport effect here.
   %transferDelay = 50;
   if ( !%client.triggeredMove )
   {
      %client.player.playLeaveEffect();
      %transferDelay = 2000;
   }

   if ( (%this.sFile !$= "") && (%this.sRoot !$= "") )
      schedule(%transferDelay, 0, "commandToClient", %client,
                      'serverTransferStream',
                      %this.sFile,
                      %this.sRoot,
                      %this.sAddr,
                      %this.spawnPt,
                      %this.newHash,
                      %this.sName,
                      %this.sPrefix,
                      %this.murmur);
   else
      schedule(%transferDelay, 0, "commandToClient", %client,
                      'serverTransfer',
                      %this.sAddr,
                      %this.spawnPt,
                      %this.newHash,
                      %this.sName,
                      %this.sPrefix,
                      %this.murmur);
}

function remoteDBData::fillClanTable( %this )
{
   for ( %i = 0; %i < %this.NumClans; %i++ )
   {
      %id = %this.ClanID[%i];
      %team = $Server::ClanData.nextTeam;
      %name = %this.ClanName[%i];
      $Server::ClanData.teams.add(%id, %team);
      $Server::ClanData.clan[%team] = %this.ClanName[%i];
      $Server::ClanData.nextTeam++;
   }

   echo(%this.NumClans @ " active clans.");
   echo("Team #:ID:Clan Name");
   %numClans = $Server::ClanData.teams.count();
   for ( %i = 0; %i < %numClans; %i++ )
   {
      %id = $Server::ClanData.teams.getKey(%i);
      %team = $Server::ClanData.teams.getValue(%i);
      %name = $Server::ClanData.clan[%team];
      echo(%team @ ":" @ %id @ ":" @ %name);
   }
   return;
}

function remoteDBData::serverRemoved( %this )
{
   if ( $TAP::isDedicated )
   {
      $TAP::isDedicated = false;
      schedule(1, 0, "quit");
   }
   $AlterVerse::serverId = 0;
}

function remoteDBData::updateRights( %this )
{
   if ( !%this.rightsAssigned )
   {
      commandToClient(%client, 'RightsRefused', 1);
      return;
   }

   // If the target player is on the server, update their data
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++)
   {
      %tmpClient = ClientGroup.getObject(%i);
      if ( %tmpClient.dbUserID == %this.playerID )
      {
         %tmpClient.buildRights = %this.rights;
         break;
      }
   }

   schedule( 0, 0, commandToClient, %this.flag, 'RightsAccepted');
}

function remoteDBData::arnsTransfered( %this )
{
   if ( %this.transAmount == 0 )
   {
      messageClient(%this.flag, 'LocalizedMsg', "", "minTransfer", "a", true, true, 1, %this.reqAmount);
      return;
   }

   %this.flag.schedule(10, "giveArns", %this.transAmount);
   
   CommandToClient(%this.flag, 'ReserveUpdate', %this.reserveLeft);

   // update the clients net worth here
   %this.flag.netWorth = mAddBigNumbers(%this.flag.netWorth, %this.transAmount);
   %this.flag.schedule(10, "writeNetWorth");
   commandToClient(%this.flag, 'setNetWorth', %this.flag.netWorth);
}
