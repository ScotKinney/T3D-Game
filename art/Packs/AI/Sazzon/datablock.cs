datablock SFXProfile(SazzonDeathCry)
{
   fileName = "art/Packs/AI/Sazzon/sound/SazzonDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(SazzonPainCry)
{
   fileName = "art/Packs/AI/Sazzon/sound/SazzonPainCry";
   description = AudioClosest3d;
   preload = false;
};

///////////////////////Sazzon Big/////////////////////////////////////////////////

datablock PlayerData(Sazzon : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Sazzon/fellguard2.dts";
   
      maxDamage = 350;
      maxForwardSpeed = 3;
      maxBackwardSpeed = 3;
      maxSideSpeed = 2;
   
      //AI specific values that can be set for this datablock
      //These values can be overridden by the spawn marker,
      //but these values override the defaults
      Weapon = "SazzonFireball";
      respawn = true;
      behavior = "ChaseBehavior";
      maxRange = 300;
      minRange = 0;
      distDetect = 300;
      sidestepDist = 5;
      paceDist = 6;
      npcAction = 0;
      spawnGroup = 1;
      fov = 360;
      leash = 35;
      cycleCounter = "5";
      weaponMode = "pattern";
      activeDodge = 1;
      team = 1;
   realName = " ";
   killerName = "Sazzon";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = SazzonDeathCry;
   PainSound = SazzonPainCry;

   mass = 100;
   drag = 1.3;
   maxdrag = 0.4;
   density = 1.1;
   maxEnergy =  60;
   repairRate = 0.33;
   energyPerDamagePoint = 75.0;

   rechargeRate = 0.256;

   boundingBox = "4 4 8";
   swimBoundingBox = "2 4 4";

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;

   // Foot Prints
   decalData   = DefaultFootprint;
   decalOffset = 0.25;

};

//////////////////////////Small Sazzons/////////////////////////////////////

datablock PlayerData(SazzonSmall : Sazzon)
{
   maxDamage = 100;
   maxForwardSpeed = 2;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   maxRange = 125;
   minRange = 0;
   distDetect = 100;
   sidestepDist = 5;
   paceDist = 6;
   killerName = "Sazzons Minion";
   boundingBox = "2 2 5";
   swimBoundingBox = "2 4 4";

   // Foot Prints
   decalData   = DefaultFootprint;
   decalOffset = 0.25;

};

// Load the Sazzon weapon script
exec("./weapon/sazzonfireball.cs");