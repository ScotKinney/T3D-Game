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

// TODO: Mars. Remove size from all calls to CenterPrint() and adjust for no sound
$centerPrintActive = 0;

// time is specified in seconds
function clientCmdCenterPrint( %message, %time, %noSound, %arg0, %arg1, %arg2 )
{
   // if centerprint is already visible, reset text and time.
   if ($centerPrintActive) {   
      if (centerPrintDlg.removePrint !$= "")
         cancel(centerPrintDlg.removePrint);
   }
   else {
      CenterPrintDlg.visible = 1;
      $centerPrintActive = 1;
   }

   // Make our localized display message
   %dispMsg = guiStrings.cpMsg[%message];
   if ( %dispMsg $= "" )
      %dispMsg = %message;
   for (%i = 0; %i < 3; %i++)
   {
      if ( %arg[%i] $= "" )
         break;
      %dispMsg = strReplace(%dispMsg, "%" @ (%i+1), %arg[%i]);
   }

   CenterPrintText.setText( "<just:center>" @ %dispMsg );
   // Force the textbox to resize itself vertically.
   CenterPrintText.forceReflow();
   // Grab the new extent of the text box.
   %newExtent = CenterPrintText.getExtent();
   CenterPrintDlg.extent = firstWord(CenterPrintDlg.extent) @ " " @
         (getWord(%newExtent, 1) + 4);

   // Play the centerprint sound effect
   if ( !%noSound )
      sfxPlayOnce(CenterPrintSFX);

   if (%time > 0)
      centerPrintDlg.removePrint = schedule( ( %time * 1000 ), 0,
         "clientCmdClearCenterPrint" );
}

function CenterPrintText::onResize(%this, %width, %height)
{
   %this.position = "2 2";
}

//-------------------------------------------------------------------------------------------------------

function clientCmdClearCenterPrint()
{
   $centerPrintActive = 0;
   CenterPrintDlg.visible = 0;
   CenterPrintDlg.removePrint = "";
}
