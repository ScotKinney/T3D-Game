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
   
   maxDamage = 200;
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

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 7.8;
   maxUnderwaterSideSpeed = 7.8;

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
