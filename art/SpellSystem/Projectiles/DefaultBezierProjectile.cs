datablock BezierProjectileData(DefaultBezierProjectile)
{
   projectileShapeName = "";
   
   muzzleVelocity = 10;
   velInheritFactor = 0;
   armingDelay = 0;
   particleEmitter = DefaultBezierProjectileEmitter;
   lifetime = 2000;
   fadeDelay = 2000;
   isBallistic = false;
   bounceElasticity = 0;
   bounceFriction = 0;
   gravityMod = 0;
   hasLight = false;
   lightRadius = 3;
   lightColor = "0.8 0.8 1.0";
   
   bezierweights = "0 0 25";
};