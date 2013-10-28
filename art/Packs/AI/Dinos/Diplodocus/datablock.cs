// Diplodocus

datablock SFXProfile(DiploDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/DiplodocusDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(DiploPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/DiplodocusPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(DiploFootprints)
{
   size = 2;
   material = "DinoQuadFootprint";
};

datablock PlayerData(Diplo : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Diplodocus/Diplodocus.dts";
   
   maxDamage = 1500;
   maxForwardSpeed = 4;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Diplo_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 12;
   minRange = 10;
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
   killerName = "a Diplodocus";
   computeCRC = true;

   //Death Cry
   DeathSound = DiploDeathCry;
   PainSound = DiploPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 7.8;
   maxUnderwaterSideSpeed = 7.8;

   minImpactSpeed = 45;

   boundingBox = "6 20 12";//LR-FB-UpDN
   swimBoundingBox = "6 20 12";

   // Foot Prints
   decalData   = DiploFootprints;
   decalOffset = 1.5;

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

////////////////////Dino - Diplo_Jaw/////////////////

datablock GameBaseData(Diplo_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw2Sound;
   impulse = 1200;
};

datablock GameBaseData(Diplo_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw2Sound;
   impulse = 1200;
};

datablock GameBaseData(Diplo_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw2Sound;
   impulse = 1200;
};


datablock ShapeBaseImageData(Diplo_JawImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Dinos/Diplodocus/Diplo_Jaw.dts";
   item = Diplo_JawWeapon; //This is the name of the WEAPON that comes from the weapons table.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Diplo_JawOne;
   hthAttack[1]                     = Diplo_JawTwo;
   hthAttack[2]                     = Diplo_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";

};