// ----------------------------------------------------------------------------
// Avatar customizer gui
// ----------------------------------------------------------------------------
//$ImAMigrant = true;

// Set default values for all avatars here
function AvSelectionGui::defaultAvatar(%this, %gender)
{  // Makes the default avatar if none has been saved
   if ( $ImAMigrant || !$IsSubscriber )
   {  // Migrant setups
      if ( %gender $= "Male" )
      {
         switch ($pref::Player::WorldID)
         {
            case 1:  // Sparta
               return "55,59,35,242,6,269,13";
            case 2:  // Caerule
               return "55,59,35,20,65,63,70,77";
            case 3:  // Mythriel
               return "55,59,298,35,294,295,292";
            case 4:  // Viken
               return "55,59,50,35,279,280,283";
            case 5:  // Maya
               return "55,59,237,35,313,320,378,306,309";
            default:
               return "55,59,298,35,294,295,292";
         }
      }
      else
      {
         switch ($pref::Player::WorldID)
         {
            case 1:  // Sparta
               return "80,99,216,355,350,348,347,352";
            case 2:  // Caerule
               return "80,99,216,387,393,382,379,380,390,395,392";
            case 3:  // Mythriel
               return "80,99,366,216,368,364,363,370";
            case 4:  // Viken
               return "80,99,397,216,396,404,398,401";
            case 5:  // Maya
               return "80,99,216,330,326,325,361,328,324";
            default:
               return "80,99,366,216,368,364,363,370";
         }
      }
   }
   else
   {  // Citizen setups
      if ( %gender $= "Male" )
      {
         switch ($pref::Player::WorldID)
         {
            case 1:  // Sparta
               return "92,54,203,89,339,267,262,270,6,269,12,362";
            case 2:  // Caerule
               return "94,206,32,59,275,278,23,29,68,65,63,73";
            case 3:  // Mythriel
               return "57,37,201,88,303,291,294,295,377";
            case 4:  // Viken
               return "92,226,203,89,290,268,270,17,281,279,284";
            case 5:  // Maya
               return "57,237,201,90,316,310,312,304,307,313,320,378";
            default:
               return "55,59,50,35,279,282";
         }
      }
      else
      {
         switch ($pref::Player::WorldID)
         {
            case 1:  // Sparta
               return "111,355,218,102,135,345,342,346,349,350,348,347,352,360";
            case 2:  // Caerule
               return "80,161,215,114,144,385,380,389,395,382,379,392";
            case 3:  // Mythriel
               return "81,173,213,102,142,373,367,370,368,364,363,374,365";
            case 4:  // Viken
               return "111,195,217,102,136,409,405,399,396,402";
            case 5:  // Maya
               return "81,331,216,102,136,337,334,327,323,326,325,361";
            default:
               return "80,99,216,330,326,325,328,324";
         }
      }
   }
}

function AvSelectionGui::setupAvAnimations(%this)
{
   // opt = shirt, pant, feet, cape, misc
   // base = face, skin tone, hair, eye
   
   // Random animations. Plays any from the following list
   %this.numAltAnims = 0;
   //%this.altAnim[0] = "jump";
   //%this.altAnim[1] = "flex3";
   //%this.altAnim[2] = "celwave";
   
   // Play once every 10 - 20 seconds
   %this.minAnimTime = 10000;
   %this.maxAnimTime = 20000;
}

function AvSelectionGui::onWake(%this)
{
   // If the right mouse button was bound, unbind it but remember the state so
   // it can be restored in onSleep
   %this.rightMouseBind = globalActionMap.getCommand(mouse, button1);
   if ( %this.rightMouseBind !$= "" )
      globalActionMap.unbind( mouse, button1);

   // Add the progress bar control
   %this-->PlayButton.setActive(false);
   %this-->HomesteadButton.setActive(false);
   %this-->SaveButton.setActive(false);
   //%this-->PlayButton.setText("Initializing");

   // Make sure we have the latest options and tints
   %this.LoadPlayerMats();
   exec("art/players/base/clientExec.cs");

   Canvas.popDialog(AVMainGui);

   %this.setupAvAnimations();
   //%this.outfit = $pref::Player::Outfit;

   // Startup the background music
   stopIntroMusic();
   %this.playSelectorMusic();

   if ( %this.optionsSet )
   {  // setup the correct model and install the text
      // If were setting up for a citizen, create the selector planks.
      if ( !$ImAMigrant && $IsSubscriber )
         %this.MakePlanks();

      %this.outfit = %this.findCurrentOutfit();
      %this.homeworldChanged(false);
      %this.makeCurrentOutfit();
      %this.setAvModel();
      %this.updateButtons();
   }

   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   // Pop/Push the chat dialog so it is on top if connected to chat server
   if ( MainChatHud.isAwake() )
      Canvas.popDialog(MainChatHud);

   if (isObject(clientChat) && clientChat.connected)
      Canvas.pushDialog(MainChatHud);
}

function AvSelectionGui::LoadPlayerMats(%this)
{
   // Create a group for the materials
   if( isObject( ClientPlayerMaterials ) )
      ClientPlayerMaterials.delete();
   %oldGroup = $instantGroup;
   $instantGroup = 0;
   %matGroup = new SimGroup(ClientPlayerMaterials);
   $instantGroup = %matGroup;

   %filter = "art/players/base/*/materials.cs";
   loadDirMaterials(%filter);

   $instantGroup = %oldGroup;
}

function AvSelectionGui::initOptions(%this)
{
   // Setup for the starting homeworld and gender
   %this.lastHomeworld = -1;
   %this.homeworldID = $pref::Player::WorldID;
   %this.homeworldIndex = %this.homeworldData.getIndexFromKey(%this.homeworldID);
   %this.curGender = (($pref::Player::Gender $= "MALE") ? 0 : 1);

   if ( AvSelectionGui.savedMale $= "" )
      AvSelectionGui.savedMale = %this.defaultAvatar("Male");
   if ( AvSelectionGui.savedFemale $= "" )
      AvSelectionGui.savedFemale = %this.defaultAvatar("Female");

   if ( %this.curGender == 0 )
   {
      %this.curOpts = getBarWord(AvSelectionGui.savedMale, 0);
      %this.curOverlays = getBarWord(AvSelectionGui.savedMale, 1);
   }
   else
   {
      %this.curOpts = getBarWord(AvSelectionGui.savedFemale, 0);
      %this.curOverlays = getBarWord(AvSelectionGui.savedFemale, 1);
   }

   if ( %this.isAwake() )
   {  // setup the correct model and install the text
      if ( !$ImAMigrant && $IsSubscriber && (%this.numPlanks < 11) )
         %this.MakePlanks();

      %this.outfit = %this.findCurrentOutfit();
      %this.homeworldChanged(false);
      %this.makeCurrentOutfit();
      %this.setAvModel();
      %this.updateButtons();
   }

   %this.optionsSet = true;
   %this-->AvatarView.visible = true;
   %this-->GenderBtnLf.visible = true;
   %this-->GenderBtnRt.visible = true;
   %this-->HomeworldBtnLf.visible = true;
   %this-->HomeworldBtnRt.visible = true;
   %this-->OutfitBtnLf.visible = true;
   %this-->OutfitBtnRt.visible = true;
}

function AvSelectionGui::onSleep(%this)
{
   if ( isEventPending(%this.animSchedule) )
      cancel(%this.animSchedule);

   %this.RemoveMaterials();
   AvSelModelView.setModel("");

   // Stop the background music
   %this.stopSelectorMusic();

   // Remove any planks created for selections
   if ( %this.hasPlanks )
   {
      %this.removeTintBtns();
      for ( %i = 0; %i < %this.numPlanks; %i++ )
      {
         %this.remove(%this.plank[%i]);
         %this.plank[%i].delete();
      }
      %this.numPlanks = 0;
      %this.hasPlanks = false;
   }

   %this.deleteDataArrays();

   if( isObject( ClientPlayerMaterials ) )
      ClientPlayerMaterials.delete();

   // Remove textures from the pool
   cleanupTexturePool();
   flushTextureCache();


   // restore the right mouse bind
   if ( %this.rightMouseBind !$= "" )
      globalActionMap.bind(mouse, button1, %this.rightMouseBind);
}

