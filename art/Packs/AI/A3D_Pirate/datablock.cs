/////////////////Uncle Salty/////////////////

datablock PlayerData(Salty : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/A3D_Pirate/A3D_Pirate.dts";
   
   maxDamage = 300;
   maxForwardSpeed = 2;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   maxStepHeight = .25;
   //attackWait = 900; //in miliseconds
   
      //AI specific values that can be set for this datablock
      //These values can be overridden by the spawn marker,
      //but these values override the defaults
      //Weapon = "bomb";
      respawn = true;
      behavior = "NPCVendorBehavior";
      maxRange = 5;
      minRange = 0;
      distDetect = 5;
      sidestepDist = 10;
      paceDist = 6;
      npcAction = 5;
      spawnGroup = 1;
      fov = 360;
      leash = 35;
      cycleCounter = "5";
      weaponMode = "pattern";
      activeDodge = 1;
      team = 1;
   realName = "Uncle Salty";
   hasClickAction = true;
   willBuy = "Gems";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = MaleDeathCry;
   PainSound = MalePainCry;

   mass = 100;
   drag = 1.3;
   maxdrag = 0.4;

   boundingBox = "1 0.7 2";

   numDeathAnims = 3;   
   numDamageAnims = 0;
   hasLocationalAnims = false;
};

exec("./salty.cs");
