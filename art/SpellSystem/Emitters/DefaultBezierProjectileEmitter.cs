datablock BillboardParticleData(DefaultBezierProjectileParticles)
{
   textureName          = "core/art/particles/spark";
   dragCoeffiecient     = 0.0;
   gravityCoefficient   = 0.0;
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 300;
   lifetimeVarianceMS   = 25;
   useInvAlpha = false;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "1 0.0 0.0 1.0";
   colors[1]     = "1 0.2 0.2 1.0";
   colors[2]     = "1 0.3 0.3 0";

   sizes[0]      = 0.25;
   sizes[1]      = 0.35;
   sizes[2]      = 1.0;

   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;
};

datablock GraphEmitterData(DefaultBezierProjectileEmitter)
{
   ejectionPeriodMS = 1;
   ejectionVelocity = 0.25;
   velocityVariance = 0.10;
   particles = DefaultBezierProjectileParticles;
   ejectionOffset   = 1;
   overrideAdvances = false;
   
   xFunc = "cos(t/50)";
   zFunc = "sin(t/50)";
   Loop = false;
};