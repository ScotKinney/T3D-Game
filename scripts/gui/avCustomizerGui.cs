function AVCustomizer::onWake(%this)
{
   if ( !%this.hasOptions )
      %this.makeOptions();

   // Update the gui layout
   %screenExtent = Canvas.getExtent();
   //%this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));
}

function AVCustomizer::onSleep(%this)
{
}

function AVCustomizer::onSaveClicked(%this)
{  // Save the current setup
   return;
}

function AVCustomizer::onCloseClicked(%this)
{
   return;
}

function AVCustomizer::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents. Sizes and positions are taken from the
   // reference art and scaled to the current screen height (%newHeight)
   // The reference art is 1920x1080.
   %verticalScale = %newHeight / 1080;
   %horizontalScale = %newWidth / 1920;

   // Resize the fonts used for all controls based on screen height
   %this.resizeFonts(%verticalScale);
   %useScale = 1; //%verticalScale;

   // The shadebox is 300x400
   %xExtent = mRound(300 * %useScale);
   %yExtent = mRound(400 * %useScale);
   %this-->ShadeBox.resize(0, 40, %xExtent, %yExtent);

   // There is a horizontal bar at 0, 34, 101, 317 and 398
   %this-->BarTop.resize(0, 0, %xExtent, 2);
   %yPos = mRound(34 * %useScale);
   %this-->BarMid1.resize(0, %yPos, %xExtent, 2);
   %yPos = mRound(101 * %useScale);
   %this-->BarMid2.resize(0, %yPos, %xExtent, 2);
   %yPos = mRound(317 * %useScale);
   %this-->BarMid3.resize(0, %yPos, %xExtent, 2);
   %this-->BarBottom.resize(0, %yExtent-2, %xExtent, 2);

   // The title bitmap is 77x20 @ 111,7
   %xExtent = mRound(77 * %useScale);
   %xPos = mRound(111 * %useScale);
   %yExtent = mRound(20 * %useScale);
   %yPos = mRound(7 * %useScale);
   %this-->Title.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The contact points are 16x22 @ 47,2 and 230,2
   %xExtent = mRound(16 * %useScale);
   %yExtent = mRound(22 * %useScale);
   %yPos = mRound(2 * %useScale);
   %xPos = mRound(47 * %useScale);
   %this-->LeftContact.resize(%xPos, %yPos, %xExtent, %yExtent);
   %xPos = mRound(230 * %useScale);
   %this-->RightContact.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The close button is 16x15 @ 276,9
   %xExtent = mRound(16 * %useScale);
   %xPos = mRound(276 * %useScale);
   %yExtent = mRound(15 * %useScale);
   %yPos = mRound(9 * %useScale);
   %this-->CloseBtn.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The save button is 160x49 @ 69,347
   %xExtent = mRound(160 * %useScale);
   %xPos = mRound(69 * %useScale);
   %yExtent = mRound(49 * %useScale);
   %yPos = mRound(347 * %useScale);
   %this-->SaveBtn.resize(%xPos, %yPos, %xExtent, %yExtent);

}

function AVCustomizer::resizeFonts(%this, %scaleFactor)
{  // Torque adjusts font sizes, to get the true point size we need to increase
   // the requested point size x1.2 for Tahoma
   %fontMult = 1.2;

   // The option labels are 18 point
   %fontPoint = mRound(18 * %scaleFactor);
   //AVTitle1Profile.fontSize = mRound(%fontPoint * %fontMult);

}

