//------------------------------------------------------------------------------
// Client support for chat parties

//------------------------------------------------------------------------------
function MainChatHud::setPartyButtons( %this )
{
   if (!isObject(clientChat) || 
      ((clientChat.inParty == 0) && (clientChat.partyPending $= "")))
   {  // The player is not in a chat party
      ChatPartyPage-->ChatButton0.setText(guiStrings.chatPBCreate);
      ChatPartyPage-->ChatButton0.command = "sendChatCommand(\"mkparty\");";
      ChatPartyPage-->ChatButton0.setVisible(true);
      ChatPartyPage-->ChatButton1.setVisible(false);
      ChatPartyPage-->ChatButton2.setVisible(false);
   }
   else if ( clientChat.inParty == $currentPlayerID )
   {  // The player is the owner of a chat party
      ChatPartyPage-->ChatButton0.setText(guiStrings.chatPBClose);
      ChatPartyPage-->ChatButton0.command = "sendChatCommand(\"klparty\");";
      ChatPartyPage-->ChatButton1.setText(guiStrings.chatPBInvite);
      ChatPartyPage-->ChatButton1.command = "ChatPartyPage.showInvitePopup();";
      ChatPartyPage-->ChatButton2.setText(guiStrings.chatPBRemove);
      ChatPartyPage-->ChatButton2.command = "ChatPartyPage.showRemovePopup();";
      ChatPartyPage-->ChatButton0.setVisible(true);
      ChatPartyPage-->ChatButton1.setVisible(true);
      ChatPartyPage-->ChatButton2.setVisible(true);
   }
   else 
   {
      if ( clientChat.inParty == 0 )
      {
         ChatPartyPage-->ChatButton0.setText(guiStrings.chatPBCreate);
         ChatPartyPage-->ChatButton0.command = "sendChatCommand(\"mkparty\");";
      }
      else
      {
         ChatPartyPage-->ChatButton0.setText(guiStrings.chatPBLeave);
         ChatPartyPage-->ChatButton0.command = "sendChatCommand(\"klparty\");";
      }
      ChatPartyPage-->ChatButton0.setVisible(true);

      ChatPartyPage-->ChatButton1.setText(guiStrings.chatPBAccept);
      ChatPartyPage-->ChatButton1.command = "ChatPartyPage.showAcceptPopup();";
      ChatPartyPage-->ChatButton2.setText(guiStrings.chatPBDecline);
      ChatPartyPage-->ChatButton2.command = "ChatPartyPage.showDeclinePopup();";
      ChatPartyPage-->ChatButton1.setVisible(clientChat.partyPending !$= "");
      ChatPartyPage-->ChatButton2.setVisible(clientChat.partyPending !$= "");
   }
}

function ChatPartyPage::createParty(%this)
{  // Create a chat party for the player
   clientChat.inParty = $currentPlayerID;
   clientChat.partyPending = "";
   clientChat.partyList.empty();
   clientChat.partyList.add($currentPlayerID, $currentUsername);
   MainChatHud::setPartyButtons();
}

function ChatPartyPage::killParty(%this)
{  // Remove the chat party owned by this player
   if (ChatPopup.isAwake() && ( ChatPopup.paneControl $= "PartyOwn"))
      Canvas.popDialog(ChatPopup);
   clientChat.inParty = 0;
   clientChat.partyList.empty();
   MainChatHud::setPartyButtons();
}

function ChatPartyPage::leftParty(%this,%quitterName, %quitterID)
{  // A player has left the chat party
   %index = clientChat.partyList.getIndexFromKey(%quitterID);
   if ( %index > -1 )
      clientChat.partyList.erase(%index);
}

function ChatPartyPage::joinParty(%this,%newName, %newID)
{  // A player has joined the chat party
   %index = clientChat.partyList.getIndexFromKey(%newID);
   if ( %index == -1 )
      clientChat.partyList.add(%newID, %newName);
}

