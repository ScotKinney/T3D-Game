// Compsognathus

datablock SFXProfile(CompsognathusDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/CompsognathusDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(CompsognathusPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/CompsognathusPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(CompsognathusFootprints)
{
   size = .3;
   material = "DinoBiPedSMFootprint";
};

datablock SFXProfile(CompsognathusAttack1)
{
   filename = "art/Packs/AI/Dinos/sound/CompsognathusAttack1";
   description = AudioClose3d;
   preload = false;
};

datablock PlayerData(compsognathus : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Compsognathus/Compsognathus.dts";

   maxDamage = 300;
   maxForwardSpeed = 5;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;
   run2speed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Comp_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 1;
   minRange = 0;
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
   killerName = "a Comp";
   computeCRC = true;

   //Death Cry
   DeathSound = CompsognathusDeathCry;
   PainSound = CompsognathusPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 100;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 4;
   maxUnderwaterBackwardSpeed = 2;
   maxUnderwaterSideSpeed = 2;

   minImpactSpeed = 45;

   boundingBox = ".7 1.2 1";
   swimBoundingBox = ".7 1.2 1";

   // Foot Prints
   decalData   = CompsognathusFootprints;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 89;
   jumpSurfaceAngle = 80;
   maxStepHeight = 3.0;

   // Footstep Sounds
   FootSoftSound        = "DinoLightSoftSound";
   FootHardSound        = "DinoLightHardSound";
   FootMetalSound       = "DinoLightHardSound";
   FootSnowSound        = "DinoLightSoftSound";
   ImpactSoftSound      = "DinoLightHardSound";
   ImpactHardSound      = "DinoLightHardSound";
   ImpactMetalSound     = "DinoLightHardSound";
   ImpactSnowSound      = "DinoLightSoftSound";
};

////////////////////Dino - Comp_Jaw/////////////////

datablock GameBaseData(Comp_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.2;
   endDamage = 2.3;
   soundDelay = 0; // Play sound 0 ms after animation starts
   swingSound = CompsognathusAttack1;
   impulse = 200; 
};

datablock GameBaseData(Comp_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.2;
   endDamage = 2.3;
   soundDelay = 0; // Play sound 0 ms after animation starts
   swingSound = CompsognathusAttack1;
   impulse = 200; 
};

datablock GameBaseData(Comp_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.2;
   endDamage = 2.3;
   soundDelay = 0; // Play sound 0 ms after animation starts
   swingSound = CompsognathusAttack1;
   impulse = 200; 
};


datablock ShapeBaseImageData(Comp_JawImage : BaseMeleeImage)
{
   shapefile = "art/shapes/weapons/Comp_Jaw/Comp_Jaw.dts";
   item = Comp_JawWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Comp_JawOne;
   hthAttack[1]                     = Comp_JawTwo;
   hthAttack[2]                     = Comp_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";
};