function AVCustomizer::makeOptions(%this)
{  // Make all of the option selection controls
   %nextY = 37;
   %this.optCtrl[0] = %this.addOption(0, %nextY, "Gender", "None", false, "None"); %nextY += 22;
   %this.optCtrl[1] = %this.addOption(1, %nextY, "Outfit", "None", true, "None"); %nextY += 22;
   %nextY += 5; // Separator
   %this.optCtrl[2] = %this.addOption(2, %nextY, "Face Shape", "Face", false, "avOptions"); %nextY += 22;
   %this.optCtrl[3] = %this.addOption(3, %nextY, "Hair", "HairStyle", true, "avOptions"); %nextY += 22;
   %this.optCtrl[4] = %this.addOption(4, %nextY, "Eye Color", "EyeColor", false, "avOptions"); %nextY += 22;
   %this.optCtrl[5] = %this.addOption(5, %nextY, "Base Skin", "SkinTone", false, "avOptions"); %nextY += 22;
   %tintPos = %nextY;
   %nextY += 22; // Tint line;
   
   %plankText = (%this.curGender == 0) ? "Facial Hair" : "Makeup";
   %category = (%this.curGender == 0) ? "FacialHair" : "Makeup";
   %table = (%this.curGender == 0) ? "avTints" : "avOptions";
   %this.optCtrl[6] = %this.addOption(6, %nextY, %plankText, %category, true, %table); %nextY += 22;
   %this.optCtrl[7] = %this.addOption(7, %nextY, "War Paint", "WarPaint", true, "avTints"); %nextY += 22;

   %this.optCtrl[8] = %this.addOption(8, %nextY, "Tattoos", "Tattoo", true, "avTints"); %nextY += 22;
   %this.optCtrl[9] = %this.addOption(9, %nextY, "Scars", "Scar", true, "avTints"); %nextY += 22;
   
   %this.hasOptions = true;
   %this.numOptions = 10;
   
   // Make all tint buttons
   %this.makeTintBtns(%tintPos);
}

function AVCustomizer::addOption(%this, %optID, %yPos, %optText, %category, %canBeNone, %table)
{  // Make and return an option selection
   %newOpt = new GuiTextCtrl() {
      text = %optText;
      maxLength = "1024";
      margin = "0 0 0 0";
      padding = "0 0 0 0";
      anchorTop = "1";
      anchorBottom = "0";
      anchorLeft = "1";
      anchorRight = "0";
      position = ("0" SPC %yPos);
      extent = "240 22";
      minExtent = "8 8";
      horizSizing = "right";
      vertSizing = "bottom";
      profile = "AVOptionTextProfile";
      visible = "1";
      active = "1";
      tooltipProfile = "GuiToolTipProfile";
      hovertime = "1000";
      isContainer = "1";
      internalName = "OptionText";
      canSave = "1";
      canSaveDynamicFields = "0";

      new GuiBitmapButtonCtrl() {
         canSaveDynamicFields = "0";
         Enabled = "1";
         isContainer = "0";
         Profile = "AVInputSoundProfile";
         horizSizing = "right";
         vertSizing = "bottom";
         position = "5 3";
         Extent = "16 16";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         command = "AVCustomizer.onSelectBtn(" @ %optID @ ", -1);";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         tooltip = "";
         bitmap = "art/gui/common/ButtonLeft";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
         internalName = "OptBtnLf";
      };
      new GuiBitmapButtonCtrl() {
         canSaveDynamicFields = "0";
         Enabled = "1";
         isContainer = "0";
         Profile = "AVInputSoundProfile";
         horizSizing = "right";
         vertSizing = "bottom";
         position = "219 3";
         Extent = "16 16";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         command = "AVCustomizer.onSelectBtn(" @ %optID @ ", 1);";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         tooltip = "";
         bitmap = "art/gui/common/ButtonRight";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
         internalName = "OptBtnRt";
      };
      new GuiBitmapButtonCtrl() {
         canSaveDynamicFields = "0";
         Enabled = "1";
         isContainer = "0";
         Profile = "AVInputSoundProfile";
         horizSizing = "right";
         vertSizing = "bottom";
         position = "179 3";
         Extent = "40 16";
         MinExtent = "8 2";
         canSave = "1";
         Visible = %canBeNone;
         Active = %canBeNone;
         command = "AVCustomizer.onClearBtn(" @ %optID @ ");";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         tooltip = "";
         bitmap = "art/gui/buttons/Eye";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
         internalName = "OptBtnRt";
      };
   };
   
   %newOpt.category = %category;
   %newOpt.numOptions = 0;
   %newOpt.optList = "";
   %newOpt.curOption = "";
   %newOpt.canBeNone = %canBeNone;
   %newOpt.table = %table;

   %this-->ShadeBox.addGuiControl(%newOpt);
   return %newOpt;
}
