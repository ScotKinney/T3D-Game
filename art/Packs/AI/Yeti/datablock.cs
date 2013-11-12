//////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Yeti

datablock SFXProfile(YetiDeathCry)   
{   
   fileName = "art/Packs/AI/Yeti/sound/YetiDeathCry";   
   description = AudioClosest3d;   
   preload = false;   
}; 

datablock SFXProfile(YetiPainCry)   
{   
   fileName = "art/Packs/AI/Yeti/sound/YetiPainCry";   
   description = AudioClosest3d;   
   preload = false;   
};

datablock PlayerData(YetiWhite : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/Yeti/Yeti01.dts";
   
   maxDamage = 200;
   maxForwardSpeed = 3;
   maxBackwardSpeed = 3;
   maxSideSpeed =2;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "IceBall";
   respawn = true;
   behavior = "LeashedBehavior";
   maxRange = 200;
   minRange = 0;
   distDetect = 200;
   sidestepDist = 5;
   paceDist = 6;
   npcAction = 0;
   spawnGroup = 1;
   fov = 360;
   leash = 200;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   team = 1;
   realName = " ";
   killerName = "a Yeti";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = YetiDeathCry;
   PainSound = YetiPainCry;

   numDeathAnims = 2;
   numDamageAnims = 0;

   boundingBox = "4 4 6";
   swimBoundingBox = "2 4 4";

   // Foot Prints
   decalData   = DefaultFootprint;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
};

// Load the Yeti weapon script
exec("./weapon.cs");
