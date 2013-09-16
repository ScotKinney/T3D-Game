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
exec("./environment.cs");
exec("./triggers.cs");

exec("./defaultEffects.cs");
exec("./player.cs");

// Load the player datablocks
$AlterVerse::AvSet = "Base";  // TODO: This should be set by level config
exec("art/players/" @ $AlterVerse::AvSet @ "/datablock.cs");

// Any datablocks contained in the loaded art packs
exec("art/Packs/skies/default/datablock.cs");

// Load our other player datablocks
//exec("./aiPlayer.cs");

// IPS datablocks
exec("art/ParticleSystem/defaultDatablocks.cs");
exec("art/ParticleSystem/graphExamples.cs");
exec("art/SpellSystem/exec.cs");
