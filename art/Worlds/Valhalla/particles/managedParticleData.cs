//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// This is the default save location for any Particle datablocks created in the
// Particle Editor (this script is executed from onServerCreated())

//////////////////////SLOW STEAM///////////////
datablock BillboardParticleData(SlowSteamParticle)
{
   textureName          = "core/art/particles/steam";
   dragCoefficient      = 0.3;
   gravityCoefficient   = -0.1;   // rises slowly
   inheritedVelFactor   = 0.00;
   windCoefficient      = 0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 250;
   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "1 1 1 0.0";
   colors[1]     = "1 1 1 0.1";
   colors[2]     = "1 1 1 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 1.5;
   sizes[2]      = 2.0;

   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;
};

datablock SphereEmitterData(SlowSteamEmitter)
{
   ejectionPeriodMS = 100;
   periodVarianceMS = 25;

   ejectionVelocity = 0.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 90.0;  

   particles = SlowSteamParticle;
};

datablock ParticleEmitterNodeData(SlowSteamEmitterNode)
{
   timeMultiple = 1;
};
