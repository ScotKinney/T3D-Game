// Functions for Server Selection screen

function ServerSelGui::onWake(%this)
{
   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   // Pop/Push the chat dialog so it is on top if connected to chat server
   if ( MainChatHud.isAwake() )
      Canvas.popDialog(MainChatHud);

   if (isObject(clientChat) && clientChat.connected)
      Canvas.pushDialog(MainChatHud);
}

function ServerSelGui::onSleep(%this)
{
}

function ServerSelGui::onResize(%this, %newWidth, %newHeight)
{  // Reposition the gui contents.
   %verticalScale = %newHeight / 900;
   %horizontalScale = %newWidth / 1600;

   // resize the fonts used on this page
   %useScale = (%verticalScale > %horizontalScale) ? %verticalScale : %horizontalScale;
   %this.resizeFonts(%useScale);

   // Center the info box
   %boxExtent = %this->InfoFrame.getExtent();
   %boxXExtent = getWord(%boxExtent, 0);
   %boxYExtent = getWord(%boxExtent, 1);
   %xPos = (%newWidth - %boxXExtent) / 2;
   %yPos = (%newHeight - %boxYExtent) / 2;
   %this->InfoFrame.resize(%xPos, %yPos, %boxXExtent, %boxYExtent);

   // The Prefs button is 54x41 and positioned at the bottom left of the screen
   %xExtent = mRound(54 * %useScale);
   %yExtent = mRound(41 * %useScale);
   %xPos = 8;
   %yPos = %newHeight - (%yExtent + 8);
   %textYExtent = mRound(19 * %useScale);
   %textYPos = %yPos - %textYExtent;
   %this->PrefsText.resize(%xPos, %textYPos, %xExtent, %textYExtent);
   %this->PrefsBtn.resize(%xPos, %yPos, %xExtent, %yExtent);
   
   // The exit button is 54x41 and positioned at the bottom right
   %xPos = %newWidth - (%xExtent + 8);
   %this->ExitText.resize(%xPos, %textYPos, %xExtent, %textYExtent);
   %this->ExitBtn.resize(%xPos, %yPos, %xExtent, %yExtent);
}

function ServerSelGui::resizeFonts(%this, %scaleFactor)
{
   // Torque adjusts font sizes, to get the true point size we need to increase
   // the requested point size x1.6 for Trajan and x1.2 for Arial
   %trajanMult = 1.6;
   %arialMult = 1.2;
   
   // The text input font is 16 point
   %fontPoint = 14 * %scaleFactor;
   //AVDevLabelProfile.fontsize = mRound(%fontPoint * %trajanMult);

   // The button font is 12 point
   %fontPoint = 12 * %scaleFactor;
   AVDevHeaderProfile.fontSize = mRound(%fontPoint * %trajanMult);
}
