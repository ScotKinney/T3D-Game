//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

// This is the default save location for any Particle datablocks created in the
// Particle Editor (this script is executed from onServerCreated())

datablock BillboardParticleData(ParticleSteamData)
{
   textureName = "core/art/particles/smoke2.png";
   animTexName = "core/art/particles/smoke2.png";
   lifetimeMS = "5000";
   lifetimeVarianceMS = "250";
   spinRandomMin = "-25";
   spinRandomMax = "25";
   colors[0] = "0.992126 0.992126 0.992126 0";
   colors[1] = "0.992126 0.992126 0.992126 0.207";
   colors[2] = "0.992126 0.992126 0.992126 0";
   colors[3] = "0.992126 0.992126 0.992126 1";
   sizes[0] = "27.083";
   sizes[1] = "33.3303";
   sizes[2] = "31.2489";
   sizes[3] = "0";
   times[1] = "0.498039";
   times[2] = "1";
   times[3] = "1";
   spinSpeed = "0.05";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
};

datablock SphereEmitterData(ParticleSteamEmitter)
{
   ejectionPeriodMS = 625;
   periodVarianceMS = 10;
   ejectionVelocity = 0;
   velocityVariance = 0;
   thetaMin         = 0.0;
   thetaMax         = 39;
   lifetimeMS       = 0;
   particles = "ParticleSteamData";
   blendStyle = "NORMAL";
   ejectionOffset = "40";
   softnessDistance = "1";
   softParticles = "1";
   lifetimeVarianceMS = "0";
};

datablock GroundEmitterData(gr_DefaultEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
   radius = "1";
};

datablock BillboardParticleData(damageAmountParticle)
{
   textureName          = "core/art/particles/SpriteNumbers01";
   dragCoeffiecient     = 0;
   gravityCoefficient   = -0.1;
   inheritedVelFactor   = "0.8";
   constantAcceleration = "0";
   lifetimeMS           = "3000";
   lifetimeVarianceMS   = "500";
   useInvAlpha =  false;
   spinRandomMin = -5;
   spinRandomMax = 5;

   colors[0]     = "0.5 0.2 0.2 0.8";
   colors[1]     = "0.9 0.4 0.4 1.0";
   colors[2]     = "0.75 0.1 0.1 0.9";
   colors[3]     = ".5 0 0 0";

   sizes[0]      = 0.3;
   sizes[1]      = 0.5;
   sizes[2]      = 0.4;
   sizes[3]      = 0;

   times[0]      = 0.0;
   times[1]      = 0.35;
   times[2]      = 0.8;
   times[3]      = 1;
   
   dragCoefficient = 0.25;
   spinSpeed = "0.0";
   animTexName = "core/art/particles/SpriteNumbers01";
   textureCoords[0]     = "0.375 0.166667";
   textureCoords[1]     = "0.375 0.25";
   textureCoords[2]     = "0.5 0.25";
   textureCoords[3]     = "0.5 0.166667";
};

datablock SphereEmitterData(NumberTestEmitter)
{
   particles = "damageAmountParticle";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "2000";
   velocityVariance = "0";
   softParticles = "0";
   softnessDistance = "1";
};