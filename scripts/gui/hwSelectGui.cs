// ----------------------------------------------------------------------------
// Homeworld Selection gui
// ----------------------------------------------------------------------------
/*
Welcome to Sky City is 30 px, all font is Tahoma, Choose carefully line is 20 px, 
The HW Links are 30 px, Kingdom info font is 16 px, 
the rest is 14 px, The Viken pink is b34aa8, the rest of the font on the page is d7d7d7.
*/
function HWSelect::onWake(%this)
{
   %this-->WorldPic.visible = false;
   if ( %this.currentHW $= "" )
      %this.currentHW = -1;
   if ( %this.numWorlds == 0 )
      %this.makeHWButtons();

   // Update the gui layout
   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   // Make array storage for the homeworld and kingdom text
   %this.curHWData = -1;
   %this.HWData = new ArrayObject();

   if ( %this.currentHW > -1 )
   {
      %this.HWButton[%this.currentHW].setStateOn(true);
      %this.loadHWData(%this.currentHW, $AlterVerse::worldList.getKey(%this.currentHW));
   }
}

function HWSelect::onSleep(%this)
{
   // Delete all stored text
   if ( isObject(%this.HWData) )
   {
      for (%i = 0; %i < %this.HWData.count(); %i++)
      {
         %dataObj = %this.HWData.getValue(%i);
         %kArray = %dataObj.kingdoms;
         %numKingdoms = %kArray.count();
         for (%j = 0; %j < %numKingdoms; %j++)
         {
            %kObj = %kArray.getValue(%j);
            %kObj.delete();
         }
         %kArray.delete();
      }
      %this.HWData.delete();
   }
}

function HWSelect::onWorldClick(%this, %index, %hwID)
{  // A homeworld button has been selected. Load the descriptions.
   %this-->WorldPic.visible = false;
   %this.loadHWData(%index, %hwID);
}

function HWSelect::onKingdomSelected(%this)
{  // A kingdom has been selected, show it's details.
   //%this-->WorldPic.visible = false;

   %listBox = %this-->KISelect;
   %this.curKID = %listBox.getSelected();
   %this.setKingdomText(%this.curKID);
   %this.layoutInsets();
}

function HWSelect::onNextClicked(%this)
{
   %hwID = -1;
   if ( %this.currentHW > -1 )
      %hwID = $AlterVerse::worldList.getKey(%this.currentHW);

   if (( %hwID < 1 ) || ( %this.curKID < 1 ))
   {
      %message = "You must select a Home World and Kingdom before entering The AlterVerse.";
      ShowAVMessageBox("", %message, 0, "OK", "");
      return;
   }

   if ( ((%hwID !$= $pref::Player::WorldID) || (%this.curKID !$= $pref::Player::KingdomID))
          && ($pref::Player::ClanID > 0) && ($pref::Player::WorldID > 0) )
   {
      %message = %this.makeClanWarning(%hwID);
      ShowAVMessageBox("Alliance Message:", %message, 0,
         "Continue", "HWSelect.SaveChanges(" @ %hwID @ ", " @ %this.curKID @");",
         "Cancel", "");
   }
   else if ((%hwID !$= $pref::Player::WorldID) || (%this.curKID !$= $pref::Player::KingdomID))
      HWSelect.SaveChanges(%hwID, %this.curKID);
   else
      schedule(1, 0, "NextStartupStep");
}

function HWSelect::makeClanWarning(%this, %hwID)
{
   if ( %hwID $= $pref::Player::WorldID )
      %changed = "Kingdom";
   else
      %changed = "Home World";

   if ( $pref::Player::ClanLeader )
   {
      %hMsg = "<color:dd1111>Warning:<color:ffffff> You are the leader of the " @ $pref::Player::ClanName @ " alliance. If you change " @ %changed @ ", your alliance will be disbanded!";
   }
   else if ( $pref::Player::ClanID > 0 )
   {
      %hMsg = "Changeing your " @ %changed @ " will automatically remove you from the " @ $pref::Player::ClanName @ " alliance.";
   }

   return %hMsg;
}

