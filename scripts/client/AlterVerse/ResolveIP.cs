//-----------------------------------------------------------------------------
// Functions for resolving the IP of servers on our local LAN

function ResolveLocalIP(%serverAddress, %spawnPoint, %isTransfer)
{
   $LocalStartAddr = %serverAddress;
   $LocalSpawn = %spawnPoint;
   $LocalTrans = %isTransfer;
   $LocalTries++;

   // Get the port number from the passed port
   %port = getSubStr(%serverAddress, strlen($TAP::localIP)+1, -1);

   // Query the lan to see who's listening on that port
   queryLANServers(
      %port,      // lanPort for local queries
      0,          // Query flags
      "Any",       // gameTypes
      "Any",    // missionType
      //$Client::GameTypeQuery,       // gameTypes
      //$Client::MissionTypeQuery,    // missionType
      0,          // minPlayers
      120,        // maxPlayers
      0,          // maxBots
      2,          // regionMask
      0,          // maxPing
      100,        // minCPU
      0           // filterFlags
   );
}

function onServerQueryStatus(%status, %msg, %value)
{
	echo("ServerQuery: " SPC %status SPC %msg SPC %value);
   // Update query status
   // States: start, update, ping, query, done
   // value = % (0-1) done for ping and query states

   if ( %status $= "done" )
      schedule(0, 0, doJoinLocal);
}

function doJoinLocal()
{
   %sc = getServerCount();
   if ( %sc < 1 )
   {
      if ( $LocalTries < 5 )
         ResolveLocalIP($LocalStartAddr, $LocalSpawn, $LocalTrans);
      else
      {
         if ( $TAP::isDev && isFile("art/gui/devGuis/serverSel.gui") )
         {  // If it's a developer, return to the server selection gui.
            Canvas.setContent( $TAP::isTappedIn ? BlackGui : LoginGui );
            Canvas.pushDialog(ServerSelGui);
         }
         else if ( !$TAP::isTappedIn )
            Canvas.setContent( LoginGui );
         else
            quit();
      }
   }
      
   for( %i = 0; %i < %sc; %i ++ )
   {
      setServerInfo(%i);
      if ( ($ServerInfo::Name $= $ServerName) || (%i == (%sc-1)) )
      {
         %localAddr = $ServerInfo::Address;
         connectToServer(%localAddr, $LocalSpawn, $LocalTrans, true);
         return;
      }
   }
}
