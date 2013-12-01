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

   singleton GuiControlProfile (AVGuiWindowProfile)
   {
      fontType = "Arial Bold";
      fontSize = 16;
      opaque = false;
      border = 2;
      fillColor = "20 20 20";
      fillColorHL = "68 68 68";
      fillColorNA = "128 128 128";
      fontColor = "50 50 50";
      fontColorHL = "0 0 0";
      bevelColorHL = "255 255 255";
      bevelColorLL = "0 0 0";
      text = "untitled";
      bitmap = "core/art/gui/images/window";
      textOffset = "8 4";
      hasBitmapArray = true;
      justify = "left";
      yPositionOffset = "21";
      category = "AlterVerse";
   };

   singleton GuiControlProfile( AVGuiTextEditProfile )
   {
      fontType = "Arial Bold";
      fontSize = 16;
      opaque = true;
      bitmap = "./images/textEdit";
      hasBitmapArray = true; 
      border = -2; // fix to display textEdit img
      fillColor = "80 80 80";
      fillColorHL = "80 80 80";
      fontColor = "255 255 255";
      fontColorHL = "255 255 255";
      fontColorSEL = "98 100 137";
      fontColorNA = "200 200 200";
      textOffset = "4 2";
      autoSizeWidth = false;
      autoSizeHeight = true;
      justify = "left";
      tab = true;
      canKeyFocus = true;   
      category = "AlterVerse";
   };

   singleton GuiControlProfile( AVGuiNumberEditProfile : AVGuiTextEditProfile )
   {
      numbersOnly = "1";
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

   singleton GuiControlProfile(AVToolbarIconProfile)
   {
      opaque = "1";
      fillColor = "1 1 1 70";
      bitmap = "";
      hasBitmapArray = "0";
      category = "AlterVerse";
   };

   singleton GuiControlProfile(AVHealthTextProfile)
   {
      justify = "Center";
      bitmap = "";
      hasBitmapArray = "0";
      fontType = "Arial Bold";
      fontSize = 28;
      fontColor = "255 255 255";
   };

   singleton GuiControlProfile(AVToolbarStatTextProfile : AVGuiTextEditProfile)
   {
      justify = "Center";
      bitmap = "";
      hasBitmapArray = "0";
      category = "AlterVerse";
   };

singleton GuiControlProfile (AVPanelCaptionProfile)
{
   opaque = false;
   justify = "center";
   fontType = "Arial Bold";
   fontSize = 24;
   fontColor = "200 200 200";
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
      category = "AlterVerse";
   };

   singleton GuiControlProfile (AVPanelTextRight : AVPanelText)
   {
      justify = "right";
      category = "AlterVerse";
   };

   singleton GuiControlProfile (AVPanelTextBold : AVPanelText)
   {
      fontType = "Arial Bold";
      fontSize = 16;
      category = "AlterVerse";
   };

   singleton GuiControlProfile (AVPanelSRB : AVPanelText)
   {  // Small right-bold
      fontType = "Arial Bold";
      justify = "right";
      category = "AlterVerse";
   };

   singleton GuiControlProfile( AVSlider : AVPanelText )
   {
      bitmap = "core/art/gui/images/slider";
      category = "AlterVerse";
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

   singleton GuiControlProfile(AV_HUD_InfoBox_Profile)
   {
      fontColorLink = "255 96 96";
      fontColorLinkHL = "0 0 255";
   };

   singleton GuiControlProfile(AV_HUD_InfoBox_Backdrop_Profile)
   {
      fontColorLink = "255 96 96";
      fontColorLinkHL = "0 0 255";
      opaque = true;
      fillColor = "0 0 0 200";
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

   singleton SFXProfile(RiftGainFocusSound)
   {
      filename    = "art/sound/ui/webshape_gain_focus.ogg";
      description = AudioGui;
      preload = false;
   };

   singleton SFXProfile(RiftLoseFocusSound)
   {
      filename    = "art/sound/ui/webshape_lose_focus.ogg";
      description = AudioGui;
      preload = false;
   };

   singleton GuiControlProfile (AVWebResponderProfile)
   {
      canKeyFocus = true;
      soundButtonDown = RiftGainFocusSound;
      soundButtonOver = RiftLoseFocusSound;
      category = "Tools";
   };
