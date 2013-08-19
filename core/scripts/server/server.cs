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

function initBaseServer()
{
   // Base server functionality
   exec("./audio.cs");
   exec("./message.cs");
   exec("./commands.cs");
   exec("./levelInfo.cs");
   exec("./missionLoad.cs");
   exec("./missionDownload.cs");
   exec("./clientConnection.cs");
   exec("./kickban.cs");
   exec("./game.cs");
   exec("./spawn.cs");
   exec("./camera.cs");
   exec("./centerPrint.cs");
}

/// Attempt to find an open port to initialize the server with
function portInit(%port)
{
   %failCount = 0;
   while(%failCount < 20 && !setNetPort(%port))
   {
      echo("Port init failed on port " @ %port @ " trying next port.");
      %port++; %failCount++;
   }

   // return success/failure here and record the port we ended up with
   if(%failCount < 20)
   {
      $AlterVerse::serverPort = %port;
      return true;
   }
   return false;
}

/// Create a server of the given type, load the given level, and then
/// create a local client connection to the server.
//
/// @return true if successful.
function createAndConnectToLocalServer( %serverType, %level )
{
   if( !createServer( %serverType, %level ) )
      return false;
   
   %conn = new GameConnection( ServerConnection );
   RootGroup.add( ServerConnection );

   %conn.setConnectArgs( $pref::Player::Name );
   %conn.setJoinPassword( $Client::Password );
   
   %result = %conn.connectLocal();
   if( %result !$= "" )
   {
      %conn.delete();
      destroyServer();
      
      return false;
   }

   return true;
}

/// Create a server with either a "SinglePlayer" or "MultiPlayer" type
/// Specify the level to load on the server
function createServer(%serverType, %level)
{
   if ( !$Server::Loaded )
      initServer();

   // Increase the server session number.  This is used to make sure we're
   // working with the server session we think we are.
   $Server::Session++;
   
   if (%level $= "")
   {
      error("createServer(): level name unspecified");
      return false;
   }
   
   // Make sure our level name is relative so that it can send
   // across the network correctly
   %level = makeRelativePath(%level, getWorkingDirectory());

   destroyServer();

   $missionSequence = 0;
   $Server::PlayerCount = 0;
   $Server::ServerType = %serverType;
   $Server::LoadFailMsg = "";
   $Physics::isSinglePlayer = true;
   
   // Setup for multi-player, the network must have been
   // initialized before now.
   if (%serverType $= "MultiPlayer")
   {
      echo("Starting multiplayer mode");
      $Physics::isSinglePlayer = false;

      // If a bind address has been set, make sure it get's used
      if ( ($AlterVerse::BindAddress !$= "") &&
         ($AlterVerse::BindAddress !$= "dynamic") )
         $Pref::Net::BindAddress = $AlterVerse::BindAddress;
      else
         $Pref::Net::BindAddress = "";

      // Set the address that we will report to the server list
      if ( $AlterVerse::ShowAddress !$= "" )
         $AlterVerse::serverAddress = $AlterVerse::ShowAddress;
      else
         $AlterVerse::serverAddress = $Pref::Net::BindAddress;

      // Make sure the network port is set to the correct pref.
      if ( $AlterVerse::StartPort $= "" )
         $AlterVerse::StartPort = $Pref::Server::Port; 
      if(!portInit($AlterVerse::StartPort))
      {
         echo("Could not initialize UDP port");
         echo("shutting down");
         schedule(5000, 0, quit);
         return;
      }
      allowConnections(true);
   }

   // Create the ServerGroup that will persist for the lifetime of the server.
   new SimGroup(ServerGroup);

   // Load up any core datablocks
   exec("core/art/datablocks/datablockExec.cs");

   // Let the game initialize some things now that the
   // the server has been created
   $Server::MissionFile = %level;
   $ServerName = FileBase(%level);
   $WorldPath = "art/worlds/" @ $ServerName;
   onServerCreated();

   loadMission(%level, true);

   // Only register with the server list if we allow connections
   if ( %serverType $= "MultiPlayer" )
      schedule(5000, 0, RegisterServer);

   return true;
}

