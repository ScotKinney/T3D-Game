// Male Wizard
datablock PlayerData(Wizard : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/Wizard_M/Wizard.dts";

   maxDamage = 200;
   maxForwardSpeed = 5;
   maxBackwardSpeed = 4;
   maxSideSpeed = 3;
   run2Speed = 3;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "WizardStaff";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 1.75;
   minRange = 1;
   moveTolerance = 0.75;
   distDetect = 100;
   sidestepDist = 2;
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
   computeCRC = true;

   //Death Cry
   DeathSound = MaleDeathCry;
   PainSound = MalePainCry;

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

   numDeathAnims = 1;
   numDamageAnims = 1;

   boundingBox = "0.7 0.7 2";
   swimBoundingBox = "0.7 0.7 2";
   pickupRadius = 0.75;

   // Foot Prints
   decalData   = DefaultFootprint;
   decalOffset = 0.1;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;  //two meters
};

// Load the weapon script
exec("./weapon.cs");
