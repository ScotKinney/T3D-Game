// Velociraptor

datablock SFXProfile(VelociraptorDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/VelociraptorDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(VelociraptorPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/VelociraptorPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(VelociraptorFootprints)
{
   size = .4;
   material = "DinoBiPedSMFootprint";
};

datablock SFXProfile(VelociraptorAttack1)
{
   filename = "art/Packs/AI/Dinos/sound/VelociraptorAttack1";
   description = AudioClose3d;
   preload = false;
};

//////////////////////////////////////////////////////////

datablock PlayerData(Velociraptor : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Velociraptor/Velociraptor.dts";

   maxDamage = 500;
   maxForwardSpeed = 6;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Raptor_Jaw";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 1;
   minRange = 0;
   distDetect = 130;
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
   killerName = "a Raptor";
   computeCRC = true;

   //Death Cry
   DeathSound = VelociraptorDeathCry;
   PainSound = VelociraptorPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 2;  // Damage1 and Damage2

   mass = 100;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 4;
   maxUnderwaterBackwardSpeed = 2;
   maxUnderwaterSideSpeed = 2;

   minImpactSpeed = 45;

   boundingBox = "1 3 2";
   swimBoundingBox = "1 3 2";

   // Foot Prints
   decalData   = VelociraptorFootprints;
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

////////////////////Dino - Raptor_Jaw/////////////////

datablock GameBaseData(Raptor_JawOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 50;
   startDamage = 0.47;
   endDamage = .8;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = VelociraptorAttack1;
   impulse = 300; 
};

datablock GameBaseData(Raptor_JawTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 50;
   startDamage = 0.17;
   endDamage = 1.7;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = VelociraptorAttack1;
   impulse = 300; 
};

datablock GameBaseData(Raptor_JawThree)
{
   seqName = "attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 50;
   startDamage = 0.3;
   endDamage = 1.8;
   soundDelay = 1; // Play sound 0 ms after animation starts
   swingSound = VelociraptorAttack1;
   impulse = 300; 
};


datablock ShapeBaseImageData(Raptor_JawImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Dinos/Velociraptor/Raptor_Jaw.dts";
   item = Raptor_JawWeapon; //This is the name of the WEAPON that comes from the weapons table.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Raptor_JawOne;
   hthAttack[1]                     = Raptor_JawTwo;
   hthAttack[2]                     = Raptor_JawThree;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "JawHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "JawHitLiveSound";
};
