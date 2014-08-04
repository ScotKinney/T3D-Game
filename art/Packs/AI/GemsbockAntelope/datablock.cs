///////////Pain Death Cries//////

datablock SFXProfile(GemsbockAntelopeDeathCry)
{
   fileName = "art/Packs/AI/GemsbockAntelope/sound/AntelopeDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(GemsbockAntelopePainCry)
{
   fileName = "art/Packs/AI/GemsbockAntelope/sound/AntelopePainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

new Material(GemsbockAntelopeFootprint)
{
   diffuseMap[0] = "art/Packs/AI/GemsbockAntelope/FP_Antelope";
   normalMap[0] = "art/Packs/AI/GemsbockAntelope/FP_Antelope";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};

datablock DecalData(GemsbockAntelopeFootprints)
{
   size = .3;
   material = "GemsbockAntelopeFootprint";
};

//////////////////////////////////Gemsbock datablock

datablock PlayerData(GemsbockAntelope : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/GemsbockAntelope/GemsbockAntelope.dts";
   
      maxDamage = 200;
      maxForwardSpeed = 10;
      maxBackwardSpeed = 5;
      maxSideSpeed = 5;
      run2Speed = 6;

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
   killerName = "a Gemsbock";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = GemsbockAntelopeDeathCry;
   PainSound = GemsbockAntelopePainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2 2 2";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = GemsbockAntelopeFootprints;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters

};