function AvSelectionGui::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents. Sizes and positions are taken from the
   // reference art and scaled to the current screen height (%newHeight)
   // The reference art is 1600x900.
   %verticalScale = %newHeight / 900;
   %horizontalScale = %newWidth / 1600;
   
   // Resize the fonts used for all controls based on screen height
   %this.resizeFonts(%verticalScale);

   // Customizer Logo
   // The logo is 294x194 and positioned at 20, 5
   %xExtent = mRound(294 * %verticalScale);
   %yExtent = mRound(150 * %verticalScale);
   %xPos = mRound(20 * %horizontalScale);
   %yPos = mRound(5 * %verticalScale);
   %this-->AVLogoImage.resize(%xPos, %yPos, %xExtent, %yExtent);
   %logoCenter = %xPos + %xExtent / 2;
   %logoRight = %xPos + %xExtent;

   // Text Blocks
   // The block image is 605x256 and positioned 5 pixels from the top and
   // centered horizontally on the screen
   %xExtent = mRound(605 * %verticalScale);
   %yExtent = mRound(256 * %verticalScale);
   %xPos = mRound((%newWidth - %xExtent) / 2);
   //if ( %xPos < %logoRight )
      //%xPos = %logoRight; // Don't overlap the logo.
   %yPos = mRound(5 * %verticalScale);
   %this-->TextBlock.resize(%xPos, %yPos, %xExtent, %yExtent);
   %blockXPos = %xPos;
   %blockBottom = %yPos + %yExtent;
   
   // Homeworld description area
   // The homeworld text area is 510 pixels wide and centered within the block
   %xExtent = mRound(410 * %verticalScale);
   %xPos = %blockXPos + mRound(97.5 * %verticalScale);
   
   // Homeworld Title is 40 pixels tall and 2 pixels from the top
   %yExtent = mRound(40 * %verticalScale);
   %yPos = mRound(2 * %verticalScale);
   %this-->HomeworldTitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // Homeworld text is 90 pixels tall and 59 pixels from the top
   %yExtent = mRound(90 * %verticalScale);
   %yPos = mRound(47 * %verticalScale);
   %this-->HomeworldText.resize(%xPos, %yPos, %xExtent, %yExtent);

   // Selection Planks
   // The Planks are 237x30 and centered under the logo. They begin 156 pixels
   // from the top
   %xExtent = mRound(237 * %verticalScale);
   %yExtent = mRound(30 * %verticalScale);
   %xPos = mRound(%logoCenter - (%xExtent / 2));
   %yPos = mRound(156 * %verticalScale);
   %this-->GenderPlank.resize(%xPos, %yPos, %xExtent, %yExtent);
   %this-->GenderPlankText.resize(%xPos, %yPos, %xExtent, %yExtent);
   
   // The right/left buttons are 30x30, centered vertically on the planks and
   // positioned 8 pixels from the edges
   %btnPadding = mRound(8 * %verticalScale);
   %btn1X = %xPos + %btnPadding;
   %btn2X = %xPos + %xExtent - (%btnPadding + %yExtent);
   %this-->GenderBtnLf.resize(%btn1X, %yPos, %yExtent, %yExtent);
   %this-->GenderBtnRt.resize(%btn2X, %yPos, %yExtent, %yExtent);

   %yPos += %yExtent + 1;
   %this-->HomeworldPlank.resize(%xPos, %yPos, %xExtent, %yExtent);
   %this-->HomeworldPlankText.resize(%xPos, %yPos, %xExtent, %yExtent);
   %this-->HomeworldBtnLf.resize(%btn1X, %yPos, %yExtent, %yExtent);
   %this-->HomeworldBtnRt.resize(%btn2X, %yPos, %yExtent, %yExtent);

   //%yPos += %yExtent + 1;
   //%this-->ClanPlank.resize(%xPos, %yPos, %xExtent, %yExtent);
   //%this-->ClanPlankText.resize(%xPos, %yPos, %xExtent, %yExtent);
   //%this-->ClanBtnLf.resize(%btn1X, %yPos, %yExtent, %yExtent);
   //%this-->ClanBtnRt.resize(%btn2X, %yPos, %yExtent, %yExtent);

   %yPos += %yExtent + 1;
   %this-->OutfitPlank.resize(%xPos, %yPos, %xExtent, %yExtent);
   %this-->OutfitPlankText.resize(%xPos, %yPos, %xExtent, %yExtent);
   %this-->OutfitBtnLf.resize(%btn1X, %yPos, %yExtent, %yExtent);
   %this-->OutfitBtnRt.resize(%btn2X, %yPos, %yExtent, %yExtent);

   if ( $ImAMigrant || !$IsSubscriber)
   {  // Do setup for non-subscribers (migrants)
      %this.showCitizenFields(false);
      %this.showMigrantFields(true);
      %this.migrantLayout(%verticalScale, %logoCenter, %yPos + %yExtent);
   }
   else
   {  // Do setup for subscribers (citizens)
      %this.showMigrantFields(false);
      %this.showCitizenFields(true);
      %this.citizenLayout(%verticalScale, %logoCenter, %yPos + %yExtent);
   }

   // Info Logo
   // The logo is 294x194 and positioned 5 pixels from the top and 20 pixels
   // from the right edge
   %xExtent = mRound(294 * %verticalScale);
   %yExtent = mRound(150 * %verticalScale);
   %xPos = %newWidth - mRound(20 * %horizontalScale) - %xExtent;
   %yPos = mRound(5 * %verticalScale);
   %this-->BCLogo2Image.resize(%xPos, %yPos, %xExtent, %yExtent);
   %logoCenter = %xPos + %xExtent / 2;
   %logoRight = %xPos + %xExtent;

   // Info Plank
   // The info png is 237x500, centered under the logo and 156 pixels
   // from the top
   %xExtent = mRound(237 * %verticalScale);
   %yExtent = mRound(500 * %verticalScale);
   %xPos = mRound(%logoCenter - (%xExtent / 2));
   %yPos = mRound(156 * %verticalScale);
   %this-->InfoPlank.resize(%xPos, %yPos, %xExtent, %yExtent);
   
   // PlayChains 13x25 and run from the bottom of the logo to the play button
   // they are spaced 120 pixels apart horizontally
   %chainXExtent = mRound(13 * %verticalScale);
   %chainYExtent = mRound(25 * %verticalScale);
   %xPos = mRound(%logoCenter - (60 * %verticalScale + %chainXExtent));
   %this-->PlayChainLeft.resize(%xPos, %yPos + %yExtent, %chainXExtent, %chainYExtent);

   %xPos = mRound(%logoCenter + (60 * %verticalScale));
   %this-->PlayChainRight.resize(%xPos, %yPos + %yExtent, %chainXExtent, %chainYExtent);
   %chainBottom = %yPos + %yExtent + %chainYExtent;

   // Play button
   // The play button is 150x48 and hanging from the chains centered under the logo.
   %xExtent = mRound(183 * %verticalScale);
   %yExtent = mRound(48 * %verticalScale);
   %xPos = mRound(%logoCenter - (%xExtent / 2));//%xPos = %newWidth - %xExtent - mRound(65 * %horizontalScale);
   %yPos = %chainBottom;
   %this-->PlayButton.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The Homestead button is one pixel below the bottom of the play button
   %yPos = %yPos + %yExtent + 1;
   %this-->HomesteadButton.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The Save button is one pixel below the bottom of the Homestead button
   %yPos = %yPos + %yExtent + 1;
   %this-->SaveButton.resize(%xPos, %yPos, %xExtent, %yExtent);

   // Gui Title
   // The title area is 380x26 and positioned 20 pixels from the right edge,
   // 2 pixels from the top.
   //%xExtent = mRound(380 * %verticalScale);
   //%yExtent = mRound(26 * %verticalScale);
   //%xPos = %newWidth - %xExtent - mRound(20 * %horizontalScale);
   //%yPos = mRound(8 * %verticalScale);
   //%this-->TitleText.resize(%xPos, %yPos, %xExtent, %yExtent);

   // AEG LLC
   // The AEG area is 300x16 and positioned 10 pixels from the left edge of the
   //screen, at pixel 840y
   %xExtent = mRound(300 * %verticalScale);
   %yExtent = mRound(16 * %verticalScale);
   %xPos = mRound(10 * %horizontalScale);
   %yPos = %newHeight - (%yExtent + 2); //mRound(840 * %verticalScale);
   %this-->AEGLLCText.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The model and control block are laid out based on the center of the
   // pedestal which is conveniently now at the center of the screen.
   %pedestalCenter = mRound(%newWidth / 2);

   // We want the models eyes (center of view) to be at 510 pixels. With the
   // bottom of the control @ 843y.
   %viewCenter = mRound(501 * %verticalScale);//266-501
   %viewBottom = mRound(860 * %verticalScale);//800-843
   %yExtent = (%viewBottom - %viewCenter) * 2;
   %yPos = %viewBottom - %yExtent;
   %xExtent = mRound(%yExtent * 1.25);
   %xPos = %pedestalCenter - mRound(%xExtent / 2);
   %this-->AvatarView.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The control block is 117x50 and positioned 795 pixels from the top
   %xExtent = mRound(117 * %verticalScale);
   %xPos = %pedestalCenter - mRound(%xExtent / 2);
   %yExtent = mRound(50 * %verticalScale);
   %yPos = mRound(800 * %verticalScale);
   %this-->ZoomBlock.resize(%xPos, %yPos, %xExtent, %yExtent);
   %cbCenter = %yPos + mRound(%yExtent / 2);
   
   // The plus/minus buttons are 15x15 and centered in the control block
   %xExtent = mRound(15 * %verticalScale);
   %xPos = %pedestalCenter - mRound(%xExtent / 2);
   %yPos = %cbCenter - %xExtent;
   %this-->ZoomInBtn.resize(%xPos, %yPos, %xExtent, %xExtent);
   %this-->ZoomOutBtn.resize(%xPos, %cbCenter, %xExtent, %xExtent);

   // The rotate buttons are 32x32 with a 13 pixel gap on either side of +/- 
   %btnExtent = mRound(32 * %verticalScale);
   %yPos = %cbCenter - mRound(%btnExtent / 2);
   %gapSize = mRound(13 * %verticalScale);
   %this-->RotateLFBtn.resize(%xPos - %gapSize - %btnExtent, %yPos, %btnExtent, %btnExtent);
   %this-->RotateRtBtn.resize(%xPos + %xExtent + %gapSize, %yPos, %btnExtent, %btnExtent);
}

function AvSelectionGui::showMigrantFields(%this, %showVal)
{
   %this-->MigrantScroll.setVisible(%showVal);
   %this-->MigrantTitle.setVisible(%showVal);
   %this-->MigrantText.setVisible(%showVal);
   %this-->SubscribeButton.setVisible(%showVal);
}

function AvSelectionGui::migrantLayout(%this, %scaleFactor, %centerLine, %lastBottom)
{  // Size and position all fields for migrants
   // The scroll is 300x436 and cenetered 30 pixels below the last plank
   %xExtent = mRound(300 * %scaleFactor);
   %yExtent = mRound(436 * %scaleFactor);
   %xPos = mRound(%centerLine - (%xExtent / 2));
   %yPos = %lastBottom + mRound(30 * %scaleFactor);
   %scrollTop = %yPos;
   %this-->MigrantScroll.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The text areas on the scroll are 270 pixels wide
   %xExtent = mRound(270 * %scaleFactor);
   %xPos = mRound(%centerLine - (%xExtent / 2));

   // The title is 28 pixels tall and 69 pixels below the scroll top
   %yExtent = mRound(28 * %scaleFactor);
   %yPos = %scrollTop + mRound(69 * %scaleFactor);
   %this-->MigrantTitle.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The text is 150 pixels tall and 124 pixels below the scroll top
   %yExtent = mRound(150 * %scaleFactor);
   %yPos = %scrollTop + mRound(124 * %scaleFactor);
   %this-->MigrantText.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The subscribe (click here) button  is 339 pixels below the scroll top
   // and 28 pixels tall
   %yExtent = mRound(28 * %scaleFactor);
   %yPos = %scrollTop + mRound(339 * %scaleFactor);
   %this-->SubscribeButton.resize(%xPos, %yPos, %xExtent, %yExtent);
}

function AvSelectionGui::showCitizenFields(%this, %showVal)
{
   %this-->Plank1ChainLeft.setVisible(%showVal);
   %this-->Plank1ChainRight.setVisible(%showVal);
   %this-->Plank2ChainLeft.setVisible(%showVal);
   %this-->Plank2ChainRight.setVisible(%showVal);
   %this-->Plank3ChainLeft.setVisible(%showVal);
   %this-->Plank3ChainRight.setVisible(%showVal);

   %this-->TintPlank.setVisible(%showVal);
   %this-->TatooButton.setVisible(%showVal);
   %this-->AccessoryButton.setVisible(%showVal);
}

function AvSelectionGui::citizenLayout(%this, %scaleFactor, %centerLine, %lastBottom)
{  // Size and position all fields for subscribers
   // PlayChains 13x25 and run from the bottom of the last plank
   // they are spaced 120 pixels apart horizontally
   %chainXExtent = mRound(13 * %scaleFactor);
   %chainYExtent = mRound(25 * %scaleFactor);
   %chain1XPos = mRound(%centerLine - (60 * %scaleFactor + %chainXExtent));
   %this-->Plank1ChainLeft.resize(%chain1XPos, %lastBottom, %chainXExtent, %chainYExtent);

   %chain2XPos = mRound(%centerLine + (60 * %scaleFactor));
   %this-->Plank1ChainRight.resize(%chain2XPos, %lastBottom, %chainXExtent, %chainYExtent);
   %lastBottom += %chainYExtent;

   // The Planks are 237x30 and centered under the logo hanging from the chains
   %xExtent = mRound(237 * %scaleFactor);
   %yExtent = mRound(30 * %scaleFactor);
   %xPos = mRound(%centerLine - (%xExtent / 2));

   %btnPadding = mRound(8 * %scaleFactor);
   %btn1X = %btnPadding;
   %btn2X = %xExtent - (%btnPadding + %yExtent);

   for ( %i = 0; %i < 4; %i++ )
   {
      %this.plank[%i].resize(%xPos, %lastBottom, %xExtent, %yExtent);
      %this.plank[%i]-->PlankText.resize(0, 0, %xExtent, %yExtent);
      %this.plank[%i]-->PlankBtnLf.resize(%btn1X, 0, %yExtent, %yExtent);
      %this.plank[%i]-->PlankBtnRt.resize(%btn2X, 0, %yExtent, %yExtent);
      %lastBottom += %yExtent + 1;
   }

   %this-->TintPlank.resize(%xPos, %lastBottom, %xExtent, %yExtent);
   %this.layoutTintBtns();
   %lastBottom += %yExtent + 1;

   for ( %i = 4; %i < 6; %i++ )
   {
      %this.plank[%i].resize(%xPos, %lastBottom, %xExtent, %yExtent);
      %this.plank[%i]-->PlankText.resize(0, 0, %xExtent, %yExtent);
      %this.plank[%i]-->PlankBtnLf.resize(%btn1X, 0, %yExtent, %yExtent);
      %this.plank[%i]-->PlankBtnRt.resize(%btn2X, 0, %yExtent, %yExtent);
      %lastBottom += %yExtent + 1;
   }

   %lastBottom--;
   %this-->Plank2ChainLeft.resize(%chain1XPos, %lastBottom, %chainXExtent, %chainYExtent);
   %this-->Plank2ChainRight.resize(%chain2XPos, %lastBottom, %chainXExtent, %chainYExtent);
   %lastBottom += %chainYExtent;

   for ( %i = 6; %i < 10; %i++ )
   {
      %this.plank[%i].resize(%xPos, %lastBottom, %xExtent, %yExtent);
      %this.plank[%i]-->PlankText.resize(0, 0, %xExtent, %yExtent);
      %this.plank[%i]-->PlankBtnLf.resize(%btn1X, 0, %yExtent, %yExtent);
      %this.plank[%i]-->PlankBtnRt.resize(%btn2X, 0, %yExtent, %yExtent);
      %lastBottom += %yExtent + 1;
   }

   %lastBottom--;
   %this-->Plank3ChainLeft.resize(%chain1XPos, %lastBottom, %chainXExtent, %chainYExtent);
   %this-->Plank3ChainRight.resize(%chain2XPos, %lastBottom, %chainXExtent, %chainYExtent);
   %lastBottom += %chainYExtent;

   // The overlay popup should be positioned to appear directly above the tattoo button
   %popupExt = OverlaysDlg.getExtent();
   %popupXExt = getWord(%popupExt, 0);
   %popupYExt = getWord(%popupExt, 1);
   %popupXPos = %centerLine - mRound(%popupXExt / 2);
   %popupYPos = %lastBottom - %popupYExt;
   OverlaysDlg.resize(%popupXPos, %popupYPos, %popupXExt, %popupYExt);
   
   %this-->TatooButton.resize(%xPos, %lastBottom, %xExtent, %yExtent);
   %lastBottom += %yExtent + 1;

   // The accessory popup should be positioned to appear directly above the accessory button
   %popupExt = MiscOptionDlg.getExtent();
   %popupXExt = getWord(%popupExt, 0);
   %popupYExt = getWord(%popupExt, 1);
   %popupXPos = %centerLine - mRound(%popupXExt / 2);
   %popupYPos = %lastBottom - %popupYExt;
   MiscOptionDlg.resize(%popupXPos, %popupYPos, %popupXExt, %popupYExt);
   
   %this-->AccessoryButton.resize(%xPos, %lastBottom, %xExtent, %yExtent);

   // Scar plank
   %lastBottom += %yExtent + 1;
   %this.plank[10].resize(%xPos, %lastBottom, %xExtent, %yExtent);
   %this.plank[10]-->PlankText.resize(0, 0, %xExtent, %yExtent);
   %this.plank[10]-->PlankBtnLf.resize(%btn1X, 0, %yExtent, %yExtent);
   %this.plank[10]-->PlankBtnRt.resize(%btn2X, 0, %yExtent, %yExtent);
}

