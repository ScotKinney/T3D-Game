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
