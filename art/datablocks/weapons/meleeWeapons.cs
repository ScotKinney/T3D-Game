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


////////////Base Home World Swords

// All Home World swords use the same attacks and sounds. Defined once and inherited.
datablock ShapeBaseImageData(ValMaleSwordImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/valsword/Sword_Val.dts";
   holsterShape = "art/inv/weapons/valsword/Sword_Val_Mounted.dts";
   item = ValMaleSwordWeapon; //This is the name of the WEAPON that comes from the weapons table.
   canH2H = true;

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

datablock ShapeBaseImageData(ValFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/valsword/Sword_Val.dts";
   holsterShape = "art/inv/weapons/valsword/BF_SwordMtd_Val.dts";
   item = ValFemaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(MythMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/L_sword/longsword.dts";
   holsterShape = "art/inv/weapons/L_sword/LongSword_Mounted.dts";
   item = MythMaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(MythFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/L_sword/longsword.dts";
   holsterShape = "art/inv/weapons/L_sword/BF_LSword_Mtd.dts";
   item = MythFemaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(FJMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/scimi/scimitar1_4.dts";
   holsterShape = "art/inv/weapons/scimi/Scimitar_Mounted1_4.dts";
   item = FJMaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(FJFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/Scimi/scimitar1_4.dts";
   holsterShape = "art/inv/weapons/Scimi/Scimitar_BF_Mtd.dts";
   item = FJFemaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(KardMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   holsterShape = "art/inv/weapons/KarSword/SpartanSword_Mounted1_4.dts";
   item = KardMaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(KardFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   holsterShape = "art/inv/weapons/KarSword/BF_Sword_Kard_Mtd.dts";
   item = KardFemaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(TokMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/TokSword/SwordTok.dts";
   holsterShape = "art/inv/weapons/TokSword/SwordTok_Mounted.dts";
   item = TokMaleSwordWeapon;
   canH2H = true;
};

datablock ShapeBaseImageData(TokFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/TokSword/SwordTok.dts";
   holsterShape = "art/inv/weapons/TokSword/BF_Sword_Tok_Mtd.dts";
   item = TokFemaleSwordWeapon;
   canH2H = true;
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

datablock ShapeBaseImageData(ExcaliburSwordImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/TH_Swords/TH_SwordA.dts";
   item = Excalibur_SwordWeapon; //This is the name of the WEAPON that comes from the weapons table.
   canH2H = true;
   canUseMounted = false;

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

datablock ShapeBaseImageData(DecimatorSwordImage : ExcaliburSwordImage)
{
   shapefile = "art/inv/weapons/TH_Swords/TH_SwordB.dts";
   item = Decimator_SwordWeapon;
};

datablock ShapeBaseImageData(BoneCrusherSwordImage : ExcaliburSwordImage)
{
   shapefile = "art/inv/weapons/TH_Swords/TH_SwordC.dts";
   item = Bone_Crusher_SwordWeapon;
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
   canH2H = true;
   canUseMounted = true;
   mountPoint = 4;

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
   canH2H = true;
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
   canH2H = true;
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
   canH2H = true;
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
   canH2H = true;
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
   canH2H = true;
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

/////////////Steel War Axe/////////////////

/////////////Steel War Axe Attacks and Damage////////////////

singleton GameBaseData(SteelWarAxeSwing1 : SwordSwing1_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing2 : SwordSwing2_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing3 : SwordSwing3_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing4 : SwordSwing4_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing5 : SwordSwing5_RH)
{
   damageAmount = 70;
};

singleton GameBaseData(SteelWarAxeSwing6 : SwordSwing6_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing7 : SwordSwing7_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing8 : SwordSwing8_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing9 : SwordSwing9_RH)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwing10 : SwordSwing10_RH)
{
   damageAmount = 70;
};


datablock ShapeBaseImageData(SteelWarAxeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/axes/Axe_A.dts";
   item = Steel_War_AxeWeapon; //This is the name of the WEAPON that comes from the weapons table.
   canH2H = true;

   hthNumAttacks = 10;
   hthAttack[0]                     = SteelWarAxeSwing1;
   hthAttack[1]                     = SteelWarAxeSwing2;
   hthAttack[2]                     = SteelWarAxeSwing3;
   hthAttack[3]                     = SteelWarAxeSwing4;
   hthAttack[4]                     = SteelWarAxeSwing5;
   hthAttack[5]                     = SteelWarAxeSwing6;
   hthAttack[6]                     = SteelWarAxeSwing7;
   hthAttack[7]                     = SteelWarAxeSwing8;
   hthAttack[8]                     = SteelWarAxeSwing9;
   hthAttack[9]                     = SteelWarAxeSwing10;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///////////////END Steel War Axe



///////////////////////////Double War Axe ///////////////

/////////////Double War Axe Attacks and Damage////////////////

singleton GameBaseData(DoubleWarAxeSwing1 : SwordSwing1_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing2 : SwordSwing2_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing3 : SwordSwing3_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing4 : SwordSwing4_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing5 : SwordSwing5_RH)
{
   damageAmount = 80;
};

singleton GameBaseData(DoubleWarAxeSwing6 : SwordSwing6_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing7 : SwordSwing7_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing8 : SwordSwing8_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing9 : SwordSwing9_RH)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwing10 : SwordSwing10_RH)
{
   damageAmount = 80;
};


datablock ShapeBaseImageData(DoubleWarAxeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Axes/Axe_B.dts";
   item = Double_War_AxeWeapon;
   canH2H = true;

   hthNumAttacks = 10;
   hthAttack[0]                     = DoubleWarAxeSwing1;
   hthAttack[1]                     = DoubleWarAxeSwing2;
   hthAttack[2]                     = DoubleWarAxeSwing3;
   hthAttack[3]                     = DoubleWarAxeSwing4;
   hthAttack[4]                     = DoubleWarAxeSwing5;
   hthAttack[5]                     = DoubleWarAxeSwing6;
   hthAttack[6]                     = DoubleWarAxeSwing7;
   hthAttack[7]                     = DoubleWarAxeSwing8;
   hthAttack[8]                     = DoubleWarAxeSwing9;
   hthAttack[9]                     = DoubleWarAxeSwing10;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

/////////////END Double War Axe//////////////////


///////////Iron War Axe////////////////////

///////////Iron War Axe Attacks////////////////

singleton GameBaseData(IronWarAxeSwing1 : SwordSwing1_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing2 : SwordSwing2_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing3 : SwordSwing3_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing4 : SwordSwing4_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing5 : SwordSwing5_RH)
{
   damageAmount = 60;
};

singleton GameBaseData(IronWarAxeSwing6 : SwordSwing6_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing7 : SwordSwing7_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing8 : SwordSwing8_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing9 : SwordSwing9_RH)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwing10 : SwordSwing10_RH)
{
   damageAmount = 60;
};

datablock ShapeBaseImageData(IronWarAxeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Axes/Axe_C.dts";
   item = Iron_War_AxeWeapon;
   canH2H = true;

   hthNumAttacks = 10;
   hthAttack[0]                     = IronWarAxeSwing1;
   hthAttack[1]                     = IronWarAxeSwing2;
   hthAttack[2]                     = IronWarAxeSwing3;
   hthAttack[3]                     = IronWarAxeSwing4;
   hthAttack[4]                     = IronWarAxeSwing5;
   hthAttack[5]                     = IronWarAxeSwing6;
   hthAttack[6]                     = IronWarAxeSwing7;
   hthAttack[7]                     = IronWarAxeSwing8;
   hthAttack[8]                     = IronWarAxeSwing9;
   hthAttack[9]                     = IronWarAxeSwing10;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};
///////////END Iron War Axe////////////////////

///////////Wizards Staff for Players///////////////////////

///////////WizardsStaff Attacks////////////////

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
   shapefile = "art/inv/weapons/WizardStaff/WizardsStaff.dts";
   item = Wizards_StaffWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

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