function AvSelectionGui::removeTintBtns(%this)
{
   for (%i = 0; %i < %this-->TintPlank.numButtons; %i++)
   {
      %this-->TintPlank.remove(%this-->TintPlank.tintBtn[%i]);
      %this-->TintPlank.tintBtn[%i].delete();
   }
   %this-->TintPlank.numButtons = 0;
}

function AvSelectionGui::layoutTintBtns(%this)
{  // space the tint buttons evenly across the plank
   %extent = %this-->TintPlank.getExtent();
   %numButtons = %this-->TintPlank.numButtons;
   %xExtent = getWord(%extent, 0);
   %yExtent = getWord(%extent, 1);
   %btnExtent = mRound(%yExtent * 0.6);
   %yPos = mRound((%yExtent - %btnExtent) / 2);
   %btnPadding = mFloor((%xExtent - (%numButtons * %btnExtent)) / (%numButtons + 1));
   %xPos = %btnPadding;
   
   for ( %i = 0; %i < %numButtons; %i++ )
   {
      %this-->TintPlank.tintBtn[%i].resize(%xPos, %yPos, %btnExtent, %btnExtent);
      %xPos += %btnPadding + %btnExtent;
   }
}

function AvSelectionGui::makeTintBtns(%this)
{
   %this.removeTintBtns();
   %this-->TintPlank.numButtons = 0;
   
   // Always add a "none" button
   %buttonNum = 0;
   %this-->TintPlank.tintBtn[%buttonNum] = %this.addTintButton(%buttonNum, "", 0);
   %buttonNum++;
   
   // Add all tints
   %numTints = AvatarTints.count();
   for (%i = 0; %i < %numTints; %i++)
   {
      %key = AvatarTints.getKey(%i);
      %value = AvatarTints.getValue(%i);
      %gender = GetCommaWord(%value, 3);
      %category = GetCommaWord(%value, 1);
      %fileName = GetCommaWord(%value, 5);
      if ( (%gender != 2) && (%gender != %this.curGender)  )
         continue;   // This option is not for this model

      if ( %category $= "Tint" )
      {
         if ( "/" $= getSubStr(%fileName, 0, 1) )
            %fileName = "art/players/base/tints" @ %fileName;
         %this-->TintPlank.tintBtn[%buttonNum] = %this.addTintButton(%buttonNum, %fileName, %key);
         %buttonNum++;
      }
   }
   %this-->TintPlank.numButtons = %buttonNum;
}

function AvSelectionGui::addTintButton(%this, %tintNum, %pngFile, %tintID)
{
   //%newButton = new GuiBitmapButtonCtrl() {
   %newButton = new GuiBitmapButtonBorderCtrl() {
      canSaveDynamicFields = "0";
      Enabled = "1";
      isContainer = "1";
      Profile = "BCTintButtonProfile";
      horizSizing = "right";
      vertSizing = "bottom";
      position = "0 0";
      Extent = "30 30";
      MinExtent = "8 2";
      canSave = "0";
      Visible = "1";
      command = "AvSelectionGui.onTintBtn(" @ %tintID @ ");";
      tooltipProfile = "GuiToolTipProfile";
      hovertime = "1000";
      tooltip = "";
      bitmap = %pngFile;
      groupNum = "-1";
      buttonType = "PushButton";
      useMouseEvents = "0";
   };

   %this-->TintPlank.addGuiControl(%newButton);
   return %newButton;
}

function AvSelectionGui::makePlanks(%this)
{  // Make all of the citizen selection planks
   %this.plank[0] = %this.addPlank(0, "Face Shape", "Face", "4", false, "avOptions");
   %this.plank[1] = %this.addPlank(1, "Hair", "HairStyle", "5", true, "avOptions");
   %this.plank[2] = %this.addPlank(2, "Eye Color", "EyeColor", "6", false, "avOptions");
   %this.plank[3] = %this.addPlank(3, "Base Skin", "SkinTone", "7", false, "avOptions");
   
   %plankText = (%this.curGender == 0) ? "Facial Hair" : "Makeup";
   %category = (%this.curGender == 0) ? "FacialHair" : "Makeup";
   %table = (%this.curGender == 0) ? "avTints" : "avOptions";
   %this.plank[4] = %this.addPlank(4, %plankText, %category, "9", true, %table);
   %this.plank[5] = %this.addPlank(5, "War Paint", "WarPaint", "", true, "avTints");

   %this.plank[6] = %this.addPlank(6, "Wrist Guards", "ForeArm", "2", true, "avOptions");
   %this.plank[7] = %this.addPlank(7, "Arm Bands", "Arm", "3", true, "avOptions");
   %this.plank[8] = %this.addPlank(8, "Shin Guards", "Shin", "4", true, "avOptions");
   %this.plank[9] = %this.addPlank(9, "Leg Bands", "Thigh", "5", true, "avOptions");
   %this.plank[10] = %this.addPlank(10, "Scar", "Scar", "4", true, "avTints");
   
   %this.hasPlanks = true;
   %this.numPlanks = 11;
   
   // Make all tint buttons
   %this.makeTintBtns();
}

function AvSelectionGui::addPlank(%this, %plnkID, %plnkText, %category, %pngNum,
                                  %canBeNone, %table)
{  // Make and return a citizen selection plank
   %newPlank = new GuiBitmapCtrl() {
      bitmap = "art/gui/avCustomizer/Plank" @ %pngNum;
      wrap = "0";
      position = "591 25";
      extent = "270 30";
      minExtent = "8 8";
      horizSizing = "right";
      vertSizing = "bottom";
      profile = "GuiDefaultProfile";
      visible = "1";
      active = "1";
      tooltipProfile = "GuiToolTipProfile";
      hovertime = "1000";
      isContainer = "0";
      InternalName = "PlankBackground";
      canSave = "0";
      canSaveDynamicFields = "0";

      new GuiTextCtrl() {
         text = %plnkText;
         maxLength = "1024";
         margin = "0 0 0 0";
         padding = "0 0 0 0";
         anchorTop = "1";
         anchorBottom = "0";
         anchorLeft = "1";
         anchorRight = "0";
         position = "0 0";
         extent = "270 30";
         minExtent = "8 8";
         horizSizing = "right";
         vertSizing = "bottom";
         profile = "AVPlankTextProfile";
         visible = "1";
         active = "1";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         isContainer = "1";
         internalName = "PlankText";
         canSave = "1";
         canSaveDynamicFields = "0";
      };
      new GuiBitmapButtonCtrl() {
         canSaveDynamicFields = "0";
         Enabled = "1";
         isContainer = "0";
         Profile = "AVInputSoundProfile";
         horizSizing = "right";
         vertSizing = "bottom";
         position = "0 0";
         Extent = "30 30";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         command = "AvSelectionGui.onSelectBtn(" @ %plnkID @ ", -1);";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         tooltip = "";
         bitmap = "art/gui/avCustomizer/ButtonLeft";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
         internalName = "PlankBtnLf";
      };
      new GuiBitmapButtonCtrl() {
         canSaveDynamicFields = "0";
         Enabled = "1";
         isContainer = "0";
         Profile = "AVInputSoundProfile";
         horizSizing = "right";
         vertSizing = "bottom";
         position = "0 0";
         Extent = "30 30";
         MinExtent = "8 2";
         canSave = "1";
         Visible = "1";
         command = "AvSelectionGui.onSelectBtn(" @ %plnkID @ ", 1);";
         tooltipProfile = "GuiToolTipProfile";
         hovertime = "1000";
         tooltip = "";
         bitmap = "art/gui/avCustomizer/ButtonRight";
         groupNum = "-1";
         buttonType = "PushButton";
         useMouseEvents = "0";
         internalName = "PlankBtnRt";
      };
   };
   
   %newPlank.category = %category;
   %newPlank.numOptions = 0;
   %newPlank.optList = "";
   %newPlank.curOption = "";
   %newPlank.canBeNone = %canBeNone;
   %newPlank.table = %table;

   %this.addGuiControl(%newPlank);
   return %newPlank;
}

function AvSelectionGui::resizeFonts(%this, %scaleFactor)
{  // Torque adjusts font sizes, to get the true point size we need to increase
   // the requested point size x1.6 for Trajan
   %trajanMult = 1.6;

   // The Plank and gui title fonts are 12 point
   %fontPoint = mRound(13 * %scaleFactor);
   AVPlankTextProfile.fontSize = mRound(%fontPoint * %trajanMult);
   AVPlankButtonProfile.fontSize = mRound(%fontPoint * %trajanMult);

   // The Migrant title and button fonts are 14 point
   %fontPoint = mRound(14 * %scaleFactor);
   AVScrollTitleProfile.fontSize = mRound(%fontPoint * %trajanMult);
   AVScrollButtonProfile.fontSize = mRound(%fontPoint * %trajanMult);

   // The Migrant text font is 10 point
   %fontPoint = mRound(10 * %scaleFactor);
   AVScrollTextProfile.fontSize = mRound(%fontPoint * %trajanMult);

   // The Homeworld title font is 22 point
   %fontPoint = mRound(22 * %scaleFactor);
   AVHomeworldTitleProfile.fontSize = mRound(%fontPoint * %trajanMult);

   // The info text font is 9 point
   %fontPoint = mRound(9 * %scaleFactor);
   AVInfoTextProfile.fontSize = mRound(%fontPoint * %trajanMult);

   // The play button font is 14 point
   %fontPoint = mRound(14 * %scaleFactor);
   AVPlayButtonProfile.fontSize = mRound(%fontPoint * %trajanMult);

   // The AEG LLC font is 10 point
   %fontPoint = mRound(10 * %scaleFactor);
   AVAEGLLCProfile.fontSize = mRound(%fontPoint * %trajanMult);
}

