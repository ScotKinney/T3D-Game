datablock ParticleData(CrushParticle : DefaultParticle)
{
   sizes[0] = "0.1";
   sizes[1] = "0.15";
   sizes[2] = "0.1";
   sizes[3] = "0.1";
   times[1] = "0.34902";
   times[2] = "0.721569";
   spinRandomMin = "-791";
   HighResTexture = "art/Worlds/MarsTest/Particles/mainfalls01.png";
   textureName = "art/Worlds/MarsTest/Particles/mainfalls01.png";
   animTexName = "art/Worlds/MarsTest/Particles/mainfalls01.png";
   times[0] = "0";
   originalName = "CrushParticle";
   spinRandomMax = "708.5";
   colors[0] = "0 0.976471 1 1";
   colors[1] = "0.996078 0.698039 0.00784314 0.954";
   colors[2] = "0.996078 0.0627451 0.00784314 0.535";
   colors[3] = "0.354331 0.354331 0.354331 0";
   useInvAlpha = "1";
   dragCoefficient = "0.458";
   inheritedVelFactor = "0.25";
   lifetimeMS = "600";
   lifetimeVarianceMS = "5";
   spinSpeed = "0.667";
};

datablock SphereEmitterData(CrushEmitter : DefaultEmitter)
{
   particles = "CrushParticle";
   thetaMin = "0";
   thetaMax = "0";
   ejectionPeriodMS = "15";
   periodVarianceMS = "5";
   ejectionVelocity = "0";
   ejectionOffset = "0";
   orientParticles = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   alignDirection = "0 1 0";
};
