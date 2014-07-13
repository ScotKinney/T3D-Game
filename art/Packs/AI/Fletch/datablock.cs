// Old Fletch

datablock PlayerData(Fletch : DefaultPlayerData)
{
   renderFirstPerson = false;

   className = Armor;
   shapeFile = "art/Packs/AI/Fletch/nongfu.dts";
   
   maxDamage = 100;
   maxForwardSpeed = 2;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "F_Hammer";
   respawn = true;
   behavior = "KillableNPCBehavior";
   maxRange = 1;
   minRange = 0;
   distDetect = 8;
   sidestepDist = 10;
   paceDist = 6;
   npcAction = 5;
   spawnGroup = 1;
   fov = 150;
   leash = 50;
   cycleCounter = "5";
   weaponMode = "pattern";
   activeDodge = 1;
   team = 1;
   realName = "Old Fletch";
   killerName = "Old Fletch";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   //DeathSound = MaleDeathCry;
   //PainSound = MalePainCry;
   numPainSounds = 10;
   PainSound[0] = MalePainCry1;
   PainSound[1] = MalePainCry2;
   PainSound[2] = MalePainCry3;
   PainSound[3] = MalePainCry4;
   PainSound[4] = MalePainCry5;
   PainSound[5] = MalePainCry6;
   PainSound[6] = MalePainCry7;
   PainSound[7] = MalePainCry8;
   PainSound[8] = MalePainCry9;
   PainSound[9] = MalePainCry10;

   numDeathSounds = 7;
   DeathSound[0] = MaleDeathCry1;
   DeathSound[1] = MaleDeathCry2;
   DeathSound[2] = MaleDeathCry3;
   DeathSound[3] = MaleDeathCry4;
   DeathSound[4] = MaleDeathCry5;
   DeathSound[5] = MaleDeathCry6;
   DeathSound[6] = MaleDeathCry7;

   mass = 100;
   drag = 1.3;
   maxdrag = 0.4;

   boundingBox = "1 1 2";
   swimBoundingBox = "1 2 2";

   // Damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters

   numDeathAnims = 4;   
   numDamageAnims = 2;
   hasLocationalAnims = false;
};

// Load the weapon and control scripts
exec("./weapon.cs");
exec("./fletchSounds.cs");
exec("./fletch.cs");
