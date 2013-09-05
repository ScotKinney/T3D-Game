//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------
// Override base controls
//GuiMenuButtonProfile.soundButtonOver = "AudioButtonOver";
//GuiMenuButtonProfile.soundButtonDown = "AudioButtonDown";

//-----------------------------------------------------------------------------
// Chat Hud profiles
singleton GuiControlProfile (ChatHudEditProfile)
{
   opaque = false;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = false;
   borderThickness = 0;
   borderColor = "40 231 240";
   fontColor = "40 231 240";
   fontColorHL = "40 231 240";
   fontColorNA = "128 128 128";
   textOffset = "0 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
   cursorColor = "40 231 240 255";
};

singleton GuiControlProfile (ChatHudTextProfile)
{
   opaque = false;
   fillColor = "255 255 255";
   fillColorHL = "128 128 128";
   border = false;
   borderThickness = 0;
   borderColor = "40 231 240";
   fontColor = "40 231 240";
   fontColorHL = "40 231 240";
   fontColorNA = "128 128 128";
   textOffset = "0 0";
   autoSizeWidth = true;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
};

singleton GuiControlProfile (ChatHudButtonProfile)
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
   fontColor = "225 225 225 225";
   fontColorHL = "255 255 255 255";
   fontColorNA = "155 155 155 225"; 
   fontColorSEL = "255 255 255 255";
};

singleton GuiControlProfile (TransparentButtonProfile)
{
   opaque = false;
   fillColor = "255 255 255 0";
   fillColorHL = "255 255 255 0";
   fillColorSEL = "255 255 255 0";

   border = 0;
   borderThickness = 0;
   borderColor = "225 225 225 0";
   borderColorHL = "255 255 255 0";
   borderColorNA = "155 155 155 0"; 

   justify = "center";
   fontColor = "225 225 225 0";
   fontColorHL = "255 255 255 0";
   fontColorNA = "155 155 155 0"; 
   fontColorSEL = "255 255 255 0";
};

singleton GuiControlProfile ("ChatHudMessageProfile")
{
   fontType = "Arial";
   fontSize = 16;
   fontColor = "44 172 181";      // default color (death msgs, scoring, inventory)
   fontColors[1] = "4 235 105";   // client join/drop, tournament mode
   fontColors[2] = "219 200 128"; // gameplay, admin/voting, pack/deployable
   fontColors[3] = "255 255 255";   // team chat, spam protection message, client tasks
   fontColors[4] = "180 180 180";  // Grunt
   fontColors[5] = "200 200 50 200";  // used in single player game
   // WARNING! Colors 6-9 are reserved for name coloring
   autoSizeWidth = true;
   autoSizeHeight = true;
};

singleton GuiControlProfile ("ChatHudScrollProfile")
{
   opaque = false;
   borderThickness = 0;
   borderColor = "0 255 0";
   bitmap = "core/art/gui/images/scrollBar";
   hasBitmapArray = true;
};

singleton GuiControlProfile ("ChatHudBdrScrollProfile")
{
   opaque = false;
   border = true;
   borderThickness = 1;
   borderColor = "225 225 225 225";
   bitmap = "core/art/gui/images/scrollBar";
   hasBitmapArray = true;
};

singleton GuiControlProfile( ChatTabBookProfile )
{
   fillColorHL = "100 100 100";
   fillColorNA = "150 150 150";
   fontColor = "30 30 30";
   fontColorHL = "0 0 0";
   fontColorNA = "50 50 50";
   fontType = "Arial";
   fontSize = 14;
   //justify = "center";
   justify = "left";
   bitmap = "art/gui/chat/chattab";
   tabWidth = 64;
   tabHeight = 20;
   tabPosition = "Top";
   tabRotation = "Horizontal";
   //textOffset = "0 -3";
   textOffset = "6 0";
   tab = true;
   cankeyfocus = true;
   //border = false;
   //opaque = false;
   category = "Core";
};

singleton GuiControlProfile( ChatTabPageProfile : GuiDefaultProfile )
{
   fontType = "Arial";
   fontSize = 10;
   justify = "center";
   bitmap = "art/gui/chat/chattab";
   opaque = false;
   fillColor = "240 239 238";
   category = "Core";
};

//-----------------------------------------------------------------------------
// Core Hud profiles

singleton GuiControlProfile ("HudScrollProfile")
{
   opaque = false;
   border = true;
   borderColor = "0 255 0";
   bitmap = "core/art/gui/images/scrollBar";
   hasBitmapArray = true;
};

singleton GuiControlProfile ("HudTextProfile")
{
   opaque = false;
   fillColor = "128 128 128";
   fontColor = "0 255 0";
   border = true;
   borderColor = "0 255 0";
};

singleton GuiControlProfile ("ChatHudBorderProfile")
{
   bitmap = "art/gui/chat/chatHudBorderArray";
   hasBitmapArray = true;
   opaque = false;
};


