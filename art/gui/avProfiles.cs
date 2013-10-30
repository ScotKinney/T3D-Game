// ----------------------------------------------------------------------------
// General AlterVerse GUI profiles
// ----------------------------------------------------------------------------

   singleton GuiControlProfile (AVToolTipProfile)
   {
      fillColor = "10 10 10 180";
      fontType = "Arial";
      fontSize = 14;
      fontColor = "255 255 255 255";
      category = "AlterVerse";
   };

   singleton SFXProfile(AvGuiSound)
   {
      filename    = "art/sound/itemTake.ogg";
      description = AudioGui;
      preload = true;
   };

   singleton GuiControlProfile (AVInputSoundProfile)
   {
      soundButtonDown = AvGuiSound;
   };

   singleton GuiControlProfile (AVProgressTextProfile)
   {
      opaque = false;
      border = 0;
      fontSize = "14";
      justify = "center";
      fontColor = "192 192 192 255";
      fontType = "Arial";
      borderThickness = "0";
      category = "AlterVerse";
   };

   singleton GuiControlProfile( AVTAPLinkProfile )
   {
      justify = "left";
      tab = true;
      canKeyFocus = true;   
      category = "AlterVerse";
   };

   singleton GuiControlProfile(AVToolbarBorderProfile)
   {
      category = "AlterVerse";
      bitmap = "core/art/gui/toolbar/AVToolbarBorder.png";
      hasBitmapArray = "1";
      opaque = "0";
      category = "AlterVerse";
   };

   singleton GuiControlProfile (AVPanelText)
   {
      // fill color
      fillColor = "239 237 222";

      // border color
      borderColor   = "138 134 122";

      // font
      fontType = "Arial";
      fontSize = 14;
      fontColor = "255 255 255";

      category = "AlterVerse";
   };
   singleton GuiControlProfile (AVPanelTextCenter : AVPanelText)
   {
      justify = "center";
      category = "AlterVerse";
   };

   singleton GuiControlProfile(AVPanelTextCenterBold : AVPanelTextCenter)
   {
      fontType = "Arial Bold";
   };

   singleton GuiControlProfile(AVShapeNameHud : GuiModelessDialogProfile)
   {
      fontColor = "0 255 0";
      fontColors[1] = "0 255 0"; // Human Player Names
      fontColors[2] = "0 255 0"; // Horse Names
      fontColors[3] = "0 255 0"; // Treasuries
      fontColors[4] = "0 255 0"; // AI Names
      fontColors[5] = "0 255 0"; // Not used yet
   };

   singleton GuiControlProfile (AVToolPanel) 
   {
      opaque = false;
      border = -2;
      bitmap = "tools/editorClasses/gui/panels/menu-fullborder";
      category = "AlterVerse";
   };

   singleton GuiControlProfile (AVToolsTextCenter)
   {
      fontColor = "50 50 50";
      fontType = "Arial Bold";
      fontSize = 16;
      justify = "center";
      category = "Tools";
   };

   singleton GuiControlProfile (AVWebResponderProfile)
   {
      canKeyFocus = true;
      category = "Tools";
   };
