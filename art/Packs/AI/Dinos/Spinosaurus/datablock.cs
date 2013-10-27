// Spinosaurus

datablock SFXProfile(SpinoDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/SpinosaurusDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(SpinoPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/SpinosaurusPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(SpinosaurusFootprints)
{
   size = 3;
   material = "DinoBiPedFootprint";
};

datablock PlayerData(Spino : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Spinosaurus/spinosaurus.dts";
   
   maxDamage = 600;
   maxForwardSpeed = 8;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Spino_Jaw";
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
   killerName = "a Spinosaurus";
   computeCRC = true;

   //Death Cry
   DeathSound = SpinoDeathCry;
   PainSound = SpinoPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 4;
   maxUnderwaterBackwardSpeed = 3;
   maxUnderwaterSideSpeed = 3;

   minImpactSpeed = 45;

   boundingBox = "3 7 10";//LR-FB-UpDN
   swimBoundingBox = "3 7 10";

   // Foot Prints
   decalData   = SpinosaurusFootprints;
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

////////////////////Dino - Spino_Jaw/////////////////

datablock GameBaseData(Spino_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 150;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw1Sound;
   impulse = 800;
};

datablock GameBaseData(Spino_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 150;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw1Sound;
   impulse = 800;
};

datablock GameBaseData(Spino_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 150;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw1Sound;
   impulse = 800;
};


datablock ShapeBaseImageData(Spino_JawImage : BaseMeleeImage)
{
   shapefile = "art/shapes/weapons/Spino_Jaw/Spino_Jaw.dts";
   item = Spino_JawWeapon; //This is the name of the WEAPON that comes from the weapons table.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Spino_JawOne;
   hthAttack[1]                     = Spino_JawTwo;
   hthAttack[2]                     = Spino_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";
};