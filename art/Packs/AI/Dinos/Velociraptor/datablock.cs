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

datablock PlayerData(Velociraptor : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Velociraptor/Velociraptor.dts";

   maxDamage = 180;
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

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 7.8;
   maxUnderwaterSideSpeed = 7.8;

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
