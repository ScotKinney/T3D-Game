/// Death Cries
datablock SFXProfile(GnomeDeathCry1)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeDeathCry1";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeDeathCry2)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeDeathCry2";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeDeathCry3)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeDeathCry3";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeDeathCry4)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeDeathCry4";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeDeathCry5)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeDeathCry5";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeDeathCry6)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeDeathCry6";
   description = AudioClose3d;
   preload = false;
};


/// Pain Cries
datablock SFXProfile(GnomePain1)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry1";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain2)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry2";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain3)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry3";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain4)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry4";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain5)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry5";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain6)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry6";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain7)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry7";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain8)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry8";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomePain9)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePainCry9";
   description = AudioClose3d;
   preload = false;
};

/// Attack sounds (Taunts)
datablock SFXProfile(GnomeTaunt1)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeTaunt1";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeTaunt2)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeTaunt2";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeTaunt3)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeTaunt3";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeTaunt4)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeTaunt4";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeTaunt5)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeTaunt5";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(GnomeTaunt6)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomeTaunt6";
   description = AudioClose3d;
   preload = false;
};

////////////////////////PubTalk SFX

datablock SFXProfile(GnomePubTalk)
{
   fileName = "art/Packs/AI/Gnome_Townie/sound/GnomePubTalk";
   description = AudioClose3d;
   preload = false;
};

///////////////////////////Gnome Townie Axe weapon

////////////////////////////////GnomeAxe////////////////////////////////////////////////

singleton GameBaseData(AxeSwingOne)
{
   seqName = "Attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "SwordSwing1Sound";
   impulse = 400;
};

singleton GameBaseData(AxeSwingTwo)
{
   seqName = "Attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "SwordSwing2Sound";
   impulse = 400;
};

singleton GameBaseData(AxeSwingThree)
{
   seqName = "Attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "";
   impulse = 400;
};

singleton GameBaseData(AxeSwingFour)
{
   seqName = "Attack4";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "SwordSwing3Sound";
   impulse = 400;
};

datablock ShapeBaseImageData(GnomeAxeImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Gnome_Townie/GT_axe.dts";
   item = GnomeAxeWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 4;
   hthAttack[0]                     = AxeSwingOne;
   hthAttack[1]                     = AxeSwingTwo;
   hthAttack[2]                     = AxeSwingThree;
   hthAttack[3]                     = AxeSwingFour;

   // Sounds for when an Axe hits a player or object
   hitStaticSound = "SwordHitStaticSound";
   hitLiveSound = "SwordHitLiveSound";
};


////////////////////Gnome Townie datablock

datablock PlayerData(GnomeTownie : DefaultPlayerData)
{
   renderFirstPerson = false;

   shapeFile = "art/Packs/AI/Gnome_Townie/GT.dts";
   
   maxDamage = 200;
   maxForwardSpeed = 2;
   maxBackwardSpeed = 2;
   maxSideSpeed = 1;
   
   //AI specific values that can be set for this datablock
   //These values can be overridden by the spawn marker,
   //but these values override the defaults
   Weapon = "";
   respawn = true;
   behavior = "GuardBehavior";
   maxRange = 2.0;
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
   killerName = "a Gnome";
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
   numDamageAnims = 4;

   boundingBox = ".75 .75 1.5";//LR-FB-UpDN - Torque Physics
   swimBoundingBox = "1 1 1";

   // Foot Prints
   decalData   = PlayerFootprint;
   decalOffset = 0.25;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 60;
   jumpSurfaceAngle = 60;
   maxStepHeight = 2;  //This get's multiplied by scale and gnomes are 1 scale
};

////////////////////Gnome Townie Talker datablock

datablock PlayerData(GnomeTalker : GnomeTownie)
{
   shapeFile = "art/Packs/AI/Gnome_Townie/GT_Talker.dts";
   paceDist = 0;
   behavior = "StationaryNPCBehavior";
   canMove = false;
   returnToMarker = true;
   npcAction = 0;
   realName = "Norm";
   canTalk = true;
   talkDuration = 11000; // 11 Seconds
};

////////////////////Gnome Townie Eater datablock

datablock PlayerData(GnomeEater : GnomeTownie)
{
   shapeFile = "art/Packs/AI/Gnome_Townie/GT_Eater.dts";
   paceDist = 0;
   behavior = "StationaryNPCBehavior";
   canMove = false;
   returnToMarker = true;
   npcAction = 0;
   realName = "Cliff";
};

datablock SFXProfile(GnomePubTalk)   
{   
   filename = "art/Packs/AI/Gnome_Townie/Sound/GnomePubTalk";   
   description = NPCVoice3D;   
   preload = false;   
}; 

function GnomeTalker::clickedByPlayer(%this, %obj, %player)
{  // Start the Gnome's talk animation and sound effect
   if ( %obj.isTalking )
      return;  // Already talking, so don't restart

   // Look at the player we're talking to
   %obj.setAimObject(%player, $AISK_CHAR_HEIGHT);

   %obj.setActionThread("T_LongTalk");
   %obj.talkAnimTimer = %obj.schedule(%this.talkDuration, "setActionThread", "Root");
   serverPlay3D(GnomePubTalk, %obj.getTransform());

   %obj.isTalking = true;
   %this.talkSeqTimer = %this.schedule(%this.talkDuration + 1000, "endTalkSequence", %obj);
}

function GnomeTalker::endTalkSequence(%this, %obj)
{
   %obj.isTalking = false;
   // Turn back to the eater
   %obj.setAimObject(Gnome_Eating);
}