function ChatPartyPage::joiningParty(%this, %line)
{  // We are joining a chat party
   clientChat.partyList.empty();

   %numMembers = getBarWord(%line, 1);
   %memberList = "";
   for ( %i = 0; %i < %numMembers; %i++)
   {
      %memID = getBarWord(%line, %i + 2);
      %text = UserListGuiList.getRowTextById(%memID);
      %memName = getField(%text, 0);
      %memberList = %memberList @ ((%i == 0) ? "" : ", ") @ %memName;
      clientChat.partyList.add(%memID, %memName);
      if ( %i == 0 )
      {
         clientChat.inParty = %memID;
         %ownerName = %memName;
      }
   }

   // Now add us as the last in list
   clientChat.partyList.add($currentPlayerID, $currentUsername);
   %memberList = %memberList @ ", " @ $currentUsername;

   // Make the chat message
   %message = chatStrings.msg[21];
   %message = strReplace(%message, "%1", %ownerName);
   %message = strReplace(%message, "%2", %memberList);
   MainChatHud.addLine(%message, "p", true);
   MainChatHud::setPartyButtons();
}

function ChatPartyPage::invReceived(%this, %hostName, %partyID)
{  // Received an invitation to a party
   if ( clientChat.partyPending $= "" )
      clientChat.partyPending = %partyID;
   else
      clientChat.partyPending = clientChat.partyPending TAB %partyID;
   MainChatHud::setPartyButtons();
}

function ChatPartyPage::showInvitePopup(%this)
{  // Called when the invite to party button is pressed
   ChatPopup.hideAll();
   ChatPopup-->Title.setText(guiStrings.selPlayer);   // Select Player
   
   // Find all players that are not in the party and add them to the array ctrl
   if ( UserListGui.sortCol != 0 )
   {  // Make sure the user list is sorted by name, so the names are in order
      UserListGui.sortCol = 0;
      UserListGui.sortAsc = true;
      UserListGuiList.sort(0, true);
   }
   
   %count = UserListGuiList.rowCount();
   %inList = 0;
   ChatPopup-->ctrlArray.deleteAllObjects(); // Make sure control is empty
   for ( %i = 0; %i < %count; %i++ )
   {
      %idVal = UserListGuiList.getRowId(%i);
      %partyIdx = clientChat.partyList.getIndexFromKey(%idVal);
      if ((%idVal == $currentPlayerID) || (%partyIdx != -1))
         continue;
      %text = UserListGuiList.getRowText(%i);
      %name = getField(%text, 0);

      // Add the name to the array ctrl
      %chkCtrl = ChatPopup.makeCheckBox(%name);
      %chkCtrl.idVal = %idVal;
      ChatPopup-->ctrlArray.addGuiControl(%chkCtrl);
      %inList++;
   }

   // If we have players to invite, setup the buttons, format and show the popup
   if ( %inList > 0 )
   {
      ChatPopup-->PushBtn1.setText(guiStrings.chatPBSndInt);   // Send Invite
      ChatPopup-->PushBtn1.command = "ChatPartyPage.sendInvite();";
      ChatPopup-->PushBtn0.setText(guiStrings.btnCancel);   // Cancel
      ChatPopup-->PushBtn0.command = "Canvas.popDialog(ChatPopup);";

      %height = 67 + (%inList * 18);
      if ( %height > 400 )
         %height = 400;
      ChatPopup.verticalLayout(130, %height, 2);
      ChatPopup.positionAtMouse();
      ChatPopup-->Title.setVisible(true);
      ChatPopup-->scrollControl.setVisible(true);
      ChatPopup-->PushBtn0.setVisible(true);
      ChatPopup-->PushBtn1.setVisible(true);
      ChatPopup.paneControl = "PartyOwn";
      Canvas.pushDialog(ChatPopup);
   }
   else
   {  // No one to invite, put a message in chat and return
      MainChatHud.addLine(chatStrings.msg[14], "p", false, true);
   }
}

function ChatPartyPage::sendInvite(%this)
{  // Get all of the selected players and send them an invite
   %count = ChatPopup-->ctrlArray.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %chkCtrl = ChatPopup-->ctrlArray.getObject(%i);
      if ( %chkCtrl.getValue() )
         sendChatCommand("invparty|" @ %chkCtrl.idVal);
   }
   Canvas.popDialog(ChatPopup); // Close the popup
}

