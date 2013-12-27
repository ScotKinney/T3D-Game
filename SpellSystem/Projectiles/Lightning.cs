
datablock ExplosionData(LightningHitExplosion)
{
   lifeTimeMS = "384";
   
   particleEmitter = LightningBall;
   particleDensity = "20";
   particleRadius = "0.2";
   faceViewer = "1";
   lightStartBrightness = "0.941176";
   lightEndBrightness = "0.941176";
};

datablock BezierProjectileData(LightningProjectile : DefaultBezierProjectile)
{
   projectileShapeName = "";
   muzzleVelocity = 20;
   velInheritFactor = 0;
   armingDelay = 0;
   particleEmitter = LightningBolt;
   lifetime = 2000;
   fadeDelay = 2000;
   isBallistic = false;
   bounceElasticity = 0;
   bounceFriction = 0;
   gravityMod = 0;
   hasLight = true;
   lightRadius = 3;
   lightColor = "1.0 1.0 1.0";
   directDamage = 65;
   explosion = LightningHitExplosion;
};