// ----------------------------------------------------------------------------
// Gui profiles used by the avatar customizer
// ----------------------------------------------------------------------------

singleton GuiControlProfile (AVPlankTextProfile)
{
   opaque = false;
   border = 0;
   fontSize = "16";
   justify = "center";
   fontColor = "210 210 210 255";
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   borderThickness = "0";
   category = "AVCustomizer";
};

singleton GuiControlProfile( AVPlankButtonProfile : AVInputSoundProfile )
{
   fontSize = 16;
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   fontColor = "210 210 210 255";
   fontColorHL = "255 255 255 255";
   fontColorNA = "100 100 100 255";
   border = false;
   fixedExtent = false;
   justify = "center";
   category = "AVCustomizer";
};

singleton GuiControlProfile (AVHomeworldTitleProfile)
{
   opaque = false;
   border = 0;
   fontSize = "26";
   justify = "center";
   fontColor = "255 255 255 255";
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   borderThickness = "0";
   category = "AlterVerse";
};

singleton GuiControlProfile (AVInfoTextProfile)
{
   opaque = false;
   border = 0;
   fontSize = "10";
   justify = "center";
   fontColor = "200 200 200 200";
   fontType = "Arial Bold";
   borderThickness = "0";
   category = "AlterVerse";
};

singleton GuiControlProfile (AVScrollTitleProfile)
{
   opaque = false;
   border = 0;
   fontSize = "18";
   justify = "center";
   fontColor = "0 0 0 255";
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   borderThickness = "0";
   category = "AlterVerse";
};

singleton GuiControlProfile (AVScrollTextProfile)
{
   opaque = false;
   border = 0;
   fontSize = "18";
   justify = "center";
   fontColor = "0 0 0 255";
   //fontType = "Trajan Pro";
   fontType = "Tahoma";
   borderThickness = "0";
   category = "AlterVerse";
};

singleton GuiControlProfile (AVScrollButtonProfile : AVInputSoundProfile)
{
   opaque = false;
   fillColor = "232 232 232 0";
   fillColorHL = "232 232 232 0";
   fillColorNA = "232 232 232 0";
   border = false;

   fontColor = "0 0 0 255";
   fontColorSEL = "50 50 50 255";
   fontColorHL = "50 50 50 255";
   fontColorNA = "100 100 100 255";

   fontSize = "18";
   justify = "center";
   fontColor = "0 0 0 255";
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   borderThickness = "0";
   category = "AlterVerse";
};

singleton GuiControlProfile (AVAEGLLCProfile)
{
   opaque = false;
   border = 0;
   fontSize = "8";
   justify = "left";
   fontColor = "255 255 255 255";
   //fontType = "Trajan Pro";
   fontType = "Tahoma";
   borderThickness = "0";
   category = "AlterVerse";
};

singleton GuiControlProfile( AVPlayButtonProfile : AVInputSoundProfile )
{
   fontSize = 36;
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   fontColor = "210 210 210 255";
   fontColorHL = "255 255 255 255";
   fontColorNA = "100 100 100 255";
   border = false;
   fixedExtent = false;
   justify = "center";
   category = "AlterVerse";
};

singleton GuiControlProfile (AVPopupScrollProfile : GuiScrollProfile)
{
   opaque = true;
   border = 1;
   borderColor   = "255 255 255 225";

   // fill color
   fillColor = "10 10 10 0";

   bitmap = "art/gui/avCustomizer/scrollBar";
   hasBitmapArray = true;

   category = "AlterVerse";
};

singleton GuiControlProfile( AVPopupButtonProfile : AVInputSoundProfile )
{
   fontSize = 16;
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   fontColor = "210 210 210 255";
   fontColorHL = "255 255 255 255";
   fontColorNA = "100 100 100 255";
   border = false;
   fixedExtent = false;
   justify = "center";
   category = "AlterVerse";
};
