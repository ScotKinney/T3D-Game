
// ----------------------------------------------------------------------------
// Profiles for front-end guis. Login and server list
// ----------------------------------------------------------------------------

   singleton GuiControlProfile (AVLoginLabelProfile)
   {
      opaque = false;
      border = 0;
      fontSize = "16";
      justify = "left";
      fontColor = "192 192 192 255";
      fontType = "Tahoma";
      borderThickness = "0";
      category = "FrontEnd";
   };

   singleton GuiControlProfile (AVLoginButtonProfile)
   {
      opaque = false;
      border = 0;
      fontSize = "12";
      justify = "center";
      fontColor = "192 192 192 255";
      fontType = "Tahoma";
      borderThickness = "0";
      category = "FrontEnd";
   };
   
   singleton GuiControlProfile(AVLoginEditProfile)
   {
      opaque = true;
      bitmap = "art/gui/textEdit";
      hasBitmapArray = true; 
      border = -2; // fix to display textEdit img
      //borderWidth = "1";  // fix to display textEdit img
      fillColor = "242 241 240 0";
      fillColorHL = "242 241 240 0";
      fontColor = "255 255 255";
      fontColorHL = "0 0 0";
      fontColorSEL = "98 100 137";
      fontColorNA = "200 200 200";
      textOffset = "4 2";
      autoSizeWidth = false;
      autoSizeHeight = false;
      justify = "left";
      tab = true;
      canKeyFocus = true;
      fontSize = 16;
      fontType = "Arial Bold";
      category = "FrontEnd";
   };

   singleton GuiControlProfile (AVLoginLinkProfile : AVInputSoundProfile)
   {
      opaque = false;
      border = 0;
      fontSize = "12";
      justify = "center";
      fontColor = "192 192 192 255";

      fillColor = "232 232 232 0";
      fillColorHL = "232 232 232 0";
      fillColorNA = "232 232 232 0";
      border = false;

      fontColorSEL = "50 50 50 255";
      fontColorHL = "50 50 50 255";
      fontColorNA = "100 100 100 255";
      
      fontColors[4] = "192 192 192 255"; // Link Color
      fontColors[5] = "255 255 255 255"; // Link Color HL

      fontType = "Tahoma";
      borderThickness = "0";
      category = "FrontEnd";
   };

   singleton SFXProfile(InitiateSound)
   {
      filename    = "art/sound/InitiatingStartUpSeq.ogg";
      description = AudioGui;
      preload = false;
   };

   singleton GuiControlProfile (AVLoginSoundProfile)
   {
      soundButtonDown = InitiateSound;
   };
