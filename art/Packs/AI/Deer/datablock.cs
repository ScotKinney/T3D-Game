///////////Pain Death Cries//////

datablock SFXProfile(DeerDeathCry)
{
   fileName = "art/Packs/AI/Deer/sound/DeerDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(DeerPainCry)
{
   fileName = "art/Packs/AI/Deer/sound/DeerPainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

new Material(DeerFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Deer/FP_Antelope";
   normalMap[0] = "art/Packs/AI/Deer/FP_Antelope";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};

datablock DecalData(DeerFootprints)
{
   size = .25;
   material = "DeerFootprint";
};

//////////////////////////////Deer Datablock

datablock PlayerData(Deer : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Deer/fallowDeer_AllAnims.dts";
   
      maxDamage = 100;
      maxForwardSpeed = 10;
      maxBackwardSpeed = 5;
      maxSideSpeed = 5;
      run2Speed = 6;
  
      respawn = true;
      behavior = "HuntedBehavior";
      maxRange = 20;
      minRange = 10;
      distDetect = 80;
      sidestepDist = 5;
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
   killerName = "a Deer";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = DeerDeathCry;
   PainSound = DeerPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2 2 2";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = DeerFootprints;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters

};