//-----------------------------------------------------------------------------
// UserPopup - Menu options when clicking on a player
//-----------------------------------------------------------------------------

function UserPopup::onSleep(%this)
{
   return;
}

function UserPopup::onWake(%this)
{
   return;
}

function UserPopup::positionAtMouse(%this)
{
   %globalPos = Canvas.getCursorPos();

   %localPos = Canvas.screenToClient(%globalPos); 
   %mouse_x = getWord(%localPos,0); 
   %mouse_y = getWord(%localPos,1);
   
   %win_size = Canvas.getExtent();
   %win_wd = getWord(%win_size,0);
   %win_ht = getWord(%win_size,1);

   %popup_size = %this-->ActionList.getExtent();
   %popup_wd = getWord(%popup_size,0) + 2;
   %popup_ht = getWord(%popup_size,1) + 2;
   %this-->PopupFrame.setExtent(%popup_wd, %popup_ht);

   // Attempt to place to the right of and below mouse
   %popup_x = ((%mouse_x + %popup_wd) < %win_wd) ? %mouse_x : (%win_wd - %popup_wd);
   %popup_y = ((%mouse_y + %popup_ht) > %win_ht) ? (%win_ht - %popup_ht) : %mouse_y;
   %this-->PopupFrame.setPosition(%popup_x, %popup_y);
}

function UserPopup::backgroundClick(%this)
{
   Canvas.popDialog(%this);
}

function UserPopup::showPopup(%this, %userID, %userName)
{  // Add options for the chosen user and show menu
   if ( !isObject(clientChat) )
      return;  // Nothing can be done without a chat connection

   // Start with an empty menu
   %this-->ActionList.clear();

   // Remeber the user we're setup for
   %this.userID = %userID;
   %this.userName = %userName;

   // Friend options
   //%isFriend = (clientChat.friendsList.getIndexFromKey(%userID) > -1);
   //if ( %isFriend )
   //{  // User is a friend, so add all friend options
      //%this-->ActionList.addRow(1, guiStrings.userOption[1]); // Remove Friend
      //// Only add IM option if the friend is currently online
      //if (UserListGuiList.getRowNumById(%userID) != -1)
         //%this-->ActionList.addRow(2, guiStrings.userOption[2]); // Send IM
      //%this-->ActionList.addRow(3, guiStrings.userOption[3]); // Send Telegram
   //}
   //else
      //%this-->ActionList.addRow(0, guiStrings.userOption[0]); // Send Friend request

   // Party Options
   if ( clientChat.inParty == $currentPlayerID )
   {
      if ( clientChat.partyList.getIndexFromKey(%userID) == -1 )
         %this-->ActionList.addRow(4, guiStrings.userOption[4]); // Invite To Party
      else
         %this-->ActionList.addRow(5, guiStrings.userOption[5]); // Remove From Party
   }

   // Mute/Unmute only for online players
   if (UserListGuiList.getRowNumById(%userID) != -1)
   {
      %isMuted = (clientChat.muteList.getIndexFromKey(%userID) > -1);
      if ( %isMuted )
         %this-->ActionList.addRow(7, guiStrings.userOption[7]); // Unmute
      else
         %this-->ActionList.addRow(6, guiStrings.userOption[6]); // Mute
   }

   // Position and show the menu
   Canvas.pushDialog(%this);
   %this.positionAtMouse();
   return;
}

function UserPopup::onClick(%this)
{
   %commandID = %this-->ActionList.getSelectedId();
   Canvas.popDialog(%this);

   switch (%commandID)
   {
      case 0: // Send Friend Request
         %message = strReplace(guiStrings.mbFriendRequest, "%1", %this.userName);
         %callback = "sendChatCommand(\"mkfrnd|1|" @ %this.userID @ "|0\");";
         ShowQuestMessageBox("", %message, 0, guiStrings.btnSend, %callback, guiStrings.btnCancel);
      case 1: // Remove Friend
         %message = strReplace(guiStrings.mbFriendRemove, "%1", %this.userName);
         %callback = "sendChatCommand(\"mkfrnd|0|" @ %this.userID @ "|0\");";
         ShowQuestMessageBox("", %message, 0, guiStrings.btnRemove, %callback, guiStrings.btnCancel);
      case 2: // Send IM
         MessageHud.makeIMHUD(%this.userID);
      case 3: // Send Telegram
         SendTelegram.showSendGui(%this.userID, %this.userName, "");
      case 4: // Invite To Party
         sendChatCommand("invparty|" @ %this.userID);
      case 5: // Remove From Party
         sendChatCommand("remparty|" @ %this.userID);
      case 6: // Mute
         sendChatCommand("mute|1|" @ %this.userID);
      case 7: // Unmute
         sendChatCommand("mute|0|" @ %this.userID);
   }
   return;
}

function UserPopup::onSelect(%this, %selID, %text)
{
   return;
}
//UserPopup.showPopup();
