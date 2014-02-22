////////////////////////////////////////////////////////////////////////////////
// Droids

datablock SFXProfile(DeathCryDroid1)   
{   
   fileName = "art/Packs/AI/Droids/sound/Droid1DeathCry";   
   description = AudioClosest3d;   
   preload = true;   
}; 

datablock SFXProfile(PainCryDroid1)   
{   
   fileName = "art/Packs/AI/Droids/sound/Droid1PainCry";   
   description = AudioClosest3d;   
   preload = true;   
};

datablock PlayerData(Droid1 : DefaultPlayerData)
{
   renderFirstPerson = false;
   shapeFile = "art/Packs/AI/Droids/mecha01.dts";

   maxDamage = 500;
   maxForwardSpeed = 2;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "DroidGun5";
   respawn = true;
   behavior = "ChaseBehavior";
   maxRange = 25;
   minRange = 0;
   distDetect = 100;
   sidestepDist = 5;
   paceDist = 6;
   npcAction = 0;
   spawnGroup = 1;
   fov = 360;
   leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   team = 2;
   realName = " ";
   killerName = "a Droid";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = DeathCryDroid1;
   PainSound = PainCryDroid1;

   numDeathAnims = 3;
   numDamageAnims = 0;   

   minImpactSpeed = 45;

   boundingBox = "5 4 9";
   swimBoundingBox = "5 4 9";

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
};

// Load the Droids weapon
exec("./weapon.cs");
