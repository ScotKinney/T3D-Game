//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// This is the default save location for any Particle datablocks created in the
// Particle Editor (this script is executed from onServerCreated())

datablock BillboardParticleData(MagellanFireParticles)
{
   textureName = "core/art/particles/fireball.png";
   gravityCoefficient = "-0.202686";
   lifetimeMS = "400";
   lifetimeVarianceMS = "299";
   spinSpeed = "1";
   spinRandomMin = "-200";
   spinRandomMax = "0";
   animTexName = "core/art/particles/fireball.png";
   colors[0] = "1 0.897638 0.795276 0.2";
   colors[1] = "1 0.496063 0 1";
   colors[2] = "0.0944882 0.0944882 0.0944882 0";
   sizes[0] = "0.997986";
   sizes[1] = "1.99902";
   sizes[2] = "2.99701";
   times[1] = "0.498039";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(MagellanFireEmitter)
{
   particles = "MagellanFireParticles";
   blendStyle = "ADDITIVE";
   ejectionPeriodMS = "10";
   periodVarianceMS = "5";
   ejectionVelocity = "4";
   velocityVariance = "2";
   thetaMax = "120";
};

datablock BillboardParticleData(SP2_TendrilSmokeA_P)
{
   textureName           = "art/Worlds/Magellan/particles/sp2_tendrilSmoke";
   dragCoeffiecient      = 0.5;
   gravityCoefficient    = -0.4;
   windCoefficient       = 0;
   inheritedVelFactor    = 0.00;
   lifetimeMS            = 2000;
   lifetimeVarianceMS    = 200;
   spinRandomMin         = -300.0;
   spinRandomMax         = 300.0;
   colors[0]             = "0.2 0.2 0.2 0.2";
   colors[1]             = "0.5 0.5 0.5 0.05";
   colors[2]             = "1.0 1.0 1.0 0.02"; //0.01"; -- too low
   colors[3]             = "0.0 0.0 0.0 0.0";
   sizes[0]              = 0.2;
   sizes[1]              = 0.7;
   sizes[2]              = 1.3;
   sizes[3]              = 2.0;
   times[0]              = 0.0;
   times[1]              = 0.3;
   times[2]              = 0.7;
   times[3]              = 1.0;
};

// vector emitter pointing straight up
datablock SphereEmitterData(SP2_TendrilSmokeA_E)
{
  ejectionPeriodMS      = 20;
  periodVarianceMS      = 0;
  ejectionVelocity      = 1.0;
  velocityVariance      = 0.0;
  particles             = SP2_TendrilSmokeA_P;
  blendStyle            = "NORMAL";
};