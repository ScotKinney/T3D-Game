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

//------------------------------------------------------------------------------
// Loading info is text displayed on the client side while the mission
// is being loaded.  This information is extracted from the mission file
// and sent to each the client as it joins.
//------------------------------------------------------------------------------

//------------------------------------------------------------------------------
// dumpLoadInfo
//
// Echo the mission information to the console
//------------------------------------------------------------------------------
function dumpLoadInfo()
{
	echo( "Level Name: " @ theLevelInfo.name );
   echo( "Level Description:" );
   
   for( %i = 0; theLevelInfo.desc[%i] !$= ""; %i++ )
      echo ("   " @ theLevelInfo.desc[%i]);
}

//------------------------------------------------------------------------------
// sendLoadInfoToClient
//
// Sends mission description to the client
//------------------------------------------------------------------------------
function sendLoadInfoToClient( %client )
{
   messageClient( %client, 'MsgLoadInfo', "", theLevelInfo.levelName );

   // Send Mission Description a line at a time
   for( %i = 0; theLevelInfo.desc[%i] !$= ""; %i++ )
     messageClient( %client, 'MsgLoadDescripition', "", theLevelInfo.desc[%i] );

   messageClient( %client, 'MsgLoadInfoDone' );
}
