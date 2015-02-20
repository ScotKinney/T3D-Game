
function AvOverlays::clearAllOptions(%this)
{
   %this.numControls = 0;
   %this-->checkBoxArray.deleteAllObjects();
}

function AvOverlays::addOption(%this, %optID, %optName)
{
   // Create an instance of the control
   %newCtrlID = new GuiCheckBoxCtrl() {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "AVPopupCheckProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "226 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      Command = "AvOverlays.onOverlayChange(" @ %optID @ ");";
      tooltipprofile = "GuiToolTipProfile";
      hovertime = "1000";
      text = %optName;
      groupNum = "-1";
      buttonType = "ToggleButton";
      useMouseEvents = "0";
      useInactiveState = "0";
      optionID = %optID;
   };

   // Add it to the control array
   %this-->checkBoxArray.addGuiControl(%newCtrlID);
   %this.numControls++;
}

function AvOverlays::onOverlayChange(%this, %optID)
{
   %this.makeOverlayStr();
   AvSelectionGui.onOverlayChange();
}

function AvOverlays::checkOption(%this, %optID)
{
   for (%i = 0; %i < %this.numControls; %i++)
   {
      if ( %this-->checkBoxArray.getObject(%i).optionID == %optID )
      {
         %this-->checkBoxArray.getObject(%i).setValue(1);
         return;
      }
   }
}

function AvOverlays::makeOverlayStr(%this)
{
   %this.overlayStr = "";
   for (%i = 0; %i < %this.numControls; %i++)
   {
      if ( %this-->checkBoxArray.getObject(%i).getValue() )
      {
         %optID = %this-->checkBoxArray.getObject(%i).optionID;
         if ( %this.overlayStr !$= "" )
            %this.overlayStr = %this.overlayStr @ ",";
         %this.overlayStr = %this.overlayStr @ %optID;
      }
   }
}

function AvOverlays::onClearAllClick(%this)
{
   for (%i = 0; %i < %this.numControls; %i++)
      %this-->checkBoxArray.getObject(%i).setValue(0);
   
   %this.overlayStr = "";
   AvSelectionGui.onOverlayChange();
}

