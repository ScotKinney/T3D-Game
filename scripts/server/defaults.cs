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
exec( "core/scripts/server/defaults.cs" );

// some general gameplay defaults
$AlterVerse::PlayerHealthDecreaseTime = 600000; // players health will be automatically decreased per 60000ms (10 minutes)
$AlterVerse::PlayerHealthDecreaseAmount = 1;  // the players health will decrease by 1 units
$AlterVerse::LowHealthThreshold = 0.6;        // players health is low at 60% damage
$AlterVerse::DangerousLowHealthThreshold = 0.8;// players health is considered dangerously low at 80% damage
$AlterVerse::PickupRadius = 10;  // distance at which player can pickup items
$AlterVerse::RandomItemLossBias = 0.3; // adjustment for how many items the player loses on death(<1 loses less items, >1 loses more items)
$AlterVerse::deathArnPercent = 60; // max percentage of arns a player will lose on death

// Now add your own game specific server preferences as
// well as any overloaded core defaults here.
if ( isFile( "./prefs.cs" ) )
   exec( "./prefs.cs" );
