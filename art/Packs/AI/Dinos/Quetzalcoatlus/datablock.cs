// Quetzalcoatlus

datablock SFXProfile(QuetzDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/QuetzalcoatlusDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(QuetzPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/QuetzalcoatlusPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(QuetzFootprints)
{
   size = 1;
   material = "DinoBiPedFootprint";
};

datablock SFXProfile(QuetzalcoatlusAttack1)
{
   filename = "art/Packs/AI/Dinos/sound/QuetzalcoatlusAttack1";
   description = AudioClose3d;
   preload = false;
};

///////////////////////////////////////////////////////////

datablock PlayerData(Quetzal : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Quetzalcoatlus/Quetzalcoatlus.dts";
   
   maxDamage = 400;
   maxForwardSpeed = 4;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Quetz_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 3;
   minRange = 2;
   distDetect = 60;
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
   killerName = "a Quetzalcoatlus";
   computeCRC = true;

   //Death Cry
   DeathSound = QuetzDeathCry;
   PainSound = QuetzPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 4;
   maxUnderwaterBackwardSpeed = 2;
   maxUnderwaterSideSpeed = 2;

   minImpactSpeed = 45;

   boundingBox = "2 4 4";//LR-FB-UpDN
   swimBoundingBox = "2 4 4";

   // Foot Prints
   decalData   = QuetzFootprints;
   decalOffset = .7;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 50;
   maxStepHeight = 2.0;  //Let bugs crawl over things

   // Footstep Sounds
   FootSoftSound        = "DinoMedSoftSound";
   FootHardSound        = "DinoMedHardSound";
   FootMetalSound       = "DinoMedHardSound";
   FootSnowSound        = "DinoMedSoftSound";
   ImpactSoftSound      = "DinoMedHardSound";
   ImpactHardSound      = "DinoMedHardSound";
   ImpactMetalSound     = "DinoMedHardSound";
   ImpactSnowSound      = "DinoMedSoftSound";
};

////////////////////Dino - Quetz_Jaw/////////////////

datablock GameBaseData(Quetz_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = QuetzalcoatlusAttack1;
   impulse = 300;
};

datablock GameBaseData(Quetz_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = QuetzalcoatlusAttack1;
   impulse = 300;
};

datablock GameBaseData(Quetz_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = QuetzalcoatlusAttack1;
   impulse = 300;
};


datablock ShapeBaseImageData(Quetz_JawImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Dinos/Quetzalcoatlus/Quetz_Jaw.dts";
   item = Quetz_JawWeapon; //This is the name of the WEAPON that comes from the weapons table.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Quetz_JawOne;
   hthAttack[1]                     = Quetz_JawTwo;
   hthAttack[2]                     = Quetz_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";
};