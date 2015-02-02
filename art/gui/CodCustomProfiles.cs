singleton GuiControlProfile( GuiServerBrowserHeaderProfile )
{
	opaque = false;
	border = "1";

	fontColor = "0 0 0 255";
	fontColorHL = "0 0 255 255";
	fontColorNA = "0 0 0 255";
	//fontColorSEL ="0 0 0";
	fixedExtent = 0;
	justify = "center";
	canKeyFocus = false;
	bitmap = "core/art/gui/images/server_tabs";
	hasBitmapArray = "1";
	category = "Core";
   fontColors[1] = "0 0 255 255";
   fontColors[3] = "0 0 0 255";
   fontColorSEL = "0 0 0 255";
   profileForChildren = "";
   fillColor = "0 255 160 160";
};
singleton GuiControlProfile( GuiServerBrowserProfile )
{
	opaque = false;
	border = "0";

	fontColor = "254 254 254 255";
	fontColorHL = "255 255 255";
	fontColorNA = "180 180 180";
	//fontColorSEL ="0 0 0";
	fixedExtent = 0;
	justify = "center";
	canKeyFocus = true;
	hasBitmapArray = "0";
	category = "Core";
   fontColors[0] = "254 254 254 255";
   fontColors[1] = "255 255 255 255";
   fontColors[2] = "180 180 180 255";
   fillColorHL = "2 138 204 255";
   fillColorSEL = "1 147 103 255";
   fillColor = "242 241 240 53";
   fillColorNA = "1 147 103 141";
   borderThickness = "0";
   fontSize = "20";
   fontType = "Arial Bold";
};


singleton GuiControlProfile( GuiServerBrowserSortProfile )
{
	opaque = false;
	border = "1";
	fixedExtent = 0;
	justify = "Bottom";
	canKeyFocus = false;
	bitmap = "core/art/gui/images/shll_sortarrow";
	hasBitmapArray = "0";
	category = "Core";
	fontColors[0] = "255 255 255 255";
	fontColors[1] = "255 255 255 255";
	fontColors[2] = "255 255 255 255";
   fontColor = "255 255 255 255";
   fontColorHL = "255 255 255 255";
   fontColorNA = "255 255 255 255";
   fontColors[4] = "255 255 255 255";
   fontColors[5] = "255 255 255 255";
   fontColors[6] = "255 255 255 255";
   fontColors[7] = "255 255 255 255";
   fontColors[8] = "255 255 255 255";
   fontColors[9] = "255 255 255 255";
   fontColorLink = "255 255 255 255";
   fontColorLinkHL = "255 255 255 255";
   returnTab = "1";
};


if( !isObject( GuiWindowCollapseProfile ) )
new GuiControlProfile (GuiWindowCollapseProfile : GuiWindowProfile)
{
   category = "Core";
};
/////////
if( !isObject( GuiTransparentScrollProfile ) )
new GuiControlProfile( GuiTransparentScrollProfile )
{
   opaque = false;
   fillColor = "255 255 255";
	 fontColor = "0 0 0";
   border = false;
   borderThickness = 2;
   borderColor = "100 100 100";
   bitmap = "./images/scrollBar";
   hasBitmapArray = true;
   category = "Core";
};


if( !isObject( GuiTextBoldCenterProfile ) )
new GuiControlProfile (GuiTextBoldCenterProfile : GuiTextProfile)
{
   fontColor = "50 50 50";
   fontType = "Arial Bold";
   fontSize = 16;
   justify = "center";
   category = "Core";
};


if( !isObject( GuiTextListProfile ) )
new GuiControlProfile( GuiTextListProfile : GuiTextProfile ) 
{
   tab = true;
   canKeyFocus = true;
   category = "Core";
};



singleton GuiControlProfile(ChinatownHUDTextProfile : GuiTextBoldCenterProfile)
{
   fontType = "vrinda bold";
   fontColors[0] = "255 0 18 255";
   fontColor = "255 0 18 255";
   fontSize = "60";
   category = "Chinatown";
};

if( !isObject( GuiTextBoldCenterProfile ) )
new GuiControlProfile (GuiTextBoldCenterProfile : GuiTextProfile)
{
   fontColor = "50 50 50";
   fontType = "Arial Bold";
   fontSize = 16;
   justify = "center";
   category = "Core";
};

