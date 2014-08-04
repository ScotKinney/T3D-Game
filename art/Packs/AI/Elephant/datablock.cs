///////////Pain Death Cries//////

datablock SFXProfile(ElephantDeathCry)
{
   fileName = "art/Packs/AI/Elephant/sound/ElephantDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ElephantPainCry)
{
   fileName = "art/Packs/AI/Elephant/sound/ElephantPainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

datablock DecalData(ElephantFootprints)
{
   size = 0.6;
   material = "ElephantFootprint";
};


datablock PlayerData(Elephant : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Elephant/AsianElephant.dts";
   
      maxDamage = 500;
      maxForwardSpeed = 2;
      maxBackwardSpeed = 1;
      maxSideSpeed = 1;
   
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
   killerName = "an Elephant";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = ElephantDeathCry;
   PainSound = ElephantPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   SprintSpeedMult = 1; //How much of original speed to sprint

   boundingBox = "2 5 4.5";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = ElephantFootprints;
   decalOffset = 0.45;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
 
};
