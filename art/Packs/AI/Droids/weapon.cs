
datablock ProjectileData(DroidGun5Projectile : BaseProjectile)
{
   projectileShapeName = "art/Packs/AI/Droids/weapon/5_56.dts";
   scale="1 1 1";
   muzzleVelocity = 50;
   directDamage = 50;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   radiusDamage = 0;
   damageRadius = 0;
   explosion = XRBoltsHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.0;
   decal = ScorchRXDecalSmall;

   retrievable = "";
};

datablock ShapeBaseImageData(DroidGun5Image : BaseAutoImage)
{
   shapefile = "art/Packs/AI/Droids/weapon/gun05.dts";
   scale = "1 1 1";
   projectile = DroidGun5Projectile;
   wetProjectile = DroidGun5Projectile;
   stateSound[3] = XR75FireSound;
   //stateTimeoutValue[3] = 0.05;
   stateTimeoutValue[5] = 0.05;
};
