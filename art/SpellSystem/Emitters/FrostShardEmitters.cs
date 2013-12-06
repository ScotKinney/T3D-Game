//------------------------------------------------------------------------------
//----------------------------- PROJECTILE EMITTERS ----------------------------
//------------------------------------------------------------------------------

datablock ParticleData(FrostShardParticles)
{
   HighResTexture       = "core/art/particles/flare.png";
   //MidResTexture        = "art/shapes/particles/smokeM";
   //LowResTexture        = "art/shapes/particles/smokeL";
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = "938";  // lasts 0.4 second
   lifetimeVarianceMS   = "0";   // ... precisely
   useInvAlpha = "1";
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "0.521569 0.952941 0.996078 1";
   colors[1]     = "0.890196 0.972549 0.996078 0.755906";
   colors[2]     = "0.752941 0.972549 0.996078 0.204724";
   colors[3]     = "0.74902 0.980392 0.996078 0";

   sizes[0]      = "0.25";
   sizes[1]      = "0.25";
   sizes[2]      = "0.25";
   sizes[3]      = "0.25";

   times[0]      = 0.0;
   times[1]      = "0.290196";
   times[2]      = "0.517647";
   spinSpeed     = "2";
   textureName = "core/art/particles/flare.png";
   animTexName = "core/art/particles/flare.png";
};

datablock SphereEmitterData(FrostShardEmitter)
{
   ejectionVelocity = 0.25;
   velocityVariance = 0.10;
   thetaMin = 0.0;
   thetaMax = 180;
   particles = FrostShardParticles;
   ejectionOffset   = "0.05";
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = 0;
   orientParticles  = "0";
   ejectionPeriodMS = "200";
   blendStyle = "Normal";
   softParticles = "1";
   softnessDistance = "1";
};
