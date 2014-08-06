///////////////////////Shark datablock

datablock PlayerData(Shark : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/sharks/TigerShark.dts";
   
   maxDamage = 300;
   maxForwardSpeed = 6;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "SharkJaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 2.5;
   minRange = 0;
   distDetect = 100;
   sidestepDist = 5;
   paceDist = 15;
   moveTolerance = 0.5;
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

   maxUnderwaterForwardSpeed = 6;
   maxUnderwaterBackwardSpeed = 3;
   maxUnderwaterSideSpeed = 2;

   physicsPlayerType = "CapsuleY";
   boundingBox = "0.5 2.1 0.5";
   swimBoundingBox = "0.5 2.1 0.5";

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 30;
   jumpSurfaceAngle = 30;
   maxStepHeight = .5;

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
   filename = "art/Packs/AI/sharks/sound/sharkattack";
   description = AudioClose3d;
   preload = true;
};

datablock GameBaseData(Shark_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 50;
   startDamage = 0;
   endDamage = .5;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = SharkAttackhitSound;
   impulse = 300; 
};

datablock ShapeBaseImageData(SharkJawImage : BaseMeleeImage)
{
   // Replace this when we have a weapon for the shark
   shapefile = "art/packs/ai/sharks/weapon/sharktooth.dae";
   mountPoint = 1;   // Connects to "Mount1" not "Mount0"

   hthNumAttacks = 1;
   hthAttack[0] = Shark_JawOne;

   numMovingAttacks = 1;
   movingAttack[0] = Shark_JawOne;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "";
};
