//TolgartsAxe
datablock ProjectileData(TolgartsAxeProjectile : BaseProjectile)
{
   projectileShapeName = "art/Packs/AI/Tolgart/tolgartsaxe.dts";
   scale = ".8 .8 .8";
   muzzleVelocity = 35;
   directDamage = 35;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   radiusDamage = 0;
   damageRadius = 5;
   explosion = AxeHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "";
};

datablock ProjectileData(tolgartsAxeWetProjectile : TolgartsAxeProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(TolgartsAxeImage : BaseTriggeredImage)
{
   shapefile = "art/Packs/AI/Tolgart/tolgartsaxe.dts";
   scale = "1 1 1";
   projectile = TolgartsAxeProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = TolgartsAxeWetProjectile;
   rearmDelay = 1000;
   fullSkelAnim = true;
   fireAnim = "Attack";
   fireSound = BaseThrowSound;
};
