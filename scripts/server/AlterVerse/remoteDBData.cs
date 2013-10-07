function remoteDBCommand(%command, %params, %flag)
{
   %request = new HTTPObject() {
      class = "remoteDBData";
      status = "failure";
      message = "";
      command = %command;
      flag = %flag;  // Any generic flag data needed by the response processor
   };

   %argStr = "Cmnd=" @ %command;
   if ( %params !$= "" )
      %argStr = %argStr @ "&" @ %params;
   %request.get( $serverPath, "/private_web/" @ "getServerData.php", %argStr );
}
//www.alterverse.com/private_web/getServerData.php?Cmnd=RegisterServer&SvrName=My Name&DspName=Gold Mine

function remoteDBData::process( %this )
{
   switch$( %this.status )
   {
      case "success":
         %this.handleDBResult(%this);
      default:
         echo(%this.message);
   }
   %this.schedule(0, delete);
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

      case "DisconnectUser":
      case "ServerPing":

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
      LocalClientConnection.AuthenticateUser();
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
   %client.createPersistantStats(%this.dbID, %this.dbUserName);
   %client.subscribe = %this.dbSubscribe;
   %client.CMDesi = %this.dbCMDesi;
   %client.health = %this.health;
   %client.skullLevel = %this.skullLevel;
   %client.wealth = %this.wealth;
   %client.weapon = %this.weapon;
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

   schedule(1000, 0, "commandToClient", %client, 
                   'serverTransfer', 
                   %this.sAddr, 
                   %this.spawnPt, 
                   %this.newHash,
                   %this.sName,
                   %this.sPrefix);
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
