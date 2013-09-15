// Clan functions

function InitClanTable()
{
   MakeClanTable();

   if ( $Server::DB::Remote )
   {
      remoteDBCommand("GetClanData", "", 0);
      return;
   }

   // Read the data for all active clans
   %results = DB::Select("id, name, teamNum",
         "AVClans", "active=b'1'", "id");
   %numClans = %results.getNumRows();

   for ( %i = 0; %i < %numClans; %i++ )
   {
      $Server::ClanData.teams.add(%results.id, $Server::ClanData.nextTeam);
      $Server::ClanData.clan[$Server::ClanData.nextTeam] = %results.name;
      $Server::ClanData.nextTeam++;
      if ( (%i >= (%numClans - 1)) || !%results.nextRow() )
         break;
   }

   if ( %numClans > 0 )
      %results.Delete();

   echo(%numClans @ "active clans.");
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

function DeleteClanTable()
{
   if ( isObject($Server::ClanData.teams) )
      $Server::ClanData.teams.delete();
   if ( isObject($Server::ClanData) )
      $Server::ClanData.delete();
}

function MakeClanTable()
{
   DeleteClanTable();

   // Create an object to store clan info
   $Server::ClanData = new ScriptObject();
   $Server::ClanData.teams = new ArrayObject();
   if ( !isObject($Server::ClanData.teams) )
      return;

   // Teams are indexed by clan ID
   $Server::ClanData.teams.add("0", "0");
   $Server::ClanData.teams.add("1", "1");
   $Server::ClanData.nextTeam = 2;

   // Clan names are indexed by team #
   $Server::ClanData.clan[0] = "Renegade"; // Team #0 is for observers not in game
   $Server::ClanData.clan[1] = "Non-Clan AI"; // Team #1 is for AI that attack anything
}

// Give the client his teams default weapon
function GameConnection::giveClanWeapon(%client)
{
   if (%client.gender $= "MALE")
      %client.clanWeapon = $Server::ClanData.mWeapon[%client.clanID];
   else
      %client.clanWeapon = $Server::ClanData.fWeapon[%client.clanID];
}

function GameConnection::isClanWeapon(%client, %itemID)
{
   %numTeams = $Server::ClanData.teams.count();

   // The first 2 teams, observers and AI, don't have clan weapons
   for ( %i = 2; %i < %numTeams; %i++ )
   {
      %cid = $Server::ClanData.teams.getKey(%i);
      if ( %itemID == $Server::ClanData.mWeapon[%cid].ItemID )
         return true;
      if ( %itemID == $Server::ClanData.fWeapon[%cid].ItemID )
         return true;
   }

   return false;
}