function HWSelect::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents. Sizes and positions are taken from the
   // reference art and scaled to the current screen height (%newHeight)
   // The reference art is 1920x1080.
   %verticalScale = %newHeight / 1080;
   %horizontalScale = %newWidth / 1920;
   
   // Resize the fonts used for all controls based on screen height
   %this.resizeFonts(%verticalScale);
   
   // Force the drop down menu to close so it doesn't end up in the wrong place
   %this-->KISelect.forceClose();

   // The Top Title is 30 pixels tall and 11 pixels from the top
   %yExtent = mRound(30 * %verticalScale);
   %yPos = mRound(11 * %verticalScale);
   %this-->HWTitle1.resize(0, %yPos, %newWidth, %yExtent);

   // The second line is 20 pixels tall and 50 pixels from the top
   %yExtent = mRound(20 * %verticalScale);
   %yPos = mRound(50 * %verticalScale);
   %this-->HWTitle2.resize(0, %yPos, %newWidth, %yExtent);

   // Position the homeworld buttons
   %this.layoutHWButtons(%newWidth, %newHeight, %verticalScale);

   // The checkbox is 250x20, 32 pixels from the left and 35 pixels from the bottom
   %xExtent = mRound(250 * %verticalScale);
   %xPos = mRound(32 * %verticalScale);
   %yExtent = mRound(20 * %verticalScale);
   %yPos = %newHeight - mRound(35 * %verticalScale);
   %this-->SkipCheck.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The HW backgoud image is 1600x900 with a 15px drop shadow on the right and
   // bottom. The bitmap size is 1650x950 @ 156,125
   %useScale = (%verticalScale < %horizontalScale) ? %verticalScale : %horizontalScale;
   if ( (%useScale < 0.8) && (%horizontalScale < %verticalScale) )
   {  // We're scaling it way down, give all but 2% of the available width
      %useScale = (%newWidth * 0.98) / 1600;
      // Unless that makes it too tall ( 1040 = 915 pic and ds + 125 y offset )
      if ( (%useScale * 1040) > %newHeight )
         %useScale = %newHeight / 1040;
   }
   %xExtent = mRound(1650 * %useScale);
   %xPos = mRound((%newWidth - (1600 * %useScale)) / 2);
   %yExtent = mRound(950 * %useScale);
   %yPos = mRound(125 * %verticalScale);
   %yMax = mRound((%newHeight - (900 * %useScale)) / 2);
   if ( %yPos < %yMax )
      %yPos = %yMax;
   %this-->WorldPic.resize(%xPos, %yPos, %xExtent, %yExtent);
   %this-->WorldPic.curScale = %useScale;

   if ( %this-->WorldPic.visible )
      %this.layoutInsets();
}

function HWSelect::layoutHWButtons(%this, %newWidth, %newHeight, %useScale)
{
   // The spacers are 4x30 at full scale
   %spacerWidth = mRound(4 * %useScale);
   %spacerHeight = mRound(30 * %useScale);
   %textGap = mRound(30 * %useScale);

   // Find the width of each button and total them
   %totalWidth = 0;
   for (%i = 0; %i < %this.numWorlds; %i++)
   {
      %btnWidth = %this.HWButton[%i].getTextWidth(%this.HWButton[%i].text) + %textGap;
      %this.HWButton[%i].newWidth = %btnWidth;
      %totalWidth += %btnWidth;
   }
   %totalWidth += (%spacerWidth * (%this.numWorlds + 1));

   // The homeworld links are 30 pixels tall and 81 pixels from the top
   %yPos = mRound(81 * %useScale);
   %spacerY = mRound(83 * %useScale);
   %startX = (%newWidth - %totalWidth) / 2;
   %this.HWSpacer[0].resize(%startX, %spacerY, %spacerWidth, %spacerHeight);
   %startX += %spacerWidth;

   for (%i = 0; %i < %this.numWorlds; %i++)
   {
      %btnWidth = %this.HWButton[%i].newWidth;
      %this.HWButton[%i].resize(%startX, %yPos, %btnWidth, %spacerHeight);
      %startX += %btnWidth;

      %this.HWSpacer[%i+1].resize(%startX, %spacerY, %spacerWidth, %spacerHeight);
      %startX += %spacerWidth;
   }
}

