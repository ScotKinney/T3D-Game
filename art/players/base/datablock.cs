//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// Player Audio Profiles
//----------------------------------------------------------------------------

//////////////////////////////////////////////////////////////////////////
//Pain-Death Cries - FootPrints
//////////////////////////////////////////////////////////////////////////

//MalePlayer
datablock SFXProfile(MaleDeathCry)   
{   
   fileName = "art/players/base/sound/MaleDeathCry";   
   description = AudioClosest3d;   
   preload = false;   
}; 

datablock SFXProfile(MalePainCry)
{
   fileName = "art/players/base/sound/MalePainCry";
   description = AudioClosest3d;
   preload = false;
};

//FemalePlayer
datablock SFXProfile(FemaleDeathCry)
{
   fileName = "art/players/base/sound/FemaleDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(FemalePainCry)
{
   fileName = "art/players/base/sound/FemalePainCry";
   description = AudioClosest3d;
   preload = false;
};

//----------------------------------------------------------------------------

datablock PlayerData(MalePlayerData : DefaultPlayerData)
{
   shapeFile = "art/players/base/basemale/basemale1_4.dts";
   optionPath = "art/players/base";
   physicsPlayerType = "CapsuleZ";

   //Death Cry
   DeathSound = MaleDeathCry;
   PainSound = MalePainCry;
   
   DefaultSetup = "55,59,35,20,65,63,70,77";
   DefaultSetup[Caerule] = "55,59,35,20,65,63,70,77";
   DefaultSetup[Sparta] = "55,59,35,242,6,269,362,13";
   DefaultSetup[Mythriel] = "55,59,298,35,294,295,377,291";
   DefaultSetup[Viken] = "55,59,50,35,279,282,285";
   DefaultSetup[Maya] = "55,59,237,35,313,320,378,306,309";
};

datablock PlayerData(FemalePlayerData : DefaultPlayerData)
{
   shapeFile = "art/players/base/basefemale/basefemale1_4.dts";
   optionPath = "art/players/base";
   physicsPlayerType = "CapsuleZ";

   //Death Cry
   DeathSound = FemaleDeathCry;
   PainSound = FemalePainCry;

   DefaultSetup = "80,99,216,386,393,382,379,380,390,393,390";
   DefaultSetup[Caerule] = "80,99,216,386,393,382,379,380,390,393,390";
   DefaultSetup[Sparta] = "80,99,216,356,350,348,347,360,351";
   DefaultSetup[Mythriel] = "80,99,366,216,368,364,363,374,365,369";
   DefaultSetup[Viken] = "80,99,397,216,396,406,400,403";
   DefaultSetup[Maya] = "80,99,216,330,326,325,361,328,324";
};

// Player fishing sounds
datablock SFXProfile(PoleCastSound)
{
   fileName = "art/sound/cast";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(FishCatchSound)
{
   fileName = "art/sound/FishCatch";
   description = AudioClosest3d;
   preload = false;
};
