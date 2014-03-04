// Female Wizard
datablock PlayerData(FemWizard : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/Wizard_F/FemWizard.dts";

   maxDamage = 200;
   maxForwardSpeed = 5;
   maxBackwardSpeed = 4;
   maxSideSpeed = 3;
   run2Speed = 3;

   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "WizardStaff2";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 1.5;
   minRange = 0.75;
   moveTolerance = 0.5;
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

   mass = 100;
   drag = 1.3;
   maxdrag = 0.4;

   numPainSounds = 10;
   PainSound[0] = FemalePainCry1;
   PainSound[1] = FemalePainCry2;
   PainSound[2] = FemalePainCry3;
   PainSound[3] = FemalePainCry4;
   PainSound[4] = FemalePainCry5;
   PainSound[5] = FemalePainCry6;
   PainSound[6] = FemalePainCry7;
   PainSound[7] = FemalePainCry8;
   PainSound[8] = FemalePainCry9;
   PainSound[9] = FemalePainCry10;

   numDeathSounds = 7;
   DeathSound[0] = FemaleDeathCry1;
   DeathSound[1] = FemaleDeathCry2;
   DeathSound[2] = FemaleDeathCry3;
   DeathSound[3] = FemaleDeathCry4;
   DeathSound[4] = FemaleDeathCry5;
   DeathSound[5] = FemaleDeathCry6;
   DeathSound[6] = FemaleDeathCry7;

   numDeathAnims = 1;
   numDamageAnims = 1;

   boundingBox = "0.7 0.7 2";
   swimBoundingBox = "0.7 0.7 2";
   pickupRadius = 0.75;

   // Foot Prints
   decalData   = FemaleFootprint;
   decalOffset = 0.06;

   dustEmitter = LiftoffDustEmitter;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 70;
   jumpSurfaceAngle = 80;
   maxStepHeight = 1.5;
};

// Load the weapon script
exec("./weapon.cs");
