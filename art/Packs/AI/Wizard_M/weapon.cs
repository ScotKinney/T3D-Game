////////////////////////////////WizardStaff for Wizard////////////////////////////////////////////////

datablock GameBaseData(wiz_attack1)
{
   seqName = "attack1";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock GameBaseData(wiz_attack2)
{
   seqName = "attack2";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 40;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 500;
   swingSound = SwordSwing1Sound;
   impulse = 200;
};

datablock ShapeBaseImageData(WizardStaffImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Wizard_M/WizardStaff.dts";

   // Here are the Attacks we support
   hthNumAttacks = 2;
   hthAttack[0]                     = wiz_attack1;
   hthAttack[1]                     = wiz_attack2;

   // No sounds for when a staff hits a player or object
   hitStaticSound = "";
   hitLiveSound = "";
};