singleton GuiControlProfile(ChinatownRedHUDTextProfile : ChinatownHUDTextProfile)
{
   fontColors[0] = "254 2 9 255";
   fontColor = "254 2 9 255";
};
singleton GuiControlProfile(codGuiDefaultProfile4)
{
   bitmap = "art/gui/multiplayMenu/images/chatHudBorderArray.png";
   hasBitmapArray = "1";
};

singleton GuiControlProfile(codGuiPopUpMenuProfile5)
{
   category = "cod";
};

singleton GuiControlProfile(codGuiServerScrollProfile)
{
   bitmap = "core/art/gui/images/scrollBar";
   category = "cod";
   opaque = "1";
   fillColor = "81 81 81 223";
};

singleton GuiControlProfile(codGuiTextProfileLobbyPlayer)
{
   fontType = "Arial Bold";
   fontSize = "24";
   fontColors[0] = "234 197 127 201";
   fontColor = "234 197 127 201";
   justify = "Center";
};

singleton GuiControlProfile(codGuiMLTextProfileplayerDesc)
{
   category = "cod";
   fontType = "Arial Bold";
   fontSize = "18";
   opaque = "1";
   fillColor = "161 161 161 255";
   fontColors[0] = "0 249 255 255";
   fontColor = "0 249 255 255";
   cursorColor = "120 238 69 255";
};

singleton GuiControlProfile(codChatHudTextProfileLobby)
{
   opaque = "0";
   fillColor = "83 83 83 176";
   fillColorHL = "14 14 14 255";
   fontSize = "24";
   fontColors[0] = "204 230 217 255";
   fontColors[1] = "48 48 48 255";
   fontColor = "204 230 217 255";
   fontColorHL = "48 48 48 255";
   justify = "Left";
   fillColorNA = "115 115 115 255";
   fontType = "Arial Bold";
};

singleton GuiControlProfile(codGuiTextProfileLobbyPlayer2)
{
   fontColors[0] = "234 197 127 201";
   fontColor = "234 197 127 201";
   fontType = "Arial Bold";
   fontSize = "27";
};

singleton GuiControlProfile(codGuiDefaultProfileLobby)
{
   opaque = "1";
   fillColor = "25 25 25 223";
};

singleton GuiControlProfile (codChatHudEditProfileLobby)
{
   opaque = "1";
   fillColor = "81 81 81 223";
   fillColorHL = "58 136 110 255";
   border = false;
   borderThickness = 0;
   borderColor = "40 231 240";
   fontColor = "124 214 138 255";
   fontColorHL = "16 18 18 255";
   fontColorNA = "234 234 234 255";
   textOffset = "0 2";
   autoSizeWidth = false;
   autoSizeHeight = true;
   tab = true;
   canKeyFocus = true;
   fontType = "Arial Bold";
   fontSize = "30";
   fontColors[0] = "124 214 138 255";
   fontColors[1] = "16 18 18 255";
   fontColors[2] = "234 234 234 255";
   fillColorSEL = "255 0 178 255";
};



