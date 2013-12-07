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

// Load up all scripts.  This function is called when
// a server is constructed.
exec("./camera.cs");
exec("./triggers.cs");
exec("./inventory.cs");
exec("./shapeBase.cs");
exec("./item.cs");
exec("./projectile.cs");
exec("./radiusDamage.cs");

// Load our supporting weapon script, it contains methods used by all weapons.
exec("./weapon.cs");
exec("./melee.cs");

// Load our default player script
exec("./player.cs");

// Load the AI scripts
exec("./UAISK/aiExecutes.cs");

if ( theLevelInfo.canBringHorses )
   exec("./horse.cs");

// Load our gametypes
exec("./gameCore.cs"); // This is the 'core' of the gametype functionality.

exec("./AlterVerse/authentication.cs"); // client authentication

// Load all of the inventory item datablocks
exec("./AlterVerse/worldItems.cs");

//if ( theLevelInfo.hasTreasury )
//{
   exec("./alterVerse/clanTreasury.cs");
   //exec("./alterVerse/raidHours.cs");
//}

// Load Lantern
exec("./alterVerse/Lantern.cs");

// Load Fishing scripts
exec("./alterVerse/fishBait.cs");
exec("./alterVerse/fishing.cs");

// Load spell manager scripts
exec("./SpellManager.cs");

// Load all spells in the spells folder.
exec("./Spells/Fireball.cs");
exec("./Spells/AOEFireball.cs");
exec("./Spells/Blink.cs");
exec("./Spells/Daze.cs");
exec("./Spells/flashheal.cs");
exec("./Spells/frostbarrage.cs");
exec("./Spells/manainfusion.cs");
exec("./Spells/rainoffire.cs");
exec("./Spells/Invisibility.cs");
