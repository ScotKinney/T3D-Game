
datablock ProjectileData(IceBallProjectile : BaseProjectile)
{
   projectileShapeName = "art/Packs/AI/Yeti/weapon/IceBall.dts";
   scale="1 1 1";
   directDamage = 30;
   radiusDamage = 10;
   damageRadius = 10;

   explosion = ProjectileExplosion;
   waterExplosion = 0;
   areaImpulse = 100;
   shakeCamera = true;

   particleWaterEmitter = 0;
   lightDesc = 0;

   muzzleVelocity = 25;
   velInheritFactor = 1.0;

   lifetime = 30000;

   bounceElasticity = 0.4;
   bounceFriction = 0.01;
   gravityMod = 0.5;
   decal = 0;

   retrievable = "";
};

datablock ProjectileData(IceBallWetProjectile : IceBallProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.1;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(IceBallImage : BaseTriggeredImage)
{
   shapefile = "art/Packs/AI/Yeti/weapon/IceBall.dts";
   scale = "1 1 1";
   projectile = IceBallProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = IceBallWetProjectile;

   rearmDelay = 1000;
   fullSkelAnim = true;
   fireAnim = "Attack";
   fireSound = BaseFireSound;
};
