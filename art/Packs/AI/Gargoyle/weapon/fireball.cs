// GargoyleFireball
datablock SFXProfile(GargFireballSound)
{
   filename = "art/Packs/AI/Gargoyle/sound/gargfireball";
   description = AudioClose3d;
   preload = true;
};

datablock ParticleData(GargFireballParticle)
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

datablock SphereEmitterData(GargFireballEmitter)
{
   particles = "GargFireballParticle";
   blendStyle = "ADDITIVE";
   ejectionPeriodMS = "10";
   periodVarianceMS = "5";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0";
   thetaMax = "120";
};

datablock ProjectileData(GargoyleFireballProjectile : BaseProjectile)
{
   projectileShapeName = "art/packs/AI/Gargoyle/weapon/dracofireball.dae";
   scale="0.5 0.5 0.5";
   muzzleVelocity = 30;
   directDamage = 30;
   directImplulse = 100;
   particleEmitter = GargFireballEmitter;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
   radiusDamage = 20;
   damageRadius = 10;
   explosion = 0;
   waterExplosion = 0;
   areaImpulse = 20;
   shakeCamera = false;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;//5000;
   fadeDelay = 5000;//5000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   //armingDelay = 0;
   //bounceElasticity = 0.4;
   //bounceFriction = 0.01;
   //isBallistic = true;
   retrievable = "";
};

datablock ProjectileData(GargoyleFireballWetProjectile : GargoyleFireballProjectile)
{
   muzzleVelocity = 20;
   gravityMod = 0.1;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(GargoyleFireballImage : BaseTriggeredImage)
{
   shapefile = "art/packs/AI/Gargoyle/weapon/dracofireball.dae";
   scale = "1 1 1";
   projectile = GargoyleFireballProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = GargoyleFireballWetProjectile;
   fireSound = GargFireballSound;
   fireAnim = "spit_fire";
   fullSkelAnim = false;
};


