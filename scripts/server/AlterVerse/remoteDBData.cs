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
      case "ServerPing":
      case "RemoveServer":
      case "GetClanData":
         %this.fillClanTable();
      default:
         echo("Valid command with no handler??? (" @ %result.command @ ")");
   }
}

function remoteDBData::saveRegistrationData( %this )
{
   $AlterVerse::serverId = %this.serverID;
   $AlterVerse::serverName = %this.serverName;

   // we will perform a heartbeat in 90 seconds
   $heartbeatSchedule = schedule(90000, 0, alterVerseServerHeartbeat);
   echo("Server registered with database.");
   ConnectToChat();
}

function remoteDBData::fillClanTable( %this )
{
   for ( %i = 0; %i < %this.NumClans; %i++ )
   {
      %id = %this.ClanID[%i];
      %team = %this.teamNum[%i];
      %name = %this.ClanName[%i];
      $Server::ClanData.teams.add(%id, %this.teamNum[%i]);
      $Server::ClanData.clan[%team] = %this.ClanName[%i];
      $Server::ClanData.mWeapon[%id] = %this.male_weapon[%i] @ "Weapon";
      $Server::ClanData.fWeapon[%id] = %this.female_weapon[%i] @ "Weapon";
   }

   echo(%this.NumClans @ "active clans.");
   echo("Team #:ID:Clan Name");
   %numClans = $Server::ClanData.teams.count();
   for ( %i = 0; %i < %numClans; %i++ )
   {
      %id = $Server::ClanData.teams.getKey(%i);
      %team = $Server::ClanData.teams.getValue(%i);
      %name = $Server::ClanData.clan[%team];
      echo(%team @ ":" @ %id @ ":" @ %name);
   }
}
