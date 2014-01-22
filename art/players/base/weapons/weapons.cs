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
singleton GameBaseData(Punch1_RH)
{
   seqName = "Punch1_RH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = .5;
   //soundDelay = 400;
   //swingSound = PunchComboSound;
   impulse = 200;
};

singleton GameBaseData(Punch2_RH)
{
   seqName = "Punch2_RH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 200;
};

singleton GameBaseData(Punch3_RH)
{
   seqName = "Punch3_RH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 600;
   //swingSound = Punch1Sound;
   impulse = 200;
};

singleton GameBaseData(Punch4_RH)
{
   seqName = "Punch4_RH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 200;
};

datablock ShapeBaseImageData(RightHandImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/RHand.dts";
   mountPoint = 0;

   // Here are the Attacks we support
   hthNumAttacks = 4;
   hthAttack[0]                     = Punch1_RH;
   hthAttack[1]                     = Punch2_RH;
   hthAttack[2]                     = Punch3_RH;
   hthAttack[3]                     = Punch4_RH;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "Punch1Sound";
};

////////////////////////////////Left Hand///////////////////////////////////////
singleton GameBaseData(Punch1_LH)
{
   seqName = "Punch1_LH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = 5;
   //soundDelay = 400;
   //swingSound = PunchComboSound;
   impulse = 200;
};

singleton GameBaseData(Punch2_LH)
{
   seqName = "Punch2_LH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 200;
};

singleton GameBaseData(Punch3_LH)
{
   seqName = "Punch3_LH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 600;
   //swingSound = Punch1Sound;
   impulse = 200;
};

singleton GameBaseData(Punch4_LH)
{
   seqName = "Punch4_LH";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 500;
   //swingSound = Punch1Sound;
   impulse = 200;
};

datablock ShapeBaseImageData(LeftHandImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/LHand.dts";
   mountPoint = 2;

   // Here are the Attacks we support
   hthNumAttacks = 4;
   hthAttack[0]                     = Punch1_LH;
   hthAttack[1]                     = Punch2_LH;
   hthAttack[2]                     = Punch3_LH;
   hthAttack[3]                     = Punch4_LH;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "Punch1Sound";
};

////////////////////////////////Right Foot//////////////////////////////////////
singleton GameBaseData(Kick1_RF)
{
   seqName = "Kick1_RF";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 400;
   //swingSound = Kick1Sound;
   impulse = 250;
};

singleton GameBaseData(Kick2_RF)
{
   seqName = "Kick2_RF";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0;
   endDamage = .5;
   //soundDelay = 500;
   //swingSound = Kick1Sound;
   impulse = 250;
};

singleton GameBaseData(Kick3_RF)
{
   seqName = "Kick3_RF";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0;
   endDamage = .5;
   //soundDelay = 600;
   //swingSound = Kick1Sound;
   impulse = 250;
};

datablock ShapeBaseImageData(RightFootImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/RFoot.dts";
   mountPoint = 10;

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Kick1_RF;
   hthAttack[1]                     = Kick2_RF;
   hthAttack[2]                     = Kick3_RF;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "Kick1Sound";
};

////////////////////////////////Left Foot///////////////////////////////////////
singleton GameBaseData(Kick1_LF)
{
   seqName = "Kick1_LF";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0;
   endDamage = 0.5;
   //soundDelay = 400;
   //swingSound = Kick1Sound;
   impulse = 250;
};

singleton GameBaseData(Kick2_LF)
{
   seqName = "Kick2_LF";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0;
   endDamage = .5;
   //soundDelay = 500;
   //swingSound = Kick1Sound;
   impulse = 250;
};

singleton GameBaseData(Kick3_LF)
{
   seqName = "Kick3_LF";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0;
   endDamage = .5;
   //soundDelay = 600;
   //swingSound = Kick1Sound;
   impulse = 250;
};

datablock ShapeBaseImageData(LeftFootImage : BaseMeleeImage)
{
   shapefile = "art/players/base/weapons/LFoot.dts";
   mountPoint = 12;

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = Kick1_LF;
   hthAttack[1]                     = Kick2_LF;
   hthAttack[2]                     = Kick3_LF;

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
