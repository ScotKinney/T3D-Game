//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

//------------------------------------------------------------------------------
function LoadingGui::onAdd(%this)
{
   //%this.qLineCount = 0;
}

//------------------------------------------------------------------------------
function LoadingGui::onWake(%this)
{
   // Startup the loading music
   playIntroMusic($AlterVerse::serverPrefix);
   
   // Add the progress bar control
   %this-->ProgressFrame.addGuiControl(LoadingProgress);
   
   // Look for a custom loading screen background for this mission
   %backgroundFile = "art/gui/backgrounds/" @ $AlterVerse::serverPrefix @ "Background";
   if ( !isFile(%backgroundFile @ ".png") && !isFile(%backgroundFile @ ".jpg"))
      %backgroundFile = "art/gui/backgrounds/CavesOfWisdomBackGround";
   LoadingGui-->BackgroundBmp.setBitmap(%backgroundFile);

   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   // Pop/Push the chat dialog so it is on top if connected to chat server
   if ( MainChatHud.isAwake() )
      Canvas.popDialog(MainChatHud);
   if (isObject(clientChat) && clientChat.connected)
      Canvas.pushDialog(MainChatHud);

   PutTLOnTop();  // Bring the TL gui back onto the canvas
}

//------------------------------------------------------------------------------
function LoadingGui::onSleep(%this)
{
   stopIntroMusic();
   
   LoadingProgress.setValue( 0 );
   LoadingProgressTxt.setValue( "Establishing Communications" ); // TODO: Mars. Localize

   %this-->ProgressFrame.remove(LoadingProgress);
}

function LoadingGui::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents. Sizes and positions are taken from the
   // reference art and scaled to the current screen height (%newHeight)
   // The reference art is 1600x900.
   %verticalScale = %newHeight / 900;
   %horizontalScale = %newWidth / 1600;

   // Progress Frame
   // The progress frame is 558x44 and positioned at 540,302 on the background image
   %croppedWidth = %verticalScale > %horizontalScale;
   %cropX = 0;
   %cropY = 0;
   if ( %croppedWidth )
   {
      %cropX = mRound(((1600 * %verticalScale) - %newWidth) / 2);
      %useScale = %verticalScale;
   }
   else
   {
      %cropY = mRound(((900 * %horizontalScale) - %newHeight) / 2);
      %useScale = %horizontalScale;
   }
   
   // The progress text font is 20 point
   AVProgressTextProfile.fontSize = mRound(20 * %useScale);

   // The text box is 556x20 and positioned at 541, 696
   %xExtent = mRound(556 * %useScale);
   %yExtent = mRound(20 * %useScale);
   %xPos = mRound(541 * %useScale) - %cropX;
   %yPos = mRound(696 * %useScale) - %cropY;
   LoadingProgressTxt.resize(%xPos, %yPos, %xExtent, %yExtent);

   // The progress bar is 556x24 and positioned at 541, 716
   %yExtent = mRound(24 * %useScale);
   %yPos = mRound(716 * %useScale) - %cropY;
   %this-->ProgressFrame.resize(%xPos, %yPos, %xExtent, %yExtent);
   LoadingProgress.resize(0, 0, %xExtent, %yExtent);

   // Set the curtain scale and rotation for stereo view mode.
   %xScale = (%newWidth/%newHeight) * 0.7;
   %guiScale = %xScale @ " 0.7 0.7";
   setGuiCurtainScale(%guiScale);
   // No rotation on the loading screen, it would lag bad...
   %maxRot = "0 0 0";
   setGuiCurtainMaxRot(%maxRot);
}
