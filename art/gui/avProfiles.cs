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