function HWSelect::layoutInsets(%this)
{
   %useScale = %this-->WorldPic.curScale;
   //%useScale = 1;

   // The dropdown font is 16 point
   %fontPoint = mRound(16 * %useScale);
   AVDropListProfile.fontSize = mRound(%fontPoint * 1.2);
   AVSelectProfile.fontSize = mRound(%fontPoint * 1.2);
   AVSelectProfile.textOffset = mRound(6 * %useScale) SPC mRound(4 * %useScale);

   // The text font is 14 point
   %fontPoint = mRound(14 * %useScale);
   AVHWTextProfile.fontSize = mRound(%fontPoint * 1.2);

   %this.layoutPeoplePane(%useScale);
   %this.layoutWIPane(%useScale);
   %kiBottom = %this.layoutKIPane(%useScale);
   %this.layoutActionPane(%useScale, %kiBottom);
}
function HWSelect::layoutPeoplePane(%this, %useScale)
{  // All layout is relative to the 1600x900 HW image
   %imageWidth = mRound(1600 * %useScale);
   %imageHeight = mRound(900 * %useScale);

   // The title bitmap is 101x26 @ 57,7
   %xPos = mRound(57 * %useScale);
   %yPos = mRound(7 * %useScale);
   %xExtent = mRound(101 * %useScale);
   %yExtent = mRound(26 * %useScale);
   %this-->PeopleTitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The people text is 43 pixels below the top and 204px wide
   %this-->PeopleText.lineSpacing = mRound(8 * %useScale);
   %xPos = mRound(5 * %useScale);
   %yPos = mRound(43 * %useScale);
   %xExtent = mRound(204 * %useScale);
   %yExtent = mRound(700 * %useScale);
   %this-->PeopleText.resize(%xPos, %yPos, %xExtent, %yExtent);

   %this-->PeopleText.forceReflow();
   %textExtent = getWord(%this-->PeopleText.getExtent(), 1);
   %bottomSpace = mRound(25 * %useScale);
   %yShadeExt = %yPos + %textExtent + %bottomSpace;

   // The shade box is 214x744 at 70, 76
   %xPos = mRound(70 * %useScale);
   %yPos = mRound(30 * %useScale);
   %xExtent = mRound(214 * %useScale);
   %this-->PeopleShade.resize(%xPos, %yPos, %xExtent, %yShadeExt);

   // The top and bottom bars are 2px tall and run the width of the frame
   %this-->PeopleTop.resize(0, 0, %xExtent, 2);
   %this-->PeopleBottom.resize(0, %yShadeExt-2, %xExtent, 2);
}

function HWSelect::layoutWIPane(%this, %useScale)
{  // World Info pane
   // The title bitmap is 126x27 @ 285,7
   %xPos = mRound(285 * %useScale);
   %yPos = mRound(7 * %useScale);
   %xExtent = mRound(126 * %useScale);
   %yExtent = mRound(27 * %useScale);
   %this-->WITitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The Homeworld text is 41 pixels below the top and 676px wide
   %this-->WIText.lineSpacing = mRound(8 * %useScale);
   %xPos = mRound(10 * %useScale);
   %yPos = mRound(41 * %useScale);
   %xExtent = mRound(676 * %useScale);
   %yExtent = mRound(141 * %useScale);
   %this-->WIText.resize(%xPos, %yPos, %xExtent, %yExtent);

   %this-->WIText.forceReflow();
   %textExtent = getWord(%this-->WIText.getExtent(), 1);
   %bottomSpace = mRound(14 * %useScale);
   %yShadeExt = %yPos + %textExtent + %bottomSpace;

   // The shade box is 696x744 at 452, 2
   %xPos = mRound(452 * %useScale);
   %yPos = 2;//mRound(2 * %useScale);
   %xExtent = mRound(696 * %useScale);
   %this-->WIShade.resize(%xPos, %yPos, %xExtent, %yShadeExt);

   // The bottom bar is 2px tall and runs the width of the frame
   %this-->WIBottom.resize(0, %yShadeExt-2, %xExtent, 2);
}

