datablock BezierProjectileData(FireballProjectile : DefaultBezierProjectile)
{
   projectileShapeName = "";
   muzzleVelocity = 20;
   velInheritFactor = 0;
   armingDelay = 0;
   particleEmitter = FireballEmitter;
   lifetime = 2000;
   fadeDelay = 2000;
   isBallistic = false;
   bounceElasticity = 0;
   bounceFriction = 0;
   gravityMod = 0;
   hasLight = true;
   lightRadius = 3;
   lightColor = "0.8 0.8 1.0";
};

datablock ExplosionData(FireballHitExplosion)
{
   lifeTimeMS = "384";
   
   particleEmitter = FireballBlastEmitter;
   particleDensity = "20";
   particleRadius = "0.2";
   faceViewer = "1";
   lightStartBrightness = "0.941176";
   lightEndBrightness = "0.941176";
   
};