///////////Pain Death Cries//////

datablock SFXProfile(RhinoDeathCry)
{
   fileName = "art/Packs/AI/Rhino/sound/RhinoDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(RhinoPainCry)
{
   fileName = "art/Packs/AI/Rhino/sound/RhinoPainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////Foot Prints

new Material(RhinoFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Rhino/FP_Rhino";
   normalMap[0] = "art/Packs/AI/Rhino/FP_Rhino";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};

datablock DecalData(RhinoFootprints)
{
   size = .6;
   material = "RhinoFootprint";
};

///////////////////////Rhino Weapon//////////////

datablock GameBaseData(RhinoHorn)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1.5;
   damageAmount = 25;
   startDamage = 0;
   endDamage = 5;
   soundDelay = 50; // Play sound 50 ms after animation starts
   swingSound = "SwordSwing1Sound";
   impulse = 400;
};

datablock ShapeBaseImageData(RhinoHornImage : BaseMeleeImage)
{
   shapefile = "art/packs/AI/Rhino/weapon/RhinoHorn.dts";
   item = RhinoHornWeapon; 

   // Here are the Attacks we support
   hthNumAttacks = 1;
   hthAttack[0] = RhinoHorn;

   // Sounds for when a club hits a player or object
   hitStaticSound = "SwordHitStaticSound";
   hitLiveSound = "SwordHitLiveSound";
};

/////////////////////////////////Rhino Datablock

datablock PlayerData(RhinoAI : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/rhino/rhino.dts";
   
      maxDamage = 500;
      maxForwardSpeed = 8;
      maxBackwardSpeed = 2;
      maxSideSpeed = 2;
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
   killerName = "a Rhino";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = RhinoDeathCry;
   PainSound = RhinoPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2.5 2.5 2";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = RhinoFootprints;
   decalOffset = 0.35;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters

};
