///////////Pain Death Cries//////

datablock SFXProfile(GiraffeDeathCry)
{
   fileName = "art/Packs/AI/Giraffe/sound/GiraffeDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(GiraffePainCry)
{
   fileName = "art/Packs/AI/Giraffe/sound/GiraffePainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

new Material(GiraffeFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Giraffe/FP_Giraffe";
   normalMap[0] = "art/Packs/AI/Giraffe/FP_Giraffe";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};

datablock DecalData(GiraffeFootprints)
{
   size = .5;
   material = "GiraffeFootprint";
};

////////////////////////////////Giraffe Datablock

datablock PlayerData(GiraffeAI : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Giraffe/Giraffe.dts";
   
      maxDamage = 300;
      maxForwardSpeed = 6;
      maxBackwardSpeed = 5;
      maxSideSpeed = 5;
   
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
   killerName = "a Giraffe";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = GiraffeDeathCry;
   PainSound = GiraffePainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2 4 6";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = GiraffeFootprints;
   decalOffset = 0.45;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
 
};
