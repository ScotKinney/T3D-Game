// Chat server connection for AlterVerse game clients

// Address for connecting to chat server from outside the fire wall
$ChatExternal = "69.168.242.196:1876";
//$ChatExternal = "127.0.0.1:28020";

function connectClientChat()
{
   if ( isObject(clientChat) )
   {
      if ( isObject(clientChat.partyList) )
         clientChat.partyList.delete();
      //if ( isObject(clientChat.friendsList) )
         //clientChat.friendsList.delete();
      if ( isObject(clientChat.muteList) )
         clientChat.muteList.delete();
      clientChat.delete(); // delete old object if it already exists
   }

   // Create new TCP object and connect to the chat server
	new TCPObject(clientChat);
	clientChat.connected = false;
	clientChat.connect($ChatExternal);
}

// Handle connection failed event
function clientChat::onConnectFailed(%this)
{  // If the connection failed, try again in 30 seconds
   //MainChatHud.addLine(chatStrings.msg[7], "a", true, false);
   error("Connection to chat server failed");
   schedule(30000, 0, "connectClientChat");
}

// Handle chat connected event
function clientChat::onConnected(%this)
{
	// now that we've connected, register the client
	%this.connected = true;
	%this.regClient();
	
	// Clear lists since they will be updated by the chat server
   ServerListGuiList.clear();
   UserListGuiList.clear();
   UserListGui.numPlayers = 0;
   %this.inParty = 0;
   %this.partyPending = "";

   %this.friendsList = new ArrayObject();
   %this.partyList = new ArrayObject();
   %this.muteList = new ArrayObject();
}

function clientChat::onDisconnect(%this)
{
   error("Lost connection to chat server");

   %this.friendsList.delete();
   %this.partyList.delete();
   %this.muteList.delete();

   MainChatHud.addLine(chatStrings.msg[7], "a", true, true);
   schedule(30000, 0, "connectClientChat");
}

// Register this user with the chat system
function clientChat::regClient(%this)
{
   // send the register command
	if ( $AlterVerse::Exec::Server )
      echo("Sending chat registration");
	%this.send("regclient|" @ $currentPlayerID @ "|" @ $pref::Player::ClanID @
	   "|" @ $pref::Player::SkullLevel @ "|" @ $IsSubscriber @ "|" @ $currentUsername @ "\n");	
}

// Process a line sent from the chat server
function clientChat::onLine(%this, %line)
{
	if ( $AlterVerse::Exec::Server )
      echo("Received line: " @ %line);

   // Get the command off the front of the line and call the handler function
   %command = getBarWord(%line, 0);

   switch$ (%command)
   {
      //************************************************************************
      case "sysmsg": // A generic system message for display in chat
         %this.cmdSysMsg(%line);
      //************************************************************************
      case "text": // A message for display in chat
         %this.cmdTextMsg(%line);
      //************************************************************************
      case "syscmd": // A system command
         %this.cmdSysMsg(%line);
      //************************************************************************
      case "joinpty": // We are joining a chat party
         ChatPartyPage.joiningParty(%line);
      //************************************************************************
      case "chatmsg": // A chat message from another client
         %this.onChatMessage(%line);
      //************************************************************************
      case "imtext": // An IM from another client
         %this.onIMText(%line);
      //************************************************************************
      case "tgram": // A telegram is being delivered
         %this.onTelegram(%line);
      //************************************************************************
      case "tbody": // A full-text telegram is being delivered
         ViewTelegram.onViewTelegram(%line);
      //************************************************************************
      case "xtgram": // A telegram is being deleted
         %this.deleteTelegram(%line);
      //************************************************************************
      case "srchres": // Player search results are being delivered
         AddFriend.addResults(%line);
   }
}

// Called when muting/unmuting players
function clientChat::doMute(%this, %playerName, %playerID, %muting)
{
   %index = %this.muteList.getIndexFromKey(%playerID);
   if ( (%index > -1) && !%muting )
   {
      %this.muteList.erase(%index);
   }
   else if ( (%index == -1) && %muting )
   {
      %this.muteList.add(%playerID, %playerName);
   }
}

// Format a localized chat message
function clientChat::formatMsg(%this, %msgCode, %numArguments, %a0, %a1, %a2, %a3, %a4)
{
   %message = chatStrings.msg[%msgCode];
   for (%i = 0; %i < %numArguments; %i++)
      %message = strReplace(%message, "%" @ (%i+1), %a[%i]);

   return %message;
}

// Text message handler
function clientChat::cmdTextMsg(%this, %line)
{
   %channel = getBarWord(%line, 1);
   %notify = getBarWord(%line, 2);
   %message = getBarWord(%line, 3);

   MainChatHud.addLine(%message, %channel, %notify);
}

