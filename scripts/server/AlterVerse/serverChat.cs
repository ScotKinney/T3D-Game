// Chat server connection for AlterVerse game servers

// Address for connecting to chat server from behind the fire wall
$ChatInternal = "192.168.100.3:1876";
$ChatExternal = "69.168.242.196:1876";

function connectServerChat()
{
   if ( isObject(serverChat) )
      serverChat.delete(); // delete old object if we've already tried connecting

   // Create new TCP object and connect to the chat server
	new TCPObject(serverChat);
	serverChat.connected = false;
	if ( $Server::DB::Remote )
      serverChat.connect($ChatExternal);
   else
      serverChat.connect($ChatInternal);
}

// Handle connection failed event
function serverChat::onConnectFailed(%this)
{  // If the connection failed, try again in 30 seconds
   error("Connection to chat server failed");
   schedule(30000, 0, "connectServerChat");
}

function serverChat::onDisconnect(%this)
{
   error("Lost connection to chat server");
   schedule(30000, 0, "connectServerChat");
}

// Handle chat connected event
function serverChat::onConnected(%this)
{
	// now that we've connected, register the server
	%this.connected = true;
	%this.regServer();
}

// Register this game server with the chat system
function serverChat::regServer(%this)
{
   %canTeleport = false;
   %hasTreasury = false;
   if ( isObject(theLevelInfo) )
   {  // Get the name and details from the level info data
      %name = theLevelInfo.displayName;
      %canTeleport = ((theLevelInfo.canTeleport) ? true : false);
      %hasTreasury = ((theLevelInfo.hasTreasury) ? true : false);
   }

   if ( %name $= "" )
      %name = $ServerName;

   // send the register command
   //echo("Sending: regserver|" @ $AlterVerse::serverId @ "|" @ %canTeleport @ "|" @ %hasTreasury @ "|" @ %name @ "\n");
	%this.send("regserver|" @ $AlterVerse::serverId @ "|" @ %canTeleport @ "|" @
	   %hasTreasury @ "|" @ %name @ "\n");	

   // If we already have players on the game, identify them to the chat server
   %count = ClientGroup.getCount();
   for(%i = 0; %i < %count; %i++)
   {
      %client = ClientGroup.getObject(%i);
      %this.sendGameCmd("addusr", $AlterVerse::serverId,
         %client.dbUserID, %count);
   }
}

// Send a game command to the chat server for routing
function serverChat::sendGameCmd(%this, %msgType, %a0, %a1, %a2, %a3, %a4)
{
   %argText = "";
   for (%i = 0; %i < 5; %i++)
      if ( %a[%i] !$= "" )
         %argText = %argText @ "|" @ %a[%i];
	%this.send("gamecmd|" @ %msgType @ %argText @ "\n");
}

// Send a game message to the chat server for routing
function serverChat::sendGameMsg(%this, %tgt, %tgtID, %msgCode, %channel, %notify, %a0, %a1, %a2, %a3, %a4)
{
   %argText = "";
   %numArguments = 0;
   for (%i = 0; %i < 5; %i++)
      if ( %a[%i] !$= "" )
      {
         %argText = %argText @ "|" @ %a[%i];
         %numArguments++;
      }
	%this.send("gamemsg|" @ %tgt @ "|" @ %tgtID @ "|" @ %msgCode @ "|" @ %channel
	   @ "|" @ %notify @ "|" @ %numArguments @ "|" @ %argText @ "\n");
}
