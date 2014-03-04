//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Yeti

datablock SFXProfile(SnowWolfDeathCry)
{
   fileName = "art/Packs/AI/SnowWolf/sound/WildebeestDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(SnowWolfPainCry)
{
   fileName = "art/Packs/AI/SnowWolf/sound/WildebeestPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(SnowWolfFootprints)
{
   size = 0.2;
   material = "SnowWolfFootprint";
};

datablock PlayerData(WolfAI : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/SnowWolf/SnowWolf.dts";

   maxDamage = 500;
   maxForwardSpeed = 4;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   run2Speed = 2;

   maxUnderwaterForwardSpeed = 2;
   maxUnderwaterBackwardSpeed = 1.5;
   maxUnderwaterSideSpeed = 1;
   exitSplashSoundVelocity = 1.5;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "-noweapon";
   respawn = true;
   behavior = "PetBehavior";
   maxRange = 20;
   minRange = 10;
   distDetect = 40;
   sidestepDist = 2;
   paceDist = 20;
   npcAction = 0;
   spawnGroup = 1;
   fov = 180;
   leash = 10;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   team = 1;
   realName = " ";
   killerName = "a Wolf Dog";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = SnowWolfDeathCry;
   PainSound = SnowWolfPainCry;

   numDeathAnims = 1;
   numDamageAnims = 0;

   mass = 50;
   boundingBox = "0.5 1.3 0.9";
   swimBoundingBox = "0.5 1.3 0.9";

   // Foot Prints
   decalData   = SnowWolfFootprints;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
};

