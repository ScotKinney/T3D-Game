//************************************************************************
// UserListGui.cs

// Show/hide the gui
function UserListGui::toggle(%this)
{
   if (%this.isAwake())
      Canvas.popDialog(%this);
   else
      Canvas.pushDialog(%this);
}

//------------------------------------------------------------------------------
function UserListGui::onWake( %this )
{
   // Make sure the text has been localized
   if ( !%this.localized )
      %this.localizeText();
}

//------------------------------------------------------------------------------
function UserListGui::onSleep( %this )
{
   // If the popup menu is on the screen, hide it
   if ( UserPopup.isAwake() )
      Canvas.popDialog(UserPopup);
}

//------------------------------------------------------------------------------
function UserListGui::localizeText( %this )
{  // Replace all static text with localized versions

   // All we have are the 3 column headings
   %this-->NameButton.setText(guiStrings.ulHeading[0]);
   %this-->SkullButton.setText(guiStrings.ulHeading[1]);
   %this-->ClanButton.setText(guiStrings.ulHeading[2]);

   // Don't do it again unless the language changes
   %this.localized = true;
}


// Add a new player or update an existing line in the player list
function UserListGui::addUser(%this, %userName, %dbID, %skulls, %clanName)
{
   %text = %userName TAB %skulls TAB %clanName;

   // Update or add the player to the list control
   if (UserListGuiList.getRowNumById(%dbID) == -1)
   {
      UserListGuiList.addRow(%dbID, %text);
      %this.numPlayers++;
      //ServerListGui.updateTotal();
   }
   else
      UserListGuiList.setRowById(%dbID, %text);

   %this.sortList();
   UserListGuiList.clearSelection();
}

// Remove a player from the player list
function UserListGui::removeUser(%this, %userName, %dbID)
{
   UserListGuiList.removeRowById(%dbID);
   %this.numPlayers--;
   ServerListGui.updateTotal();
}

function UserListGui::sortList(%this)
{
   if ( %this.sortCol == 1 )
      UserListGuiList.sortNumerical(1, %this.sortAsc);
   else
      UserListGuiList.sort(%this.sortCol, %this.sortAsc);
}

function UserListGui::setSortCol(%this, %newSortCol)
{
   if ( %this.sortCol == %newSortCol )
      %this.sortAsc = !%this.sortAsc;
   %this.sortCol = %newSortCol;
   %this.sortList();
}

function UserListGui::onDoubleClick(%this)
{
   %playerID = UserListGuiList.getSelectedId();
   if ( %playerID == $currentPlayerID )
      return; // No options for ourselves

   %text = UserListGuiList.getRowTextById(%playerID);
   %name = getField(%text, 0);

   // Show the player popup menu
   UserPopup.showPopup(%playerID, %name);
}

//UserListGui.toggle();
//ServerListGui.toggle();
