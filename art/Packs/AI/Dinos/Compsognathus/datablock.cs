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

datablock PlayerData(compsognathus : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Compsognathus/Compsognathus.dts";

   maxDamage = 100;
   maxForwardSpeed = 5;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

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

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 7.8;
   maxUnderwaterSideSpeed = 7.8;

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
