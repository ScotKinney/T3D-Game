// buildRightsGui.ed.cs

function BuildRightsGui::onWake(%this)
{
   %this.currentID = 0;
   %this.savedRights = 0;
   %this.currentRights = 0;

   // Disable input until the player list has come in
   %this.allowInput(false);

   // Get the list of players that have build rights.
   %this.SendDBCommand("GetRightsList", "sOwner="@$currentPlayerID);
}

function BuildRightsGui::onPlayerChange(%this)
{
   %selID = %this-->PlayerList.getSelected();
   if ( %selID < 1 )
      return;

   %index = %this.RightsTable.getIndexFromKey(%selID);
   %rights = %this.RightsTable.getValue(%index);
   %this.currentID = %selID;
   %this.savedRights = %rights;
   %this.setChecks(%rights);
}

function BuildRightsGui::onBoxChecked(%this, %boxNum)
{
   %checkCtrl = %this.findObjectByInternalName("rightCheck"@%boxNum, true);
   %newState = %checkCtrl.getValue();

   if ( %newState )
   {
      if ( %boxNum == 0 ) // Checked the none box, uncheck all others
      {
         for (%i = 1; %i < %this.numChecks; %i++)
         {
            %checkCtrl = %this.findObjectByInternalName("rightCheck"@%i, true);
            %checkCtrl.setValue(0);
         }
      }
      else if ( %boxNum == 1 ) // Checked the all box, check all rights boxes.
      {
         for (%i = 0; %i < %this.numChecks; %i++)
         {
            %checkCtrl = %this.findObjectByInternalName("rightCheck"@%i, true);
            %checkCtrl.setValue(%i > 0);
         }
      }
      else  // Any other box, just make sure "none" is not checked
         %this-->rightCheck0.setValue(0);
   }
   else
   {  // A box was unchecked, if it was a right,
      // make sure "all" is not still checked
      if ( %boxNum > 1 )
         %this-->rightCheck1.setValue(0);
   }
   %this.currentRights = %this.makeCurrentRights();
   %this-->ApplyButton.SetActive(%this.currentRights != %this.savedRights);
}

function BuildRightsGui::onAddButton(%this)
{
   return;
}

function BuildRightsGui::onApplyButton(%this)
{
   if ( (%this.currentID > 0) && (%this.currentRights != %this.savedRights) )
   {
      // Disable input until we know if the update was successfull
      %this.allowInput(false);

      commandToServer('AssignBuildRights', %this.currentID, %this.currentRights);
   }
}

function BuildRightsGui::allowInput(%this, %state)
{
   %this-->PlayerList.SetActive(%state);
   for (%i = 0; %i < %this.numChecks; %i++)
   {
      %checkCtrl = %this.findObjectByInternalName("rightCheck"@%i, true);
      %checkCtrl.SetActive(%state && (%this.currentID > 0));
   }
   %this-->AddButton.SetActive(%state);
   %this-->ApplyButton.SetActive(%state && (%this.currentRights != %this.savedRights));
}

function BuildRightsGui::setChecks(%this, %rights)
{
   for (%i = 0; %i < %this.numChecks; %i++)
   {
      %checkCtrl = %this.findObjectByInternalName("rightCheck"@%i, true);
      %rBitVal = mPow(2, (%i - 1));
      %checkVal = ((%rights == %i) && (%i < 2)) || (%rBitVal & %rights) ||
            ((%rights == 1) && (%i > 1));
      %checkCtrl.setValue(%checkVal);
   }
   %this.currentRights = %rights;
   %this-->ApplyButton.SetActive(%this.currentRights != %this.savedRights);
}

function BuildRightsGui::makeCurrentRights(%this)
{
   %newRights = 0;
   for (%i = 0; %i < %this.numChecks; %i++)
   {
      %checkCtrl = %this.findObjectByInternalName("rightCheck"@%i, true);
      %isChecked = %checkCtrl.getValue();
      if ( %isChecked && (%i < 2) )
         return %i;
      else if ( %isChecked )
      {
         %rBitVal = mPow(2, (%i - 1));
         %newRights += %rBitVal;
      }
   }
   
   return %newRights;
}

function BuildRightsGui::addPlayer(%this, %name, %playerID)
{
   if ( %this.numPlayers == 0 )
      %this-->PlayerList.clear();   // Clear the no players line if it's there

   %this-->PlayerList.add(%name, %playerID);
   %this.RightsTable.add(%playerID, "0");
   %this.numPlayers++;
   %this.currentID = %playerID;
   %this.currentRights = 0;
   %this-->PlayerList.setSelected(%playerID);
}

function BuildRightsGui::fillPlayerList(%this, %result)
{
   // Create an ArrayObject to track the build rights
   if ( isObject(%this.RightsTable) )
      %this.RightsTable.delete();
   %this.RightsTable = new ArrayObject();

   // Clear out any names in the popup control
   %selID = -1;
   %this-->PlayerList.clear();
   %this.numPlayers = %result.NumRights;

   if ( %this.numPlayers == 0 )
      %this-->PlayerList.add("No Players Assigned Rights", -1);
   else
   {
      for (%i = 0; %i < %this.numPlayers; %i++)
      {
         %this-->PlayerList.add(%result.PlayerName[%i], %result.PlayerID[%i]);
         %this.RightsTable.add(%result.PlayerID[%i], %result.PlayerRights[%i]);
         if ( %this.currentID == %result.PlayerID[%i] )
            %selID = %this.currentID;
      }
   }

   if ( %selID > 0 )
      %this-->PlayerList.setSelected(%selID);
   else
      %this-->PlayerList.setFirstSelected();
      
   %this.allowInput(true);
}

function BuildRightsGui::rightsUpdate(%this)
{  // Reload the build rights, they have changed
   %this.allowInput(false);
   %this.SendDBCommand("GetRightsList", "sOwner="@$currentPlayerID);
}

function BuildRightsGui::handleDBResult(%this, %result)
{
   switch$( %result.command )
   {
      case "GetRightsList":
         %this.fillPlayerList(%result);
      default:
         echo("Valid command with no handler??? (" @ %result.command @ ")");
   }
}

function BuildRightsGui::SendDBCommand(%this, %command, %params, %flag)
{
   %request = new HTTPObject() {
      class = "getRightsData";
      status = "failure";
      message = "";
      command = %command;
      sender = %this;
      flag = %flag;  // Any generic flag data needed by the response processor
   };

   switch$(%command)
   {
      case "GetRightsList":
         %message = "Filling player list...Please Wait.";
      default:
         %message = "Updating database...Please Wait.";
   }

   MessageBoxOK("Communicating with database", %message, "");
   MessageBoxOKDlg-->Button0.setVisible(false);

   %argStr = "Cmnd=" @ %command;
   if ( %params !$= "" )
      %argStr = %argStr @ "&" @ %params;
   %request.get( $serverPath, "/private_web/" @ "getToolData.php", %argStr );
}

function getRightsData::process( %this )
{
   Canvas.popDialog(MessageBoxOKDlg);
   MessageBoxOKDlg-->Button0.setVisible(true);

   switch$( %this.status )
   {
      case "success":
         %this.sender.handleDBResult(%this);
      default:
         echo(%this.message);
         MessageBoxOK( "Database Error", 
                    %this.message );
   }
   %this.schedule(0, delete);
}
