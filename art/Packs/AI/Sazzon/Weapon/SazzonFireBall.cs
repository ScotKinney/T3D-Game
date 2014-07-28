// SazzonFireball SFX
datablock SFXProfile(SazzonFireballSound)
{
   filename = "art/Packs/AI/Sazzon/sound/fireball";
   description = AudioClose3d;
   preload = true;
};

///Sazzon Fireball Particle FX
datablock BillboardParticleData(ProjectileSazzonFireball)
{
   textureName = "core/art/particles/fireball.png";
   lifetimeMS = "300";
   lifetimeVarianceMS = "299";
   spinSpeed = "1";
   spinRandomMin = "-400";
   spinRandomMax = "0";
   animTexName = "core/art/particles/fireball.png";
   colors[0] = "1 0.897638 0.795276 0.2";
   colors[1] = "1 0.496063 0 0.6";
   colors[2] = "0.0944882 0.0944882 0.0944882 0";
   sizes[0] = "0.997986";
   sizes[1] = "1.99902";
   sizes[2] = "2.99701";
   times[1] = "0.498039";
   times[2] = "1";
   times[3] = "1";
   gravityCoefficient = "-2";
};

datablock SphereEmitterData(SazzonFireballEmitter)
{
   particles = "ProjectileSazzonFireball";
   blendStyle = "ADDITIVE";
   ejectionPeriodMS = "10";
   periodVarianceMS = "5";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0";
   thetaMax = "120";
};

///////////////////Sazzons Fireball Projectile

// Fireball
datablock ProjectileData(SazzonFireballProjectile : BaseProjectile)
{
   projectileShapeName = "art/Packs/AI/Sazzon/weapon/LavaRock.dts";
   scale="1 1 1";
   muzzleVelocity = 35;//25
   directDamage = 40;
   radiusDamage = 20;
   damageRadius = 5;
   directImplulse = 100;
   areaImpulse = 100;
   shakeCamera = true;
   particleEmitter = SazzonFireballEmitter;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
   explosion = 0;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.5;
   lifetime = 30000;//5000;
   fadeDelay = 5000;//5000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   bounceElasticity = 0.4;
   bounceFriction = 0.01;
   isBallistic = true;
   retrievable = "";
};

datablock ProjectileData(FireballWetProjectile : SazzonFireballProjectile)
{
   muzzleVelocity = 20;
   gravityMod = 0.1;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(SazzonFireballImage : BaseTriggeredImage)
{
   shapefile = "art/Packs/AI/Sazzon/weapon/LavaRock.dts";
   scale = "1 1 1";
   projectile = SazzonFireballProjectile;
   wetProjectile = FireballWetProjectile;
   fireSound = SazzonFireballSound;
   fireAnim = "attack1";
   fullSkelAnim = true;
};