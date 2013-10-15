//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

// Variables used by server scripts & code.  The ones marked with (c)
// are accessed from code.  Variables preceeded by Pref:: are server
// preferences and stored automatically in the ServerPrefs.cs file
// in between server sessions.
//
//    (c) Server::ServerType              {SinglePlayer, MultiPlayer}
//    (c) Server::GameType                Unique game name
//    ( ) Server::MissionFile             Mission .mis file name
//    (c) Server::MissionName             DisplayName from .mis file
//    (c) Server::MissionType             Not used
//    (c) Server::PlayerCount             Current player count
//    (c) Server::GuidList                Player GUID (record list?)
//    (c) Server::Status                  Current server status
//
//    (c) Pref::Server::Name              Server Name
//    (c) Pref::Server::Password          Password for client connections
//    ( ) Pref::Server::AdminPassword     Password for client admins
//    (c) Pref::Server::Info              Server description
//    (c) Pref::Server::MaxPlayers        Max allowed players
//    ( ) Pref::Server::BanTime           Duration of a player ban
//    ( ) Pref::Server::KickBanTime       Duration of a player kick & ban
//    ( ) Pref::Server::MaxChatLen        Max chat message len
//    ( ) Pref::Server::FloodProtectionEnabled Bool

//-----------------------------------------------------------------------------


//-----------------------------------------------------------------------------

function initServer()
{
   echo("\n--------- Initializing " @ $appName @ ": Server Scripts ---------");

   // Server::Status is returned in the Game Info Query and represents the
   // current status of the server. This string sould be very short.
   $Server::Status = "Unknown";

   // Turn on testing/debug script functions
   $Server::TestCheats = false;

   // The common module provides the basic server functionality
   initBaseServer();

   // Load up game server support scripts
   exec("./commands.cs");
   exec("./game.cs");
   $Server::Loaded = true;

   if( $TAP::isDedicated )
      exec("./db/init.cs");
   else
   {
      $Server::DB::Remote = true;
      exec("./AlterVerse/remoteDBData.cs");
   }
   exec("./AlterVerse/clans.cs");
   exec("./AlterVerse/playerPersistance.cs");
   exec("./AlterVerse/inventory.cs");
   exec("./AlterVerse/health.cs");
   exec("./AlterVerse/commands.cs");
   exec("./AlterVerse/serverTransfer.cs");
   exec("./AlterVerse/serverTools.cs");
}


//-----------------------------------------------------------------------------

function initDedicated()
{
   //Check to see if the server was started with the -generateItemData switch
   //If so, generate the ItemData datablocks from the AVItems table.
   if($generateItemData)
   {
      echo(" --- Generating Item Data ---");
      exec("./game.cs");
      exec("./db/init.cs");
      GenerateItemData();
      echo(" --- Exiting after generation ---");
      quit();
      return;
   }

   enableWinConsole(true);
   echo("\n--------- Starting Dedicated Server ---------");
   
   // Initialize the server scripts
   initServer();

   // Make sure this variable reflects the correct state.
   $TAP::isDedicated = true;

   // The server isn't started unless a mission has been specified.
   if ($missionArg !$= "")
   {
      //Geev 5/23/2013	
      loadMaterials();
      mountWorldPacks($WorldName);
      loadWorldSFX(false);
      loadWorldMats(false);

      createServer("MultiPlayer", $missionArg);

      //Geev 5/23/2013	  
      decalManagerLoad( $missionArg @ ".decals" ); 
   }
   else
      echo("No mission specified (use -mission filename)");
}

//------------------------------------------------------------------------------
// clearLoadInfo
//
// Clears the mission info stored
//------------------------------------------------------------------------------
function clearLoadInfo() {
   if (isObject(theLevelInfo))
      theLevelInfo.delete();
   if (isObject(MissionInfo))
      MissionInfo.delete();
}

//------------------------------------------------------------------------------
// buildLoadInfo
//
// Extract the map description from the .mis file
//------------------------------------------------------------------------------
function buildLoadInfo( %mission ) {
	clearLoadInfo();

	%infoObject = "";
	%file = new FileObject();

	if ( %file.openForRead( %mission ) ) {
		%inInfoBlock = false;
		
		while ( !%file.isEOF() ) {
			%line = %file.readLine();
			%line = trim( %line );
			
			if( %line $= "new ScriptObject(MissionInfo) {" )
				%inInfoBlock = true;
         else if( %line $= "new LevelInfo(theLevelInfo) {" )
				%inInfoBlock = true;
			else if( %inInfoBlock && %line $= "};" ) {
				%inInfoBlock = false;
				%infoObject = %infoObject @ %line; 
				break;
			}
			
			if( %inInfoBlock )
			   %infoObject = %infoObject @ %line @ " ";
		}
		
		%file.close();
	}
	else
	   error("Level file " @ %mission @ " not found.");

   // Will create the object "MissionInfo"
	eval( %infoObject );
	%file.delete();
}

