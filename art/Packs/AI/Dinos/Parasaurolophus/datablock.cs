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

datablock PlayerData(Para : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Parasaurolophus/Parasaurolophus.dts";

   maxDamage = 300;
   maxForwardSpeed = 8;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Para_Jaw";
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
   killerName = "a Parasaurolophus";
   computeCRC = true;

   //Death Cry
   DeathSound = ParaDeathCry;
   PainSound = ParaPainCry;

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 7.8;
   maxUnderwaterSideSpeed = 7.8;


   minImpactSpeed = 45;

   boundingBox = "3 7 6";//LR-FB-UpDN
   swimBoundingBox = "3 7 6";

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
