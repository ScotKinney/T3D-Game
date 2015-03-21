// ----------------------------------------------------------------------------
// Avatar Setup/Congratulations/Realm Info gui
// ----------------------------------------------------------------------------

function AVSetup::setupKingdom(%this)
{  // Set the background image based on kingdom name
   %trimName = stripChars($pref::Player::KingdomName, " ");
   %this.setBitmap("art/gui/backgrounds/" @ %trimName @ "BackGround");
   
   // Make the congratulations text
   %newText = "You are now a resident of the Kingdom of " @ $pref::Player::KingdomName @
      " on the " @ $pref::Player::WorldName @ " Home World! Fear not, Avii will continue to help guide " @
      "you on your journey and your Tap-link will be available as part of an AR Heads Up Display (HUD). " @
      "From now on you will wear the clothing of the planet you're on. You will be able to buy more clothes " @
      "in the various shops and even craft armor items to wear soon. But let's not get ahead of the game..." @
      "Take a minute now to customize your look using the Customizer. You can change it later because the " @
      "Customizer will remain available in your HUD.";

   %textBox = %this-->CongratsText;
   %textBox.setText(%textBox.format @ %newText);
}

function AVSetup::setStaticText(%this, %fontSize, %tabSize)
{
   %mainText = "<tab:" @ %tabSize @ ">When you have yourself looking good, you have a decision to make...<br>" @
      "\t1. Go to my Realm OR<br>" @
      "\t2. Go to my Kingdom<br><br>" @
      "<font:Tahoma Bold:" @ %fontSize @ ">Your Realm<font:Tahoma:" @ %fontSize @ "> " @
      "is your own plot of land in the Kingdom you choose. You host it on your own computer. " @
      "You can edit the land and foliage, build, hunt, fish, farm and plant on it. You can " @
      "invite friends to help! When ready, connect it to the AlterVerse so others can see it " @
      "and even visit if you make it public. But first you have to set it up. More details are " @
      "on the Realm Info page.<br><br>" @
      "<font:Tahoma Bold:" @ %fontSize @ ">Your Kingdom<font:Tahoma:" @ %fontSize @ "> " @
      "is on our live servers where much of the game is played. Go on quests, battle, meet others, " @
      "form alliances, find treasure and join the adventure!<br><br>" @
      "<just:center>What is your next step going to be?<br><br>Go to My Realm";
   %this-->NSTextMain.setText(%mainText);
   
   %bottomText = "<just:center>OR<br>Go to My Kingdom";
   %this-->NSTextBottom.setText(%bottomText);
}

function AVSetup::onWake(%this)
{
   // Set the background image and text for the current kingdom
   %this.setupKingdom();

   // Push the customizer onto the screen
   Canvas.pushDialog(AVCustomizer);

   // Update the gui layout
   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));
}

function AVSetup::onSleep(%this)
{
}

function AVSetup::onBackClicked(%this)
{
   $pref::startup::skipHW = false;
   $AlterVerse::StartupStep = 0;
   schedule(1, 0, "NextStartupStep");
}

function AVSetup::onRealmClicked(%this)
{  // Show the Realm setup gui
   return;
}

function AVSetup::onKingdomClicked(%this)
{
   schedule(1, 0, "NextStartupStep");
}

function AVSetup::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents. Sizes and positions are taken from the
   // reference art and scaled to the current screen height (%newHeight)
   // The reference art is 1920x1080.
   %verticalScale = %newHeight / 1080;
   %horizontalScale = %newWidth / 1920;

   // Resize the fonts used for all controls based on screen height
   %this.resizeFonts(%verticalScale);

   %rightBottom = %this.layoutCongratsPane(%newWidth, %verticalScale);
   %this.layoutNSPane(%newWidth, %verticalScale, %rightBottom);
   
   // Reposition the customizer
   %gapWidth = %newWidth - getWord(%rightBottom, 0);
   %yPos = getWord(%rightBottom, 1);
   %custX = 2 * mRound((%gapWidth - 240) / 3);
   if ( %custX < 0 )
      %custX = 0;
   AVCustomizer-->ShadeBox.setPosition(%custX, %yPos);

   // The Back button is 160x49
   %xExtent = mRound(160 * %verticalScale);
   %yExtent = mRound(49 * %verticalScale);
   %this-->BackBtn.resize(%custX, 0, %xExtent, %yExtent);

   // The checkbox is 250x20, 32 pixels from the left and 35 pixels from the bottom
   %xExtent = mRound(250 * %verticalScale);
   %xPos = mRound(32 * %verticalScale);
   %yExtent = mRound(20 * %verticalScale);
   %yPos = %newHeight - mRound(35 * %verticalScale);
   %this-->SkipCheck.resize(%xPos, %yPos, %xExtent, %yExtent);
}

function AVSetup::resizeFonts(%this, %scaleFactor)
{  // Torque adjusts font sizes, to get the true point size we need to increase
   // the requested point size x1.2 for Tahoma
   %fontMult = 1.2;

   // The info and checkbox fonts are 16 point
   %fontPoint = mRound(16 * %scaleFactor);
   AVHWTextProfile.fontSize = mRound(%fontPoint * %fontMult);
   AVNBCheckProfile.fontSize = mRound(%fontPoint * %fontMult);
}

