//////////////////////////////////////////////////////////////////////////////////////////////////////////////
//Tolgart

datablock SFXProfile(TolgartDeathCry)
{
   fileName = "art/sound/PainDeathCries/TolgartDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(TolgartPainCry)
{
   fileName = "art/sound/PainDeathCries/TolgartPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock PlayerData(Tolgart : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = $WorldPath @ "/AI/Tolgart/orc01.dts";
   
   maxDamage = 150;
   maxForwardSpeed = 3;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "TolgartsAxe";
   respawn = 1;
   behavior = "GuardBehavior";
   maxRange = 50;
   minRange = 0;
   distDetect = 150;
   sidestepDist = 5;
   paceDist = 6;
   npcAction = 0;
   spawnGroup = 1;
   fov = 360;
   leash = 35;
   cycleCounter = "5";
   activeDodge = 1;
   realName = " ";
   killerName = "a Gart";
   computeCRC = true;

   //Death Cry
   DeathSound = TolgartDeathCry;
   PainSound = TolgartPainCry;

   boundingBox = "1.25 1.25 2.8";
   swimBoundingBox = "1.25 2.8 1.25";

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;
   maxStepHeight = "1.5";  //two meters
   
   // Add the shield to the left hand ("Mount1")
   equipmentSlots = 1;
   eqShape[0] = $WorldPath @ "/AI/Tolgart/orcshield.dts";
   eqNode[0] = "mount1";
};

