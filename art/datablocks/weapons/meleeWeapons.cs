// All melee weapons that a player can carry in inventory and equip at any time

// Swing SFX
datablock SFXProfile(SwordSwing1Sound)
{
   filename = "art/sound/weapons/SwordSwing1";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(SwordSwing2Sound)
{
   filename = "art/sound/weapons/SwordSwing2";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(SwordSwing3Sound)
{
   filename = "art/sound/weapons/SwordSwing3";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(SwordHitLiveSound)
{
   filename = "art/sound/weapons/SwordHitLive";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(SwordHitStaticSound)
{
   filename = "art/sound/weapons/SwordHitStatic";
   description = AudioClose3d;
   preload = true;
};


//////////////// Sword attacks////////////////

singleton GameBaseData(SwordSwing1_LH)
{
   seqName = "SwordSwing1_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.4; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing1_RH)
{
   seqName = "SwordSwing1_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.4; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing2_LH)
{
   seqName = "SwordSwing2_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.35; //time in seconds during animation before damage is done
   endDamage = 0.6;
   soundDelay = 300; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};


singleton GameBaseData(SwordSwing2_RH)
{
   seqName = "SwordSwing2_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.35; //time in seconds during animation before damage is done
   endDamage = 0.6;
   soundDelay = 300; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing3_LH)
{
   seqName = "SwordSwing3_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.5; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing3_RH)
{
   seqName = "SwordSwing3_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.5; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing4_LH)
{
   seqName = "SwordSwing4_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.52; //time in seconds during animation before damage is done
   endDamage = 0.84;
   soundDelay = 520; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};


singleton GameBaseData(SwordSwing4_RH)
{
   seqName = "SwordSwing4_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.52; //time in seconds during animation before damage is done
   endDamage = 0.84;
   soundDelay = 520; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing5_LH)
{
   seqName = "SwordSwing5_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing5_RH)
{
   seqName = "SwordSwing5_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing6_LH)
{
   seqName = "SwordSwing6_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing6_RH)
{
   seqName = "SwordSwing6_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing7_LH)
{
   seqName = "SwordSwing7_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing7_RH)
{
   seqName = "SwordSwing7_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing8_RH)
{
   seqName = "SwordSwing8_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 500;
};


singleton GameBaseData(SwordSwing9_RH)
{
   seqName = "SwordSwing9_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing10_RH)
{
   seqName = "SwordSwing10_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing11_RH)
{
   seqName = "SwordSwing11_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 500;
};

singleton GameBaseData(SwordSwing12_RH)
{
   seqName = "SwordSwing12_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 500;
};


////////////Base Swords

////RightHand

// All Home World swords use the same attacks and sounds. Defined once and inherited.
datablock ShapeBaseImageData(AnnihilatorImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Swords/Annihilator.dts";
   item = AnnihilatorWeapon; //This is the name of the WEAPON that comes from the weapons table.

   hthNumAttacks = 12;
/* hthAttack[0]                     = SwordSwing1_LH;
   hthAttack[1]                     = SwordSwing2_LH;
   hthAttack[2]                     = SwordSwing3_LH;
   hthAttack[3]                     = SwordSwing4_LH;
   hthAttack[4]                     = SwordSwing5_LH;
   hthAttack[5]                     = SwordSwing6_LH;
   hthAttack[6]                     = SwordSwing7_LH;
*/
   hthAttack[0]                     = SwordSwing1_RH;
   hthAttack[1]                     = SwordSwing2_RH;
   hthAttack[2]                     = SwordSwing3_RH;
   hthAttack[3]                     = SwordSwing4_RH;
   hthAttack[4]                     = SwordSwing5_RH;
   hthAttack[5]                     = SwordSwing6_RH;
   hthAttack[6]                     = SwordSwing7_RH;
   hthAttack[7]                     = SwordSwing8_RH;
   hthAttack[8]                     = SwordSwing9_RH;
   hthAttack[9]                     = SwordSwing10_RH;
   hthAttack[10]                    = SwordSwing11_RH;
   hthAttack[11]                    = SwordSwing12_RH;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

/////////The rest of them based off the one above


datablock ShapeBaseImageData(AvengerImage : AnnihilatorImage)
{
   shapefile = "art/inv/weapons/Swords/Avenger.dts";
   item = AvengerWeapon;
};

datablock ShapeBaseImageData(WidowMakerImage : AnnihilatorImage)
{
   shapefile = "art/inv/weapons/Swords/WidowMaker.dts";
   item = WidowMakerWeapon;
};

datablock ShapeBaseImageData(DeathDealerImage : AnnihilatorImage)
{
   shapefile = "art/inv/weapons/Swords/DeathDealer.dts";
   item = DeathDealerWeapon;
};

datablock ShapeBaseImageData(SoulReaverImage : AnnihilatorImage)
{
   shapefile = "art/inv/weapons/Swords/SoulReaver.dts";
   item = SoulReaverWeapon;
};


////LeftHand

// All Home World swords use the same attacks and sounds. Defined once and inherited.
datablock ShapeBaseImageData(AnnihilatorLHImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Swords/AnnihilatorLH.dts";
   item = AnnihilatorLHWeapon; //This is the name of the WEAPON that comes from the weapons table.
   mountPoint = 4;
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)

   hthNumAttacks = 7;
   hthAttack[0]                     = SwordSwing1_LH;
   hthAttack[1]                     = SwordSwing2_LH;
   hthAttack[2]                     = SwordSwing3_LH;
   hthAttack[3]                     = SwordSwing4_LH;
   hthAttack[4]                     = SwordSwing5_LH;
   hthAttack[5]                     = SwordSwing6_LH;
   hthAttack[6]                     = SwordSwing7_LH;



   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

/////////The rest of them based off the one above


datablock ShapeBaseImageData(AvengerLHImage : AnnihilatorLHImage)
{
   shapefile = "art/inv/weapons/Swords/AvengerLH.dts";
   item = AvengerLHWeapon;
   mountPoint = 4;
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
};

datablock ShapeBaseImageData(WidowMakerLHImage : AnnihilatorLHImage)
{
   shapefile = "art/inv/weapons/Swords/WidowMakerLH.dts";
   item = WidowMakerLHWeapon;
   mountPoint = 4;
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
};

datablock ShapeBaseImageData(DeathDealerLHImage : AnnihilatorLHImage)
{
   shapefile = "art/inv/weapons/Swords/DeathDealerLH.dts";
   item = DeathDealerLHWeapon;
   mountPoint = 4;
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
};

datablock ShapeBaseImageData(SoulReaverLHImage : AnnihilatorLHImage)
{
   shapefile = "art/inv/weapons/Swords/SoulReaverLH.dts";
   item = SoulReaverLHWeapon;
   mountPoint = 4;
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
};


//////////////// 2H Sword Attacks////////////////

singleton GameBaseData(THS_Swing1)
{
   seqName = "2HS_Swing1";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing2)
{
   seqName = "2HS_Swing2";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing3)
{
   seqName = "2HS_Swing3";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing4)
{
   seqName = "2HS_Swing4";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing5)
{
   seqName = "2HS_Swing5";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing6)
{
   seqName = "2HS_Swing6";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing7)
{
   seqName = "2HS_Swing7";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing8)
{
   seqName = "2HS_Swing8";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing9)
{
   seqName = "2HS_Swing9";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing10)
{
   seqName = "2HS_Swing10";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(THS_Swing11)
{
   seqName = "2HS_Swing11";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 80;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};


//////////////2 Handed Swords

datablock ShapeBaseImageData(SkullSplitterImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Swords/SkullSplitter.dts";
   item = SkullSplitterWeapon; //This is the name of the WEAPON that comes from the weapons table.
   usesBothHands = true;

   hthNumAttacks = 11;

   hthAttack[0]                     = THS_Swing1;
   hthAttack[1]                     = THS_Swing2;
   hthAttack[2]                     = THS_Swing3;
   hthAttack[3]                     = THS_Swing4;
   hthAttack[4]                     = THS_Swing5;
   hthAttack[5]                     = THS_Swing6;
   hthAttack[6]                     = THS_Swing7;
   hthAttack[7]                     = THS_Swing8;
   hthAttack[8]                     = THS_Swing9;
   hthAttack[9]                     = THS_Swing10;
   hthAttack[10]                    = THS_Swing11;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

datablock ShapeBaseImageData(DecimatorImage : SkullSplitterImage)
{
   shapefile = "art/inv/weapons/Swords/Decimator.dts";
   item = DecimatorWeapon;
};

datablock ShapeBaseImageData(BoneCrusherImage : SkullSplitterImage)
{
   shapefile = "art/inv/weapons/Swords/BoneCrusher.dts";
   item = BoneCrusherWeapon;
};


////////////////////////SHIELDS///////////////////////////////

/////////////////Buckler Shield Attacks//////////////

singleton GameBaseData(BShield1)
{
   seqName = "Shield1_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 25;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 250;
};

singleton GameBaseData(BShield2)
{
   seqName = "Shield2_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 25;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 250;
};

singleton GameBaseData(BShield3)
{
   seqName = "Shield3_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 25;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 250;
};

singleton GameBaseData(BShield3)
{
   seqName = "Shield4_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 25;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 250;
};

/////////////////Targe Shield Attacks/////////////

singleton GameBaseData(TShield1)
{
   seqName = "Shield1_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 300;
};

singleton GameBaseData(TShield2)
{
   seqName = "Shield2_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 300;
};

singleton GameBaseData(TShield3)
{
   seqName = "Shield3_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 300;
};

singleton GameBaseData(TShield4)
{
   seqName = "Shield4_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 300;
};


//////////////// Wood Round Shield Attacks////////////////

singleton GameBaseData(WRShield1)
{
   seqName = "Shield1_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 40;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 400;
};

singleton GameBaseData(WRShield2)
{
   seqName = "Shield2_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 40;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 400;
};

singleton GameBaseData(WRShield3)
{
   seqName = "Shield3_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 40;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 400;
};

singleton GameBaseData(WRShield4)
{
   seqName = "Shield4_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 40;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 400;
};

//////////////// Wood Square Shield Attacks////////////////

singleton GameBaseData(WSShield1)
{
   seqName = "Shield1_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(WSShield2)
{
   seqName = "Shield2_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(WSShield3)
{
   seqName = "Shield3_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(WSShield4)
{
   seqName = "Shield4_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

//////////////// Heater Shield Attacks////////////////

singleton GameBaseData(HShield1)
{
   seqName = "Shield1_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 70;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 700;
};

singleton GameBaseData(HShield2)
{
   seqName = "Shield2_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 70;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 700;
};

singleton GameBaseData(HShield3)
{
   seqName = "Shield3_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 70;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 700;
};

singleton GameBaseData(HShield4)
{
   seqName = "Shield4_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 70;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 700;
};

//////////////// Golden Shield Attacks////////////////

singleton GameBaseData(GShield1)
{
   seqName = "Shield1_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 100;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 1000;
};

singleton GameBaseData(GShield2)
{
   seqName = "Shield2_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 100;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 1000;
};

singleton GameBaseData(GShield3)
{
   seqName = "Shield3_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 100;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 1000;
};

singleton GameBaseData(GShield4)
{
   seqName = "Shield4_LH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 100;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 1000;
};

///////Buckler Shield Images

datablock ShapeBaseImageData(ShieldBucklerAImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldBucklerA.dts";
   item = Buckler_Shield_IWeapon; //This is the name of the WEAPON that comes from the weapons table.
   canUseMounted = true;
   mountPoint = 4;
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)

   hthNumAttacks = 4;
   hthAttack[0]                     = BShield1;
   hthAttack[1]                     = BShield2;
   hthAttack[2]                     = BShield3;
   hthAttack[3]                     = BShield4;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

datablock ShapeBaseImageData(ShieldBucklerBImage : ShieldBucklerAImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldBucklerB.dts";
   item = Buckler_Shield_IIWeapon;
};

datablock ShapeBaseImageData(ShieldBucklerCImage : ShieldBucklerAImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldBucklerC.dts";
   item = Buckler_Shield_IIIWeapon;
};

///////Targe Shield Images

datablock ShapeBaseImageData(ShieldTargeAImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldTargeA.dts";
   item = Targe_Shield_IWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = true;
   mountPoint = 4;

   hthNumAttacks = 4;

   hthAttack[0]                     = TShield1;
   hthAttack[1]                     = TShield2;
   hthAttack[2]                     = TShield3;
   hthAttack[3]                     = TShield4;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

datablock ShapeBaseImageData(ShieldTargeBImage : ShieldBucklerAImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldTargeB.dts";
   item = Targe_Shield_IIWeapon;
};

datablock ShapeBaseImageData(ShieldTargeCImage : ShieldBucklerAImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldTargeC.dts";
   item = Targe_Shield_IIIWeapon;
};


///////Wooden Round Shield Images

datablock ShapeBaseImageData(RoundShieldImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldRoundNub.dts";
   item = Round_Shield_IWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = true;
   mountPoint = 4;

   hthNumAttacks = 4;
   hthAttack[0]                     = WRShield1;
   hthAttack[1]                     = WRShield2;
   hthAttack[2]                     = WRShield3;
   hthAttack[3]                     = WRShield4;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///////Wooden Square Shield Images

datablock ShapeBaseImageData(SquareShieldImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldSquare.dts";
   item = Square_Shield_IWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = true;
   mountPoint = 4;

   hthNumAttacks = 4;
   hthAttack[0]                     = WSShield1;
   hthAttack[1]                     = WSShield2;
   hthAttack[2]                     = WSShield3;
   hthAttack[3]                     = WSShield4;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///////Heater Shield Images

datablock ShapeBaseImageData(ShieldHeaterAImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldHeaterA.dts";
   item = Heater_Shield_IWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = true;
   mountPoint = 4;

   hthNumAttacks = 4;
   hthAttack[0]                     = HShield1;
   hthAttack[1]                     = HShield2;
   hthAttack[2]                     = HShield3;
   hthAttack[3]                     = HShield4;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

datablock ShapeBaseImageData(ShieldHeaterBImage : ShieldHeaterAImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldHeaterB.dts";
   item = Heater_Shield_IIWeapon;
};

datablock ShapeBaseImageData(ShieldHeaterCImage : ShieldHeaterAImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldHeaterC.dts";
   item = Heater_Shield_IIIWeapon;
};


//////////////////Golden Shield

datablock ShapeBaseImageData(ShieldGoldImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Shields/ShieldGold.dts";
   item = Golden_ShieldWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = true;
   mountPoint = 4;

   hthNumAttacks = 4;
   hthAttack[0]                     = GShield1;
   hthAttack[1]                     = GShield2;
   hthAttack[2]                     = GShield3;
   hthAttack[3]                     = GShield4;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///////////////////War Axes////////////////////////


/////////////Paralyzer War Axe/////////////////

/////////////Paralyzer War Axe Attacks and Damage////////////////

singleton GameBaseData(ParalyzerSwing1 : SwordSwing1_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing2 : SwordSwing2_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing3 : SwordSwing3_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing4 : SwordSwing4_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing5 : SwordSwing5_RH)
{
   damageAmount = 70;
};

singleton GameBaseData(ParalyzerSwing6 : SwordSwing6_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing7 : SwordSwing7_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing8 : SwordSwing8_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing9 : SwordSwing9_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerSwing10 : SwordSwing10_RH)
{
   damageAmount = 70;
};

///////////////Paralyzer LH Swings

singleton GameBaseData(ParalyzerLHSwing1 : SwordSwing1_LH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerLHSwing2 : SwordSwing2_LH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerLHSwing3 : SwordSwing3_LH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerLHSwing4 : SwordSwing4_LH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerLHSwing5 : SwordSwing5_LH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerLHSwing6 : SwordSwing6_LH)
{
   damageAmount = 70;
};
singleton GameBaseData(ParalyzerLHSwing7 : SwordSwing7_LH)
{
   damageAmount = 70;
};

datablock ShapeBaseImageData(ParalyzerImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/axes/Paralyzer.dts";
   item = ParalyzerWeapon; //This is the name of the WEAPON that comes from the weapons table.

   hthNumAttacks = 10;
   hthAttack[0]                     = ParalyzerSwing1;
   hthAttack[1]                     = ParalyzerSwing2;
   hthAttack[2]                     = ParalyzerSwing3;
   hthAttack[3]                     = ParalyzerSwing4;
   hthAttack[4]                     = ParalyzerSwing5;
   hthAttack[5]                     = ParalyzerSwing6;
   hthAttack[6]                     = ParalyzerSwing7;
   hthAttack[7]                     = ParalyzerSwing8;
   hthAttack[8]                     = ParalyzerSwing9;
   hthAttack[9]                     = ParalyzerSwing10;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///LH Paralyzer

datablock ShapeBaseImageData(ParalyzerLHImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/axes/ParalyzerLH.dts";
   item = ParalyzerLHWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = false;
   mountPoint = 4;

   hthNumAttacks = 7;
   hthAttack[0]                     = ParalyzerLHSwing1;
   hthAttack[1]                     = ParalyzerLHSwing2;
   hthAttack[2]                     = ParalyzerLHSwing3;
   hthAttack[3]                     = ParalyzerLHSwing4;
   hthAttack[4]                     = ParalyzerLHSwing5;
   hthAttack[5]                     = ParalyzerLHSwing6;
   hthAttack[6]                     = ParalyzerLHSwing7;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///////////////END Paralyzer War Axe



///////////////////////////Equalizer War Axe ///////////////

/////////////Equalizer War Axe Attacks and Damage////////////////

singleton GameBaseData(EqualizerSwing1 : SwordSwing1_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing2 : SwordSwing2_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing3 : SwordSwing3_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing4 : SwordSwing4_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing5 : SwordSwing5_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing6 : SwordSwing6_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing7 : SwordSwing7_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing8 : SwordSwing8_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing9 : SwordSwing9_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerSwing10 : SwordSwing10_RH)
{
   damageAmount = 80;
};

///////////////Equalizer LH Swings

singleton GameBaseData(EqualizerLHSwing1 : SwordSwing1_LH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerLHSwing2 : SwordSwing2_LH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerLHSwing3 : SwordSwing3_LH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerLHSwing4 : SwordSwing4_LH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerLHSwing5 : SwordSwing5_LH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerLHSwing6 : SwordSwing6_LH)
{
   damageAmount = 80;
};
singleton GameBaseData(EqualizerLHSwing7 : SwordSwing7_LH)
{
   damageAmount = 80;
};


datablock ShapeBaseImageData(EqualizerImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Axes/Equalizer.dts";
   item = EqualizerWeapon;

   hthNumAttacks = 10;
   hthAttack[0]                     = EqualizerSwing1;
   hthAttack[1]                     = EqualizerSwing2;
   hthAttack[2]                     = EqualizerSwing3;
   hthAttack[3]                     = EqualizerSwing4;
   hthAttack[4]                     = EqualizerSwing5;
   hthAttack[5]                     = EqualizerSwing6;
   hthAttack[6]                     = EqualizerSwing7;
   hthAttack[7]                     = EqualizerSwing8;
   hthAttack[8]                     = EqualizerSwing9;
   hthAttack[9]                     = EqualizerSwing10;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///LH Equalizer

datablock ShapeBaseImageData(EqualizerLHImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/axes/EqualizerLH.dts";
   item = EqualizerLHWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = false;
   mountPoint = 4;

   hthNumAttacks = 7;
   hthAttack[0]                     = EqualizerLHSwing1;
   hthAttack[1]                     = EqualizerLHSwing2;
   hthAttack[2]                     = EqualizerLHSwing3;
   hthAttack[3]                     = EqualizerLHSwing4;
   hthAttack[4]                     = EqualizerLHSwing5;
   hthAttack[5]                     = EqualizerLHSwing6;
   hthAttack[6]                     = EqualizerLHSwing7;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

/////////////END Equalizer War Axe//////////////////


///////////Liberator War Axe////////////////////

///////////Liberator War Axe Attacks////////////////

singleton GameBaseData(LiberatorSwing1 : SwordSwing1_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing2 : SwordSwing2_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing3 : SwordSwing3_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing4 : SwordSwing4_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing5 : SwordSwing5_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing6 : SwordSwing6_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing7 : SwordSwing7_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing8 : SwordSwing8_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing9 : SwordSwing9_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorSwing10 : SwordSwing10_RH)
{
   damageAmount = 60;
};

///////////////Liberator LH Swings

singleton GameBaseData(LiberatorLHSwing1 : SwordSwing1_LH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorLHSwing2 : SwordSwing2_LH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorLHSwing3 : SwordSwing3_LH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorLHSwing4 : SwordSwing4_LH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorLHSwing5 : SwordSwing5_LH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorLHSwing6 : SwordSwing6_LH)
{
   damageAmount = 60;
};
singleton GameBaseData(LiberatorLHSwing7 : SwordSwing7_LH)
{
   damageAmount = 60;
};


datablock ShapeBaseImageData(LiberatorImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Axes/Liberator.dts";
   item = LiberatorWeapon;

   hthNumAttacks = 10;
   hthAttack[0]                     = LiberatorSwing1;
   hthAttack[1]                     = LiberatorSwing2;
   hthAttack[2]                     = LiberatorSwing3;
   hthAttack[3]                     = LiberatorSwing4;
   hthAttack[4]                     = LiberatorSwing5;
   hthAttack[5]                     = LiberatorSwing6;
   hthAttack[6]                     = LiberatorSwing7;
   hthAttack[7]                     = LiberatorSwing8;
   hthAttack[8]                     = LiberatorSwing9;
   hthAttack[9]                     = LiberatorSwing10;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///LH Liberator

datablock ShapeBaseImageData(LiberatorLHImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/axes/LiberatorLH.dts";
   item = LiberatorLHWeapon; //This is the name of the WEAPON that comes from the weapons table.
   weaponSlot = 1;   // Secondary weapon slot (Left Hand)
   canUseMounted = false;
   mountPoint = 4;

   hthNumAttacks = 7;
   hthAttack[0]                     = LiberatorLHSwing1;
   hthAttack[1]                     = LiberatorLHSwing2;
   hthAttack[2]                     = LiberatorLHSwing3;
   hthAttack[3]                     = LiberatorLHSwing4;
   hthAttack[4]                     = LiberatorLHSwing5;
   hthAttack[5]                     = LiberatorLHSwing6;
   hthAttack[6]                     = LiberatorLHSwing7;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};
///////////END Liberator War Axe////////////////////

///////////Staffs///////////////////////

///////////Staff Attacks////////////////

singleton GameBaseData(Staff_Swing1)
{
   seqName = "Staff_Swing1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

singleton GameBaseData(Staff_Swing2)
{
   seqName = "Staff_Swing2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

singleton GameBaseData(Staff_Swing3)
{
   seqName = "Staff_Swing3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

singleton GameBaseData(Staff_Swing4)
{
   seqName = "Staff_Swing4";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

singleton GameBaseData(Staff_Swing5)
{
   seqName = "Staff_Swing5";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

singleton GameBaseData(Staff_Swing6)
{
   seqName = "Staff_Swing6";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock GameBaseData(Staff_Swing7)
{
   seqName = "Staff_Swing7";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock GameBaseData(Staff_Swing8)
{
   seqName = "Staff_Swing8";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock GameBaseData(Staff_Swing9)
{
   seqName = "Staff_Swing9";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock GameBaseData(Staff_Swing10)
{
   seqName = "Staff_Swing10";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock ShapeBaseImageData(WizardsStaffImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Staffs/WizardsStaff.dts";
   item = WizardsStaffWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 10;
   hthAttack[0]                     = Staff_Swing1;
   hthAttack[1]                     = Staff_Swing2;
   hthAttack[2]                     = Staff_Swing3;
   hthAttack[3]                     = Staff_Swing4;
   hthAttack[4]                     = Staff_Swing5;
   hthAttack[5]                     = Staff_Swing6;
   hthAttack[6]                     = Staff_Swing7;
   hthAttack[7]                     = Staff_Swing8;
   hthAttack[8]                     = Staff_Swing9;
   hthAttack[9]                     = Staff_Swing10;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

datablock ShapeBaseImageData(DoomImage : WizardsStaffImage)
{
   shapefile = "art/inv/weapons/Staffs/Doom.dts";
   item = DoomWeapon;
};

datablock ShapeBaseImageData(FuryImage : WizardsStaffImage)
{
   shapefile = "art/inv/weapons/Staffs/Fury.dts";
   item = FuryWeapon;
};

datablock ShapeBaseImageData(HavokImage : WizardsStaffImage)
{
   shapefile = "art/inv/weapons/Staffs/Havok.dts";
   item = HavokWeapon;
};

//////////////// Stone Pike Attacks ////////////////

singleton GameBaseData(SPikeThrust1)
{
   seqName = "Spear_Thrust1_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.5;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 300;
};

singleton GameBaseData(SPikeThrust2)
{
   seqName = "Spear_Thrust2_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.5;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 300;
};

singleton GameBaseData(SPikeThrust3)
{
   seqName = "Spear_Thrust3_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.5;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 300;
};

datablock ShapeBaseImageData(StonePikeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/spears/SpearStone_melee.dts";
   item = StonePikeWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = SPikeThrust1;
   hthAttack[1]                     = SPikeThrust2;
   hthAttack[2]                     = SPikeThrust3;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

//////////////// Iron Pike Attacks ////////////////

singleton GameBaseData(IPikeThrust1)
{
   seqName = "Spear_Thrust1_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.5;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(IPikeThrust2)
{
   seqName = "Spear_Thrust2_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.5;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

singleton GameBaseData(IPikeThrust3)
{
   seqName = "Spear_Thrust3_RH";
   fullSkelAnim = true;
   timeScale = 1; //speed the animation plays at
   damageAmount = 30;
   startDamage = 0; //time in seconds during animation before damage is done
   endDamage = 0.5;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 500;
};

datablock ShapeBaseImageData(IronPikeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/spears/SpearIron_melee.dts";
   item = IronPikeWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 3;
   hthAttack[0]                     = IPikeThrust1;
   hthAttack[1]                     = IPikeThrust2;
   hthAttack[2]                     = IPikeThrust3;


   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};
