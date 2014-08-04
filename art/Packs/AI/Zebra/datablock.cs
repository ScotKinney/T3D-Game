///////////Pain Death Cries//////

datablock SFXProfile(ZebraDeathCry)
{
   fileName = "art/Packs/AI/Zebra/sound/ZebraDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ZebraPainCry)
{
   fileName = "art/Packs/AI/Zebra/sound/ZebraPainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

new Material(ZebraFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Zebra/FP_Zebra";
   normalMap[0] = "art/Packs/AI/Zebra/FP_Zebra";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};

datablock DecalData(ZebraFootprints)
{
   size = .25;
   material = "ZebraFootprint";
};

/////////////////////////Zebra datablock

datablock PlayerData(ZebraAI : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Zebra/zebra.dts";
   
      maxDamage = 300;
      maxForwardSpeed = 8;
      maxBackwardSpeed = 4;
      maxSideSpeed = 4;
      run2Speed = 5;

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
   killerName = "a Zebra";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = ZebraDeathCry;
   PainSound = ZebraPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2 2 2";
   swimBoundingBox = "1 1 3";
   pickupRadius = 0.75;

   // Foot Prints
   decalData   = ZebraFootprints;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters

   // Footstep Sounds
   
   FootShallowSound     = HoofLightShallowSplashSound;
   FootWadingSound      = HoofLightWadingSound;
   FootUnderwaterSound  = HoofLightUnderwaterSound;
 
};
