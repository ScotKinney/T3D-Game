///////////Pain Death Cries//////

datablock SFXProfile(KuduAntelopeDeathCry)
{
   fileName = "art/Packs/AI/KuduAntelope/sound/AntelopeDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(KuduAntelopePainCry)
{
   fileName = "art/Packs/AI/KuduAntelope/sound/AntelopePainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

datablock DecalData(KuduAntelopeFootprints)
{
   size = .3;
   material = "KuduAntelopeFootprint";
};

////////////////////////////////Kudu Datablock

datablock PlayerData(KuduAI : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/kuduantelope/kuduantelope.dts";
   
      maxDamage = 300;
      maxForwardSpeed = 6;
      maxBackwardSpeed = 3;
      maxSideSpeed = 3;
      run2Speed = 4;

      respawn = true;
      behavior = "HuntedBehavior";
      maxRange = 20;
      minRange = 10;
      distDetect = 40;
      sidestepDist = 2;
      paceDist = 20;
      npcAction = 0;
      spawnGroup = 1;
      fov = 180;
      leash = 10;
      cycleCounter = "5";
      weaponMode = "pattern";
      activeDodge = 1;
      team = 1;
   realName = " ";
   killerName = "a Kudu";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = KuduAntelopeDeathCry;
   PainSound = KuduAntelopePainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2 2 2";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = KuduAntelopeFootprints;
   decalOffset = 0.15;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
 
};