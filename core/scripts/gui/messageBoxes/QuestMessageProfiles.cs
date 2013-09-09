//-----------------------------------------------------------------------------
// Control profiles for LoE message boxes
//-----------------------------------------------------------------------------

singleton GuiControlProfile (QuestMessageDialogProfile)
{
   modal = true;
   category = "AlterVerse";
};

singleton GuiControlProfile (QuestMessageTitleProfile)
{
   fontSize = "21";
   justify = "top";
   fontColor = "255 175 85 255";
   //fontType = "Trajan Pro Bold";
   fontType = "Tahoma Bold";
   category = "AlterVerse";
};

singleton GuiControlProfile (QuestMessageTextProfile)
{
   opaque = false;
   border = 0;
   fontSize = "16";
   justify = "left";
   fontColor = "255 255 255 255";
   //fontType = "Trajan Pro";
   fontType = "Tahoma";
   autoSizeWidth = true;
   autoSizeHeight = true;  
   category = "AlterVerse";
};

singleton GuiControlProfile (QuestMessageFrameProfile)
{
   opaque = false;
   bitmap = "art/gui/toolbar/AVToolbarBorder.png";
   hasBitmapArray = "1";
   category = "AlterVerse";
};

singleton GuiControlProfile(QuestMessageEditProfile)
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
   //fontType = "Trajan Pro Bold";
   fontType = "Arial Bold";
   category = "AlterVerse";
};

new GuiControlProfile( QuestMessageButtonProfile : GuiDefaultProfile )
{
   fontSize = 18;
   //fontType = "Trajan Pro";
   fontType = "Tahoma";
   fontColor = "255 255 255 255";
   fontColorHL = "200 200 200 255";
   fontColorNA = "100 100 100 255";
   border = false;
   fixedExtent = false;
   justify = "center";
   category = "AlterVerse";
};
