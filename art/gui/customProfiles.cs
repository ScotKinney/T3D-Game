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

// ----------------------------------------------------------------------------
// This is the default save location for any GuiProfiles created in the
// Gui Editor
// ----------------------------------------------------------------------------

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

// ----------------------------------------------------------------------------
// This is the default save location for any GuiProfiles created in the
// Gui Editor
// ----------------------------------------------------------------------------

singleton GuiControlProfile(GuiDefaultProfileLobby)
{
   fontSize = "20";
   fontType = "Arial Bold";
};

singleton GuiControlProfile(codGuiThumbHighlightButtonProfile1)
{
   category = "cod";
   bitmap = "core/art/gui/images/thumbHightlightButton";
   hasBitmapArray = "1";
};

singleton GuiControlProfile(codGuiTextProfileShop)
{
   fontSize = "20";
   fontColors[0] = "255 202 0 255";
   fontColor = "255 202 0 255";
};

singleton GuiControlProfile(GuiDefaultProfileShop)
{
   opaque = "1";
   category = "cod";
   fillColor = "69 69 69 224";
};

singleton GuiControlProfile(codGuiWindowProfileRpgWeapon)
{
   bitmap = "core/art/gui/images/window";
   fillColorHL = "221 221 221 255";
   border = "2";
   textOffset = "8 4";
   opaque = "1";
   fillColor = "28 28 28 233";
};

singleton GuiControlProfile(codGuiDefaultProfileServerbrowse)
{
};

singleton GuiControlProfile(GuiScoreScrollProfile)
{
   opaque = "1";
   fillColor = "55 55 55 255";
};

singleton GuiControlProfile(codGuiSkillScrollProfile)
{
   opaque = "1";
   fillColor = "160 160 160 205";
   fontSize = "17";
};

singleton GuiControlProfile(codChatGuiDefaultProfile)
{
   opaque = "1";
   fillColor = "3 3 3 255";
   fontSize = "19";
};


singleton GuiControlProfile(ChinatownButton : GuiButtonProfile)
{
   category = "Chinatown";
};

singleton GuiControlProfile(OptionsTabBorder : GuiTabBorderProfile)
{
   bitmap = "art/gui/Options/VideoWindow";
   category = "Chinatown";
};

singleton GuiControlProfile(ChinatownSliderProfile : GuiSliderProfile)
{
   bitmap = "art/gui/Options/slider.png";
   category = "Chinatown";
};

singleton GuiControlProfile(ChinatownSliderProfile : GuiSliderProfile)
{
   bitmap = "art/gui/Options/slider.png";
};

singleton GuiControlProfile(ChinatownTextEditProfile : GuiTextEditProfile)
{
   profileForChildren = "";
   category = "Chinatown";
   fontColors[0] = "253 253 253 255";
   fontColor = "253 253 253 255";
   bitmap = "art/gui/textEditField.png";
   fontColors[1] = "1 1 1 255";
   fontColorHL = "1 1 1 255";
   fontType = "Vrinda";
   fontSize = "18";
};

singleton GuiControlProfile(ChinatownHostTextProfile : GuiTextProfile)
{
   category = "Chinatown";
   fontColors[0] = "253 253 253 255";
   fontColor = "253 253 253 255";
   fontType = "Vrinda";
   fontSize = "18";
};

singleton GuiControlProfile(ChinatownPopUpMenuProfile : GuiPopUpMenuProfile)
{
   bitmap = "art/gui/dropDown.png";
   fillColor = "1 1 1 255";
   fontColors[0] = "253 253 253 255";
   fontColor = "253 253 253 255";
   fillColorHL = "1 1 1 255";
   fillColorNA = "1 1 1 255";
   fontColors[1] = "253 253 253 255";
   fontColors[2] = "253 253 253 255";
   fontColorHL = "253 253 253 255";
   fontColorNA = "253 253 253 255";
   category = "Chinatown";
   cursorColor = "253 253 253 255";
   profileForChildren = "ChinatownPopUpMenuChildrenProfile";
   fontType = "Vrinda";
   fontSize = "18";
};

singleton GuiControlProfile(ChinatownCheckboxProfile : GuiCheckBoxProfile)
{
   bitmap = "art/gui/checkbox.png";
   category = "Chinatown";
};


singleton GuiControlProfile(ChinatownTextArrayProfile : GuiTextArrayProfile)
{
   fillColor = "200 200 200 2";
   fillColorHL = "153 153 155 98";
   fontColors[0] = "87 200 86 255";
   fontColors[1] = "87 200 86 255";
   fontColors[3] = "87 200 86 255";
   fontColor = "87 200 86 255";
   fontColorHL = "87 200 86 255";
   fontColorSEL = "87 200 86 255";
   category = "Chinatown";
   fontType = "Vrinda";
   fontSize = "18";
};

singleton GuiControlProfile(ChinatownPopUpMenuChildrenProfile : GuiPopUpMenuDefault)
{
   fillColor = "1 1 1 255";
   fillColorHL = "63 63 63 255";
   fillColorNA = "1 1 1 255";
   fontColors[0] = "253 253 253 255";
   fontColors[1] = "253 253 253 255";
   fontColors[2] = "253 253 253 255";
   fontColor = "253 253 253 255";
   fontColorHL = "253 253 253 255";
   fontColorNA = "253 253 253 255";
   bitmap = "art/gui/scrollbar.png";
   category = "Chinatown";
   fillColorSEL = "85 85 85 255";
   fontType = "Vrinda";
   fontSize = "18";
};

