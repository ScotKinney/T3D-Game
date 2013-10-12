// Thrown weapons that the player can carry in inventory

datablock ProjectileData(daggerProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/dagger/dagger.dts";
   scale = "1 1 1";
   muzzleVelocity = 25;
   directDamage = 65;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   radiusDamage = 0;
   damageRadius = 5;
   explosion = DefaultHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   //armingDelay = 100;
   retrievable = "daggerWeapon";
};

datablock ProjectileData(daggerWetProjectile : daggerProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(DaggerImage : BaseTriggeredImage)
{
   shapefile = "art/inv/weapons/Dagger/Dagger.dts";
   scale = "1 1 1";
   //item = DaggerWeapon; //This is the name of the WEAPON that comes from the weapons table in aureus.
   projectile = DaggerProjectile;
   wetProjectile = DaggerWetProjectile;
   fireAnim = "Throw_HamAxe";
   fireSound = BaseThrowSound;
};

// Cheat to test weapons before we have the full inventory system implemented.
$MaleWeaponCycle = $MaleWeaponCycle TAB "DaggerImage";
$FemaleWeaponCycle = $FemaleWeaponCycle TAB "DaggerImage";