function HWSelect::layoutKIPane(%this, %useScale)
{  // Kingdom Info pane
   // The title bitmap is 119X26 @ 47,7
   %xPos = mRound(47 * %useScale);
   %yPos = mRound(7 * %useScale);
   %xExtent = mRound(119 * %useScale);
   %yExtent = mRound(26 * %useScale);
   %this-->KITitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The choose line is 35 pixels below the top and 204px wide
   %xPos = mRound(5 * %useScale);
   %yPos = mRound(35 * %useScale);
   %xExtent = mRound(204 * %useScale);
   %yExtent = mRound(20 * %useScale);
   %this-->KIChoose.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The selection box is 54 pixels below the top and 204px wide
   %xPos = mRound(5 * %useScale);
   %yPos = mRound(54 * %useScale);
   %xExtent = mRound(204 * %useScale);
   %yExtent = mRound(24 * %useScale);
   %this-->KISelect.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The kingdom text is 87 pixels below the top and 204px wide
   %this-->KIText.lineSpacing = mRound(8 * %useScale);
   %xPos = mRound(5 * %useScale);
   %yPos = mRound(87 * %useScale);
   %xExtent = mRound(204 * %useScale);
   %yExtent = mRound(141 * %useScale);
   %this-->KIText.resize(%xPos, %yPos, %xExtent, %yExtent);

   %this-->KIText.forceReflow();
   %textExtent = getWord(%this-->KIText.getExtent(), 1);
   %curBottom = %textExtent + %yPos;

   // The population line is 30px below the text and 20px tall
   %curBottom += mRound(12 * %useScale);
   %yExtent = mRound(20 * %useScale);
   %xPos = mRound(9 * %useScale);
   %this-->KIPop.resize(%xPos, %curBottom, %xExtent, %yExtent);

   // The alliances line is 20px below that
   %curBottom += %yExtent;
   %this-->KIClans.resize(%xPos, %curBottom, %xExtent, %yExtent);

   %bottomSpace = mRound(14 * %useScale);
   %yShadeExt = %curBottom + %yExtent + %bottomSpace;

   // The shade box is 214x354 at 1312, 76
   %xPos = mRound(1312 * %useScale);
   %yPos = mRound(30 * %useScale);
   %xExtent = mRound(214 * %useScale);
   %this-->KIShade.resize(%xPos, %yPos, %xExtent, %yShadeExt);

   // The top and bottom bars are 2px tall and run the width of the frame
   %this-->KITop.resize(0, 0, %xExtent, 2);
   %this-->KIBottom.resize(0, %yShadeExt-2, %xExtent, 2);

   // Return the bottom of this frame so next can be alligned below it
   return %yPos + %yShadeExt;
}

function HWSelect::layoutActionPane(%this, %useScale, %lastBottom)
{
   // The title bitmap is 54x21 @ 75,7
   %xPos = mRound(75 * %useScale);
   %yPos = mRound(7 * %useScale);
   %xExtent = mRound(54 * %useScale);
   %yExtent = mRound(21 * %useScale);
   %this-->ActionTitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The action text is 43 pixels below the top and 204px wide
   %this-->ActionText.lineSpacing = mRound(8 * %useScale);
   %xPos = mRound(5 * %useScale);
   %yPos = mRound(43 * %useScale);
   %xExtent = mRound(204 * %useScale);
   %yExtent = mRound(700 * %useScale);
   %this-->ActionText.resize(%xPos, %yPos, %xExtent, %yExtent);
   %this-->ActionText.forceReflow();
   %textExtent = getWord(%this-->ActionText.getExtent(), 1);
   %curBottom = %textExtent + %yPos;

   // The next button is 160x49 @ 27, 298
   %xPos = mRound(27 * %useScale);
   %curBottom += mRound(12 * %useScale);
   //%yPos = mRound(298 * %useScale);
   %xExtent = mRound(160 * %useScale);
   %yExtent = mRound(49 * %useScale);
   %this-->NextBtn.resize(%xPos, %curBottom, %xExtent, %yExtent);

   %bottomSpace = mRound(14 * %useScale);
   %yShadeExt = %curBottom + %yExtent + %bottomSpace;

   // The shade box is 214x354 at 1312, 76
   %xPos = mRound(1312 * %useScale);
   %yPos = %lastBottom + mRound(15 * %useScale);
   %xExtent = mRound(214 * %useScale);
   %this-->ActionShade.resize(%xPos, %yPos, %xExtent, %yShadeExt);

   // The top and bottom bars are 2px tall and run the width of the frame
   %this-->ActionTop.resize(0, 0, %xExtent, 2);
   %this-->ActionBottom.resize(0, %yShadeExt-2, %xExtent, 2);
}

