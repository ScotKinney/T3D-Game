
datablock PlayerData(GnomeWarrior : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/Gnomes/GnomeWarrior.dts";
   
   maxDamage = 200;
   maxForwardSpeed = 2;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "GW_Axe";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 2;
   minRange = 0;
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
   //deathEffectron = "AIBoglinDeath_EFF";
   realName = " ";
   killerName = "a Gnome Warrior";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = GnomeDeathCry;
   PainSound = "";
   
   numPainSounds = 5;
   PainSound[0] = GnomePain1;
   PainSound[1] = GnomePain2;
   PainSound[2] = GnomePain3;
   PainSound[3] = GnomePain4;
   PainSound[4] = GnomePain5;

/* numAttackSounds = 5; No Attack Sound for Gnomes!
   AttackSound[0] = BoglinAttack1;
   AttackSound[1] = BoglinAttack2;
   AttackSound[2] = BoglinAttack3;
   AttackSound[3] = BoglinAttack4;
   AttackSound[4] = BoglinAttack5;
*/

   numDeathAnims = 4;
   numDamageAnims = 3;

   boundingBox = "2 2 3";
   swimBoundingBox = "2 4 4";

   // Foot Prints
   decalData   = PlayerFootprint;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 60;
   maxStepHeight = 2;  //This get's multiplied by scale and gnomes are 1 scale
};


// Load the Gnome Warrior weapon
exec("./weapon.cs");
