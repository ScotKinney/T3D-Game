// Triceratops

datablock SFXProfile(TriDeathCry)
{
   fileName = "art/Packs/AI/Dinos/sound/TriceratopsDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(TriPainCry)
{
   fileName = "art/Packs/AI/Dinos/sound/TriceratopsPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock DecalData(TriceratopsFootprints)
{
   size = .05;
   material = "DinoQuadFootprint";
};

datablock PlayerData(Tri : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Dinos/Triceratops/Triceratops.dts";

   maxDamage = 200;
   maxForwardSpeed = 5;
   maxBackwardSpeed = 3;
   maxSideSpeed = 2;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Tri_Jaw";
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
   killerName = "a Triceratops";
   computeCRC = true;

   //Death Cry
   DeathSound = TriDeathCry;
   PainSound = TriPainCry;

   mass = 300;
   drag = 1.3;

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 7.8;
   maxUnderwaterSideSpeed = 7.8;

   minImpactSpeed = 45;

   boundingBox = "2 5 3";//LR-FB-UpDN
   swimBoundingBox = "2 5 3";

   // Foot Prints
   decalData   = TriceratopsFootprints;
   decalOffset = .5;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 50;
   maxStepHeight = 2.0;  //Let bugs crawl over things

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