function ChatPartyPage::showRemovePopup(%this)
{  // Called when the remove player button is pressed
   ChatPopup.hideAll();
   ChatPopup-->Title.setText(guiStrings.selPlayer);   // Select Player
   
   // Find all players that are in the party and add them to the array ctrl
   if ( UserListGui.sortCol != 0 )
   {  // Make sure the user list is sorted by name, so the names are in order
      UserListGui.sortCol = 0;
      UserListGui.sortAsc = true;
      UserListGuiList.sort(0, true);
   }
   
   %count = clientChat.partyList.count();
   %inList = 0;
   ChatPopup-->ctrlArray.deleteAllObjects(); // Make sure control is empty
   for ( %i = 1; %i < %count; %i++ )
   {
      %idVal = clientChat.partyList.getKey(%i);
      %name = clientChat.partyList.getValue(%i);

      // Add the name to the array ctrl
      %chkCtrl = ChatPopup.makeCheckBox(%name);
      %chkCtrl.idVal = %idVal;
      ChatPopup-->ctrlArray.addGuiControl(%chkCtrl);
      %inList++;
   }

   // If we have party members, setup the buttons, format and show the popup
   if ( %inList > 0 )
   {
      ChatPopup-->PushBtn1.setText(guiStrings.chatPBConfirmRem);   // Send Remove
      ChatPopup-->PushBtn1.command = "ChatPartyPage.sendRemove();";
      ChatPopup-->PushBtn0.setText(guiStrings.btnCancel);   // Cancel
      ChatPopup-->PushBtn0.command = "Canvas.popDialog(ChatPopup);";

      %height = 67 + (%inList * 18);
      if ( %height > 400 )
         %height = 400;
      ChatPopup.verticalLayout(130, %height, 2);
      ChatPopup.positionAtMouse();
      ChatPopup-->Title.setVisible(true);
      ChatPopup-->scrollControl.setVisible(true);
      ChatPopup-->PushBtn0.setVisible(true);
      ChatPopup-->PushBtn1.setVisible(true);
      ChatPopup.paneControl = "PartyOwn";
      Canvas.pushDialog(ChatPopup);
   }
}

function ChatPartyPage::sendRemove(%this)
{  // Get all of the selected players and remove them from the party
   %count = ChatPopup-->ctrlArray.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %chkCtrl = ChatPopup-->ctrlArray.getObject(%i);
      if ( %chkCtrl.getValue() )
         sendChatCommand("remparty|" @ %chkCtrl.idVal);
   }
   Canvas.popDialog(ChatPopup); // Close the popup
}

function ChatPartyPage::showAcceptPopup(%this)
{  // Called when the accept invite button is pressed
   %numInvites = getFieldCount(clientChat.partyPending);
   if ((clientChat.partyPending $= "") || (%numInvites < 1))
      return;  // No invites to accept

   // If there is only one invite, just accept it
   if ( %numInvites == 1 )
   {
      %partyID = getField(clientChat.partyPending, 0);
      sendChatCommand("actinv|" @ %partyID);
      clientChat.partyPending = "";
      MainChatHud::setPartyButtons();
      return;
   }

   // There's more that one pending invite so let user choose
   ChatPopup.hideAll();
   ChatPopup-->Title.setText(guiStrings.selInvite);   // Select Invite
   
   ChatPopup-->ctrlArray.deleteAllObjects(); // Make sure control is empty
   for ( %i = 0; %i < %numInvites; %i++ )
   {
      %partyID = getField(clientChat.partyPending, %i);
      %text = UserListGuiList.getRowTextById(%partyID);
      %name = getField(%text, 0);

      // Add the name to the array ctrl
      %radioCtrl = ChatPopup.makeRadioBtn(%name);
      %radioCtrl.idVal = %partyID;
      ChatPopup-->ctrlArray.addGuiControl(%radioCtrl);
   }

   ChatPopup-->PushBtn1.setText(guiStrings.chatPBAccept);   // Accept Invite
   ChatPopup-->PushBtn1.command = "ChatPartyPage.sendAccept();";
   ChatPopup-->PushBtn0.setText(guiStrings.btnCancel);   // Cancel
   ChatPopup-->PushBtn0.command = "Canvas.popDialog(ChatPopup);";

   %height = 67 + (%numInvites * 18);
   if ( %height > 400 )
      %height = 400;
   ChatPopup.verticalLayout(130, %height, 2);
   ChatPopup.positionAtMouse();
   ChatPopup-->Title.setVisible(true);
   ChatPopup-->scrollControl.setVisible(true);
   ChatPopup-->PushBtn0.setVisible(true);
   ChatPopup-->PushBtn1.setVisible(true);
   ChatPopup.paneControl = "PartyOther";
   Canvas.pushDialog(ChatPopup);
}