/// Shut down the server
function destroyServer()
{
   if ( ($Server::ServerType $= "MultiPlayer") && ($AlterVerse::serverId > 0) )
   {
      if(isEventPending($heartbeatSchedule))
         cancel($heartbeatSchedule);

      if ( $Server::DB::Remote )
         remoteDBCommand("RemoveServer", "sID=" @ $AlterVerse::serverId, 0);
      else
         DB::Delete("AVServerList", "serverId='"@$AlterVerse::serverId@"'");
      $AlterVerse::serverId = 0;
   }
   
   $Server::ServerType = "";
   allowConnections(false);
   //stopHeartbeat();
   $missionRunning = false;
   
   // End any running levels
   endMission();
   onServerDestroyed();

   // Delete all the server objects
   if (isObject(ServerGroup))
      ServerGroup.delete();

   // Delete all the connections:
   while (ClientGroup.getCount())
   {
      %client = ClientGroup.getObject(0);
      %client.delete();
   }

   $Server::GuidList = "";

   // Delete all the data blocks...
   deleteDataBlocks();
   
   // Increase the server session number.  This is used to make sure we're
   // working with the server session we think we are.
   $Server::Session++;
}

/// Reset the server's default prefs
function resetServerDefaults()
{
   echo( "Resetting server defaults..." );
   
   exec( "~/defaults.cs" );
   exec( "~/prefs.cs" );

   // Reload the current level
   loadMission( $Server::MissionFile );
}

/// Guid list maintenance functions
function addToServerGuidList( %guid )
{
   %count = getFieldCount( $Server::GuidList );
   for ( %i = 0; %i < %count; %i++ )
   {
      if ( getField( $Server::GuidList, %i ) == %guid )
         return;
   }

   $Server::GuidList = $Server::GuidList $= "" ? %guid : $Server::GuidList TAB %guid;
}

function removeFromServerGuidList( %guid )
{
   %count = getFieldCount( $Server::GuidList );
   for ( %i = 0; %i < %count; %i++ )
   {
      if ( getField( $Server::GuidList, %i ) == %guid )
      {
         $Server::GuidList = removeField( $Server::GuidList, %i );
         return;
      }
   }
}

/// When the server is queried for information, the value of this function is
/// returned as the status field of the query packet.  This information is
/// accessible as the ServerInfo::State variable.
function onServerInfoQuery()
{
   return "Doing Ok";
}

