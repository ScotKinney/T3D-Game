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

// The 5 attacks
singleton GameBaseData(SwordSwingOne)
{
   seqName = "Sword_Center";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.2; //time in seconds during animation before damage is done
   endDamage = 1.3;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = SwordSwing2Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingTwo)
{
   seqName = "Sword_Lunge";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.2; //time in seconds during animation before damage is done
   endDamage = 1.3;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingThree)
{
   seqName = "Sword_Spin";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.2; //time in seconds during animation before damage is done
   endDamage = 1.3;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingFour)
{
   seqName = "Sword_RHChop";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.2; //time in seconds during animation before damage is done
   endDamage = 1.3;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 800;
};

singleton GameBaseData(SwordSwingFive)
{
   seqName = "Sword_DubSwing";
   fullSkelAnim = false;
   timeScale = 1; //speed the animation plays at
   damageAmount = 50;
   startDamage = 0.2; //time in seconds during animation before damage is done
   endDamage = 1.3;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = SwordSwing3Sound;
   impulse = 800;
};

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
   hitStaticSound = "SwordHit1Sound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHit1Sound";
};

datablock ShapeBaseImageData(ValFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/valsword/Sword_Val.dts";
   holsterShape = "art/inv/weapons/valsword/BF_SwordMtd_Val.dts";
   item = ValFemaleSwordWeapon;
};

datablock ShapeBaseImageData(MythMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/L_sword/longsword.dts";
   holsterShape = "art/inv/weapons/L_sword/LongSword_Mounted.dts";
   item = MythMaleSwordWeapon;
};

datablock ShapeBaseImageData(MythFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/L_sword/longsword.dts";
   holsterShape = "art/inv/weapons/L_sword/BF_LSword_Mtd.dts";
   item = MythFemaleSwordWeapon;
};

datablock ShapeBaseImageData(FJMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/scimi/scimitar1_4.dts";
   holsterShape = "art/inv/weapons/scimi/Scimitar_Mounted1_4.dts";
   item = FJMaleSwordWeapon;
};

datablock ShapeBaseImageData(FJFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/Scimi/scimitar1_4.dts";
   holsterShape = "art/inv/weapons/Scimi/Scimitar_BF_Mtd.dts";
   item = FJFemaleSwordWeapon;
};

datablock ShapeBaseImageData(KardMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   holsterShape = "art/inv/weapons/KarSword/SpartanSword_Mounted1_4.dts";
   item = KardMaleSwordWeapon;
};

datablock ShapeBaseImageData(KardFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/KarSword/SpartanSword1_4.dts";
   holsterShape = "art/inv/weapons/KarSword/BF_Sword_Kard_Mtd.dts";
   item = KardFemaleSwordWeapon;
};

datablock ShapeBaseImageData(TokMaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/TokSword/SwordTok.dts";
   holsterShape = "art/inv/weapons/TokSword/SwordTok_Mounted.dts";
   item = TokMaleSwordWeapon;
};

datablock ShapeBaseImageData(TokFemaleSwordImage : ValMaleSwordImage)
{
   shapefile = "art/inv/weapons/TokSword/SwordTok.dts";
   holsterShape = "art/inv/weapons/TokSword/BF_Sword_Tok_Mtd.dts";
   item = TokFemaleSwordWeapon;
};

// Cheat to test weapons before we have the full weapons system implemented.
$MaleWeaponCycle = "RightHandImage" TAB "ValMaleSwordImage" TAB "MythMaleSwordImage"
   TAB "FJMaleSwordImage" TAB "KardMaleSwordImage" TAB "TokMaleSwordImage";
$FemaleWeaponCycle = "RightHandImage" TAB "ValFemaleSwordImage" TAB "MythFemaleSwordImage"
   TAB "FJFemaleSwordImage" TAB "KardFemaleSwordImage" TAB "TokFemaleSwordImage";