function AvSelectionGui::onSelectBtn(%this, %plankNum, %direction)
{
   %this.plank[%plankNum].curOption += %direction;
   if ( %this.plank[%plankNum].curOption >= %this.plank[%plankNum].numOptions )
      %this.plank[%plankNum].curOption = 0;
   if ( %this.plank[%plankNum].curOption < 0 )
      %this.plank[%plankNum].curOption = %this.plank[%plankNum].numOptions - 1;

   %this.plank[%plankNum].curValue = getCommaWord(%this.plank[%plankNum].optList, %this.plank[%plankNum].curOption);

   if ( (%plankNum == 3) && (%this.curGender == 1) )
   {  // Female face change so reinit the makup plank
      %this.initMakeup();
   }

   %this.makeCurrentOutfit();
   // Remove any created materials
   %this.RemoveMaterials();

   // Apply new outfit
   %this.OutfitPlayer();
   %this.UpdateMaterials();
   %this.updateButtons();
}

function AvSelectionGui::onOverlayChange(%this)
{
   %this.makeCurrentOutfit();
   // Remove any created materials
   %this.RemoveMaterials();

   // Apply new outfit
   %this.OutfitPlayer();
   %this.UpdateMaterials();
   %this.updateButtons();
}

function AvSelectionGui::onMiscOptionChange(%this)
{
   %this.makeCurrentOutfit();
   // Remove any created materials
   %this.RemoveMaterials();

   // Apply new outfit
   %this.OutfitPlayer();
   %this.UpdateMaterials();
   %this.updateButtons();
}

function AvSelectionGui::onTintBtn(%this, %tintID)
{
   %this-->TintPlank.tintID = %tintID;

   %this.makeCurrentOutfit();
   // Remove any created materials
   %this.RemoveMaterials();

   // Apply new outfit
   %this.OutfitPlayer();
   %this.UpdateMaterials();
   %this.updateButtons();
}

function AvSelectionGui::onArrowBtn(%this, %plankNum, %direction)
{
   if ( %plankNum == 0 )
   {  // TODO: Check to save changes before switching.
      if ( %this.hasChanges() )
         %this.confirmGenderChange();
      else
      {
         %this.curGender = ( %this.curGender == 0 ) ? 1 : 0;
         %this.genderChange();
      }
   }
   else if ( %plankNum == 1 )
   {
      %this.homeworldIndex += %direction;
      if ( %this.homeworldIndex < 0 )
         %this.homeworldIndex = %this.homeworldData.count() - 1;
      else if ( %this.homeworldIndex >= %this.homeworldData.count() )
         %this.homeworldIndex = 0;
      %this.homeworldChanged(true);
   }
   else if ( %plankNum == 3 )
   {
      %this.outfit += %direction;
      %this.checkOutfit();

      // Put the new outfit on the model
      %this.makeCurrentOutfit();
      // Remove any created materials
      %this.RemoveMaterials();

      // Apply new outfit
      %this.OutfitPlayer();
      %this.UpdateMaterials();
   }

   %this.updateButtons();
}

function AvSelectionGui::onSubscribePressed(%this)
{
   gotoWebPage("http://www.alterverse.com/navbarnew.asp");
}

function AvSelectionGui::clanChanged(%this, %updateModel)
{
   if ( %this.clanIndex < 0 )
      %this.clanIndex = %this.clanData.count() - 1;
   else if ( %this.clanIndex >= %this.clanData.count() )
      %this.clanIndex = 0;
   %clanInfo = %this.clanData.getValue(%this.clanIndex);
   %name = %this-->ClanTitle.format @ %clanInfo.dispName;
   %desc = %this-->ClanText.format @ %clanInfo.description;
   %this.clanID = %clanInfo.id;
   %this-->ClanTitle.setText(%name);
   %this-->ClanText.setText(%desc);

   if ( !$ImAMigrant && $IsSubscriber )
   {
      %this.initOptionLists();
      %this.ShowOptionChoices();
   }

   if ( %updateModel )
   {
      %this.makeCurrentOutfit();
      // Remove any created materials
      %this.RemoveMaterials();

      // Apply new outfit
      %this.OutfitPlayer();
      %this.UpdateMaterials();
   }
}

function AvSelectionGui::homeworldChanged(%this, %updateModel)
{
   %worldInfo = %this.homeworldData.getValue(%this.homeworldIndex);
   %name = %this-->HomeworldTitle.format @ %worldInfo.dispName;
   %desc = %this-->HomeworldText.format @ %worldInfo.description;
   %this.homeworldID = %worldInfo.id;
   %this-->HomeworldTitle.setText(%name);
   %this-->HomeworldText.setText(%desc);
   %this.lastHomeworld = %this.homeworldIndex;

   if ( !$ImAMigrant && $IsSubscriber )
   {
      %this.initOptionLists();
      %this.ShowOptionChoices();
   }

   %this.checkOutfit();
   if ( %updateModel )
   {
      %this.makeCurrentOutfit();
      // Remove any created materials
      %this.RemoveMaterials();

      // Apply new outfit
      %this.OutfitPlayer();
      %this.UpdateMaterials();
   }
}

function AvSelectionGui::checkOutfit(%this)
{  // Make sure the outfit selection is available for this homeworld/gender
   %worldInfo = %this.homeworldData.getValue(%this.homeworldIndex);

   %maxOutfits = 0;
   if ( $ImAMigrant || !$IsSubscriber )
   {
      if ( %this.curGender == 0 )
         %maxOutfits = getBarWordCount(%worldInfo.MaleClothesOpts);
      else
         %maxOutfits = getBarWordCount(%worldInfo.FemaleClothesOpts);
   }
   else
   {
      if ( %this.curGender == 0 )
         %maxOutfits = getBarWordCount(%worldInfo.MaleClothesOpts) +
               getBarWordCount(%worldInfo.MaleCitOpts);
      else
         %maxOutfits = getBarWordCount(%worldInfo.FemaleClothesOpts) +
               getBarWordCount(%worldInfo.FemaleCitOpts);
   }

   if ( %this.outfit < 0 )
      %this.outfit = %maxOutfits - 1;
   if ( %this.outfit >= %maxOutfits )
      %this.outfit = 0;
}

function AvSelectionGui::makeCurrentOutfit(%this)
{
   %worldInfo = %this.homeworldData.getValue(%this.homeworldIndex);

   if ( $ImAMigrant || !$IsSubscriber )
   {  // Migrants just get the predefined outfit
      if ( %this.curGender == 0 )
      {
         %avStr = %worldInfo.MaleBaseAv;
         %tmpStr = GetBarWord(%worldInfo.MaleAvOpts, %this.outfit);
         if ( %tmpStr !$= "" )
            %avStr = %avStr @ "," @ %tmpStr;
         %avStr = %avStr @ "," @ %worldInfo.MaleClothes;
         %tmpStr = GetBarWord(%worldInfo.MaleClothesOpts, %this.outfit);
         if ( %tmpStr !$= "" )
            %avStr = %avStr @ "," @ %tmpStr;
      }
      else
      {
         %avStr = %worldInfo.FemaleBaseAv;
         %tmpStr = GetBarWord(%worldInfo.FemaleAvOpts, %this.outfit);
         if ( %tmpStr !$= "" )
            %avStr = %avStr @ "," @ %tmpStr;
         %avStr = %avStr @ "," @ %worldInfo.FemaleClothes;
         %tmpStr = GetBarWord(%worldInfo.FemaleClothesOpts, %this.outfit);
         if ( %tmpStr !$= "" )
            %avStr = %avStr @ "," @ %tmpStr;
      }
      $pref::Player::Avatar = %avStr;
      $pref::Player::AvOverlay = "";
   }
   else
   {  // Citizens get the full options selected
      %optStr = "";
      %ovrStr = "";

      // Add The base skin tint as first overlay
      if ( %this-->TintPlank.tintID > 0 )
         %ovrStr = %this-->TintPlank.tintID;
      
      for ( %i = 0; %i < %this.numPlanks; %i++ )
      {
         %curValue = %this.plank[%i].curValue;
         if ( %curValue > 0 )
         {
            if ( %this.plank[%i].table $= "avOptions" )
            {
               if ( %optStr !$= "" )
                  %optStr = %optStr @ ",";
               %optStr = %optStr @ %curValue;
            }
            else
            {
                if ( %ovrStr !$= "" )
                  %ovrStr = %ovrStr @ ",";
               %ovrStr = %ovrStr @ %curValue;
            }
         }
      }
      
      // Add any misc options to the string
      if ( AvMiscOptions.optionStr !$= "" )
         %optStr = %optStr @ "," @ AvMiscOptions.optionStr;

      // Add the base avatar setup minus the misc items
      if ( %this.curGender == 0 )
      {
         %avStr = %worldInfo.MaleClothes;
         if ( %this.outfit < GetBarWordCount(%worldInfo.MaleClothesOpts) )
            %tmpStr = GetBarWord(%worldInfo.MaleClothesOpts, %this.outfit);
         else
         {
            %outfitIdx = %this.outfit - GetBarWordCount(%worldInfo.MaleClothesOpts);
            %tmpStr = GetBarWord(%worldInfo.MaleCitOpts, %outfitIdx);
         }
         if ( (%tmpStr !$= "") && (%tmpStr !$= "0") )
            %avStr = %avStr @ "," @ %tmpStr;
      }
      else
      {
         %avStr = %worldInfo.FemaleClothes;
         if ( %this.outfit < GetBarWordCount(%worldInfo.FemaleClothesOpts) )
            %tmpStr = GetBarWord(%worldInfo.FemaleClothesOpts, %this.outfit);
         else
         {
            %outfitIdx = %this.outfit - GetBarWordCount(%worldInfo.FemaleClothesOpts);
            %tmpStr = GetBarWord(%worldInfo.FemaleCitOpts, %outfitIdx);
         }
         if ( (%tmpStr !$= "") && (%tmpStr !$= "0") )
            %avStr = %avStr @ "," @ %tmpStr;
      }
      %optStr = %optStr @ "," @ %this.filterMiscOpts(%avStr);

      // Add any tatoos/overlays
      if ( AvOverlays.overlayStr !$= "" )
      {
          if ( %ovrStr !$= "" )
            %ovrStr = %ovrStr @ ",";
         %ovrStr = %ovrStr @ AvOverlays.overlayStr;
      }

      $pref::Player::Avatar = %optStr;
      $pref::Player::AvOverlay = %ovrStr;
   }
   %this.curOpts = $pref::Player::Avatar;
   %this.curOverlays = $pref::Player::AvOverlay;
}

function AvSelectionGui::setAvModel(%this)
{
   if ( %this.curGender == 0 )
      %this.shapePath = "art/players/base/basemale/basemale1_4.dts";
   else
      %this.shapePath = "art/players/base/basefemale/basefemale1_4.dts";

   // Remove any created materials
   %this.RemoveMaterials();

   // Install the current Avatar   
   %this.UpdateAvatarDisplay();

   %this.OutfitPlayer();
   %this.UpdateMaterials();
}

function AvSelectionGui::genderChange(%this)
{
   if ( %this.curGender == 0 )
   {
      %this.curOpts = getBarWord(AvSelectionGui.savedMale, 0);
      %this.curOverlays = getBarWord(AvSelectionGui.savedMale, 1);
   }
   else
   {
      %this.curOpts = getBarWord(AvSelectionGui.savedFemale, 0);
      %this.curOverlays = getBarWord(AvSelectionGui.savedFemale, 1);
   }
   %this.outfit = %this.findCurrentOutfit();

   if ( !$ImAMigrant && $IsSubscriber )
   {
      %this.makeTintBtns();
      %this.layoutTintBtns();
      %plankText = (%this.curGender == 0) ? "Facial Hair" : "Makeup";
      %category = (%this.curGender == 0) ? "FacialHair" : "Makeup";
      %table = (%this.curGender == 0) ? "avTints" : "avOptions";
      %this.plank[4]->PlankText.setText(%plankText);
      %this.plank[4].category = %category;
      %this.plank[4].table = %table;
      
      %this.initOptionLists();
      %this.ShowOptionChoices();
   }
   %this.checkOutfit();
   %this.makeCurrentOutfit();
   %this.setAvModel();
}

