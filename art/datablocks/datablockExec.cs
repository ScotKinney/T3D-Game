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

// Load up all datablocks.  This function is called when
// a server is constructed.

// Do the sounds first -- later scripts/datablocks may need them
exec("./audioProfiles.cs");

// Do the various effects next -- later scripts/datablocks may need them
exec("./particles.cs");
exec("./lights.cs");
exec("./triggers.cs");

exec("./defaultEffects.cs");
exec("./player.cs");

// Load the editor saved datablocks
exec("./managedDatablocks.cs");

// Our default (base) weapon datablocks
exec("./weapons/weaponFX.cs");
exec("./weapons/baseAuto.cs");
exec("./weapons/baseMelee.cs");
exec("./weapons/baseTriggered.cs");

// Load the player datablocks
exec("art/players/" @ $LoadedAvSet @ "/datablock.cs");

// Inventory weapon datablocks
exec("./weapons/meleeWeapons.cs");
exec("./weapons/thrownWeapons.cs");
exec("./weapons/firedWeapons.cs");

// Any datablocks contained in the loaded art packs
%packCount = getFieldCount($LoadedArtPacks);
for (%i = 0; %i < %packCount; %i++)
{
   %dbFile = "art/Packs/" @ getField($LoadedArtPacks, %i) @ "/datablock.cs";
   if ( isFile(%dbFile) || isFile(%dbFile @ ".dso") )
      exec(%dbFile);
}

// Custom world datablocks?
%dbFile = $WorldPath @ "/datablock.cs";
if ( isFile(%dbFile) || isFile(%dbFile @ ".dso") )
   exec(%dbFile);

// IPS datablocks
//exec("art/ParticleSystem/defaultDatablocks.cs");
//exec("art/ParticleSystem/graphExamples.cs");
exec("art/SpellSystem/exec.cs");