function AVSetup::layoutCongratsPane(%this, %newWidth, %useScale)
{  // Congratulations pane
   // The congratulations bitmap is 169x27 @ 262,7
   %xExtent = mRound(169 * %useScale);
   %xPos = mRound(262 * %useScale);
   %yExtent = mRound(27 * %useScale);
   %yPos = mRound(7 * %useScale);
   %this-->CongratsTitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The congratulations text is 674x145 @ 10,41
   %this-->CongratsText.lineSpacing = mRound(2 * %useScale);
   %xPos = mRound(10 * %useScale);
   %yPos = mRound(41 * %useScale);
   %xExtent = mRound(674 * %useScale);
   %yExtent = mRound(145 * %useScale);
   %this-->CongratsText.resize(%xPos, %yPos, %xExtent, %yExtent);

   %this-->CongratsText.forceReflow();
   %textExtent = getWord(%this-->CongratsText.getExtent(), 1);
   //%curBottom = %textExtent + %yPos;
   %bottomSpace = mRound(14 * %useScale);
   %yShadeExt = %yPos + %textExtent + %bottomSpace;

   // The congratulations inset is 694x188 centered at the top of the screen
   %xExtent = mRound(694 * %useScale);
   %xPos = mRound((%newWidth - %xExtent) / 2);
   %this-->CongratsShade.resize(%xPos, 0, %xExtent, %yShadeExt);
   %rightBottom = (%xPos + %xExtent) SPC %yShadeExt;

   // The top and bottom bars are 2px tall and run the width of the frame
   %this-->CongratsTop.resize(0, 0, %xExtent, 2);
   %this-->CongratsBottom.resize(0, %yShadeExt-2, %xExtent, 2);

   return %rightBottom;
}

function AVSetup::layoutNSPane(%this, %newWidth, %useScale, %leftTop)
{  // Next Step pane
   // The Next Step bitmap is 71x22 @ 109,6
   %xExtent = mRound(71 * %useScale);
   %xPos = mRound(109 * %useScale);
   %yExtent = mRound(22 * %useScale);
   %yPos = mRound(6 * %useScale);
   %this-->NSTitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The Next Step main text is 269x250 @ 10,41
   %tabSize = mRound(18 * %useScale);
   %this.setStaticText(AVHWTextProfile.fontSize, %tabSize);
   %this-->NSTextMain.lineSpacing = mRound(2 * %useScale);
   %xPos = mRound(10 * %useScale);
   %yPos = mRound(41 * %useScale);
   %xExtent = mRound(269 * %useScale);
   %yExtent = mRound(250 * %useScale);
   %this-->NSTextMain.resize(%xPos, %yPos, %xExtent, %yExtent);

   %this-->NSTextMain.forceReflow();
   %textExtent = getWord(%this-->NSTextMain.getExtent(), 1);
   %bottomSpace = 0; //mRound(5 * %useScale);
   %curBottom = %textExtent + %yPos + %bottomSpace;

   // The Realm info button is 160x49 centered below text
   %xExtent = mRound(160 * %useScale);
   %yExtent = mRound(49 * %useScale);
   %xPos = mRound(65 * %useScale);
   %this-->RealmBtn.resize(%xPos, %curBottom, %xExtent, %yExtent);
   %curBottom = %curBottom + %yExtent + %bottomSpace;

   // The Next Step bottom text is 269x50 @ 10,curBottom
   %this-->NSTextBottom.lineSpacing = mRound(2 * %useScale);
   %xPos = mRound(10 * %useScale);
   %xExtent = mRound(269 * %useScale);
   %yExtent = mRound(50 * %useScale);
   %this-->NSTextBottom.resize(%xPos, %curBottom, %xExtent, %yExtent);

   %this-->NSTextBottom.forceReflow();
   %textExtent = getWord(%this-->NSTextBottom.getExtent(), 1);
   %curBottom = %curBottom + %textExtent + %bottomSpace;

   // The Kingdom button is 160x49 centered below text
   %xExtent = mRound(160 * %useScale);
   %yExtent = mRound(49 * %useScale);
   %xPos = mRound(65 * %useScale);
   %this-->KingdomBtn.resize(%xPos, %curBottom, %xExtent, %yExtent);

   %bottomSpace = mRound(10 * %useScale);
   %yShadeExt = %curBottom + %yExtent + %bottomSpace;

   // The Next Step inset is 289x188
   %left = getWord(%leftTop, 0);
   %top = getWord(%leftTop, 1);
   %xExtent = mRound(289 * %useScale);
   %xPos = %left + mRound((%newWidth - %left - %xExtent) / 3);
   %this-->NSShade.resize(%xPos, %top, %xExtent, %yShadeExt);

   // The top and bottom bars are 2px tall and run the width of the frame
   %this-->NSTop.resize(0, 0, %xExtent, 2);
   %yPos = mRound(30 * %useScale);
   %this-->NSMid.resize(0, %yPos, %xExtent, 2);
   %this-->NSBottom.resize(0, %yShadeExt-2, %xExtent, 2);
}