function AvSelectionGui::ShowOptionChoices(%this)
{  // Select the current option set in all lists
   // make the base avatar for this homeworld
   %worldInfo = %this.homeworldData.getValue(%this.homeworldIndex);
   if ( %this.curGender == 0 )
   {
      %baseAv = %worldInfo.MaleBaseAv;
      %safeOutfit = ((GetBarWordCount(%worldInfo.MaleAvOpts) >= %this.outfit) ?
            0 : %this.outfit);
      %tmpStr = GetBarWord(%worldInfo.MaleAvOpts, %safeOutfit);
      if ( %tmpStr !$= "" )
         %baseAv = %baseAv @ "," @ %tmpStr;
      %baseOpts = %worldInfo.MaleClothes;
      %tmpStr = GetBarWord(%worldInfo.MaleClothesOpts, %safeOutfit);
      if ( %tmpStr !$= "" )
         %baseOpts = %baseOpts @ "," @ %tmpStr;
   }
   else
   {
      %baseAv = %worldInfo.FemaleBaseAv;
      %safeOutfit = ((GetBarWordCount(%worldInfo.FemaleAvOpts) >= %this.outfit) ?
            0 : %this.outfit);
      %tmpStr = GetBarWord(%worldInfo.FemaleAvOpts, %safeOutfit);
      if ( %tmpStr !$= "" )
         %baseAv = %baseAv @ "," @ %tmpStr;
      %baseOpts = %worldInfo.FemaleClothes;
      %tmpStr = GetBarWord(%worldInfo.FemaleClothesOpts, %safeOutfit);
      if ( %tmpStr !$= "" )
         %baseOpts = %baseOpts @ "," @ %tmpStr;
   }

   echo("\n Options: " @ %this.curOpts @ " -- Overlays: " @ %this.curOverlays);
   for ( %i = 0; %i < %this.numPlanks; %i++ )
   {
      // See if an option for this plank is selected in the current setup
      %optFound = false;
      if ( %this.plank[%i].table $= "avOptions" )
         %testStr = %this.curOpts;
      else
         %testStr = %this.curOverlays;

      if (( %this.curGender == 1 ) && (%i == 4))
         %this.initMakeup();  // Initialize makup options after skin tone has been selected

      echo("Plank #" @ %i @ ", " @ %this.plank[%i]->PlankText.text @ " optList:" @ %this.plank[%i].optList);
      for ( %j = 0; (%j < %this.plank[%i].numOptions) && !%optFound; %j++ )
      {
         %plankOpt = getCommaWord(%this.plank[%i].optList, %j);
         %numSaved = getCommaWordCount(%testStr);
         for ( %k = 0; %k < %numSaved; %k++ )
         {
            %savedOpt = getCommaWord(%testStr, %k);

            if ( %savedOpt $= %plankOpt )
            {
               %optFound = true;
               %this.plank[%i].curOption = %j;
               %this.plank[%i].curValue = %plankOpt;
               echo("Matched option: " @ %plankOpt);
               break;
            }
         }
      }

      if ( !%optFound && (%this.plank[%i].table $= "avOptions") )
      {  // The option was not found, see if there is one in the migrant setup
         for ( %k = 0; (%k < GetCommaWordCount(%baseAv)) && !%optFound; %k++ )
         {
            %baseOpt = GetCommaWord(%baseAv, %k);
            for ( %j = 0; %j < %this.plank[%i].numOptions; %j++ )
            {
               if ( %baseOpt $= getCommaWord(%this.plank[%i].optList, %j) )
               {
                  %optFound = true;
                  %this.plank[%i].curOption = %j;
                  %this.plank[%i].curValue = %baseOpt;
                  echo("Matched migrant option: " @ %baseOpt);
                  break;
               }
            }
         }
      }

      if ( !%optFound )
      {  // The option was still not found, select the first item in the list
         %this.plank[%i].curOption = 0;
         %this.plank[%i].curValue = getCommaWord(%this.plank[%i].optList, 0);
         echo("Gave default option: " @ %this.plank[%i].curValue);
      }
   }

   // Select any misc items
   %numOptions = GetCommaWordCount(%this.curOpts);
   for (%i = 0; %i < %numOptions; %i++ )
   {
      %curOption = GetCommaWord(%this.curOpts, %i);
      %index = AvatarOptions.getIndexFromKey(%curOption);
      %value = AvatarOptions.getValue(%index);

      %category = GetCommaWord(%value, 1);
      if ( %category $= "Misc" )
         AvMiscOptions.checkOption(%curOption);
   }
   AvMiscOptions.makeOptionStr();
   
   // Select the current tint any tatoos
   %this-->TintPlank.tintID = "0";
   %numOptions = GetCommaWordCount(%this.curOverlays);
   for (%i = 0; %i < %numOptions; %i++ )
   {
      %curOption = GetCommaWord(%this.curOverlays, %i);
      %index = AvatarTints.getIndexFromKey(%curOption);
      %value = AvatarTints.getValue(%index);

      %category = GetCommaWord(%value, 1);
      if ( %category $= "Tint" )
         %this-->TintPlank.tintID = %curOption;
      else if ( %category $= "Tatoo" )
         AvOverlays.checkOption(%curOption);
   }
   AvOverlays.makeOverlayStr();
}

function AvSelectionGui::initMakeup(%this)
{
   %femSkin = %this.plank[3].curValue;
   %skinIdx = AvatarOptions.getIndexFromKey(%femSkin);
   %value = AvatarOptions.getValue(%skinIdx);
   %dispName = getCommaWord(%value, 4);
   %rootName = strReplace(%dispName, "kin", "") @ "_M";
   %rootLen = strlen(%rootName);

   %this.plank[4].numOptions = 1;
   %this.plank[4].optList = "0";
   %this.plank[4].curOption = 0;
   %this.plank[4].curValue = "0";

   %numOptions = AvatarOptions.count();
   for (%optIdx = 0; %optIdx < %numOptions; %optIdx++)
   {
      %key = AvatarOptions.getKey(%optIdx);
      %value = AvatarOptions.getValue(%optIdx);

      %category = GetCommaWord(%value, 1);
      if ( %category !$= "Makeup" )
         continue;

      %gender = GetCommaWord(%value, 3);
      %worldSet = GetCommaWord(%value, 55);
      if ( (%gender != 2) && (%gender != %this.curGender) )
         continue;   // This option is not for this model

      if ( (%worldSet > 0) && (%worldSet != %this.HomeworldID) )
         continue;   // This option is not for this clan

      %dispName = getCommaWord(%value, 4);
      if ( %rootName !$= getSubStr(%dispName, 0, %rootLen) )
         continue;

      %this.plank[4].optList = %this.plank[4].optList @ "," @ %key;
      %this.plank[4].numOptions++;
   }
}

function AvSelectionGui::findCurrentOutfit(%this)
{  // Finds the currently selected outfit in the saved setup
   %worldInfo = %this.homeworldData.getValue(%this.homeworldIndex);
   if ( %this.curGender == 0 )
   {
      %baseOpts = %worldInfo.MaleClothesOpts;
      %citOpts = %worldInfo.MaleCitOpts;
   }
   else
   {
      %baseOpts = %worldInfo.FemaleClothesOpts;
      %citOpts = %worldInfo.FemaleCitOpts;
   }
   
   // Check to see if one of the base options is found
   %numOpts = getBarWordCount(%baseOpts);
   for ( %i = 0; %i < %numOpts; %i++ )
   {
      %testStr = getBarWord(%baseOpts, %i);
      if ( -1 != strstr(%this.curOpts, %testStr) )
         return %i;
      // A citizen must have all non-misc items in the option to be a match
      if ( !$ImAMigrant && $IsSubscriber )
      {
         %numWords = getCommaWordCount(%testStr);
         %goodMatch = true;
         for ( %j = 0; (%j < %numWords) && %goodMatch; %j++ )
         {
            %goodMatch = false;
            %testWord = getCommaWord(%testStr, %j);
            %optIdx = AvatarOptions.getIndexFromKey(%testWord);
            %value = AvatarOptions.getValue(%optIdx);
            %category = GetCommaWord(%value, 1);
            if ( %category $= "Misc" )
            {
               %goodMatch = true;
               continue;
            }

            %numVals = getCommaWordCount(%this.curOpts);
            for ( %k = 0; %k < %numVals; %k++ )
            {
               %testVal = getCommaWord(%this.curOpts, %k);
               if ( %testVal $= %testWord )
               {
                  %goodMatch = true;
                  break;
               }
            }
         }
         if ( %goodMatch )
            return %i;
      }
   }

   // Not in base options
   if ( $ImAMigrant || !$IsSubscriber )
      return 0;

   // Check to see if one of the citizen options is found
   %numCitOpts = getBarWordCount(%citOpts);
   for ( %i = 0; %i < %numCitOpts; %i++ )
   {
      %testStr = getBarWord(%citOpts, %i);
      if ( (%testStr $= 0) || (-1 != strstr(%this.curOpts, %testStr)) )
         return (%numOpts + %i);
   }
   
   // No matching outfit found
   return 0;
}

function AvSelectionGui::initOptionLists(%this)
{  // Put all available options into the list boxes
   // First clear all option lists
   for ( %i = 0; %i < %this.numPlanks; %i++ )
   {
      %this.plank[%i].numOptions = (%this.plank[%i].canBeNone ? 1 : 0);
      %this.plank[%i].optList = (%this.plank[%i].canBeNone ? "0" : "");
      %this.plank[%i].curOption = 0;
      %this.plank[%i].curValue = (%this.plank[%i].canBeNone ? "0" : "");
   }
   AvMiscOptions.clearAllOptions();
   AvOverlays.clearAllOptions();

   // Loop through options and add to the appropriate plank
   %numOptions = AvatarOptions.count();
   for (%optIdx = 0; %optIdx < %numOptions; %optIdx++)
   {
      %key = AvatarOptions.getKey(%optIdx);
      %value = AvatarOptions.getValue(%optIdx);
      %gender = GetCommaWord(%value, 3);
      %worldSet = GetCommaWord(%value, 55);
      if ( (%gender != 2) && (%gender != %this.curGender) )
         continue;   // This option is not for this model

      if ( (%worldSet > 0) && (%worldSet != %this.HomeworldID) )
         continue;   // This option is not for this clan

      %category = GetCommaWord(%value, 1);
      if ( %category $= "Makeup" )
         continue;   // Makeup is further filtered by face and has it's own function

      %dispName = GetCommaWord(%value, 4);
      if ( %category $= "Misc" )
      {  // Add to the misc window
         AvMiscOptions.addOption(%key, %dispName);
      }
      else
      {  // Add to the correct plank
         for ( %i = 0; %i < %this.numPlanks; %i++ )
         {
            if ( %this.plank[%i].category $= %category )
            {
               if ( %this.plank[%i].optList !$= "" )
                  %this.plank[%i].optList = %this.plank[%i].optList @ ",";
               %this.plank[%i].optList = %this.plank[%i].optList @ %key;
               %this.plank[%i].numOptions++;
               break;
            }
         }
      }
   }

   // Add all tints
   %numTints = AvatarTints.count();
   for (%tintIdx = 0; %tintIdx < %numTints; %tintIdx++)
   {
      %key = AvatarTints.getKey(%tintIdx);
      %value = AvatarTints.getValue(%tintIdx);
      %gender = GetCommaWord(%value, 3);
      %category = GetCommaWord(%value, 1);
      %worldSet = GetCommaWord(%value, 7);
      if ( (%gender != 2) && (%gender != %this.curGender)  )
         continue;   // This option is not for this model

      if ( (%worldSet > 0) && (%worldSet != %this.HomeworldID) )
         continue;   // This option is not for this clan

      %dispName = GetCommaWord(%value, 4);
      
      if ( %category $= "Tint" )
         continue;   // Skin tints are handled in their own function
      else if ( %category $= "Tatoo" )
         AvOverlays.addOption(%key, %dispName);
      else
      {  // See if we have a plank for this category
         for ( %i = 0; %i < %this.numPlanks; %i++ )
         {
            if ( %this.plank[%i].category $= %category )
            {
               if ( %this.plank[%i].optList !$= "" )
                  %this.plank[%i].optList = %this.plank[%i].optList @ ",";
               %this.plank[%i].optList = %this.plank[%i].optList @ %key;
               %this.plank[%i].numOptions++;
               break;
            }
         }
      }
   }
   
   if ( %this.curGender == 1 )
      %this.initMakeup();
}

