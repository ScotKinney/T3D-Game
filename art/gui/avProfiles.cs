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