function RegisterServer()
{  // Insert the server into the db server list
   if ( $AlterVerse::allowInitialLogin $= "" )
      $AlterVerse::allowInitialLogin = 0;

   if ( isObject(theLevelInfo) && (theLevelInfo.displayName !$= "") )
      $AlterVerse::displayName = theLevelInfo.displayName;
   else
      $AlterVerse::displayName = $AlterVerse::serverName;

   if ( $Server::DB::Remote )
   {
      %args = "SvrName="@$AlterVerse::serverName@"&DspName="@$AlterVerse::displayName;
      %args = %args @ "&AIL=" @ $AlterVerse::allowInitialLogin;
      %args = %args @ "&wType=" @ $AlterVerse::worldType;
      %args = %args @ "&wID=" @ $AlterVerse::worldID;
      %args = %args @ "&wOwner=" @ $currentPlayerID;
      %args = %args @ "&port=" @ $AlterVerse::serverPort;
      if ( $AlterVerse::serverAddress !$= "" )
         %args = %args @ "&addr=" @ $AlterVerse::serverAddress;
      remoteDBCommand("RegisterServer", %args, 0);
      return;
   }

   // See if there is already a server running with this name
   %goodName = false;
   %numTries = 0;
   %testName = $AlterVerse::serverName;
   while ( !%goodName )
   {
      %result = DB::Select("serverId, serverName, serverAddress, TIME_TO_SEC(TIMEDIFF(lastHeartbeat, NOW())) AS timeDiff", 
      /*FROM*/             "AVServerList", 
      /*WHERE*/            "serverName ='"@%testName@"' ");

      if(%result.getNumRows() > 0)
      {  // There is already a server with this name, if it hasn't pinged recently
			// or is from the same address, we can reuse the record.
			%curAddr = getWord( strreplace(%result.serverAddress, ":", " "), 0);
         if ( (%result.timeDiff > 120) || ($AlterVerse::serverAddress $= %curAddr) )
         {  // We can reuse this record
            $AlterVerse::serverId = %result.serverId;
            %result.delete();
            DB::Update("AVServerList", 
            /*SET*/    "serverAddress='" @ $AlterVerse::serverAddress @ ":" @
            $AlterVerse::serverPort @ "'" @
            ", displayName='" @ $AlterVerse::displayName @ "'" @
            ", serverOwner='10'" @
            ", worldType='" @ $AlterVerse::worldType @ "'" @
            ", worldID='" @ $AlterVerse::worldID @ "'" @
            ", allowInitialLogin='" @ $AlterVerse::allowInitialLogin @ "'" @
            ", manifestRoot='" @ $AlterVerse::manifestRoot @ "'" @
            ", manifestFile='" @ $AlterVerse::manifestFile @ "'" @
            ", lastHeartbeat=NOW()",
            /*WHERE*/  "serverId='"@$AlterVerse::serverId@"'");

            // we will perform a heartbeat in 90 seconds
            $heartbeatSchedule = schedule(90000, 0, alterVerseServerHeartbeat);
            echo("Server registered with database.");
            ConnectToChat();
            return;
         }
         else
         {
            %testName = $AlterVerse::serverName @ %numTries;
            %numTries++;
         }
      }
      else
      {
         %goodName = true;
         $AlterVerse::serverName = %testName;
      }
      %result.delete();
   }

   // create a new record for this server
   DB::Insert("AVServerList",
      "serverAddress, allowInitialLogin, serverName, displayName, serverOwner, worldType, worldID, manifestRoot, manifestFile",
      "'"@$AlterVerse::serverAddress@":"@$AlterVerse::serverPort@"'," @
      "'"@$AlterVerse::allowInitialLogin@"'," @
      "'"@$AlterVerse::serverName@"'," @
      "'"@$AlterVerse::displayName@"'," @
      "'10'," @
      "'"@$AlterVerse::worldType@"'," @
      "'"@$AlterVerse::worldID@"'," @
      "'"@$AlterVerse::manifestRoot@"'," @
      "'"@$AlterVerse::manifestFile@"'");

   // and now get the serverId
   %result = DB::Select("serverId",
   /*FROM*/             "T3D_serverList",
   /*WHERE*/            "serverName='"@$AlterVerse::serverName@"'");
   $AlterVerse::serverId = %result.serverId;
   echo("Server ID = " @ $AlterVerse::serverId);
   %result.delete();

   // we will perform a heartbeat in 90 seconds
   $heartbeatSchedule = schedule(90000, 0, alterVerseServerHeartbeat);
   echo("Server registered with database.");
   ConnectToChat();
}

// the heartbeat updates the database with the current time, and can be used
// to decide if a server is active
function alterVerseServerHeartbeat()
{
   if ( $Server::DB::Remote )
   {
      remoteDBCommand("ServerPing", "sID=" @ $AlterVerse::serverId, 0);
   }
   else
   {
      DB::Update("AVServerList", 
      /*SET*/    "lastHeartbeat=NOW()",
      /*WHERE*/  "serverId='"@$AlterVerse::serverId@"'");
   }

   $heartbeatSchedule = schedule(90000, 0, alterVerseServerHeartbeat);
}
