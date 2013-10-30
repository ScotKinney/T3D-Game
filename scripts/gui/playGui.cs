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
// PlayGui is the main TSControl through which the game is viewed.
// The PlayGui also contains the hud controls.
//-----------------------------------------------------------------------------

function PlayGui::onWake(%this)
{
   // Turn off any shell sounds...
   // sfxStop( ... );

   $enableDirectInput = "1";
   activateDirectInput();

   // Message hud dialog
   if ( isObject( MainChatHud ) )
   {
      $ChatAnchor = 0;//40;
      Canvas.pushDialog( MainChatHud );
      MainChatHud.schedule(1000, setChatHudLength, $Pref::ChatHudLength );
   }     

   // just update the action map here
   unbindChatCommands();
   moveMap.push();

   // Resize any dynamic gui elements
   %screenExtent = Canvas.getExtent();
   %this.onResize( getWord(%screenExtent, 0), getWord(%screenExtent, 1));

   PutTLOnTop();  // Bring the TL gui back onto the canvas
   $TAP::WebResponder = %this-->WebResponder;
}

function PlayGui::onSleep(%this)
{
   if ( isObject( MainChatHud ) )
      Canvas.popDialog( MainChatHud );
   
   $ChatAnchor = 0;
   
   // pop the keymaps
   moveMap.pop();
   bindChatCommands();
}

function PlayGui::clearHud( %this )
{
   Canvas.popDialog( MainChatHud );

   while ( %this.getCount() > 0 )
      %this.getObject( 0 ).delete();
}

function PlayGui::onResize(%this, %newWidth, %newHeight)
{
   %this.ResizeCenterPrint(%newWidth);
}

function PlayGui::ResizeCenterPrint(%this, %newWidth)
{  // Reposition the center print frame and text to be 10 pixels below the
   // toolbar and 18 pixels from each side of the screen
   %ctrlWidth = %newWidth - 36;
   //%barHeight = getWord(BCToolbar.getExtent(), 1);
   %barHeight = 30;
   centerPrintDlg.resize(18, %barHeight + 4, %ctrlWidth, 23);
   CenterPrintText.resize(2, 2, %ctrlWidth - 4, 19);
}

//-----------------------------------------------------------------------------
// HUD mouse functions
//-----------------------------------------------------------------------------

function PlayGui::onMouseOver(%this, %obj)
{
   //if ( isEventPending(%this.hoverEvent) )
   //{
      //cancel(%this.hoverEvent);
   //}
   //%this.hideItemPopup();

   %this.callBack("onMouseOver", %obj);
}

function PlayGui::onMouseDown(%this, %obj)
{
   //if ( isEventPending(%this.hoverEvent) )
   //{
      //cancel(%this.hoverEvent);
   //}
   //%this.hideItemPopup();
   
   %this.callBack("onMouseDown", %obj);
}

function PlayGui::onMouseUp(%this, %obj)
{
   return;
}

// GameTSCtrl::callBack re-routes the callback to different functions
// depending on the object type that we are dealing with
function PlayGui::callBack(%this, %funcName, %obj)
{
   // don't do anything if the object is not valid
   if(!isObject(%obj))
      return;
      
   // get the class name of the object
   %objClass = %obj.getClassName();

   // BloodClans Script Modification (MAR) - AFX Spell Casting >>>
   if ( %objClass $= "AIPlayer" )
      %objClass = "Player";
   // BloodClans Script Modification (MAR) - AFX Spell Casting <<<
      
   // BloodClans Script Modification (MAR) - Fishing >>>
   if ( (strstr(%objClass, "Terrain") != -1) || (%objClass $= "TSStatic") )
      return;

   if ( (%objClass $= "WaterPlane") || (%objClass $= "WaterBlock")  || (%objClass $= "River"))
      %objClass = "Water";
   // BloodClans Script Modification (MAR) - Fishing <<<

   // construct the string that will be used for the object specific callback
   // e.g. %this.onMouseOverItem(%obj);
   %funcStr = "%this." @ %funcName @ %objClass @ "(" @ %obj @ ");";

   // call the function   
   //eval(%funcStr);
}
