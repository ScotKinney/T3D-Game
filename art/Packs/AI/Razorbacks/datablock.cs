// Razorbacks

datablock SFXProfile(RazorbackDeathCry)
{
   fileName = "art/Packs/AI/RazorBacks/Sound/RazorbackDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(RazorbackPainCry)
{
   fileName = "art/Packs/AI/RazorBacks/Sound/RazorbackPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock PlayerData(Razorback : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/RazorBacks/mesh_LOD_Final.dts";
   
   maxDamage = 150;
   maxForwardSpeed = 4;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "Boartusk";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 2;
   minRange = 1;
   distDetect = 0;
   sidestepDist = 0;
   paceDist = 0;
   npcAction = 0;
   spawnGroup = 1;
   fov = 200;
   leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 0;
   team = 1;
   realName = " ";
   killerName = "a Boar";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = RazorbackDeathCry;
   PainSound = RazorbackPainCry;

   mass = 100;
   drag = 1.3;
   maxdrag = 0.4;

   boundingBox = ".75 2 1";
   swimBoundingBox = ".75 2 1";

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters

   numDeathAnims = 1;   
   numDamageAnims = 0;
   hasLocationalAnims = false;
};

// Load the weapon script
exec("./weapon.cs");
