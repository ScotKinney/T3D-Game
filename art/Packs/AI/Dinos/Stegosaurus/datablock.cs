// Stegosaurus

datablock SFXProfile(StegoDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/StegosaurusDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(StegoPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/StegosaurusPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(StegosaurusFootprints)
{
   size = 1;
   material = "DinoQuadFootprint";
};

datablock PlayerData(Stego : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Stegosaurus/stegosaurus.dts";
   
   maxDamage = 600;
   maxForwardSpeed = 6;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Stego_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 7;
   minRange = 5;
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
   killerName = "a Stegosaurus";
   computeCRC = true;

   //Death Cry
   DeathSound = StegoDeathCry;
   PainSound = StegoPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 4;
   maxUnderwaterBackwardSpeed = 3;
   maxUnderwaterSideSpeed = 3;

   minImpactSpeed = 45;

   boundingBox = "3 7 8";//LR-FB-UpDN
   swimBoundingBox = "3 7 8";

   // Foot Prints
   decalData   = StegosaurusFootprints;
   decalOffset = 1;

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

////////////////////Dino - Stego_Jaw/////////////////

datablock GameBaseData(Stego_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw1Sound;
   impulse = 800;
};

datablock GameBaseData(Stego_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw1Sound;
   impulse = 800;
};

datablock GameBaseData(Stego_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 100;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = Jaw1Sound;
   impulse = 800;
};


datablock ShapeBaseImageData(Stego_JawImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Dinos/Stegosaurus/Stego_Jaw.dts";
   item = Stego_JawWeapon; //This is the name of the WEAPON that comes from the weapons table.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Stego_JawOne;
   hthAttack[1]                     = Stego_JawTwo;
   hthAttack[2]                     = Stego_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";
};