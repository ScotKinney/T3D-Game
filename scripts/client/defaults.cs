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

// First we execute the core default preferences.
exec( "core/scripts/client/defaults.cs" );


// Now add your own game specific client preferences as
// well as any overloaded core defaults here.
$PhysXLogWarnings = false;

// Initial TAP-Link settings
$pref::TL::isShown = 1;    // Show the TL gui inside game
$pref::TL::isDocked = 1;   // Docked, not Full size
$pref::TL::dockedPos = "0 0";
$pref::TL::framePos = "0 0";

$pref::Mumble::useVoice = 1;

$AlterVerse::FishingDistance = 150;  // Maximum distance a player can cast a line

// Finally load the preferences saved from the last
// game execution if they exist.
if ( isFile( "./prefs.cs" ) )
   exec( "./prefs.cs" );