function ChatPartyPage::sendAccept(%this)
{  // Accept the selected invite
   clientChat.partyPending = "";
   %count = ChatPopup-->ctrlArray.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %radioCtrl = ChatPopup-->ctrlArray.getObject(%i);
      if ( %radioCtrl.getValue() )
         sendChatCommand("actinv|" @ %radioCtrl.idVal);
      else
      {  // Add back any other pending invites
         if ( clientChat.partyPending $= "" )
            clientChat.partyPending = %radioCtrl.idVal;
         else
            clientChat.partyPending = clientChat.partyPending TAB %radioCtrl.idVal;
      }
   }
   Canvas.popDialog(ChatPopup); // Close the popup
   MainChatHud::setPartyButtons();
}

function ChatPartyPage::showDeclinePopup(%this)
{  // Called when the decline invite button is pressed
   %numInvites = getFieldCount(clientChat.partyPending);
   if ((clientChat.partyPending $= "") || (%numInvites < 1))
      return;  // No invites to decline

   // If there is only one invite, just decline it
   if ( %numInvites == 1 )
   {
      %partyID = getField(clientChat.partyPending, 0);
      sendChatCommand("decinv|" @ %partyID);
      clientChat.partyPending = "";
      MainChatHud::setPartyButtons();
      return;
   }

   // There's more that one pending invite so let user choose
   ChatPopup.hideAll();
   ChatPopup-->Title.setText(guiStrings.selInvite);   // Select Invite
   
   ChatPopup-->ctrlArray.deleteAllObjects(); // Make sure control is empty
   for ( %i = 0; %i < %numInvites; %i++ )
   {
      %partyID = getField(clientChat.partyPending, %i);
      %text = UserListGuiList.getRowTextById(%partyID);
      %name = getField(%text, 0);

      // Add the name to the array ctrl
      %chkCtrl = ChatPopup.makeCheckBox(%name);
      %chkCtrl.idVal = %partyID;
      ChatPopup-->ctrlArray.addGuiControl(%chkCtrl);
   }

   ChatPopup-->PushBtn1.setText(guiStrings.chatPBConfirmDec);   // Confirm Decline
   ChatPopup-->PushBtn1.command = "ChatPartyPage.sendDecline();";
   ChatPopup-->PushBtn0.setText(guiStrings.btnCancel);   // Cancel
   ChatPopup-->PushBtn0.command = "Canvas.popDialog(ChatPopup);";

   %height = 67 + (%numInvites * 18);
   if ( %height > 400 )
      %height = 400;
   ChatPopup.verticalLayout(130, %height, 2);
   ChatPopup.positionAtMouse();
   ChatPopup-->Title.setVisible(true);
   ChatPopup-->scrollControl.setVisible(true);
   ChatPopup-->PushBtn0.setVisible(true);
   ChatPopup-->PushBtn1.setVisible(true);
   ChatPopup.paneControl = "PartyOther";
   Canvas.pushDialog(ChatPopup);
}

function ChatPartyPage::sendDecline(%this)
{  // Get all of the selected invites and send decline messages
   clientChat.partyPending = "";
   %count = ChatPopup-->ctrlArray.getCount();
   for ( %i = 0; %i < %count; %i++ )
   {
      %chkCtrl = ChatPopup-->ctrlArray.getObject(%i);
      if ( %chkCtrl.getValue() )
         sendChatCommand("decinv|" @ %chkCtrl.idVal);
      else
      {  // Add back any pending invites that were not declined
         if ( clientChat.partyPending $= "" )
            clientChat.partyPending = %chkCtrl.idVal;
         else
            clientChat.partyPending = clientChat.partyPending TAB %radioCtrl.idVal;
      }
   }
   Canvas.popDialog(ChatPopup); // Close the popup
   MainChatHud::setPartyButtons();
}
