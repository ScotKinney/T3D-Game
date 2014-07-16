/////////////////CHET/////////////////

datablock PlayerData(Miner : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/MoragsMiner/Miner.dts";
   
      maxDamage = 100;
      maxForwardSpeed = 2;
      maxBackwardSpeed = 2;
      maxSideSpeed = 1;
      //attackWait = 900; //in miliseconds
   
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
   realName = "Chet";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = MaleDeathCry;
   PainSound = MalePainCry;

   mass = 100;
   drag = 1.3;
   maxdrag = 0.4;

   boundingBox = "2 2 4";

   numDeathAnims = 3;   
   numDamageAnims = 0;
   hasLocationalAnims = false;
 
};
