
datablock ParticleData(GenericFire)
{
   textureName          = "art/Packs/env/fire/smokeCampFire";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.05;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 1000;
   useInvAlpha = false;
   spinRandomMin = -90.0;
   spinRandomMax = 90.0;
   spinSpeed = 1.0;

   colors[0]     = "0.2 0.2 0.0 0.2";
   colors[1]     = "0.6 0.2 0.0 0.2";
   colors[2]     = "0.4 0.0 0.0 0.1";
   colors[3]     = "0.1 0.04 0.0 0.3";

   sizes[0]      = 0.5;
   sizes[1]      = 2.0;
   sizes[2]      = 3.0;
   sizes[3]      = 4.0;

   times[0]      = 0.0;
   times[1]      = 0.1;
   times[2]      = 0.2;
   times[3]      = 0.3;
};

datablock SphereEmitterData(GenericFireEmitter)
{
   ejectionPeriodMS = 42;
   periodVarianceMS = 0;

   ejectionVelocity = 0.55;
   velocityVariance = 0.00;
   ejectionOffset = 1.0;

   thetaMin         = 1.0;
   thetaMax         = 52.5;

   particles = "GenericFire";
   blendStyle = "ADDITIVE";
   softParticles = "0";
};

