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

function refreshBottomTextCtrl()
{
   BottomPrintText.position = "0 0";
}

function refreshCenterTextCtrl()
{
   CenterPrintText.position = "0 0";
}