singleton GuiControlProfile(ChinatownOptionsMenuLabelTextProfile : GuiTextProfile)
{
   category = "Chinatown";
   fontType = "vrinda";
   opaque = "0";
   modal = "0";
   fontSize = "30";
   fontColors[0] = "253 253 253 255";
   fontColor = "253 253 253 255";
   autoSizeWidth = "1";
   autoSizeHeight = "1";
   fontType = "Vrinda";
   fontSize = "18";
};


singleton GuiControlProfile (ChatHudBorderProfile)
{
   bitmap = "core/art/gui/images/chatHudBorderArray";
   hasBitmapArray = true;
   opaque = false;
};

singleton GuiControlProfile(WeaponHUDNoBorderProfile : ChatHudBorderProfile)
{
   hasBitmapArray = "0";
};







singleton GuiControlProfile(countDownTextProfile)
{
   fontType = "Arial Bold";
   fontSize = "50";
   fontColors[0] = "255 0 6 255";
   fontColor = "255 0 6 255";
   justify = "Center";
};

singleton GuiControlProfile(lobbyChatGuiDefaultProfile)
{
   fontSize = "22";
};

singleton GuiControlProfile(ShapMoneyValueHudProfile)
{
   fontType = "Arial Bold";
   fontColors[0] = "206 206 206 255";
   fontColors[3] = "248 248 248 255";
   fontColor = "206 206 206 255";
   fontColorSEL = "248 248 248 255";
   fontSize = "70";
};

singleton GuiControlProfile(ShapDamageValueHudProfile)
{
   fontSize = "30";
};

singleton GuiControlProfile(codGuiTextProfile5)
{
   fontColors[0] = "255 0 101 255";
   fontColor = "255 0 101 255";
};

singleton GuiControlProfile(hostDlgGuiCheckBoxProfile)
{
   fontColors[0] = "235 235 235 255";
   fontColor = "235 235 235 255";
   bitmap = "core/art/gui/images/checkbox";
   hasBitmapArray = "1";
};

singleton GuiControlProfile(soloDlgLebelGuiTextProfile)
{
   fontType = "Arial Bold";
   fontSize = "26";
   justify = "Center";
};

singleton GuiControlProfile(gamePadSelectedProfile)
{
   fontType = "Arial Bold";
   fontSize = "20";
   fontColors[0] = "247 14 36 255";
   fontColors[1] = "29 121 182 255";
   fontColor = "247 14 36 255";
   fontColorHL = "29 121 182 255";
   justify = "Center";
   fillColor = "74 74 254 255";
   opaque = "1";
};

singleton GuiControlProfile(gamepadProfile4BtmBtn)
{
   opaque = "1";
   fillColor = "255 0 30 255";
   fillColorHL = "255 0 83 255";
   fillColorNA = "255 0 42 255";
   fillColorSEL = "255 0 107 255";
   borderColor = "255 0 48 255";
   borderColorHL = "249 11 50 255";
   borderColorNA = "255 0 24 255";
   bitmap = "art/shapes/StarterForklift/Forklift_part1_1024x1024_D.jpg";
   hasBitmapArray = "1";
};

singleton GuiControlProfile(aCraftContainerPro1)
{
   opaque = "1";
   fillColor = "39 39 39 134";
};

singleton GuiControlProfile(aCraftNameLabelProf1)
{
   fontType = "Arial Bold";
   fontSize = "17";
   fontColors[0] = "0 255 160 255";
   fontColor = "0 255 160 255";
   justify = "Center";
};

singleton GuiControlProfile(aCraftGuiGuiDefaultProfile)
{
   opaque = "1";
   fillColor = "74 74 74 255";
};

singleton GuiControlProfile(abc1)
{
};

singleton GuiControlProfile(acrftBtn)
{
   bitmap = "art/gui/craftingGui/buttons/Button_Craft_Dn.png";
};

singleton GuiControlProfile(aCrftTextLabel)
{
   fontType = "Arial Bold";
   fontSize = "18";
   justify = "Center";
   fontColors[0] = "255 255 0 255";
   fontColor = "255 255 0 255";
};

singleton GuiControlProfile(aCrftProgressTextLabel)
{
   fontType = "Arial Bold";
   justify = "Center";
   fontSize = "19";
   fontColors[0] = "5 5 5 255";
   fontColor = "5 5 5 255";
};

singleton GuiControlProfile(aplusBtn)
{
   opaque = "1";
   fillColor = "56 55 55 255";
   fillColorHL = "255 0 107 255";
   fillColorNA = "56 56 56 255";
   fillColorSEL = "134 135 161 255";
   bitmap = "art/gui/craftingGui/unchoosen.png";
};

singleton GuiControlProfile(astackLabel)
{
   justify = "Center";
};

singleton GuiControlProfile(aCraftBackPackNotifier)
{
   fontType = "Arial Bold";
   fontColors[0] = "60 255 0 255";
   fontColor = "60 255 0 255";
   justify = "Center";
};

singleton GuiControlProfile(aCraftCraftingStatus)
{
   fontColors[0] = "255 0 136 255";
   fontColor = "255 0 136 255";
   justify = "Center";
   fontSize = "17";
};


singleton GuiControlProfile(aGuiWindowCollapseProfile)
{
   fontType = "Arial Bold";
   fontColors[0] = "255 160 0 255";
   fontColor = "255 160 0 255";
   justify = "Center";
   bitmap = "core/art/gui/images/window";
   hasBitmapArray = "1";
   fillColor = "242 241 240 117";
};
