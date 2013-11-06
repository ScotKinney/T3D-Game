// Parasaurolophus

datablock SFXProfile(ParaDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/ParasaurolophusDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ParaPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/ParasaurolophusPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(ParaFootprints)
{
   size = 2;
   material = "DinoBiPedFootprint";
};

////////////////////////////////////////////////////////////////////

datablock PlayerData(Para : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Parasaurolophus/Parasaurolophus.dts";

   maxDamage = 1000;
   maxForwardSpeed = 5;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Para_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 4;
   minRange = 3;
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
   killerName = "a Parasaurolophus";
   computeCRC = true;

   //Death Cry
   DeathSound = ParaDeathCry;
   PainSound = ParaPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 4;
   maxUnderwaterBackwardSpeed = 3;
   maxUnderwaterSideSpeed = 2;


   minImpactSpeed = 45;

   boundingBox = "3 8 6";//LR-FB-UpDN
   swimBoundingBox = "3 8 6";

   // Foot Prints
   decalData   = ParaFootprints;
   decalOffset = .7;

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


////////////////////Dino - Para_Jaw/////////////////

datablock GameBaseData(Para_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.4;
   endDamage = 2;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw3Sound;
   impulse = 1000;
};

datablock GameBaseData(Para_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 2;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw3Sound;
   impulse = 1000;
};

datablock GameBaseData(Para_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.3;
   endDamage = 2;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw3Sound;
   impulse = 1000;
};


datablock ShapeBaseImageData(Para_JawImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Dinos/Parasaurolophus/Para_Jaw.dts";
   item = Para_JawWeapon; //This is the name of the WEAPON that comes from the weapons table.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Para_JawOne;
   hthAttack[1]                     = Para_JawTwo;
   hthAttack[2]                     = Para_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";
};