function AvSelectionGui::filterMiscOpts(%this, %newOpts)
{  // Return the passed option string with all "misc" options removed
   %outStr = "";
   %numNew = getCommaWordCount(%newOpts);
   for ( %newIdx = 0; %newIdx < %numNew; %newIdx++ )
   {
      %curOpt = getCommaWord(%newOpts, %newIdx);
      %optIdx = AvatarOptions.getIndexFromKey(%curOpt);
      %value = AvatarOptions.getValue(%optIdx);
      %category = GetCommaWord(%value, 1);
      if ( %category !$= "Misc" )
      {
         if ( %outStr !$= "" )
            %outStr = %outStr @ ",";
         %outStr = %outStr @ %curOpt;
      }
   }
   return %outStr;
}

function AvSelectionGui::filterBaseList(%this, %baseOpts, %newOpts)
{  // Return an option string containing all items in new that are not also in base
   %outStr = "";
   %numNew = getCommaWordCount(%newOpts);
   %numBase = getCommaWordCount(%baseOpts);
   for ( %newIdx = 0; %newIdx < %numNew; %newIdx++ )
   {
      %curOpt = getCommaWord(%newOpts, %newIdx);
      %optFound = false;

      for ( %baseIdx = 0; %baseIdx < %numBase; %baseIdx++ )
      {
         %baseOpt = getCommaWord(%baseOpts, %baseIdx);
         if ( %curOpt $= %baseOpt )
         {
            %optFound = true;
            break;
         }
      }

      if ( !%optFound )
      {
         if ( %outStr !$= "" )
            %outStr = %outStr @ ",";
         %outStr = %outStr @ %curOpt;
      }
   }
   return %outStr;
}

function AvSelectionGui::initViewCtrl(%this)
{
   // Turn on lights
   AvSelModelView.setLightOn(0, true);
   AvSelModelView.setLightColor(0, "1 1 1 1");
   AvSelModelView.setLightBrightness(0, 1);
   AvSelModelView.setLightDir(0, "0 -0.707 -0.707");
}

function AvSelectionGui::UpdateAvatarDisplay(%this)
{
   // Cancel any pending animation change
   if ( isEventPending(%this.animSchedule) )
      cancel(%this.animSchedule);

   // Adjust the max distance so player appears to stand on pedastal
   if ( %this.curGender == 1 )
      AvSelModelView.maxOrbitDistance = 3.25;// Female 5.43
   else
      AvSelModelView.maxOrbitDistance = 3.40;//Male 5.62

   // Put the shape into the view control
   AvSelModelView.setModel(%this.shapePath);
   AvSelModelView.setModelRot("0 0 3.14");//-.05 0 3.14
   AvSelModelView.setCameraRot("0 0 0");

   AvSelModelView.zoom(50);//20  // Zoom out some when switching models.
   AvSelModelView.SetThread(0, "Root", 0, 1);

   
   // If we have animations, shedule one.
   if ( %this.numAltAnims > 0 )
      %this.setAnimSchedule();
}

function AvSelectionGui::OutfitPlayer(%this)
{
   //if ( %this.curGender == 1 )   // No options for female mesh yet
      //return;

   AvSelModelView.ShowModelSkin();  // Turn off all but the base (B_) meshes
   
   // Add any selected options
   %numOptions = GetCommaWordCount($pref::Player::Avatar);
   for (%i = 0; %i < %numOptions; %i++ )
   {
      %curOption = GetCommaWord($pref::Player::Avatar, %i);
      %index = AvatarOptions.getIndexFromKey(%curOption);
      %value = AvatarOptions.getValue(%index);

      // Meshes to show      
      %meshList = GetCommaWord(%value, 5);
      %count = getBarWordCount(%meshList);
      for ( %j = 0; %j < %count; %j++ )
      {
         %meshName = getBarWord(%meshList, %j);
         AvSelModelView.hideMesh(%meshName, false);
      }

      // Meshes to hide
      %meshList = GetCommaWord(%value, 6);
      %count = getBarWordCount(%meshList);
      for ( %j = 0; %j < %count; %j++ )
      {
         %meshName = getBarWord(%meshList, %j);
         AvSelModelView.hideMesh(%meshName, true);
      }

      // Apply Skins to base model
      %skinChange = false;
      for ( %j = 0; %j < 6; %j++ )
      {
         %doReskin = GetCommaWord(%value, 7 + (%j * 3));
         %skin = GetCommaWord(%value, 8 + (%j * 3));
         %texFile = GetCommaWord(%value, 9 + (%j * 3));
         if ( %doReskin )
         {
            %matIdx = %this.GetMatIndex(%skin, -1);
            if ( "/" $= getSubStr(%texFile, 0, 1) )
               %texFile = "art/players/base" @ %texFile;
            %this.matTex0_[%matIdx] = %texFile;
            //AvSelModelView.SetModelSkin(%skin, %matName);
            %skinChange = true;
         }
      }

      // Mount any needed shapes
      for ( %j = 0; %j < 5; %j++ )
      {
         %mount = GetCommaWord(%value, 24 + (%j * 6));
         %node = GetCommaWord(%value, 25 + (%j * 6));
         %shape = GetCommaWord(%value, 26 + (%j * 6));
         %doReskin = GetCommaWord(%value, 27 + (%j * 6));
         %skin = GetCommaWord(%value, 28 + (%j * 6));
         %texFile = GetCommaWord(%value, 29 + (%j * 6));
         if ( %mount )
         {
            %curNode = AvSelModelView.mountEquipment(%shape, %node);
            if ( %doReskin )
            {
               %matIdx = %this.GetMatIndex(%skin, %curNode);
               if ( "/" $= getSubStr(%texFile, 0, 1) )
                  %texFile = "art/players/base" @ %texFile;
               %this.matTex0_[%matIdx] = %texFile;
               //AvSelModelView.SetEquipmentSkin(%skin, %matName, %curNode);
               %skinChange = true;
            }
         }
      }
   }

   AvSelModelView.UpdateMeshStates();
}

function AvSelectionGui::onTatooBtn(%this)
{  // Show/hide the tatoos window
   if (AvOverlays.isAwake())
      Canvas.popDialog(AvOverlays);
   else
      Canvas.pushDialog(AvOverlays);
}

function AvSelectionGui::onAccessoryBtn(%this)
{  // Show/hide the misc options window
   if (AvMiscOptions.isAwake())
      Canvas.popDialog(AvMiscOptions);
   else
      Canvas.pushDialog(AvMiscOptions);
}

function AvSelectionGui::GetMatIndex(%this, %skinTag, %mountNode)
{  // Return a material index for this skin tag, find existing or create new
   // See if we already have a material for this skin
   for ( %idx = 0; %idx < %this.numMaterials; %idx++ )
   {
      if ( (%this.matSkin[%idx] $= %skinTag) && (%this.mountNode[%idx] == %mountNode) )
      {
         return %idx;
      }
   }

   %matIdx = %this.numMaterials;
   %this.numMaterials++;
   %this.matSkin[%matIdx] = %skinTag;
   %this.mountNode[%matIdx] = %mountNode;
   return %matIdx;
}

function AvSelectionGui::UpdateMaterials(%this)
{  // Create materials with stacked overlays.
   // Process Overlays
   %numOptions = GetCommaWordCount($pref::Player::AvOverlay);
   for (%i = 0; %i < %numOptions; %i++ )
   {
      %curOption = GetCommaWord($pref::Player::AvOverlay, %i);
      %index = AvatarTints.getIndexFromKey(%curOption);
      %value = AvatarTints.getValue(%index);

      %texFile = GetCommaWord(%value, 5);
      if ( "/" $= getSubStr(%texFile, 0, 1) )
         %texFile = "art/players/base/tints" @ %texFile;

      %skinList = GetCommaWord(%value, 6);
      %numSkins = GetBarWordCount(%skinList);
      for ( %j = 0; %j < %numSkins; %j++ )
      {
         %curSkin = GetBarWord(%skinList, %j);
         %matIdx = %this.GetMatIndex(%curSkin, -1);

         if ( %this.matTex1_[%matIdx] $= "" )
            %this.matTex1_[%matIdx] = %texFile;
         else if ( %this.matTex2_[%matIdx] $= "" )
            %this.matTex2_[%matIdx] = %texFile;
         else if ( %this.matTex3_[%matIdx] $= "" )
            %this.matTex3_[%matIdx] = %texFile;
      }
   }

   // Create Materials
   for ( %i = 0; %i < %this.numMaterials; %i++ )
   {
      // Find the material currently assigned
      %numMats = AvSelModelView.getNumMaterials(%this.mountNode[%i]);
      for ( %j = 0; %j < %numMats; %j++ )
      {
         %texName = AvSelModelView.getTextureName(%j, %this.mountNode[%i]);
         %matName = AvSelModelView.getMaterialName(%j, %this.mountNode[%i]);
         if ( %texName $= %this.matSkin[%i] )
            break;
      }
      
      if ( %j < %numMats )
      {  // skin was found
         %this.oldMat[%i] = %matName;
         %this.newMatName[%i] = "AvSelMat_" @ %i;
         %this.newMat[%i] = %this.cloneMaterial(%i, %this.newMatName[%i], %matName);
         if ( %this.mountNode[%i] == -1 )
            AvSelModelView.SetModelSkin(%texName, %this.newMatName[%i]);
         else
            AvSelModelView.SetEquipmentSkin(%texName, %this.newMatName[%i], %this.mountNode[%i]);
      }
      else
         echo("No material for: " @ %this.matSkin[%i]);
   }
}

function AvSelectionGui::RemoveMaterials(%this)
{
   for ( %i = 0; %i < %this.numMaterials; %i++ )
   {
      AvSelModelView.SetModelSkin(%this.matSkin[%i], %this.oldMat[%i]);
   }

   for ( %i = 0; %i < %this.numMaterials; %i++ )
   {
      if (!isObject(%this.newMat[%i]))
         echo("No material created");
      else
         %this.newMat[%i].Delete();
      %this.matSkin[%i] = "";
      %this.oldMat[%i] = "";
      %this.newMat[%i] = "";
      %this.newMatName[%i] = "";
      %this.mountNode[%i] = "";
      %this.matTex0_[%i] = "";
      %this.matTex1_[%i] = "";
      %this.matTex2_[%i] = "";
      %this.matTex3_[%i] = "";
   }
   %this.numMaterials = 0;
}

