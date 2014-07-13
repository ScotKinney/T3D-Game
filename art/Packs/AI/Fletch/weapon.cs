// Old Fletch's Hammer
datablock GameBaseData(F_HammerOne)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1.5;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock GameBaseData(F_HammerTwo)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1.5;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 1; // time in ms before attack sound plays
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock ShapeBaseImageData(f_hammerImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Fletch/Weapon/f_hammer.dts";

   // Here are the Attacks we support
   hthNumAttacks = 2;
   hthAttack[0]                     = F_HammerOne;
   hthAttack[1]                     = F_HammerTwo;

   // The sound to play when this weapon hits a static object
   hitStaticSound = "SwordHitStaticSound";
   // The sound to play when this weapon hits another player or AI
   hitLiveSound = "SwordHitLiveSound";
};
