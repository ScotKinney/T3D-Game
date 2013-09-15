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
   fileName = "art/sound/PainDeathCries/MaleDeathCry";   
   description = AudioClosest3d;   
   preload = false;   
}; 

datablock SFXProfile(MalePainCry)
{
   fileName = "art/sound/PainDeathCries/MalePainCry";
   description = AudioClosest3d;
   preload = false;
};

//FemalePlayer
datablock SFXProfile(FemaleDeathCry)
{
   fileName = "art/sound/PainDeathCries/FemaleDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(FemalePainCry)
{
   fileName = "art/sound/PainDeathCries/FemalePainCry";
   description = AudioClosest3d;
   preload = false;
};

//----------------------------------------------------------------------------

datablock PlayerData(MalePlayerData : DefaultPlayerData)
{
   shapeFile = "art/players/base/basemale/basemale1_4.dts";
   optionPath = "art/players/base";

   //Death Cry
   DeathSound = MaleDeathCry;
   PainSound = MalePainCry;
   
   DefaultSetup = "55,59,35,20,65,63,70,77";
};

datablock PlayerData(FemalePlayerData : DefaultPlayerData)
{
   shapeFile = "art/players/base/basefemale/basefemale1_4.dts";
   optionPath = "art/players/base";

   //Death Cry
   DeathSound = FemaleDeathCry;
   PainSound = FemalePainCry;

   DefaultSetup = "80,99,216,386,393,382,379,380,390,393,390";
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
