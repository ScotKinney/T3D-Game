///////////Pain Death Cries//////

datablock SFXProfile(WildebeestDeathCry)
{
   fileName = "art/Packs/AI/Wildebeest/sound/WildebeestDeathCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(WildebeestPainCry)
{
   fileName = "art/Packs/AI/Wildebeest/sound/WildebeestPainCry";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(Jaw1Sound)
{
   filename = "art/Packs/AI/Wildebeest/sound/Jaw1";
   description = AudioClose3d;
   preload = true;
};

///////////////Foot Prints

datablock DecalData(WildebeestFootprints)
{
   size = .2;
   material = "WildebeestFootprint";
};

////////////////////////////////Wildebeest Horns////////////////////////////////////////////////

datablock GameBaseData(WBHornsOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1.5;
   damageAmount = 25;
   startDamage = 0.2;
   endDamage = 2.3;
   soundDelay = 500; // Play sound 500 ms after animation starts
};

datablock GameBaseData(WBHornsTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1.5;
   damageAmount = 25;
   startDamage = 0.2;
   endDamage = 2.3;
   soundDelay = 500; // Play sound 500 ms after animation starts
};

datablock ShapeBaseImageData(WBHornsImage : BaseMeleeImage)
{
   shapefile = "art/packs/ai/wildebeest/weapon/WBHorns.dts";
   item = WBHornsWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 2;
   hthAttack[0]                     = WBHornsOne;
   hthAttack[1]                     = WBHornsTwo;

   hthSwingSound[0] = Jaw1Sound;
   hthSwingSound[1] = Jaw1Sound;
};

////////////////////////Wildebeest datablock

datablock PlayerData(WildebeestAI : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/wildebeest/wildebeastDTS.dts";
   
      maxDamage = 500;
      maxForwardSpeed = 6;
      maxBackwardSpeed = 3;
      maxSideSpeed = 3;
      run2Speed = 4;
   
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
   killerName = "a Wildebeest";
   cameraMaxDist = 3;
   computeCRC = true;
   
   //Death Cry
   DeathSound = WildebeestDeathCry;
   PainSound = WildebeestPainCry;

   numDeathAnims = 1;   // Death1
   numDamageAnims = 1;  // Damage1

   mass = 50;
   drag = 1.3;

   boundingBox = "2 2 2";
   swimBoundingBox = "1 1 3";

   // Foot Prints
   decalData   = WildebeestFootprints;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
 
};