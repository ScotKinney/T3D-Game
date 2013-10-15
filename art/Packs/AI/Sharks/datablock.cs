datablock PlayerData(Shark : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/sharks/TigerShark.dts";
   
   maxDamage = 300;
   maxForwardSpeed = 20;
   maxBackwardSpeed = 2;
   maxSideSpeed = 3;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "sharktooth";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 100;
   minRange = 0;
   distDetect = 100;
   sidestepDist = 5;
   paceDist = 15;
   npcAction = 0;
   spawnGroup = 1;
   fov = 360;
   leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   team = 1;
   realName = " ";
   killerName = "a Shark";
   computeCRC = true;

   //Death Cry
   DeathSound = 0;
   PainSound = 0;

   maxUnderwaterForwardSpeed = 7;
   maxUnderwaterBackwardSpeed = 4;
   maxUnderwaterSideSpeed = 4;

   physicsPlayerType = "CapsuleY";
   boundingBox = "0.5 2.1 0.5";
   swimBoundingBox = "0.5 2.1 0.5";

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 30;
   jumpSurfaceAngle = 30;
   maxStepHeight = .5;  //two meters

   // Footstep Sounds
   FootSoftSound        = "";
   FootHardSound        = "";
   FootMetalSound       = "";
   FootSnowSound        = "";
   FootShallowSound     = FootLightShallowSplashSound;
   FootWadingSound      = FootLightWadingSound;
   FootUnderwaterSound  = FootLightUnderwaterSound;
};

////////////////////////////////////////////////////////////////////////////////
// Weapon datablocks
datablock SFXProfile(SharkAttackhitSound)
{
   filename = "art/Packs/AI/sharks/sound/Sharkattack";
   description = AudioClose3d;
   preload = true;
};