function HWSelect::resizeFonts(%this, %scaleFactor)
{  // Torque adjusts font sizes, to get the true point size we need to increase
   // the requested point size x1.2 for Tahoma
   %fontMult = 1.2;

   // The main title and HW link fonts are 30 point
   %fontPoint = mRound(30 * %scaleFactor);
   AVTitle1Profile.fontSize = mRound(%fontPoint * %fontMult);
   AVHWLinkProfile.fontSize = mRound(%fontPoint * %fontMult);

   // The second line font is 20 point
   %fontPoint = mRound(20 * %scaleFactor);
   AVTitle2Profile.fontSize = mRound(%fontPoint * %fontMult);

   // The check box font is 16 point
   %fontPoint = mRound(16 * %scaleFactor);
   AVNBCheckProfile.fontSize = mRound(%fontPoint * %fontMult);
}

function HWSelect::makeHWButtons(%this)
{  // Make all homeworld buttons
   if ( !isObject($AlterVerse::worldList) )
      return;
   %this.numWorlds = $AlterVerse::worldList.count();
   for (%i = 0; %i < %this.numWorlds; %i++)
   {
      %this.HWButton[%i] = %this.addHWButton(%i, $AlterVerse::worldList.getKey(%i),
            $AlterVerse::worldList.getValue(%i));

      if ( $pref::Player::WorldID == $AlterVerse::worldList.getKey(%i) )
         %this.currentHW = %i;
   }

   // Make the spacers
   for (%i = 0; %i < %this.numWorlds + 1; %i++)
   {
      %this.HWSpacer[%i] = %this.addHWSpacer();
   }
}

function HWSelect::addHWButton(%this, %index, %hwID, %hwName)
{
   %newBtn = new GuiButtonCtrl() {
      text = %hwName;
      buttonType = "RadioButton";
      position = "0 0";
      extent = "110 30";
      minExtent = "8 8";
      horizSizing = "right";
      vertSizing = "bottom";
      profile = "AVHWLinkProfile";
      visible = "1";
      active = "1";
      tooltipProfile = "GuiToolTipProfile";
      hovertime = "1000";
      isContainer = "1";
      InternalName = "";
      command = "HWSelect.onWorldClick(" @ %index @ "," @ %hwID @ ");";
      canSave = "1";
      canSaveDynamicFields = "0";
   };

   %this.addGuiControl(%newBtn);
   return %newBtn;
}

function HWSelect::addHWSpacer(%this)
{
   %newBtn = new GuiControl() {
      position = "0 0";
      extent = "4 30";
      minExtent = "2 8";
      horizSizing = "right";
      vertSizing = "bottom";
      profile = "AVHWSpacerProfile";
      visible = "1";
      active = "1";
      tooltipProfile = "GuiToolTipProfile";
      hovertime = "1000";
      isContainer = "1";
      InternalName = "";
      canSave = "1";
      canSaveDynamicFields = "0";
   };

   %this.addGuiControl(%newBtn);
   return %newBtn;
}

function HWSelect::showHWDetails(%this, %btnIndex, %hwID)
{
   %this.currentHW = %btnIndex;
   %this-->WorldPic.setBitmap("art/gui/backgrounds/HWSelect_" @
      %this.HWButton[%btnIndex].text);

   %textBox = %this-->PeopleText;
   %msg = %this.curHWData.peopleText;
   if ( %msg $= "" )
      %msg = "No text available...";
   %textBox.setText(%textBox.format @ %msg);

   %textBox = %this-->WIText;
   %msg = %this.curHWData.description;
   if ( %msg $= "" )
      %msg = "No text available...";
   %textBox.setText(%textBox.format @ %msg);

   %kArray = %this.curHWData.kingdoms;
   %numKingdoms = %kArray.count();
   %listBox = %this-->KISelect;
   %listBox.clear();
   for ( %i = 0; %i < %numKingdoms; %i++)
   {
      %kID = %kArray.getKey(%i);
      %kData = %kArray.getValue(%i);
      %listBox.add(%kData.kname, %kID);
   }
   //%listBox.add("Nordic North", 7);
   //%listBox.add("Arctic South", 10);

   if ( ($pref::Player::WorldID == %hwID) && ($pref::Player::KingdomID > 0) )
      %this.curKID = $pref::Player::KingdomID;
   else
      %this.curKID = %kArray.getKey(0);
   %listBox.setSelected(%this.curKID, false);
   %this.setKingdomText(%this.curKID);

   %this.layoutInsets();
   %this-->WorldPic.visible = true;
}

