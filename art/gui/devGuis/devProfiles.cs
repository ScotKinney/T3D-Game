
// ----------------------------------------------------------------------------
// Profiles for Dev guis.
// ----------------------------------------------------------------------------

singleton GuiControlProfile (AVDevLabelProfile)
{
   opaque = false;
   border = 0;
   fontSize = "16";
   justify = "left";
   fontColor = "192 192 192 255";
   fontType = "Tahoma";
   borderThickness = "0";
   category = "DevGuis";
};

singleton GuiControlProfile (AVDevHeaderProfile)
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

singleton GuiControlProfile (AVDevButtonProfile)
{
   opaque = false;
   fillColor = "255 255 255 0";
   fillColorHL = "255 255 255 0";
   fillColorSEL = "255 255 255 0";

   border = 1;
   borderThickness = 1;
   borderColor = "225 225 225 225";
   borderColorHL = "255 255 255 255";
   borderColorNA = "155 155 155 225"; 

   justify = "center";
   fontType = "Tahoma";
   fontSize = "16";
   fontColor = "225 225 225 225";
   fontColorHL = "255 255 255 255";
   fontColorNA = "155 155 155 225"; 
   fontColorSEL = "255 255 255 255";
};