if(!isObject(codGuiScrollProfile)) {
   new GuiControlProfile(codGuiScrollProfile) {
      opaque = "1";
      fillColor = "255 255 255 58";
      fontColor = "0 0 0";
      fontColorHL = "150 150 150";
      border = "1";
      bitmap = "art/gui/multiplayMenu/images/scrollBar";
      hasBitmapArray = "1";
      category = "Cod";
      fontColors["1"] = "150 150 150 255";
   };
}
if(!isObject(codGuiButtonProfile1)) {
   new GuiControlProfile(codGuiButtonProfile1) {
      opaque = "0";
      border = "1";
      fontColor = "50 50 50";
      fontColorHL = "0 0 0";
      fontColorNA = "200 200 200";
      fixedExtent = "0";
      justify = "center";
      canKeyFocus = "0";
      bitmap = "art/gui/multiplayMenu/images/button";
      hasBitmapArray = "0";
      category = "Cod";
      fillColor = "242 241 240 0";
      fillColorHL = "228 228 235 0";
      fillColorNA = "255 255 255 0";
      fillColorSEL = "99 100 137 0";
      fontColors["0"] = "50 50 50 255";
      fontColors["2"] = "200 200 200 255";
   };
}
if(!isObject(codGuiListBoxProfile)) {
   new GuiControlProfile(codGuiListBoxProfile) {
      tab = "1";
      canKeyFocus = "1";
      category = "Cod";
      fontType = "Arial Bold";
      fontSize = "20";
      autoSizeWidth = "1";
      autoSizeHeight = "1";
   };
}
singleton GuiControlProfile(codGuiDefaultProfile3) {
   justify = "Center";
   fillColorHL = "7 7 7 255";
   fontColors["0"] = "42 42 42 255";
   fontColor = "42 42 42 255";
   fillColorSEL = "13 13 13 255";
   fontColors["3"] = "16 16 16 255";
   fontColorSEL = "16 16 16 255";
   fillColor = "24 24 24 255";
   category = "cod";
};
singleton GuiControlProfile(codGuiButtonProfile3) {
   justify = "Center";
   fillColor = "69 69 69 225";
   fontType = "Arial Bold";
   fontColors["0"] = "253 252 252 255";
   fontColor = "253 252 252 255";
   fontSize = "18";
   category = "cod";
   fontColors["1"] = "200 200 200 255";
   fontColorHL = "200 200 200 255";
   fontColors["3"] = "27 27 27 255";
   fontColorSEL = "27 27 27 255";
   fillColorHL = "81 81 81 255";
   fillColorNA = "255 255 255 5";
};
singleton GuiControlProfile(codGuiTextProfile3) {
   category = "cod";
   fontColors["0"] = "234 197 127 201";
   fontColor = "234 197 127 201";
   fontType = "Arial Bold";
   fontSize = "30";
};
singleton GuiControlProfile(codGuiListBoxProfile2) {
   fontSize = "20";
   fontColors["0"] = "214 214 214 252";
   fontColor = "214 214 214 252";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   fontType = "Arial Bold";
   opaque = "1";
   fillColor = "242 241 240 93";
   justify = "Left";
   category = "cod";
   fillColorHL = "17 17 17 83";
   fontColors["1"] = "191 191 191 255";
   fontColorHL = "191 191 191 255";
   textOffset = "0 0";
};
singleton GuiControlProfile(codGuiScrollProfile2) {
   opaque = "1";
   fillColor = "3 3 3 0";
   fontSize = "20";
};
if(!isObject(codGuiTextEditProfile)) {
   new GuiControlProfile(codGuiTextEditProfile) {
      opaque = "1";
      bitmap = "core/art/gui/images/textEdit";
      hasBitmapArray = "1";
      border = -(2);
      fillColor = "29 28 28 157";
      fillColorHL = "118 83 42 255";
      fontColor = "0 0 0";
      fontColorHL = "255 255 255";
      fontColorSEL = "98 100 137";
      fontColorNA = "200 200 200";
      textOffset = "4 2";
      autoSizeWidth = "0";
      autoSizeHeight = "0";
      justify = "left";
      tab = "1";
      canKeyFocus = "1";
      category = "Cod";
      fillColorNA = "69 69 69 83";
      fillColorSEL = "160 160 172 255";
      fontType = "Arial ";
      fontSize = "25";
      fontColors["1"] = "255 255 255 255";
      fontColors["2"] = "200 200 200 255";
      fontColors["3"] = "98 100 137 255";
   };
}
if(!isObject(codGuiTextEditProfile2)) {
   new GuiControlProfile(codGuiTextEditProfile2) {
      opaque = "1";
      bitmap = "core/art/gui/images/textEdit";
      hasBitmapArray = "1";
      border = -(2);
      fillColor = "29 28 28 157";
      fillColorHL = "118 83 42 255";
      fontColor = "0 0 0";
      fontColorHL = "255 255 255";
      fontColorSEL = "98 100 137";
      fontColorNA = "200 200 200";
      textOffset = "4 2";
      autoSizeWidth = "0";
      autoSizeHeight = "0";
      justify = "left";
      tab = "1";
      canKeyFocus = "1";
      category = "Cod";
      fillColorNA = "69 69 69 83";
      fillColorSEL = "160 160 172 255";
      fontType = "Arial ";
      fontSize = "25";
      fontColors["1"] = "255 255 255 255";
      fontColors["2"] = "200 200 200 255";
      fontColors["3"] = "98 100 137 255";
      numbersOnly = "1";
   };
}
if(!isObject(codGuiWindowProfile)) {
   new GuiControlProfile(codGuiWindowProfile) {
      opaque = "1";
      border = "2";
      fillColor = "169 169 169 255";
      fillColorHL = "221 221 221";
      fillColorNA = "200 200 200";
      fontColor = "50 50 50";
      fontColorHL = "0 0 0";
      bevelColorHL = "255 255 255";
      bevelColorLL = "0 0 0";
      text = "untitled";
      bitmap = "art/gui/multiplayMenu/images/window";
      textOffset = "8 4";
      hasBitmapArray = "1";
      justify = "left";
      category = "Cod";
      fontColors["0"] = "50 50 50 255";
   };
}
if(!isObject(codGuiTextEditProfile)) {
   new GuiControlProfile(codGuiTextEditProfile) {
      opaque = "1";
      bitmap = "./images/textEdit";
      hasBitmapArray = "1";
      border = -(2);
      fillColor = "242 241 240 0";
      fillColorHL = "255 255 255";
      fontColor = "0 0 0";
      fontColorHL = "255 255 255";
      fontColorSEL = "98 100 137";
      fontColorNA = "200 200 200";
      textOffset = "4 2";
      autoSizeWidth = "0";
      autoSizeHeight = "1";
      justify = "left";
      tab = "1";
      canKeyFocus = "1";
      category = "Cod";
   };
}
singleton GuiControlProfile(codGuiTextProfile) {
   fontType = "Arial Bold";
   fontSize = "25";
   category = "cod";
};
if(!isObject(codGuiButtonProfile)) {
   new GuiControlProfile(codGuiButtonProfile) {
      opaque = "0";
      border = "1";
      fontColor = "50 50 50";
      fontColorHL = "0 0 0";
      fontColorNA = "200 200 200";
      fixedExtent = "0";
      justify = "Center";
      canKeyFocus = "0";
      bitmap = "art/gui/multiplayMenu/images/button";
      hasBitmapArray = "0";
      category = "Cod";
      fillColor = "242 241 240 81";
      fillColorHL = "228 228 235 51";
      fillColorNA = "255 255 255 79";
      fontColors["0"] = "50 50 50 255";
      fontColors["2"] = "200 200 200 255";
      fontType = "Arial Bold";
      fontSize = "20";
   };
}
if(!isObject(codGuiDefaultProfile)) {
   new GuiControlProfile(codGuiDefaultProfile) {
      tab = "0";
      canKeyFocus = "0";
      hasBitmapArray = "0";
      mouseOverSelected = "0";
      opaque = "0";
      fillColor = "242 241 240 44";
      fillColorHL = "159 159 159 255";
      fillColorSEL = "98 100 137";
      fillColorNA = "255 255 255 ";
      border = "0";
      borderColor = "100 100 100";
      borderColorHL = "50 50 50 50";
      borderColorNA = "75 75 75";
      fontType = "Arial Bold";
      fontSize = "20";
      fontCharset = ANSI;
      fontColor = "164 168 165 255";
      fontColorHL = "14 14 14 255";
      fontColorNA = "0 0 0";
      fontColorSEL = "255 255 255 255";
      bitmapBase = "";
      textOffset = "0 0";
      modal = "1";
      justify = "Right";
      autoSizeWidth = "0";
      autoSizeHeight = "0";
      returnTab = "0";
      numbersOnly = "0";
      cursorColor = "0 0 0 255";
      category = "Cod";
      fontColors["0"] = "164 168 165 255";
      fontColors["3"] = "255 255 255 255";
      fontColors["1"] = "14 14 14 255";
   };
}
if(!isObject(codGuiTextProfile2)) {
   new GuiControlProfile(codGuiTextProfile2) {
      justify = "center";
      fontColor = "234 197 127 201";
      category = "cod";
      fontColors["0"] = "234 197 127 201";
      fontType = "Arial Bold";
      fontSize = "39";
   };
}
if(!isObject(GuiDefaultProfile4SoloGui)) {
   new GuiControlProfile(GuiDefaultProfile4SoloGui) {
      tab = "0";
      canKeyFocus = "0";
      hasBitmapArray = "0";
      mouseOverSelected = "0";
      category = "cod";
      opaque = "1";
      fillColor = "242 241 240 154.5";
      fillColorHL = "159 159 159 255";
      fillColorSEL = "98 100 137";
      fillColorNA = "255 255 255 ";
      border = "0";
      borderColor = "100 100 100";
      borderColorHL = "50 50 50 50";
      borderColorNA = "75 75 75";
      fontType = "Arial Bold";
      fontSize = "20";
      fontCharset = ANSI;
      fontColor = "242 242 242 255";
      fontColorHL = "0 0 0";
      fontColorNA = "0 0 0";
      fontColorSEL = "255 255 255";
      bitmapBase = "";
      textOffset = "0 0";
      modal = "1";
      justify = "Center";
      autoSizeWidth = "0";
      autoSizeHeight = "0";
      returnTab = "0";
      numbersOnly = "0";
      cursorColor = "0 0 0 255";
      fontColors["0"] = "242 242 242 255";
   };
} 

