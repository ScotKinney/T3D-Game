datablock SFXProfile(boartuskFireSound)
{
   filename = "art/Packs/AI/RazorBacks/Sound/razorbackattack";
   description = AudioClose3d;
   preload = false;
};

datablock SFXProfile(boartuskhitSound)
{
   filename = "art/Packs/AI/RazorBacks/Sound/razorbackattack";
   description = AudioClose3d;
   preload = false;
};

datablock ExplosionData(boartuskHitExplosion)
{
   soundProfile = boartuskHitSound;
   lifeTimeMS = 200;
};

datablock ProjectileData(boartuskProjectile : BaseProjectile)
{
   projectileShapeName = "art/Packs/AI/RazorBacks/Weapon/boartusk.dae";
   scale = "1 1 1";
   muzzleVelocity = 25;
   directDamage = 25;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   radiusDamage = 0;
   damageRadius = 5;
   explosion = boartuskHitExplosion;
   waterExplosion = 0;
   areaImpulse = 100;
   shakeCamera = true;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 3000;
   decal = 0;
   velInheritFactor = 1.0;
   retrievable = "";
};

datablock ProjectileData(boartuskWetProjectile : boartuskProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = 0;
};

datablock ShapeBaseImageData(boartuskImage : BaseTriggeredImage)
{
   shapefile = "art/Packs/AI/RazorBacks/Weapon/boartusk.dae";
   scale = "1 1 1";
   eyeOffset = "0.2 -0.2 0.1";// 0.1=right/left 0.4=forward/backward, -0.6=up/down
   correctMuzzleVector = true;
   //ammo = boartuskAmmo; //This is the name of the AMMO that comes from the weapons table in aureus.
   projectile = boartuskProjectile; //The name of a projectile in the BCWeapons/projectiles.cs file.
   wetProjectile = boartuskWetProjectile;
   stateSound[3] = boartuskFireSound;
   stateEmitter[5] = ""; //Do not emit smoke
   stateEmitter[14] = ""; //No smoke trail
};
