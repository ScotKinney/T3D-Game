////////////////////////////////Boglin Club////////////////////////////////////////////////

singleton GameBaseData(ClubSwingOne)
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

singleton GameBaseData(ClubSwingTwo)
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

singleton GameBaseData(ClubSwingThree)
{
   seqName = "Attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "SwordSwing2Sound";
   impulse = 400;
};

singleton GameBaseData(ClubSwingFour)
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

datablock ShapeBaseImageData(ClubImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Boglin/mace.dts";
   item = ClubWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 4;
   hthAttack[0]                     = ClubSwingOne;
   hthAttack[1]                     = ClubSwingTwo;
   hthAttack[2]                     = ClubSwingThree;
   hthAttack[3]                     = ClubSwingFour;

   // No sounds for when a club hits a player or object
   hitStaticSound = "SwordHitStaticSound";
   hitLiveSound = "SwordHitLiveSound";
};
