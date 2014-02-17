// Boglins
datablock SFXProfile(BoglinDeathCry)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinDeathCry";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(BoglinPainCry)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinPainCry";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(BoglinHit1)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinHit1";
   description = AudioClose3d;
   preload = false;
};
datablock SFXProfile(BoglinHit2)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinHit2";
   description = AudioClose3d;
   preload = false;
};
datablock SFXProfile(BoglinHit3)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinHit3";
   description = AudioClose3d;
   preload = false;
};
datablock SFXProfile(BoglinHit4)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinHit4";
   description = AudioClose3d;
   preload = false;
};
datablock SFXProfile(BoglinHit5)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinHit5";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(BoglinAttack1)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinAttack1";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinAttack2)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinAttack2";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinAttack3)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinAttack3";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinAttack4)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinAttack4";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinAttack5)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinAttack5";
   description = AudioClose3D;
   preload = false;
};

datablock SFXProfile(BoglinFish1)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinFish1";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinFish2)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinFish2";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinFish3)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinFish3";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinFish4)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinFish4";
   description = AudioClose3D;
   preload = false;
};
datablock SFXProfile(BoglinFish5)
{
   fileName = "art/Packs/AI/Boglin/sound/BoglinFish5";
   description = AudioClose3D;
   preload = false;
};

datablock PlayerData(Boglin : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/Boglin/boglin.dts";
   
   maxDamage = 200;
   maxForwardSpeed = 2;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   run2Speed = 1;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   //Weapon = "bomb";
   Weapon = "club";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 2.0;
   minRange = 0;
   distDetect = 55;
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
   killerName = "a Boglin";
   cameraMaxDist = 3;
   computeCRC = true;

   //Death Cry
   DeathSound = BoglinDeathCry;
   
   numPainSounds = 6;
   PainSound[0] = BoglinHit1;
   PainSound[1] = BoglinHit2;
   PainSound[2] = BoglinHit3;
   PainSound[3] = BoglinHit4;
   PainSound[4] = BoglinHit5;
   PainSound[5] = BoglinPainCry;

   numAttackSounds = 5;
   AttackSound[0] = BoglinAttack1;
   AttackSound[1] = BoglinAttack2;
   AttackSound[2] = BoglinAttack3;
   AttackSound[3] = BoglinAttack4;
   AttackSound[4] = BoglinAttack5;

   numDeathAnims = 1;
   numDamageAnims = 2;

   boundingBox = "0.8 0.8 1.5";
   swimBoundingBox = "0.8 0.8 1.5";

   // Foot Prints
   decalData   = PlayerFootprint;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 60;
   maxStepHeight = 2;  //This get's multiplied by scale and boglins are 1 scale

   // Add the shield to the left hand ("Mount1")
   equipmentSlots = 1;
   eqShape[0] = "art/Packs/AI/Boglin/BoglinShield.dts";
   eqNode[0] = "mount2";
};

datablock PlayerData(BoglinBig : Boglin)
{
   maxDamage = 300;
};

// Load the Boglin weapon
exec("./weapon.cs");
