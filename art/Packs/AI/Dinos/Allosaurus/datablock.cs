// Allosaurus

datablock SFXProfile(AllosaurusDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/AllosaurusDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(AllosaurusPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/AllosaurusPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(AllosaurusFootprints)
{
   size = 3;
   material = "DinoBiPedFootprint";
};

datablock PlayerData(Allosaurus : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Allosaurus/Allosaurus.dts";
   
   maxDamage = 300;
   maxForwardSpeed = 8;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;
   run2Speed = 2;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Allo_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 6;
   minRange = 3;
   distDetect = 100;
   sidestepDist = 10;
   moveTolerance = 2;
   paceDist = 20;
   npcAction = 0;
   spawnGroup = 1;
   fov = 270;
   leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 0;
   team = 1;
   respawnTime = 60000; // 60 * 1000, 60 seconds.
   deathEffectron = "";
   realName = " ";
   killerName = "an Allosaurus";
   computeCRC = true;

   //Death Cry
   DeathSound = AllosaurusDeathCry;
   PainSound = AllosaurusPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 300;
   drag = 1.3;

   boundingBox = "3 7 10";//LR-FB-UpDN
   swimBoundingBox = "3 7 10";

   // Foot Prints
   decalData   = AllosaurusFootprints;
   decalOffset = 1;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 50;
   maxStepHeight = 2.0;

   // Footstep Sounds
   FootSoftSound        = "DinoHeavySoftSound";
   FootHardSound        = "DinoHeavyHardSound";
   FootMetalSound       = "DinoHeavyHardSound";
   FootSnowSound        = "DinoHeavySoftSound";
   ImpactSoftSound      = "DinoHeavyHardSound";
   ImpactHardSound      = "DinoHeavyHardSound";
   ImpactMetalSound     = "DinoHeavyHardSound";
   ImpactSnowSound      = "DinoHeavySoftSound";
};

// Weapon and attacks
singleton GameBaseData(Allo_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 300;
   startDamage = 0.36; //time in seconds during animation before any damage begins
   endDamage = .7; //point in the animation where damage ends
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = Jaw1Sound;
   impulse = 4000; 
};

singleton GameBaseData(Allo_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 300;
   startDamage = 0.1; //time in seconds during animation before damage is done
   endDamage = 1.4;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = Jaw2Sound;
   impulse = 4000;
};

singleton GameBaseData(Allo_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 300;
   startDamage = 0.14; //time in seconds during animation before damage is done
   endDamage = 1.4;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = Jaw3Sound;
   impulse = 2000;
};

datablock ShapeBaseImageData(Allo_JawImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Dinos/Allosaurus/Allo_Jaw.dts";

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Allo_JawOne;
   hthAttack[1]                     = Allo_JawTwo;
   hthAttack[2]                     = Allo_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHit1Sound";
};
