// TRex

datablock SFXProfile(TRexDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/TRexDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(TRexPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/TRexPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(TRexFootprints)
{
   size = 3;
   material = "DinoBiPedFootprint";
};

datablock SFXProfile(TRexAttack1)
{
   filename = "art/Packs/AI/Dinos/sound/TRexAttack1";
   description = AudioClose3d;
   preload = false;
};

////////////////////////////////////////////////////////////////////////

datablock PlayerData(TRex : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/TRex/TRex.dts";

   maxDamage = 800;
   maxForwardSpeed = 6;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "TRex_Jaw";
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
   killerName = "a T Rex";
   computeCRC = true;

   //Death Cry
   DeathSound = TRexDeathCry;
   PainSound = TRexPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 5;
   maxUnderwaterBackwardSpeed = 2;
   maxUnderwaterSideSpeed = 2;

   minImpactSpeed = 45;

   boundingBox = "3 7 10";//LR-FB-UpDN
   swimBoundingBox = "3 7 10";

   // Foot Prints
   decalData   = TRexFootprints;
   decalOffset = 1;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 50;
   maxStepHeight = 2.0;  //Let bugs crawl over things
 
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

////////////////////Dino - TRex_Jaw/////////////////

datablock GameBaseData(TRex_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 300;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = TRexAttack1;
   impulse = 900;
};

datablock GameBaseData(TRex_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 300;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = TRexAttack1;
   impulse = 900;
};

datablock GameBaseData(TRex_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 300;
   startDamage = 0.2;
   endDamage = 10;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = TRexAttack1;
   impulse = 900;
};


datablock ShapeBaseImageData(TRex_JawImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Dinos/TRex/TRex_Jaw.dts";
   item = TRex_JawWeapon; //This is the name of the WEAPON that comes from the weapons table.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = TRex_JawOne;
   hthAttack[1]                     = TRex_JawTwo;
   hthAttack[2]                     = TRex_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";
};