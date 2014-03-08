//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// This is the default save location for any Particle datablocks created in the
// Particle Editor (this script is executed from onServerCreated())

datablock BillboardParticleData(ParticleRockImpactTop)
{
   textureName = "art/Worlds/Kardia/Particles/topandtopspray.png";
   animTexName = "art/Worlds/Kardia/Particles/topandtopspray.png";
   gravityCoefficient = "0.124542";
   colors[1] = "0.996078 0.996078 0.996078 0.813";
   colors[2] = "1 1 1 0.581";
   colors[3] = "1 1 1 0.015748";
   sizes[1] = "1.99597";
   sizes[2] = "1.99597";
   sizes[3] = "1.99597";
   times[1] = "0.329412";
   times[2] = "0.658824";
   spinRandomMin = "-43";
   spinRandomMax = "42";
   colors[0] = "1 1 1 0";
   sizes[0] = "1.99597";
   times[3] = "0.992157";
};

datablock SphereEmitterData(EmitterTopSpray)
{
   particles = "ParticleRockImpactTop";
   blendStyle = "NORMAL";
   ejectionVelocity = "1";
   velocityVariance = "0";
   ejectionPeriodMS = "272";
   ambientFactor = "0";
   periodVarianceMS = "0";
   thetaMin = "0";
   thetaMax = "90";
   phiVariance = "360";
   alignParticles = "0";
   softParticles = "0";
};

datablock BillboardParticleData(ParticleMainFalls01_Cave)
{
   textureName = "art/Worlds/Kardia/Particles/mainfalls01.png";
   animTexName = "art/Worlds/Kardia/Particles/mainfalls01.png";
   gravityCoefficient = "0.788767";
   sizes[0] = "1.99902";
   sizes[1] = "7.99915";
   constantAcceleration = "0.416666";
   sizes[2] = "0";
   sizes[3] = "0";
   lifetimeMS = "2064";
};

datablock SphereEmitterData(EmitterMainFalls_Cave)
{
   particles = "ParticleMainFalls01_Cave";
   blendStyle = "NORMAL";
   ejectionVelocity = "3.5";
   velocityVariance = "0";
   thetaMax = "10";
   ejectionPeriodMS = "146";
   softnessDistance = "1";
   orientParticles = "1";
   softParticles = "1";
   lifetimeMS = "0";
   ambientFactor = "0.416667";
};