function AvSelectionGui::cloneMaterial(%this, %matIdx, %newName, %oldMat )
{
   %diffuseMap = %this.matTex0_[%matIdx];
   if ( %diffuseMap $= "" )
      %diffuseMap = %oldMat.diffuseMap[0];

   %newMat = new Material(%newName) 
   {
      diffuseMap[0] = %diffuseMap;
      diffuseMap[1] = %this.matTex1_[%matIdx];
      diffuseMap[2] = %this.matTex2_[%matIdx];
      diffuseMap[3] = %this.matTex3_[%matIdx];
      mapTo = "unmapped_mat";

      diffuseColor[0] = %oldMat.diffuseColor[0];
      diffuseColor[1] = %oldMat.diffuseColor[1];
      diffuseColor[2] = %oldMat.diffuseColor[2];
      diffuseColor[3] = %oldMat.diffuseColor[3];

      overlayMap[0] = %oldMat.overlayMap[0];
      overlayMap[1] = %oldMat.overlayMap[1];
      overlayMap[2] = %oldMat.overlayMap[2];
      overlayMap[3] = %oldMat.overlayMap[3];

      lightMap[0] = %oldMat.lightMap[0];
      lightMap[1] = %oldMat.lightMap[1];
      lightMap[2] = %oldMat.lightMap[2];
      lightMap[3] = %oldMat.lightMap[3];

      toneMap[0] = %oldMat.toneMap[0];
      toneMap[1] = %oldMat.toneMap[1];
      toneMap[2] = %oldMat.toneMap[2];
      toneMap[3] = %oldMat.toneMap[3];

      detailMap[0] = %oldMat.detailMap[0];
      detailMap[1] = %oldMat.detailMap[1];
      detailMap[2] = %oldMat.detailMap[2];
      detailMap[3] = %oldMat.detailMap[3];

      detailScale[0] = %oldMat.detailScale[0];
      detailScale[1] = %oldMat.detailScale[1];
      detailScale[2] = %oldMat.detailScale[2];
      detailScale[3] = %oldMat.detailScale[3];

      normalMap[0] = %oldMat.normalMap[0];
      normalMap[1] = %oldMat.normalMap[1];
      normalMap[2] = %oldMat.normalMap[2];
      normalMap[3] = %oldMat.normalMap[3];

      detailNormalMap[0] = %oldMat.detailNormalMap[0];
      detailNormalMap[1] = %oldMat.detailNormalMap[1];
      detailNormalMap[2] = %oldMat.detailNormalMap[2];
      detailNormalMap[3] = %oldMat.detailNormalMap[3];

      detailNormalMapStrength[0] = %oldMat.detailNormalMapStrength[0];
      detailNormalMapStrength[1] = %oldMat.detailNormalMapStrength[1];
      detailNormalMapStrength[2] = %oldMat.detailNormalMapStrength[2];
      detailNormalMapStrength[3] = %oldMat.detailNormalMapStrength[3];

      specular[0] = %oldMat.specular[0];
      specular[1] = %oldMat.specular[1];
      specular[2] = %oldMat.specular[2];
      specular[3] = %oldMat.specular[3];

      specularPower[0] = %oldMat.specularPower[0];
      specularPower[1] = %oldMat.specularPower[1];
      specularPower[2] = %oldMat.specularPower[2];
      specularPower[3] = %oldMat.specularPower[3];

      pixelSpecular[0] = %oldMat.pixelSpecular[0];
      pixelSpecular[1] = %oldMat.pixelSpecular[1];
      pixelSpecular[2] = %oldMat.pixelSpecular[2];
      pixelSpecular[3] = %oldMat.pixelSpecular[3];

      specularMap[0] = %oldMat.specularMap[0];
      specularMap[1] = %oldMat.specularMap[1];
      specularMap[2] = %oldMat.specularMap[2];
      specularMap[3] = %oldMat.specularMap[3];

      parallaxScale[0] = %oldMat.parallaxScale[0];
      parallaxScale[1] = %oldMat.parallaxScale[1];
      parallaxScale[2] = %oldMat.parallaxScale[2];
      parallaxScale[3] = %oldMat.parallaxScale[3];

      useAnisotropic[0] = %oldMat.useAnisotropic[0];
      useAnisotropic[1] = %oldMat.useAnisotropic[1];
      useAnisotropic[2] = %oldMat.useAnisotropic[2];
      useAnisotropic[3] = %oldMat.useAnisotropic[3];

      envMap[0] = %oldMat.envMap[0];
      envMap[1] = %oldMat.envMap[1];
      envMap[2] = %oldMat.envMap[2];
      envMap[3] = %oldMat.envMap[3];

      vertLit[0] = %oldMat.vertLit[0];
      vertLit[1] = %oldMat.vertLit[1];
      vertLit[2] = %oldMat.vertLit[2];
      vertLit[3] = %oldMat.vertLit[3];

      vertColor[0] = %oldMat.vertColor[0];
      vertColor[1] = %oldMat.vertColor[1];
      vertColor[2] = %oldMat.vertColor[2];
      vertColor[3] = %oldMat.vertColor[3];

      minnaertConstant[0] = %oldMat.minnaertConstant[0];
      minnaertConstant[1] = %oldMat.minnaertConstant[1];
      minnaertConstant[2] = %oldMat.minnaertConstant[2];
      minnaertConstant[3] = %oldMat.minnaertConstant[3];

      subSurface[0] = %oldMat.subSurface[0];
      subSurface[1] = %oldMat.subSurface[1];
      subSurface[2] = %oldMat.subSurface[2];
      subSurface[3] = %oldMat.subSurface[3];

      subSurfaceColor[0] = %oldMat.subSurfaceColor[0];
      subSurfaceColor[1] = %oldMat.subSurfaceColor[1];
      subSurfaceColor[2] = %oldMat.subSurfaceColor[2];
      subSurfaceColor[3] = %oldMat.subSurfaceColor[3];

      subSurfaceRolloff[0] = %oldMat.subSurfaceRolloff[0];
      subSurfaceRolloff[1] = %oldMat.subSurfaceRolloff[1];
      subSurfaceRolloff[2] = %oldMat.subSurfaceRolloff[2];
      subSurfaceRolloff[3] = %oldMat.subSurfaceRolloff[3];

      glow[0] = %oldMat.glow[0];
      glow[1] = %oldMat.glow[1];
      glow[2] = %oldMat.glow[2];
      glow[3] = %oldMat.glow[3];

      emissive[0] = %oldMat.emissive[0];
      emissive[1] = %oldMat.emissive[1];
      emissive[2] = %oldMat.emissive[2];
      emissive[3] = %oldMat.emissive[3];

      doubleSided = %oldMat.doubleSided;

      animFlags[0] = %oldMat.animFlags[0];
      animFlags[1] = %oldMat.animFlags[1];
      animFlags[2] = %oldMat.animFlags[2];
      animFlags[3] = %oldMat.animFlags[3];

      scrollDir[0] = %oldMat.scrollDir[0];
      scrollDir[1] = %oldMat.scrollDir[1];
      scrollDir[2] = %oldMat.scrollDir[2];
      scrollDir[3] = %oldMat.scrollDir[3];

      scrollSpeed[0] = %oldMat.scrollSpeed[0];
      scrollSpeed[1] = %oldMat.scrollSpeed[1];
      scrollSpeed[2] = %oldMat.scrollSpeed[2];
      scrollSpeed[3] = %oldMat.scrollSpeed[3];

      rotSpeed[0] = %oldMat.rotSpeed[0];
      rotSpeed[1] = %oldMat.rotSpeed[1];
      rotSpeed[2] = %oldMat.rotSpeed[2];
      rotSpeed[3] = %oldMat.rotSpeed[3];

      rotPivotOffset[0] = %oldMat.rotPivotOffset[0];
      rotPivotOffset[1] = %oldMat.rotPivotOffset[1];
      rotPivotOffset[2] = %oldMat.rotPivotOffset[2];
      rotPivotOffset[3] = %oldMat.rotPivotOffset[3];

      waveType[0] = %oldMat.waveType[0];
      waveType[1] = %oldMat.waveType[1];
      waveType[2] = %oldMat.waveType[2];
      waveType[3] = %oldMat.waveType[3];

      waveFreq[0] = %oldMat.waveFreq[0];
      waveFreq[1] = %oldMat.waveFreq[1];
      waveFreq[2] = %oldMat.waveFreq[2];
      waveFreq[3] = %oldMat.waveFreq[3];

      waveAmp[0] = %oldMat.waveAmp[0];
      waveAmp[1] = %oldMat.waveAmp[1];
      waveAmp[2] = %oldMat.waveAmp[2];
      waveAmp[3] = %oldMat.waveAmp[3];

      sequenceFramePerSec[0] = %oldMat.sequenceFramePerSec[0];
      sequenceFramePerSec[1] = %oldMat.sequenceFramePerSec[1];
      sequenceFramePerSec[2] = %oldMat.sequenceFramePerSec[2];
      sequenceFramePerSec[3] = %oldMat.sequenceFramePerSec[3];

      sequenceSegmentSize[0] = %oldMat.sequenceSegmentSize[0];
      sequenceSegmentSize[1] = %oldMat.sequenceSegmentSize[1];
      sequenceSegmentSize[2] = %oldMat.sequenceSegmentSize[2];
      sequenceSegmentSize[3] = %oldMat.sequenceSegmentSize[3];

      cellIndex[0] = %oldMat.cellIndex[0];
      cellIndex[1] = %oldMat.cellIndex[1];
      cellIndex[2] = %oldMat.cellIndex[2];
      cellIndex[3] = %oldMat.cellIndex[3];

      cellLayout[0] = %oldMat.cellLayout[0];
      cellLayout[1] = %oldMat.cellLayout[1];
      cellLayout[2] = %oldMat.cellLayout[2];
      cellLayout[3] = %oldMat.cellLayout[3];

      cellSize[0] = %oldMat.cellSize[0];
      cellSize[1] = %oldMat.cellSize[1];
      cellSize[2] = %oldMat.cellSize[2];
      cellSize[3] = %oldMat.cellSize[3];

      bumpAtlas[0] = %oldMat.bumpAtlas[0];
      bumpAtlas[1] = %oldMat.bumpAtlas[1];
      bumpAtlas[2] = %oldMat.bumpAtlas[2];
      bumpAtlas[3] = %oldMat.bumpAtlas[3];

      castShadows = %oldMat.castShadows;
      planarReflection = %oldMat.planarReflection;
      translucent = %oldMat.translucent;
      translucentBlendOp = %oldMat.translucentBlendOp;
      translucentZWrite = %oldMat.translucentZWrite;
      alphaTest = %oldMat.alphaTest;
      alphaRef = %oldMat.alphaRef;
      dynamicCubemap = %oldMat.dynamicCubemap;
      showFootprints = %oldMat.showFootprints;
      showDust = %oldMat.showDust;
      effectColor[0] = %oldMat.effectColor[0];
      effectColor[1] = %oldMat.effectColor[1];
      footstepSoundId = %oldMat.footstepSoundId;
      customFootstepSound = %oldMat.customFootstepSound;
      impactSoundId = %oldMat.impactSoundId;
      customImpactSound = %oldMat.customImpactSound;
   };
   
   if ( !isObject(%newMat) )
      return 0;
   return %newMat;
}

function AvSelectionGui::playSelectorMusic(%this)
{
   %this.bgMusic = new SFXProfile()
   {
      filename    = "art/sound/avConvert.ogg";
      description = AudioMusicLoop2D;
   };
   %this.bdMusicId = sfxPlay(%this.bgMusic);
}

function AvSelectionGui::stopSelectorMusic(%this)
{
   if ( isObject(%this.bgMusic) )
   {
      sfxStop(%this.bdMusicId);
      %this.bgMusic.delete();
      %this.bgMusic = 0;
   }
}

function AvSelectionGui::playBaseAnim(%this)
{
   AvSelModelView.SetThread(0, "Root", 0, 1);
   %this.setAnimSchedule();
}

function AvSelectionGui::playAltAnim(%this)
{
   %num = getRandom(0, %this.numAltAnims - 1);
   %this.animSchedule = -1;
   AvSelModelView.SetThread(0, %this.altAnim[%num], 0, 0.5, true);
}

function AvSelectionGui::setAnimSchedule(%this)
{
   if ( (%this.maxAnimTime < %this.minAnimTime) || (%this.minAnimTime < 2) )
      return;
   %this.animSchedule = %this.schedule(getRandom(%this.minAnimTime, %this.maxAnimTime), "playAltAnim");
}

function AvSelectionGui::startMove(%this, %rotateVal, %zoomVal)
{
   if ( isEventPending(%this.moveTimer) )
      cancel(%this.moveTimer);   // Prevent getting multiple loops running

   if ( %rotateVal != 0 )
      %this-->AvatarView.rotateModel(%rotateVal);
   if ( %zoomVal != 0 )
      %this-->AvatarView.zoom(%zoomVal);

   %this.moveTimer = %this.schedule(50, "startMove", %rotateVal, %zoomVal);
}

function AvSelModelView::onAnimationDone(%this)
{  // Callback when a one-shot animation has finished.
   AvSelectionGui.playBaseAnim();
}

function AvSelZoomIn::onMouseDown(%this)
{
   AvSelectionGui.startMove(0, -3);
}

function AvSelZoomOut::onMouseDown(%this)
{
   AvSelectionGui.startMove(0, 3);
}

