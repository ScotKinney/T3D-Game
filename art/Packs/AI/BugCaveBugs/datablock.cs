datablock SFXProfile(BugDeathCry)
{
   fileName = "art/Packs/AI/BugCaveBugs/sound/BugDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(BugPainCry)
{
   fileName = "art/Packs/AI/BugCaveBugs/sound/BugPainCry";
   description = AudioClosest3d;
   preload = false;
};
////////////////////////Bug 1//////////////////

datablock PlayerData(Bug1 : DefaultPlayerData)
{
   renderFirstPerson = false;
   shapeFile = "art/Packs/AI/BugCaveBugs/alien01.dts";
   
      maxDamage = 20;
      maxForwardSpeed = 3;
      maxBackwardSpeed = 3;
      maxSideSpeed = 2;
   
      //AI specific values that can be set for this datablock
      //These values can be overridden by the spawn marker,
      //but these values override the defaults
      Weapon = "";
      respawn = true;
      behavior = "GuardBehavior";
      maxRange = 5;
      minRange = 0;
      distDetect = 150;
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
      respawnTime = 60000; // 60 * 1000, 60 seconds.
      //deathEffectron = "AISmBugDeath_EFF";
   realName = " ";
   killerName = "a nasty Bug";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = BugDeathCry;
   PainSound = BugPainCry;

   numDeathAnims = 2;
   numDamageAnims = 0;

   boundingBox = "6 6 7";
   swimBoundingBox = "6 6 5";

   // Foot Prints
   decalData   = PlayerFootprint;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 89;
   jumpSurfaceAngle = 80;
   maxStepHeight = 3.0;  //Let bugs crawl over things
 
};

////////////////////////Bug 2//////////////////

datablock PlayerData(Bug2 : Bug1)
{
   shapeFile = "art/packs/AI/BugCaveBugs/alien04.dts";
   maxDamage = 60;
   boundingBox = "6 6 5";
   swimBoundingBox = "6 6 5";
};

////////////////////////Bug 3//////////////////

datablock PlayerData(Bug3 : Bug1)
{
   shapeFile = "art/packs/AI/BugCaveBugs/alien08.dts";
   maxDamage = 120;
   boundingBox = "6 6 5";
   swimBoundingBox = "6 6 5";
};

// Load the bug weapon script
exec("./weapon.cs");