// Generic system message handler
function clientChat::cmdSysMsg(%this, %line)
{
   %msgType = getBarWord(%line, 1);
   %msgCode = getBarWord(%line, 2);
   %channel = getBarWord(%line, 3);
   %notify = getBarWord(%line, 4);
   %numArguments = getBarWord(%line, 5);
   for ( %i = 0; %i < %numArguments; %i++)
      %a[%i] = getBarWord(%line, %i + 6);

   if ( %msgCode !$= "0" )
   {  // There is text to be displayed in chat
      %message = %this.formatMsg(%msgCode, %numArguments, %a0, %a1, %a2, %a3, %a4);
      MainChatHud.addLine(%message, %channel, %notify);
   }

   // If there is a handler for the specific message type call it now
   switch$ (%msgType)
   {
      //************************************************************************
      case "userjoin": // A user has joined, add them to the user list
         UserListGui.addUser(%a0, %a1, %a2, %a3);
      //************************************************************************
      case "userrem": // A user has left, remove them from the user list
         UserListGui.removeUser(%a0, %a1);
      //************************************************************************
      case "svradd": // Add a game server to the server list
         ServerListGui.addServer(%a0, %a1, %a2, %a3);
      //************************************************************************
      case "svrrem": // Remove a game server from the server list
         ServerListGui.removeServer(%a0);
      //************************************************************************
      case "svrcount": // A game server is reporting an updated player count
         ServerListGui.updateCount(%a0, %a1);
      //************************************************************************
      case "mkpty": // A chat party has been created for this player
         ChatPartyPage.createParty();
      //************************************************************************
      case "klpty": // Player is no longer in a chat party
         ChatPartyPage.killParty();
      //************************************************************************
      case "lvpty": // A player has left our chat party
         ChatPartyPage.leftParty(%a0, %a1);
      //************************************************************************
      case "jnpty": // A player has joined our chat party
         ChatPartyPage.joinParty(%a0, %a1);
      //************************************************************************
      case "ptyinv": // We have been invited to a party
         ChatPartyPage.invReceived(%a0, %a1);
      //************************************************************************
      case "frnd": // Add a player to our friends list
         ChatFriendsPage.addFriend(%a0, %a1);
      //************************************************************************
      case "xfrnd": // Remove a player from our friends list
         ChatFriendsPage.removeFriend(%a0);
      //************************************************************************
      case "mute": // We have muted or unmuted another player
         %this.doMute(%a0, %a1, %a2);
      //************************************************************************
      default: // All other messages just display in chat and exit
         return;
   }
}

// Chat message handler
function clientChat::onChatMessage(%this, %line)
{
   %channel = getBarWord(%line, 1);
   %notify = getBarWord(%line, 2);
   %text = getBarWord(%line, 3);

   // Convert back all newlines from \* and all |'s from \&
   %text = strReplace(%text, "\*", "\n");
   %text = strReplace(%text, "\&", "|");

   %message = "\c3" @ getTimeStr() @ " - " @ %text;
   MainChatHud.addLine(%message, %channel, %notify);
}

// IM handler
function clientChat::onIMText(%this, %line)
{
   %tgtName = getBarWord(%line, 1);
   %from = getBarWord(%line, 2);
   %text = getBarWord(%line, 3);

   // Convert back all newlines from \* and all |'s from \&
   %text = strReplace(%text, "\*", "\n");
   %text = strReplace(%text, "\&", "|");

   if ( %tgtName $= "" )
      %message = "\c3" @ getTimeStr() @ " - " @ %from @ chatStrings.msg[29] @ %text;
   else
   {
      %tgtText = strReplace(chatStrings.msg[30], "%1", %tgtName);
      %message = "\c3" @ getTimeStr() @ " -" @ %tgtText @ %text;
   }
   MainChatHud.addLine(%message, "f", true);
}

function sendChatMessage(%message, %pane)
{
   if ( !isObject(clientChat) || !clientChat.connected )
      return; // Not connected to a chat server

   // Convert the tab pane # to a chat channel
   switch( %pane )
   {
      case 0:
         %channel = "g";   // Global
      case 1:
         %channel = "l";   // Local
      case 2:
         %channel = "c";   // Clan
      case 3:
         %channel = "p";   // Party
      default:
         %channel = "g";   // Default to Global
   }
   
   // Convert all newlines to \* and all |'s to \&
   %message = strReplace(%message, "\n", "\*");
   %message = strReplace(%message, "|", "\&");

	clientChat.send("chatmsg|" @ %channel @ "|" @ %message @ "\n");	
}

function sendIMMessage(%message, %tgtID)
{
   if ( !isObject(clientChat) || !clientChat.connected )
      return; // Not connected to a chat server

   // Convert all newlines to \* and all |'s to \&
   %message = strReplace(%message, "\n", "\*");
   %message = strReplace(%message, "|", "\&");

	clientChat.send("immsg|" @ %tgtID @ "|" @ %message @ "\n");	
}

function sendChatCommand(%message)
{  // For sending general purpose messages that require no formatting
   if ( !isObject(clientChat) || !clientChat.connected )
      return; // Not connected to a chat server

	clientChat.send("usercmd|" @ %message @ "\n");
}

function bindChatCommands()
{
   globalActionMap.bind(keyboard, enter, toggleMessageHud );
}

function unbindChatCommands()
{
   globalActionMap.unbind( keyboard, enter);
}