function AvSelRotateCCW::onMouseDown(%this)
{
   AvSelectionGui.startMove(3, 0);
}

function AvSelRotateCW::onMouseDown(%this)
{
   AvSelectionGui.startMove(-3, 0);
}

function GuiBitmapButtonCtrl::onMouseUp(%this)
{
   if ( isEventPending(AvSelectionGui.moveTimer) )
      cancel(AvSelectionGui.moveTimer);
}

function AvSelectionGui::deleteDataArrays(%this)
{  // Clear out the homeworld data array
   if ( isObject(AvSelectionGui.homeworldData) )
   {
      for (%i = 0; %i < AvSelectionGui.homeworldData.numWorlds; %i++)
      {
         %so = %this.homeworldData.getValue(%i);
         %so.delete();
      }
      AvSelectionGui.homeworldData.delete();
      AvSelectionGui.homeworldData = 0;
   }
}

function AvSelectionGui::updateButtons(%this)
{
   %this-->PlayButton.setActive(true);
   %this-->HomesteadButton.setActive(true);
   %this-->SaveButton.setActive(%this.hasChanges());
}

function AvSelectionGui::hasChanges(%this)
{
   if ( %this.curGender != (($pref::Player::Gender $= "MALE") ? 0 : 1) )
      return true;   // Gender changed

   if ( %this.homeworldID !$= $pref::Player::WorldID )
      return true;   // Homeworld changed

   %compStr = ((%this.curGender == 0) ? AvSelectionGui.savedMale : AvSelectionGui.savedFemale);
   %currentStr = %this.curOpts;
   if ( %this.curOverlays !$= "" )
      %currentStr = %currentStr @ "|" @ %this.curOverlays;

   if ( %compStr !$= %currentStr )
      return true;   // Setup changed

   return false;
}

function AvSelectionGui::BeginMission(%this)
{
   // Initialize Mumble
   if ( $pref::Mumble::useVoice )
      LaunchMumble($currentUsername);
   $Mumble::Running = true;
   $Mumble::InLobby = true;
   $Mumble::Context = "Lobby";
   $Mumble::ModeVal = 0;
   $Mumble::ModeStr = "Player+Camera";

   if ( ($TAP::serverID $= "") && $TAP::isDev && isFile("art/gui/devGuis/serverSel.gui") )
   {  // If it's a developer, bring up the server selection gui.
      if ( !isObject(ServerSelGui) )
      {
         exec("art/gui/devGuis/devProfiles.cs");
         exec("art/gui/devGuis/serverSel.gui");
         exec("art/gui/devGuis/serverSelGui.cs");

         if ( $pref::HostMultiPlayer $= "" )
            $pref::HostMultiPlayer = "1";
         exec("art/gui/devGuis/chooseLevel.gui");
         exec("art/gui/devGuis/chooseLevelGui.cs");
      }
      canvas.pushDialog(ServerSelGui);
      Canvas.popDialog(%this);
   }
   else
   {  // For all others load the level selected by the login script.
      loadLoadingGui();
      connectToServer($serverToJoin, "", false, false);
   }
}

function AvSelectionGui::onPlayBtn(%this)
{
   if ( %this.hasChanges() )
   {
      %message = "Save current avatar setup for use in game?";

      %message = %this.addHomeworldMsg(%message);

      ShowAVMessageBox("Avatar Setup Changed", %message, 0,
         "Save", "AvSelectionGui.SaveChanges(2);",
         "Discard", "AvSelectionGui.DiscardChanges(2);",
         "Cancel", "AvSelectionGui.DiscardChanges(0);");
   }
   else
      %this.BeginMission();
}

function AvSelectionGui::onHomesteadBtn(%this)
{
   return;
}

function AvSelectionGui::onSaveBtn(%this)
{
   //echo("Gender: " @ %this.curGender @ ", HWID: " @ %this.homeworldID @ ", Outfit: " @ %this.outfit @ ", Setup: " @ %this.curOpts);
   if ( (%this.homeworldID !$= $pref::Player::WorldID) && ($pref::Player::ClanID > 0) )
   {
      %message = %this.addHomeworldMsg(%message);
      ShowAVMessageBox("Homeworld Changed", %message, 0,
         "Save", "AvSelectionGui.SaveChanges(0);",
         "Cancel", "AvSelectionGui.DiscardChanges(0);");
   }
   else
      AvSelectionGui.SaveChanges(0);
}

function AvSelectionGui::confirmGenderChange(%this)
{
   if (%this.curGender == 0)
      %message = "Save changes to the male avatar before switching to the female avatar?";
   else
      %message = "Save changes to the female avatar before switching to the male avatar?";

   %message = %this.addHomeworldMsg(%message);

   ShowAVMessageBox("Avatar Setup Changed", %message, 0,
      "Save", "AvSelectionGui.SaveChanges(1);",
      "Discard", "AvSelectionGui.DiscardChanges(1);",
      "Cancel", "AvSelectionGui.DiscardChanges(0);");
}


function AvSelectionGui::addHomeworldMsg(%this, %message)
{  // Make the homeworld change message
   if ( %this.homeworldID $= $pref::Player::WorldID )
      return %message;

   if ( $pref::Player::ClanLeader )
   {
      %hMsg = "<color:dd1111>Warning:<color:ffffff> You are the leader of the " @ $pref::Player::ClanName @ " clan. If you change Homeworld, your clan will be disbanded!";
   }
   else if ( $pref::Player::ClanID > 0 )
   {
      %hMsg = "Changeing your Homeworld will automatically remove you from the " @ $pref::Player::ClanName @ " clan.";
   }

   if ( %message $= "" )
      %message = %hMsg;
   else
      %message = %message @ "\n\n" @ %hMsg;

   return %message;
}

function AvSelectionGui::SaveChanges(%this, %changeVal)
{
   %genderChanged = false;
   %hmidChanged = false;
   %setupChanged = false;

   // hash our password combined with the supplied hash
   %pwdHash = getStringMD5( $currentHash @ $currentPasswordHash );

   %args = "uid=" @ $currentPlayerID @"\t"@ "uhash=" @ %pwdHash;

   if ( %this.curGender != (($pref::Player::Gender $= "MALE") ? 0 : 1) )
   {
      %args = %args @ "\t" @ "usex=" @ ((%this.curGender == 0) ? "Male" : "Female");
      %genderChanged = true;
   }

   if ( %this.homeworldID !$= $pref::Player::WorldID )
   {
      %args = %args @ "\t" @ "hwid=" @ %this.homeworldID;
      %hmidChanged = true;
   }

   %compStr = ((%this.curGender == 0) ? AvSelectionGui.savedMale : AvSelectionGui.savedFemale);
   %currentStr = %this.curOpts;
   if ( %this.curOverlays !$= "" )
   {
      %currentStr = %currentStr @ "|" @ %this.curOverlays;
      %setupChanged = true;
   }

   if ( %compStr !$= %currentStr )
      %args = %args @ "\t" @ ((%this.curGender == 0) ? "mav=" : "fav=") @ %currentStr;

   %this-->PlayButton.setActive(false);
   %this-->HomesteadButton.setActive(false);
   %this-->SaveButton.setActive(false);
   %this-->GenderBtnLf.setActive(false);
   %this-->GenderBtnRt.setActive(false);

   new HttpObject(httpAvatarChange){
      status = "failure";
      changeVal = %changeVal;
      genderChanged = %genderChanged;
      hmidChanged = %hmidChanged;
      setupChanged = %setupChanged;
      message = "";
   };

   httpAvatarChange.get( $serverPath, $scriptPath @ "avatarChange.php", %args );  
}

function AvSelectionGui::DiscardChanges(%this, %changeVal)
{
   %this.homeworldID = $pref::Player::WorldID;
   %this.homeworldIndex = %this.homeworldData.getIndexFromKey(%this.homeworldID);

   if ( %changeVal == 0 )
   {
      if ( %this.curGender == 0 )
      {
         %this.curOpts = getBarWord(AvSelectionGui.savedMale, 0);
         %this.curOverlays = getBarWord(AvSelectionGui.savedMale, 1);
      }
      else
      {
         %this.curOpts = getBarWord(AvSelectionGui.savedFemale, 0);
         %this.curOverlays = getBarWord(AvSelectionGui.savedFemale, 1);
      }
      %this.outfit = %this.findCurrentOutfit();
      %this.homeworldChanged(true);
   }
   else if ( %changeVal == 1 )
   {
      %worldInfo = %this.homeworldData.getValue(%this.homeworldIndex);
      %name = %this-->HomeworldTitle.format @ %worldInfo.dispName;
      %desc = %this-->HomeworldText.format @ %worldInfo.description;
      %this.homeworldID = %worldInfo.id;
      %this-->HomeworldTitle.setText(%name);
      %this-->HomeworldText.setText(%desc);
      %this.lastHomeworld = %this.homeworldIndex;

      %this.curGender = ( %this.curGender == 0 ) ? 1 : 0;
      %this.genderChange();
   }
   else if ( %changeVal == 2 )
      %this.BeginMission();
}

function AvSelectionGui::getHomeworldData(%this)
{
   if( isObject(%this.clanData) )
      %this.deleteDataArrays();
   %this.optionsSet = false;
   
   %request = new HTTPObject() {
      class = "getHomeworldInfo";
      status = "failure";
      message = "";
   };
   
   %request.get( $serverPath, $scriptPath @ "getHomeworldInfo.php", "uid=" @ $currentPlayerID );
}

function httpAvatarChange::process( %this )
{

   switch$( %this.status )
   {
   case "success":
      $currentPasswordHash = %this.hash;

      if ( %this.hmidChanged )
      {
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
      }

      $pref::Player::WorldID = %this.world_id;
      $pref::Player::Gender = %this.gender;
      AvSelectionGui.savedMale = %this.maleAv;
      AvSelectionGui.savedFemale = %this.femaleAv;

      // Now that the new values have been set, the call to discard, just installs them
      AvSelectionGui.DiscardChanges(%this.changeVal);

   default:
      echo(%this.message);
      MessageBoxOK( "Failed to contact web server", "Could not update avatar setup:" SPC %this.message);
      AvSelectionGui.DiscardChanges(0);
   }
   %this.schedule(0, delete);

   AvSelectionGui.updateButtons();
   AvSelectionGui-->GenderBtnLf.setActive(true);
   AvSelectionGui-->GenderBtnRt.setActive(true);
}

function getHomeworldInfo::process( %this )
{
   // Create the arrays to store the data
   AvSelectionGui.homeworldData = new ArrayObject();

   switch$( %this.status )
   {
   case "success":
      // Fill in all fields for homeworlds
      for (%i = 0; %i < %this.NumWorlds; %i++)
      {
         %so = new ScriptObject()
         {
            id = %this.WorldID[%i];
            dispName = %this.WorldName[%i];
            description = %this.WorldDescription[%i];
            MaleBaseAv = %this.MaleBaseAv[%i];
            FemaleBaseAv = %this.FemaleBaseAv[%i];
            MaleAvOpts = %this.MaleAvOpts[%i];
            FemaleAvOpts = %this.FemaleAvOpts[%i];
            MaleClothes = %this.MaleClothes[%i];
            FemaleClothes = %this.FemaleClothes[%i];
            MaleClothesOpts = %this.MaleClothesOpts[%i];
            FemaleClothesOpts = %this.FemaleClothesOpts[%i];
            MaleCitOpts = %this.MaleCitOpts[%i];
            FemaleCitOpts = %this.FemaleCitOpts[%i];
         };

         AvSelectionGui.homeworldData.add(%so.id, %so);
      }
      AvSelectionGui.homeworldData.numWorlds = %this.NumWorlds;

      // Add the users saved avatar setups
      AvSelectionGui.savedMale = %this.SavedMale;
      AvSelectionGui.savedFemale = %this.SavedFemale;

      AvSelectionGui.initOptions();

   default:
      echo(%this.message);
      MessageBoxOK( "Failed to contact web server", "Could not load clan data. Avatar options will not be available" SPC %this.message);
      AvSelectionGui.setActive(true);
   }
   %this.schedule(0, delete);

   InventoryRequest();
}
