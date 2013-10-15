//Gargoyle
datablock SFXProfile(GargoyleDeathCry)
{
   fileName = "art/Packs/AI/Gargoyle/sound/GargoyleDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(GargoylePainCry)
{
   fileName = "art/Packs/AI/Gargoyle/sound/GargoylePainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(GargoyleWingFlap)
{
   fileName = "art/Packs/AI/Gargoyle/sound/GargWing";
   description = AudioClosest3d;
   preload = false;
};

datablock PlayerData(IlluraGargoyle : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Gargoyle/gargoyle.dts";

   canFly = true;
   airControl = 0.0;
   fallingSpeedThreshold = -100;

   maxDamage = 150;
   maxForwardSpeed = 14;
   maxBackwardSpeed = 10;
   maxSideSpeed = 5;
   attackWait = 1500; //in miliseconds
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "GargoyleFireball";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 20;
   minRange = 10;
   distDetect = 5;
   sidestepDist = 5;
   paceDist = 7;
   npcAction = 0;
   spawnGroup = 1;
   fov = 180;
   //leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   moveTolerance = 5.0;
   team = 1;
   realName = " ";
   killerName = "a Gargoyle";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = GargoyleDeathCry;
   PainSound = GargoylePainCry;

   mass = 0;
   drag = 0;
   maxdrag = 0;
   density = 0;
   maxEnergy =  100;
   repairRate = 0.275;
   energyPerDamagePoint = 55.0;

   rechargeRate = 0.2;  

   crouchForce = 45.0 * 9.0;
   maxCrouchForwardSpeed = 4.0;
   maxCrouchBackwardSpeed = 2.0;
   maxCrouchSideSpeed = 2.0;

   maxUnderwaterForwardSpeed = 14;
   maxUnderwaterBackwardSpeed = 10;
   maxUnderwaterSideSpeed = 5;
   surfaceSwim = true;

   // Foot Prints
   decalData   = DefaultFootprint;
   decalOffset = 0.7;

   // Sound effect to play while flying
   wingFlap = "GargoyleWingFlap";
   maxTimeScale = 4;
   minTimeScale = 1;

   boundingBox = "2 2 2";
   swimBoundingBox = "2 4 4";

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   // Switch "run2" anim above this speed
   run2Speed = 7;

   mountable = true; // Players can mount this AI
   driverNode = 1;
   mountPose[1]	= "gargsitfull"; // Driver
   //mountPose[1]	= "scoutroot"; // Driver
};