if(!isObject(codGuiDefaultProfile2)) {
   new GuiControlProfile(codGuiDefaultProfile2) {
      tab = "0";
      canKeyFocus = "0";
      hasBitmapArray = "0";
      mouseOverSelected = "0";
      category = "cod";
      opaque = "1";
      fillColor = "242 241 240 44";
      fillColorHL = "159 159 159 255";
      fillColorSEL = "98 100 137";
      fillColorNA = "255 255 255 ";
      border = "0";
      borderColor = "100 100 100";
      borderColorHL = "50 50 50 50";
      borderColorNA = "75 75 75";
      fontType = "Arial Bold";
      fontSize = "20";
      fontCharset = ANSI;
      fontColor = "242 242 242 255";
      fontColorHL = "0 0 0";
      fontColorNA = "0 0 0";
      fontColorSEL = "255 255 255";
      bitmapBase = "";
      textOffset = "0 0";
      modal = "1";
      justify = "Center";
      autoSizeWidth = "0";
      autoSizeHeight = "0";
      returnTab = "0";
      numbersOnly = "0";
      cursorColor = "0 0 0 255";
      fontColors["0"] = "242 242 242 255";
   };
}
if(!isObject(codGuiMLTextProfile1)) {
   new GuiControlProfile(codGuiMLTextProfile1) {
      fontColorLink = "100 100 100";
      fontColorLinkHL = "255 255 255";
      autoSizeWidth = "1";
      autoSizeHeight = "1";
      border = "0";
      category = "cod";
      fillColor = "232 232 232 255";
      fontColors["4"] = "100 100 100 255";
      fontColors["5"] = "255 255 255 255";
      fontType = "Arial Bold";
      fontSize = "20";
      fontColors["0"] = "243 243 243 255";
      fontColor = "243 243 243 255";
   };
}
if(!isObject(codGuiTextProfile3)) {
   new GuiControlProfile(codGuiTextProfile3) {
      justify = "left";
      fontColor = "234 197 127 201";
      category = "cod";
      fontColors["0"] = "234 197 127 201";
      fontType = "Arial Bold";
      fontSize = "35";
   };
}
if(!isObject(codGuiTextProfile4)) {
   new GuiControlProfile(codGuiTextProfile4) {
      justify = "left";
      fontColor = "234 197 127 201";
      category = "cod";
      fontColors["0"] = "234 197 127 201";
      fontType = "Arial Bold";
      fontSize = "35";
   };
}
singleton GuiControlProfile(codGuiPopUpMenuProfile4) {
   category = "cod";
   bitmap = "./images/dropDown";
};
if(!isObject(codGuiPopUpMenuProfile1)) {
   new GuiControlProfile(codGuiPopUpMenuProfile1 : GuiPopUpMenuDefault) {
      textOffset = "6 4";
      bitmap = "./images/dropDown";
      hasBitmapArray = "1";
      border = "1";
      profileForChildren = GuiPopUpMenuDefault;
      category = "Core";
   };
}
if(!isObject(codGuiCheckBoxProfile)) {
   new GuiControlProfile(codGuiCheckBoxProfile) {
      opaque = "0";
      fillColor = "232 232 232";
      border = "0";
      borderColor = "100 100 100";
      fontSize = "1";
      fontColor = "11 11 11 255";
      fontColorHL = "80 80 80";
      fontColorNA = "200 200 200";
      fixedExtent = "1";
      justify = "Right";
      bitmap = "art/gui/multiplayMenu/images/checkbox";
      hasBitmapArray = "1";
      category = "cod";
      fontColors["0"] = "11 11 11 255";
      fontColors["1"] = "80 80 80 255";
      fontColors["2"] = "200 200 200 255";
   };
}
singleton GuiControlProfile(codGuiDefaultProfile3) {
   justify = "Center";
   fillColorHL = "7 7 7 255";
   fontColors["0"] = "42 42 42 255";
   fontColor = "42 42 42 255";
   fillColorSEL = "13 13 13 255";
   fontColors["3"] = "16 16 16 255";
   fontColorSEL = "16 16 16 255";
   fillColor = "24 24 24 255";
   category = "cod";
};
singleton GuiControlProfile(codGuiButtonProfile3) {
   justify = "Center";
   fillColor = "69 69 69 225";
   fontType = "Arial Bold";
   fontColors["0"] = "253 252 252 255";
   fontColor = "253 252 252 255";
   fontSize = "18";
   category = "cod";
   fontColors["1"] = "200 200 200 255";
   fontColorHL = "200 200 200 255";
   fontColors["3"] = "27 27 27 255";
   fontColorSEL = "27 27 27 255";
   fillColorHL = "81 81 81 255";
};
singleton GuiControlProfile(codGuiTextProfile3) {
   category = "cod";
   fontColors["0"] = "234 197 127 201";
   fontColor = "234 197 127 201";
   fontType = "Arial Bold";
};
singleton GuiControlProfile(codGuiListBoxProfile2) {
   fontSize = "20";
   fontColors["0"] = "214 214 214 252";
   fontColor = "214 214 214 252";
   autoSizeWidth = "0";
   autoSizeHeight = "0";
   fontType = "Arial Bold";
   opaque = "1";
   fillColor = "242 241 240 93";
   justify = "Left";
   category = "cod";
   fillColorHL = "17 17 17 83";
   fontColors["1"] = "191 191 191 255";
   fontColorHL = "191 191 191 255";
   textOffset = "0 0";
};
singleton GuiControlProfile(codGuiScrollProfile2) {
   opaque = "1";
   fillColor = "3 3 3 0";
   fontSize = "20";
};
singleton GuiControlProfile(codGuiTextProfile4) {
   category = "core";
   fontType = "Arial Bold";
   fontSize = "19";
   fontColors["0"] = "249 205 35 175";
   fontColor = "249 205 35 175";
   fontColors["1"] = "193 193 193 255";
   fontColorHL = "193 193 193 255";
};
singleton GuiControlProfile(codGuiPopUpMenuProfile) {
   category = "cod";
};
singleton GuiControlProfile(codGuiRadioProfile1) {
   category = "cod";
   bitmap = "art/gui/multiplayMenu/images/radioButton.png";
   fontType = "Arial Bold";
   fontSize = "16";
   fontColors["0"] = "179 179 179 55";
   fontColors["1"] = "230 230 230 255";
   fontColors["3"] = "249 249 249 255";
   fontColor = "179 179 179 55";
   fontColorHL = "230 230 230 255";
   fontColorSEL = "249 249 249 255";
};
singleton GuiControlProfile(inGameGuiDefaultProfile)
{
   opaque = "1";
};

