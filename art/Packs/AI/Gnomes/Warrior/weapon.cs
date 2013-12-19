singleton GameBaseData(GW_AxeSwingOne)
{
   seqName = "Attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 10;
   startDamage = 0.4;
   endDamage = 0.5;
   soundDelay = 0;
   swingSound = "SwordSwing1Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingTwo)
{
   seqName = "Attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.5;
   endDamage = 0.6;
   soundDelay = 0;
   swingSound = "SwordSwing2Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingThree)
{
   seqName = "Attack3";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 25;
   startDamage = 0.5;
   endDamage = 0.54;
   soundDelay = 0;
   swingSound = "SwordSwing3Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingFour)
{
   seqName = "Attack4";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.15;
   endDamage = 0.6;
   soundDelay = 0;
   swingSound = "SwordSwing1Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingFive)
{
   seqName = "Attack5";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.49;
   endDamage = 0.68;
   soundDelay = 0;
   swingSound = "SwordSwing2Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingSix)
{
   seqName = "Attack6";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.78;
   endDamage = 0.83;
   soundDelay = 0;
   swingSound = "SwordSwing3Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingSeven)
{
   seqName = "Attack7";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.74;
   endDamage = 0.87;
   soundDelay = 0;
   swingSound = "SwordSwing1Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingEight)
{
   seqName = "Attack8";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 1.8;
   endDamage = 1.9;
   soundDelay = 1000;
   swingSound = "SwordSwing2Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingNine)
{
   seqName = "Attack9";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 30;
   startDamage = 0.53;
   endDamage = 2.5;
   soundDelay = 0;
   swingSound = "SwordSwing3Sound";
   impulse = 200;
};

singleton GameBaseData(GW_AxeSwingTen)
{
   seqName = "Attack10";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 30;
   startDamage = 0.53;
   endDamage = 3.0;
   soundDelay = 0;
   swingSound = "SwordSwing1Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingEleven)
{
   seqName = "Attack11";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 30;
   startDamage = 0.83;
   endDamage = 1.0;
   soundDelay = 0;
   swingSound = "SwordSwing2Sound";
   impulse = 100;
};

singleton GameBaseData(GW_AxeSwingTwelve)
{
   seqName = "Attack12";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.68;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "SwordSwing3Sound";
   impulse = 300;
};

datablock ShapeBaseImageData(GW_AxeImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Gnomes/Warrior/GW_Axe.dts";


   // Here are the Attacks we support
   hthNumAttacks = 12;
   hthAttack[0]                     = GW_AxeSwingOne;
   hthAttack[1]                     = GW_AxeSwingTwo;
   hthAttack[2]                     = GW_AxeSwingThree;
   hthAttack[3]                     = GW_AxeSwingFour;
   hthAttack[4]                     = GW_AxeSwingFive;
   hthAttack[5]                     = GW_AxeSwingSix;
   hthAttack[6]                     = GW_AxeSwingSeven;
   hthAttack[7]                     = GW_AxeSwingEight;
   hthAttack[8]                     = GW_AxeSwingNine;
   hthAttack[9]                     = GW_AxeSwingTen;
   hthAttack[10]                     = GW_AxeSwingEleven;
   hthAttack[11]                     = GW_AxeSwingTwelve;

   // Sounds for when a club hits a player or object
   hitStaticSound = "SwordHitStaticSound";
   hitLiveSound = "SwordHitLiveSound";
};
