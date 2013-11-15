////////////////////////////////Boglin Club////////////////////////////////////////////////

singleton GameBaseData(ClubSwingOne)
{
   seqName = "Sword_Swing";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "";
   impulse = 400;
};

singleton GameBaseData(ClubSwingTwo)
{
   seqName = "Sword_Thrust";
   fullSkelAnim = true;
   timeScale = 1;
   damageAmount = 20;
   startDamage = 0.2;
   endDamage = 1.3;
   soundDelay = 0;
   swingSound = "";
   impulse = 400;
};

datablock ShapeBaseImageData(ClubImage : BaseMeleeImage)
{
   shapefile = "art/Packs/AI/Boglin/weapon/Club.dts";
   item = ClubWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.

   // Here are the Attacks we support
   hthNumAttacks = 2;
   hthAttack[0]                     = ClubSwingOne;
   hthAttack[1]                     = ClubSwingTwo;

   // No sounds for when a club hits a player or object
   hitStaticSound = "";
   hitLiveSound = "";
};