function HWSelect::setKingdomText(%this, %kID)
{
   %kArray = %this.curHWData.kingdoms;
   %kIndex = %kArray.getIndexFromKey(%kID);
   if ( %kIndex == -1 )
      return;
   %kData = %kArray.getValue(%kIndex);

   %textBox = %this-->KIText;
   %msg = %kData.desc;
   if ( %msg $= "" )
      %msg = "No text available...";
   %textBox.setText(%textBox.format @ %msg);

   %textBox = %this-->KIPop;
   %textBox.setText(%textBox.format @ %kData.population);

   %textBox = %this-->KIClans;
   %textBox.setText(%textBox.format @ %kData.numClans);
}

function HWSelect::SaveChanges(%this, %hwID, %kID)
{
   // hash our password combined with the supplied hash
   %pwdHash = getStringMD5( $currentHash @ $currentPasswordHash );
   %args = "uid=" @ $currentPlayerID @"\t"@ "uhash=" @ %pwdHash;
   %args = %args @ "\t" @ "hwid=" @ %hwID;
   %args = %args @ "\t" @ "kid=" @ %kID;

   new HttpObject(httpKingdomChange){
      status = "failure";
      message = "";
   };

   httpKingdomChange.get( $serverPath, $scriptPath @ "kingdomChange.php", %args );  
}

function HWSelect::loadHWData(%this, %btnIndex, %hwID)
{
   %dataIndex = %this.HWData.getIndexFromKey(%hwID);
   if (%dataIndex != -1)
   {  // This data has already been loaded
      %this.curHWData = %this.HWData.getValue(%dataIndex);
      %this.showHWDetails(%btnIndex, %hwID);
      return;
   }

   if ( %this.dataLoading )
      return;

   // No data yet, so get it from the server
   %this.dataLoading = true;
   %request = new HTTPObject() {
      class = "getHomeworldData";
      status = "failure";
      message = "";
      btnIndex = %btnIndex;
   };
   
   %request.get( $serverPath, $scriptPath @ "getHomeworldData.php", "hwid=" @ %hwID );
}

function getHomeworldData::process( %this )
{  //HWSelect
   switch$( %this.status )
   {
   case "success":
      // Make an array of kingdoms
      %kArray = new ArrayObject();
      for (%i = 0; %i < %this.NumKingdoms; %i++)
      {
         %kObj = new ScriptObject()
         {
            kname = %this.KName[%i];
            desc = %this.KDesc[%i];
            population = %this.KPop[%i];
            numClans = %this.KAll[%i];
         };
         
         %kArray.add(%this.KingdomID[%i], %kObj);
      }

      // Store the data for this homeworld
      %hwObj = new ScriptObject()
      {
         description = %this.WorldDesc;
         peopleText = %this.WorldPeeps;
         kingdoms = %kArray;
      };

      HWSelect.HWData.add(%this.WorldID, %hwObj);
      HWSelect.curHWData = %hwObj;
      HWSelect.showHWDetails(%this.btnIndex, %this.WorldID);
      
   default:
      echo(%this.message);
      MessageBoxOK( "Failed to contact web server", "Could not load world data." SPC %this.message);
   }
   HWSelect.dataLoading = false;
   %this.schedule(0, delete);
}

function httpKingdomChange::process( %this )
{

   switch$( %this.status )
   {
   case "success":
      $currentPasswordHash = %this.hash;

      $serverToJoin = %this.server;
      $ServerName = %this.svrName;
      $AlterVerse::serverPrefix = %this.filePrefix;
      // the murmur server that's used for voice chat
      $Mumble::murmurAddress = %this.murmur;
      // and the manifest paths
      $manifestRoot = %this.manifestRoot;
      $manifestFile = %this.manifestFile;
      $pref::Player::ClanID = %this.clan_id;
      $pref::Player::ClanName = %this.clan_name;
      $pref::Player::ClanLeader = %this.clan_ldr;

      $pref::Player::WorldID = %this.world_id;
      $pref::Player::KingdomID = %this.kingdom_id;
      $pref::Player::WorldName = %this.world_name;
      $pref::Player::KingdomName = %this.kingdom_name;

      schedule(1, 0, "NextStartupStep");
   default:
      echo(%this.message);
      MessageBoxOK( "Failed to contact web server", "Could not update Kingdom selection:" SPC %this.message);
   }
   %this.schedule(0, delete);
}

//$AlterVerse::worldList.getKey(%i);
//Canvas.pushDialog(HWSelect);
//Canvas.setContent(HWSelect);
//HWTestLink.setStateOn(1);
