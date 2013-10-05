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
   run2Speed = 4;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Allo_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 7;
   minRange = 5;
   distDetect = 100;
   sidestepDist = 2;
   paceDist = 20;
   npcAction = 0;
   spawnGroup = 1;
   fov = 270;
   leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   team = 1;
   respawnTime = 60000; // 60 * 1000, 60 seconds.
   deathEffectron = "";
   realName = " ";
   killerName = "an Allosaurus";
   computeCRC = true;

   //Death Cry
   DeathSound = AllosaurusDeathCry;
   PainSound = AllosaurusPainCry;

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
   timeScale = .1;
   damageAmount = 300;
   startDamage = 0.2;
   endDamage = 5;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw1Sound;
};

singleton GameBaseData(Allo_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = .1;
   damageAmount = 300;
   startDamage = 0.2;
   endDamage = 5;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw2Sound;
};

singleton GameBaseData(Allo_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = .1;
   damageAmount = 300;
   startDamage = 0.2;
   endDamage = 5;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw3Sound;
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
