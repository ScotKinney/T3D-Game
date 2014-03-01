///The Archer


datablock PlayerData(GnomeArcher : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/Gnomes/Archer/Gnome_Archer.dts";

   maxDamage = 200;
   maxForwardSpeed = 2.5;
   maxBackwardSpeed = 1;
   maxSideSpeed = 1;
   run2Speed = 1.5;

   isAmphibious = true;
   maxUnderwaterForwardSpeed = 2;
   maxUnderwaterBackwardSpeed = 1.5;
   maxUnderwaterSideSpeed = 1;
   exitSplashSoundVelocity = 1.5;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "GA_Crossbow";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 20;
   minRange = 0;
   distDetect = 50;
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
   //deathEffectron = "AIBoglinDeath_EFF";
   realName = " ";
   killerName = "a Gnome Archer";
   cameraMaxDist = 3;
   computeCRC = true;

   numDeathSounds = 6;
   DeathSound[0] = GnomeDeathCry1;
   DeathSound[1] = GnomeDeathCry2;
   DeathSound[2] = GnomeDeathCry3;
   DeathSound[3] = GnomeDeathCry4;
   DeathSound[4] = GnomeDeathCry5;
   DeathSound[5] = GnomeDeathCry6;

   numPainSounds = 9;
   PainSound[0] = GnomePain1;
   PainSound[1] = GnomePain2;
   PainSound[2] = GnomePain3;
   PainSound[3] = GnomePain4;
   PainSound[4] = GnomePain5;
   PainSound[5] = GnomePain6;
   PainSound[6] = GnomePain7;
   PainSound[7] = GnomePain8;
   PainSound[8] = GnomePain9;

   numAttackSounds = 6;
   AttackSound[0] = GnomeTaunt1;
   AttackSound[1] = GnomeTaunt2;
   AttackSound[2] = GnomeTaunt3;
   AttackSound[3] = GnomeTaunt4;
   AttackSound[4] = GnomeTaunt5;
   AttackSound[5] = GnomeTaunt6;

   numDeathAnims = 4;
   numDamageAnims = 3;

   boundingBox = ".7 .7 1.5";
   swimBoundingBox = ".7 1.5 .7";

   // Foot Prints
   decalData   = DefaultFootprint;
   decalOffset = 0.2;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 60;
   maxStepHeight = 2;  //This get's multiplied by scale and gnomes are 1 scale
};


// Load the Gnome Archer weapon
exec("./weapon.cs");