//-----------------------------------------------------------------------------
// Center and bottom print

singleton GuiControlProfile ("CenterPrintProfile")
{
   opaque = false;
   fillColor = "128 128 128";
   fontColor = "0 255 0";
   border = true;
   borderColor = "0 255 0";
};

singleton GuiControlProfile ("CenterPrintTextProfile")
{
   opaque = false;
   fontType = "Arial";
   fontSize = 12;
   fontColor = "0 255 0";
};

// -----------------------------------------------------------------------------
// HUD popup menu
// -----------------------------------------------------------------------------
singleton GuiControlProfile (HudPopupProfile)
{
   opaque = true;
   mouseOverSelected = 1;
   border = 0;
   borderThickness = 0;
   borderColor = "0 0 0 225";
   borderColorHL = "100 100 100 255";
   borderColorNA = "155 155 155 225"; 

   fontType = "Arial";
   fontSize = 14;
   fontColor = "200 200 200 225";
   fontColorHL = "255 255 255 255";
   fontColorNA = "155 155 155 225"; 
   fontColorSEL = "50 50 50 255";

   fillColor = "0 0 0 225";
   fillColorHL ="100 100 100 255";
   fillColorSEL = "0 0 0 0";
   fillColorNA = "0 0 0 0";
};

singleton GuiControlProfile (HudPopupFrameProfile)
{
   opaque = false;
   border = 1;
   borderThickness = 1;
   borderColor = "225 225 225 225";
   borderColorHL = "255 255 255 0";
   borderColorNA = "155 155 155 225"; 

   fillColor = "0 0 0 0";
   fillColorHL ="0 0 0 0";
   fillColorSEL = "0 0 0 0";
   fillColorNA = "0 0 0 0";
};

// -----------------------------------------------------------------------------
// HUD buttons
// -----------------------------------------------------------------------------
singleton GuiControlProfile (HudTextBtnProfile)
{
   opaque = false;
   fillColor = "255 255 255 0";
   fillColorHL = "255 255 255 0";
   fillColorSEL = "255 255 255 0";

   border = 0;
   borderThickness = 0;

   justify = "left";
   fontType = "ArialBold";
   fontSize = 14;
   fontColor = "225 225 225 225";
   fontColorHL = "255 255 255 255";
   fontColorNA = "155 155 155 225"; 
   fontColorSEL = "255 255 255 255";
};

singleton GuiControlProfile (HudTextBtnCenterProfile : HudTextBtnProfile)
{
   justify = "center";
};

// -----------------------------------------------------------------------------
// HUD text
// -----------------------------------------------------------------------------

singleton GuiControlProfile (HudTextNormalProfile)
{
   opaque = false;
   fontType = "Arial";
   fontSize = 14;
   fontColor = "255 255 255";
   fontColorHL = "255 255 255";
   fontColorNA = "255 255 255";
   fontColorSEL= "255 255 255";

   fillColor = "0 0 0 0";
   fillColorHL = "0 0 0 0";
   fillColorSEL = "0 0 0 0";
   fillColorNA = "0 0 0 0";

   borderColor = "0 0 0 0";
   borderColorHL = "0 0 0 0";
   borderColorNA = "0 0 0 0";
};

singleton GuiControlProfile (HudTextItalicProfile : HudTextNormalProfile)
{
   fontType = "ArialItalic";
};

singleton GuiControlProfile (HudTextBoldProfile : HudTextNormalProfile)
{
   fontType = "ArialBold";
};

singleton GuiControlProfile (HudTextListProfile : HudTextNormalProfile)
{
   fillColorHL = "50 50 50 255";
   fillColorSEL = "50 50 50 255";
   borderColorHL = "50 50 50 255";
};

// -----------------------------------------------------------------------------
// Numerical health text
// -----------------------------------------------------------------------------

singleton GuiControlProfile (NumericHealthProfile)
{
   opaque = true;
   justify = "center";
   fontType = "ArialBold";
   fontSize = 32;
   fontColor = "255 255 255";
};

singleton GuiControlProfile (TransparentButtonProfile)
{
   opaque = false;
   fillColor = "255 255 255 0";
   fillColorHL = "255 255 255 0";
   fillColorSEL = "255 255 255 0";

   border = 0;
   borderThickness = 0;
   borderColor = "225 225 225 0";
   borderColorHL = "255 255 255 0";
   borderColorNA = "155 155 155 0"; 

   justify = "center";
   fontColor = "225 225 225 0";
   fontColorHL = "255 255 255 0";
   fontColorNA = "155 155 155 0"; 
   fontColorSEL = "255 255 255 0";
};

singleton GuiControlProfile( GuiAwesomiumProfile )
{
   textOffset = "4 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   justify = "left";
   tab = true;
   canKeyFocus = true;   
   category = "Core";
};
