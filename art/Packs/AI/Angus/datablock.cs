// Angus Fishman

singleton SFXProfile(AngusVoice1)   
{   
   filename = "art/Packs/AI/Angus/Sound/needpole.ogg";   
   description = AudioClosest3d;   
   preload = false;   
};

datablock PlayerData(Angus : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Angus/Angus.dts";
   
   maxDamage = 100;
   maxForwardSpeed = 2;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   //Weapon = "bomb";
   respawn = true;
   behavior = "NPCVendorBehavior";
   maxRange = 25;
   minRange = 0;
   distDetect = 100;
   sidestepDist = 10;
   paceDist = 6;
   npcAction = 7;
   spawnGroup = 1;
   fov = 360;
   leash = 35;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   team = 1;
   realName = "Angus Fishman";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = MaleDeathCry1;
   PainSound = MalePainCry1;

   mass = 100;
   drag = 1.3;
   maxdrag = 0.4;

   //boundingBox = "1 1 2";
   boundingBox = "50 50 140";
 
   numDeathAnims = 0;   
   numDamageAnims = 0;
   hasLocationalAnims = false;
};
