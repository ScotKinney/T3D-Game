datablock ParticleData(Flames : DefaultParticle)
{
   sizes[0] = "1";
   sizes[1] = "2.08143";
   sizes[2] = "2.08143";
   sizes[3] = "4.1659";
   times[1] = "0.352941";
   times[2] = "0.72549";
   spinRandomMin = "-83.8";
   HighResTexture = "core/art/particles/fire.png";
   textureName = "core/art/particles/fire.png";
   animTexName = "core/art/particles/fire.png";
   times[0] = "0";
   originalName = "Flames";
   spinRandomMax = "99";
   colors[0] = "0 0.669291 1 1";
   colors[1] = "0.992126 0.944882 0 0.629921";
   colors[2] = "1 0.0629921 0 0.330709";
   colors[3] = "0.354331 0.354331 0.354331 0";
   useInvAlpha = "1";
   dragCoefficient = "0.44477";
   inheritedVelFactor = "0.499022";
   lifetimeMS = "1354";
   lifetimeVarianceMS = "900";
   spinSpeed = "0.3";
};

datablock SphereEmitterData(Immolation : DefaultEmitter)
{
   particles = "Flames";
   thetaMin = "0";
   thetaMax = "0";
   ejectionPeriodMS = "55";
   periodVarianceMS = "54";
   ejectionVelocity = "0.5";
   ejectionOffset = "0";
   orientParticles = "0";
   phiVariance = "360";
   softnessDistance = "1";
   ambientFactor = "0";
   alignDirection = "0 1 0";
};
