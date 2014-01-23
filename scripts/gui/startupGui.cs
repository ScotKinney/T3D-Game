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
// StartupGui is the splash screen that initially shows when the game is loaded
//-----------------------------------------------------------------------------

function loadStartup()
{
   // The index of the current splash screen
   $StartupIdx = 0;

   %screenExtent = Canvas.getExtent();
   StartupGui.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   // A list of the splash screens and logos
   // to cycle through. Note that they have to
   // be in consecutive numerical order
   StartupGui.bitmap0     = "art/gui/common/black";
   StartupGui.logo0       = "art/gui/alpha_splash";
   StartupGui.bitmap1     = "art/gui/common/black";
   StartupGui.logo1       = "art/gui/dogstarlogo";
   
   // Call the next() function to set our firt
   // splash screen
   StartupGui.next();
   
   // If tapped in, start the game login process
   if ( $TAP::isTappedIn )
      TapInStage1();

   reInitMaterials();
   reloadCurtainMaterials();
   // Play our startup sound
   //SFXPlayOnce(AudioGui, "art/sound/gui/startup");//SFXPlay(startsnd);
}

function StartupGui::onResize(%this, %newWidth, %newHeight)
{
   // Set the curtain scale and rotation for stereo view mode.
   %xScale = (%newWidth/%newHeight) * 0.7;
   %guiScale = %xScale @ " 0.7 0.7";
   setGuiCurtainScale(%guiScale);
   // No rotation on the loading screen, it would lag bad...
   %maxRot = "0 0 0";
   setGuiCurtainMaxRot(%maxRot);
}

function StartupGui::click(%this)
{
   StartupFadeGui.done = true;
   StartupFadeGui.onDone();
}

function StartupGui::next(%this)
{
   // Set us to a blank screen while we load the next one
   Canvas.setContent(BlankGui);

   // Set our bitmap and reset the done variable
   StartupFadeGui.setBitmap(getVariable(%this @ ".bitmap" @ $StartupIdx));
   StartupFadeGui.done = false;

   // If we have a logo then set it
   if (isObject(%this-->StartupLogo))
   {
      if (getVariable(%this @ ".logo" @ $StartupIdx) !$= "")
      {
         %this-->StartupLogo.setBitmap(getVariable(%this @ ".logo" @ $StartupIdx));

         if (getVariable(%this @ ".logoPos" @ $StartupIdx) !$= "")
         {
            %logoPosX = getWord(getVariable(%this @ ".logoPos" @ $StartupIdx), 0);
            %logoPosY = getWord(getVariable(%this @ ".logoPos" @ $StartupIdx), 1);

            %this-->StartupLogo.setPosition(%logoPosX, %logoPosY);
         }

         if (getVariable(%this @ ".logoExtent" @ $StartupIdx) !$= "")
            %this-->StartupLogo.setExtent(getVariable(%this @ ".logoExtent" @ $StartupIdx));

         %this-->StartupLogo.setVisible(true);
      }
      else
         %this-->StartupLogo.setVisible(false);
   }

   // If we have a secondary logo then set it
   if (isObject(%this-->StartupLogoSecondary))
   {
      if (getVariable(%this @ ".seclogo" @ $StartupIdx) !$= "")
      {
         %this-->StartupLogoSecondary.setBitmap(getVariable(%this @ ".seclogo" @ $StartupIdx));

         if (getVariable(%this @ ".seclogoPos" @ $StartupIdx) !$= "")
         {
            %logoPosX = getWord(getVariable(%this @ ".seclogoPos" @ $StartupIdx), 0);
            %logoPosY = getWord(getVariable(%this @ ".seclogoPos" @ $StartupIdx), 1);

            %this-->StartupLogoSecondary.setPosition(%logoPosX, %logoPosY);
         }

         if (getVariable(%this @ ".seclogoExtent" @ $StartupIdx) !$= "")
            %this-->StartupLogoSecondary.setExtent(getVariable(%this @ ".seclogoExtent" @ $StartupIdx));

         %this-->StartupLogoSecondary.setVisible(true);
      }
      else
         %this-->StartupLogoSecondary.setVisible(false);
   }

   // Increment our screen index for the next screen
   $StartupIdx++;

   // Set the Canvas to our newly updated GuiFadeinBitmapCtrl
   Canvas.setContent(%this);
}

function StartupFadeGui::onDone(%this)
{
   // If we have been tagged as done decide if we need
   // to end or cycle to the next one
   if (%this.done)
   {
      // See if we have a valid bitmap for the next screen
      if (getVariable("StartupGui.bitmap" @ $StartupIdx) $= "")
      {
         // Clear our data and load the main menu
         %this.done = true;
         
         // NOTE: Don't ever ever delete yourself during a callback from C++.
         //
         // Deleting the whole gui itself seems a bit excessive, what if we want 
         // to return to the startup gui at a later time?  Any bitmaps set on 
         // the controls should be unloaded automatically if the control is not 
         // awake, if this is not the case then that's what needs to be fixed.
         
         //%this.delete();
         //BlankGui.delete();
         //flushTextureCache();
         
         loadMainMenu();
      }
      else
      {
         // We do have a bitmap so cycle to it
         StartupGui.next();
      }
   }
}