singleton GuiControlProfile(countDownGuiProgressTextProfile)
{
   fontSize = "50";
   fontType = "Arial Bold";
   justify = "Center";
   fontColors[0] = "255 0 53 255";
   fontColor = "255 0 53 255";
   opaque = "1";
};


singleton GuiControlProfile(countDownTextProfile)
{
   fontType = "Arial Bold";
   fontSize = "50";
   fontColors[0] = "255 0 6 255";
   fontColor = "255 0 6 255";
   justify = "Center";
};


singleton GuiControlProfile(codGuiTextProfile6)
{
   fontType = "Arial Bold";
   fontSize = "30";
   fontColors[0] = "0 255 71 255";
   fontColor = "0 255 71 255";
};


singleton GuiControlProfile(playerListGuiButtonProfile)
{
   fontType = "Arial Bold";
   fontSize = "10";
   justify = "Center";
};

singleton GuiControlProfile(ChinatownGuiProgressTextProfile : GuiProgressTextProfile)
{
   fontSize = "14";
	fontType = "Arial";
   fontColor = "0 0 0";
   justify = "center";
   category = "Core";
   fontColors[0] = "253 253 253 255";
   fontColor = "253 253 253 255";
   category = "Chinatown";
   fontType = "Vrinda";
   fontSize = "18";
};
singleton GuiControlProfile(lobbyGlobalGuiTextProfile)
{
   fontSize = "12";
   fontColors[0] = "112 245 202 255";
   fontColor = "112 245 202 255";
   fontType = "Arial Bold";
};
singleton GuiControlProfile(codGuiButtonProfile3) {
   justify = "Center";
   fillColor = "69 69 69 225";
   fontType = "Arial Bold";
   fontColors["0"] = "253 252 252 255";
   fontColor = "253 252 252 255";
   fontSize = "18";
   category = "cod";
   fontColors["1"] = "200 200 200 255";
   fontColorHL = "200 200 200 255";
   fontColors["3"] = "27 27 27 255";
   fontColorSEL = "27 27 27 255";
   fillColorHL = "81 81 81 255";
};
singleton GuiControlProfile(codGuiTextProfile3) {
   category = "cod";
   fontColors["0"] = "234 197 127 201";
   fontColor = "234 197 127 201";
   fontType = "Arial Bold";
};

