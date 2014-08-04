///////////Pain Death Cries//////

datablock SFXProfile(ImpalaDeathCry)
{
   fileName = "art/Packs/AI/Impala/sound/AntelopeDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ImpalaPainCry)
{
   fileName = "art/Packs/AI/Impala/sound/AntelopePainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

datablock DecalData(ImpalaFootprints)
{
   size = .3;
   material = "ImpalaFootprint";
};

/////////////////Impala datablock

datablock PlayerData(IMPALAAI : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Impala/impala.dts";
   
      maxDamage = 100;
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
   killerName = "an Impala";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = ImpalaDeathCry;
   PainSound = ImpalaPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2 2 2";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = ImpalaFootprints;
   decalOffset = 0.15;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters

};