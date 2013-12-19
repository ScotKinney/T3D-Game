///////Gnome Archer Crossbow////////////////////////////////////////////////

///Crossbow Fire Sound

datablock SFXProfile(GA_CrossbowFire)
{
   fileName = "art/Packs/AI/Gnomes/sound/GA_CrossbowFire";
   description = AudioClose3d;
   preload = false;
};

///Crossbow Hit Sound

datablock SFXProfile(GA_CrossbowHit)
{
   fileName = "art/Packs/AI/Gnomes/sound/GA_CrossbowHit";
   description = AudioClose3d;
   preload = false;
};

datablock ProjectileData(GA_BoltProjectile : BoltProjectile)
{
   projectileShapeName = "art/Packs/AI/Gnomes/Archer/GA_Bolt.dts";
   scale = "1 1 1";
   muzzleVelocity = 35;
   directDamage = 35;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   radiusDamage = 0;
   damageRadius = 5;
   explosion = GA_CrossbowHit;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.3;
   lifetime = 30000;
   decal = ScorchRXDecalSmall;
   velInheritFactor = 1.0;
   retrievable = "";
};

datablock ProjectileData(GA_BoltWetProjectile : BoltWetProjectile)
{
   muzzleVelocity = 10;
   gravityMod = 0.6;
   particleWaterEmitter = ProjectileTrailWaterEmitter;
};

datablock ShapeBaseImageData(GA_CrossbowImage : CrossbowImage)
{
   shapefile = "art/Packs/AI/Gnomes/Archer/GA_Crossbow.dts";
   scale = "1 1 1";
   projectile = GA_BoltProjectile; 
   wetProjectile = GA_BoltWetProjectile;
   rearmDelay = 4000;
   fullSkelAnim = true;
   fireAnim = "Attack1";
   fireSound = GA_CrossbowFire;
};
