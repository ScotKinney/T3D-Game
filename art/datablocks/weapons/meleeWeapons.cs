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

singleton GameBaseData(SwordSwingOne)
{
   seqName = "Sword_Center";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.4; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 400; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingTwo)
{
   seqName = "Sword_Lunge";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.35; //time in seconds during animation before damage is done
   endDamage = 0.6;
   soundDelay = 300; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingThree)
{
   seqName = "Sword_Spin";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.5; //time in seconds during animation before damage is done
   endDamage = 0.8;
   soundDelay = 500; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingFour)
{
   seqName = "Sword_RHChop";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.52; //time in seconds during animation before damage is done
   endDamage = 0.84;
   soundDelay = 520; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingFive)
{
   seqName = "Sword_DubSwing";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.3; //time in seconds during animation before damage is done
   endDamage = 0.9;
   soundDelay = 316; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 800;
};

////////////Swords

// All swords use the same 5 attacks and sounds. Defined once and inherited.
datablock ShapeBaseImageData(ValMaleSwordImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/valsword/Sword_Val.dts";
   holsterShape = "art/inv/weapons/valsword/Sword_Val_Mounted.dts";
   item = ValMaleSwordWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   hthNumAttacks = 5;
   hthAttack[0]                     = SwordSwingOne;
   hthAttack[1]                     = SwordSwingTwo;
   hthAttack[2]                     = SwordSwingThree;
   hthAttack[3]                     = SwordSwingFour;
   hthAttack[4]                     = SwordSwingFive;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

/////////The Swords

datablock ShapeBaseImageData(ValFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/valsword/Sword_Val.dts";
   holsterShape = "art/inv/weapons/valsword/BF_SwordMtd_Val.dts";
   item = ValFemaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(MythMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/L_sword/longsword.dts";
   holsterShape = "art/inv/weapons/L_sword/LongSword_Mounted.dts";
   item = MythMaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(MythFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/L_sword/longsword.dts";
   holsterShape = "art/inv/weapons/L_sword/BF_LSword_Mtd.dts";
   item = MythFemaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(FJMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/scimi/scimitar1_4.dts";
   holsterShape = "art/inv/weapons/scimi/Scimitar_Mounted1_4.dts";
   item = FJMaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(FJFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/Scimi/scimitar1_4.dts";
   holsterShape = "art/inv/weapons/Scimi/Scimitar_BF_Mtd.dts";
   item = FJFemaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(KardMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   holsterShape = "art/inv/weapons/KarSword/SpartanSword_Mounted1_4.dts";
   item = KardMaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(KardFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   holsterShape = "art/inv/weapons/KarSword/BF_Sword_Kard_Mtd.dts";
   item = KardFemaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(TokMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/TokSword/SwordTok.dts";
   holsterShape = "art/inv/weapons/TokSword/SwordTok_Mounted.dts";
   item = TokMaleSwordWeapon;
   canH2H = false;
};

datablock ShapeBaseImageData(TokFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/TokSword/SwordTok.dts";
   holsterShape = "art/inv/weapons/TokSword/BF_Sword_Tok_Mtd.dts";
   item = TokFemaleSwordWeapon;
   canH2H = false;
};

///////////////////War Axes////////////////////////

/////////////Steel War Axe/////////////////

/////////////Steel War Axe Attacks and Damage////////////////

singleton GameBaseData(SteelWarAxeSwingOne : SwordSwingOne)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwingTwo : SwordSwingTwo)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwingThree : SwordSwingThree)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwingFour : SwordSwingFour)
{
   damageAmount = 70;
};
singleton GameBaseData(SteelWarAxeSwingFive : SwordSwingFive)
{
   damageAmount = 70;
};


datablock ShapeBaseImageData(SteelWarAxeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/axes/Axe_A.dts";
   item = SteelWarAxeWeapon; //This is the name of the WEAPON that comes from the weapons table.
   canH2H = false;

   hthNumAttacks = 5;
   hthAttack[0]                     = SteelWarAxeSwingOne;
   hthAttack[1]                     = SteelWarAxeSwingTwo;
   hthAttack[2]                     = SteelWarAxeSwingThree;
   hthAttack[3]                     = SteelWarAxeSwingFour;
   hthAttack[4]                     = SteelWarAxeSwingFive;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

///////////////END Steel War Axe



///////////////////////////Double War Axe ///////////////

/////////////Double War Axe Attacks and Damage////////////////

singleton GameBaseData(DoubleWarAxeSwingOne : SwordSwingOne)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwingTwo : SwordSwingTwo)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwingThree : SwordSwingThree)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwingFour : SwordSwingFour)
{
   damageAmount = 80;
};
singleton GameBaseData(DoubleWarAxeSwingFive : SwordSwingFive)
{
   damageAmount = 80;
};


datablock ShapeBaseImageData(DoubleWarAxeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Axes/Axe_B.dts";
   item = DoubleWarAxeWeapon;
   canH2H = false;

   hthNumAttacks = 5;
   hthAttack[0]                     = DoubleWarAxeSwingOne;
   hthAttack[1]                     = DoubleWarAxeSwingTwo;
   hthAttack[2]                     = DoubleWarAxeSwingThree;
   hthAttack[3]                     = DoubleWarAxeSwingFour;
   hthAttack[4]                     = DoubleWarAxeSwingFive;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};

/////////////END Double War Axe//////////////////


///////////Iron War Axe////////////////////

///////////Iron War Axe Attacks////////////////

singleton GameBaseData(IronWarAxeSwingOne : SwordSwingOne)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwingTwo : SwordSwingTwo)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwingThree : SwordSwingThree)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwingFour : SwordSwingFour)
{
   damageAmount = 60;
};
singleton GameBaseData(IronWarAxeSwingFive : SwordSwingFive)
{
   damageAmount = 60;
};

datablock ShapeBaseImageData(IronWarAxeImage : BaseMeleeImage)
{
   shapefile = "art/inv/weapons/Axes/Axe_C.dts";
   item = IronWarAxeWeapon;
   canH2H = false;

   hthNumAttacks = 5;
   hthAttack[0]                     = IronWarAxeSwingOne;
   hthAttack[1]                     = IronWarAxeSwingTwo;
   hthAttack[2]                     = IronWarAxeSwingThree;
   hthAttack[3]                     = IronWarAxeSwingFour;
   hthAttack[4]                     = IronWarAxeSwingFive;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};
