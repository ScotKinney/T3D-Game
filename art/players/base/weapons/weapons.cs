// Base player weapon datablocks

////////////////////////////////H2H Sounds//////////////////////////////////////
datablock SFXProfile(Punch1Sound)
{
   filename = "art/players/base/sound/Punch1";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(PunchComboSound)
{
   filename = "art/players/base/sound/PunchCombo";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(Kick1Sound)
{
   filename = "art/players/base/sound/Kick1";
   description = AudioClose3d;
   preload = true;
};

////////////////////////////////Right Hand//////////////////////////////////////
singleton GameBaseData(RH_PunchCombo)
{
   seqName = "RH_PunchCombo";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   //soundDelay = 400;
   //swingSound = PunchComboSound;
   impulse = 500;
};

singleton GameBaseData(RH_PunchDown)
{
   seqName = "RH_PunchDown";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.3;
   endDamage = 0.6;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 700;
};

singleton GameBaseData(RH_PunchJab)
{
   seqName = "RH_PunchJab";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.65;
   endDamage = 0.85;
   //soundDelay = 600;
   //swingSound = Punch1Sound;
   impulse = 500;
};

singleton GameBaseData(RH_PunchRound)
{
   seqName = "RH_PunchRound";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.50;
   endDamage = 0.73;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 700;
};

datablock ShapeBaseImageData(RightHandImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/RHand.dts";
   mountPoint = 0;

   // Here are the Attacks we support
   hthNumAttacks = 4;
   hthAttack[0]                     = RH_PunchCombo;
   hthAttack[1]                     = RH_PunchDown;
   hthAttack[2]                     = RH_PunchJab;
   hthAttack[3]                     = RH_PunchRound;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "Punch1Sound";
};

////////////////////////////////Left Hand///////////////////////////////////////
singleton GameBaseData(LH_PunchCombo)
{
   seqName = "LH_PunchCombo";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   //soundDelay = 400;
   //swingSound = PunchComboSound;
   impulse = 500;
};

singleton GameBaseData(LH_PunchDown)
{
   seqName = "LH_PunchDown";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.3;
   endDamage = 0.6;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 700;
};

singleton GameBaseData(LH_PunchJab)
{
   seqName = "LH_PunchJab";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.65;
   endDamage = 0.85;
   //soundDelay = 600;
   //swingSound = Punch1Sound;
   impulse = 500;
};

singleton GameBaseData(LH_PunchRound)
{
   seqName = "LH_PunchRound";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.50;
   endDamage = 0.73;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 700;
};

datablock ShapeBaseImageData(LeftHandImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/LHand.dts";
   mountPoint = 2;

   // Here are the Attacks we support
   hthNumAttacks = 4;
   hthAttack[0]                     = LH_PunchCombo;
   hthAttack[1]                     = LH_PunchDown;
   hthAttack[2]                     = LH_PunchJab;
   hthAttack[3]                     = LH_PunchRound;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "Punch1Sound";
};

////////////////////////////////Right Foot//////////////////////////////////////
singleton GameBaseData(RF_KickHigh)
{
   seqName = "RF_KickHigh";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.5;
   endDamage = 0.6;
   //soundDelay = 400;
   //swingSound = Kick1Sound;
   impulse = 1200;
};

singleton GameBaseData(RF_KickLow)
{
   seqName = "RF_KickLow";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.55;
   endDamage = .75;
   //soundDelay = 500;
   //swingSound = Kick1Sound;
   impulse = 1200;
};

singleton GameBaseData(RF_SpinKick1)
{
   seqName = "RF_SpinKick1";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.6;
   endDamage = .73;
   //soundDelay = 600;
   //swingSound = Kick1Sound;
   impulse = 1200;
};

datablock ShapeBaseImageData(RightFootImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/RFoot.dts";
   mountPoint = 10;

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = RF_KickHigh;
   hthAttack[1]                     = RF_KickLow;
   hthAttack[2]                     = RF_SpinKick1;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "Kick1Sound";
};

////////////////////////////////Left Foot///////////////////////////////////////
singleton GameBaseData(LF_KickHigh)
{
   seqName = "LF_KickHigh";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.5;
   endDamage = 0.6;
   //soundDelay = 400;
   //swingSound = Kick1Sound;
   impulse = 1200;
};

singleton GameBaseData(LF_KickLow)
{
   seqName = "LF_KickLow";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.55;
   endDamage = .75;
   //soundDelay = 500;
   //swingSound = Kick1Sound;
   impulse = 1200;
};

singleton GameBaseData(LF_SpinKick1)
{
   seqName = "LF_SpinKick1";
   fullSkelAnim = false;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.6;
   endDamage = .73;
   //soundDelay = 600;
   //swingSound = Kick1Sound;
   impulse = 1200;
};

datablock ShapeBaseImageData(LeftFootImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/LFoot.dts";
   mountPoint = 12;

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = LF_KickHigh;
   hthAttack[1]                     = LF_KickLow;
   hthAttack[2]                     = LF_SpinKick1;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "Kick1Sound";
};

function Player::equipBaseWeapons(%this, %weaponSlotUsed)
{
   if ( !%weaponSlotUsed )
   {
      %this.mountImage(RightHandImage, 0);
      %this.setImageAmmo(0, true);
   }

   %this.mountImage(LeftHandImage, 1);
   %this.setImageAmmo(1, true);

   %this.mountImage(RightFootImage, 2);
   %this.setImageAmmo(2, true);

   %this.mountImage(LeftFootImage, 3);
   %this.setImageAmmo(3, true);
}
