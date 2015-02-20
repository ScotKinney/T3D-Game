//-----------------------------------------------------------------------------
// ChatPopup - General purpose info popup for chat system messages/requests
//-----------------------------------------------------------------------------

function ChatPopup::onSleep(%this)
{  // Remove any objects added to the array control
   %this.paneControl = "";
   %this-->ctrlArray.deleteAllObjects();
}

function ChatPopup::backgroundClick(%this)
{
   Canvas.popDialog(%this);
}

function ChatPopup::hideAll(%this)
{  // Hide all controls within the popup
   %this-->Title.setVisible(false);
   %this-->scrollControl.setVisible(false);
   %this-->PushBtn0.setVisible(false);
   %this-->PushBtn1.setVisible(false);
   %this-->PushBtn2.setVisible(false);
}

function ChatPopup::positionAtMouse(%this)
{
   %globalPos = Canvas.getCursorPos();

   %localPos = Canvas.screenToClient(%globalPos); 
   %mouse_x = getWord(%localPos,0); 
   %mouse_y = getWord(%localPos,1);
   
   %win_size = Canvas.getExtent();
   %win_wd = getWord(%win_size,0);
   %win_ht = getWord(%win_size,1);

   %popup_size = ChatPopupFrame.getExtent();
   %popup_wd = getWord(%popup_size,0);
   %popup_ht = getWord(%popup_size,1);

   // Attempt to rise to the right of and above mouse
   %popup_x = ((%mouse_x + %popup_wd) < %win_wd) ? %mouse_x : (%win_wd - %popup_wd);
   %popup_y = ((%mouse_y - %popup_ht) > 0) ? (%mouse_y - %popup_ht) : 0;
   ChatPopupFrame.setPosition(%popup_x, %popup_y);
}

function ChatPopup::verticalLayout(%this, %width, %height, %numButtons)
{  // Layout the popup as a tall narrow box
   //%this.hideAll();
   ChatPopupFrame.setExtent(%width, %height);
   %this-->backFill.setExtent(%width - 8, %height - 8);
   %this-->Title.setExtent(%width - 8, 16);
   %bottom = %height - 4;

   for ( %i = 0; %i < %numButtons; %i++ )
   {
      %btnName = "PushBtn" @ %i;
      %btnCtrl = %this.findObjectByInternalName(%btnName, true);
      %btnCtrl.setExtent(%width - 10, 16);
      %btnCtrl.setPosition(5, %bottom - 18);
      %bottom -= 18;
   }

   %this-->scrollControl.setExtent(%width - 10, %bottom - 25);
   %this-->scrollControl.setPosition(5, 23);
}

function ChatPopup::makeCheckBox(%this, %name)
{
   // Create an instance of the control
   %newCtrlID = new GuiRadioCtrl() {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "AVPopupCheckProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "120 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      tooltipprofile = "GuiToolTipProfile";
      hovertime = "1000";
      text = %name;
      groupNum = "-1";
      buttonType = "ToggleButton";
      useMouseEvents = "0";
      useInactiveState = "0";
   };
   
   return %newCtrlID;
}

function ChatPopup::makeRadioBtn(%this, %name)
{
   // Create an instance of the control
   %newCtrlID = new GuiRadioCtrl() {
      canSaveDynamicFields = "0";
      isContainer = "0";
      Profile = "BCPopupRadioProfile";
      HorizSizing = "right";
      VertSizing = "bottom";
      Position = "0 0";
      Extent = "120 18";
      MinExtent = "8 2";
      canSave = "1";
      Visible = "1";
      tooltipprofile = "GuiToolTipProfile";
      hovertime = "1000";
      text = %name;
      groupNum = "-1";
      buttonType = "RadioButton";
      useMouseEvents = "0";
      useInactiveState = "0";
   };
   
   return %newCtrlID;
}
//Canvas.pushDialog(ChatPopup);
//ChatPopup.verticalLayout(
