/*
datablock ParticleData(LightningRod : DefaultParticle)
{
   sizes[0] = "1.2";
   sizes[1] = "1";
   sizes[2] = "1";
   sizes[3] = "1";
   times[1] = "0.229167";
   times[2] = "0.333333";
   HighResTexture = "art/particles/bastardbolt.png";
   textureName = "art/particles/bastardbolt.png";
   animTexName = "art/particles/bastardbolt.png";
   dragCoefficient = "0";
   inheritedVelFactor = "1";
   lifetimeMS = "188";
   lifetimeVarianceMS = "0";
   spinSpeed = "1";
   spinRandomMin = "-125";
   spinRandomMax = "125.4";
   colors[0] = "0.576471 0.886275 0.996078 1";
   colors[1] = "0.00784314 0.996078 0.972549 0.637795";
   colors[2] = "0.996078 0.992157 0.992157 0.330709";
   times[3] = "0.5";
   gravityCoefficient = "1";
   constantAcceleration = "-10";
};

datablock ParticleData(LightningRod1 : DefaultParticle)
{
   inheritedVelFactor = "1";
   lifetimeMS = "188";
   lifetimeVarianceMS = "0";
   spinSpeed = "0.271";
   spinRandomMin = "-125";
   spinRandomMax = "167.1";
   HighResTexture = "art/particles/bastardbolt1.png";
   textureName = "art/particles/bastardbolt1.png";
   animTexName = "art/particles/bastardbolt1.png";
   colors[0] = "0.996078 0.992157 0.992157 1";
   colors[1] = "0.54902 0.737255 0.996078 0.637795";
   colors[2] = "0.00784314 0.00784314 0.996078 0.330709";
   sizes[0] = "1.5";
   sizes[1] = "1.5";
   sizes[2] = "1.5";
   sizes[3] = "1.5";
   times[1] = "0.33";
   times[2] = "0.4375";
   gravityCoefficient = "1";
   constantAcceleration = "-10";
};

datablock ParticleData(LightningRod2 : DefaultParticle)
{
   sizes[0] = "1.65";
   sizes[1] = "1.5";
   sizes[2] = "1.5";
   sizes[3] = "1";
   times[1] = "0.166667";
   times[2] = "0.354167";
   inheritedVelFactor = "1";
   lifetimeMS = "376";
   lifetimeVarianceMS = "0";
   spinSpeed = "0";
   spinRandomMin = "-1";
   spinRandomMax = "0";
   HighResTexture = "art/particles/bastardbolt2.png";
   textureName = "art/particles/bastardbolt2.png";
   animTexName = "art/particles/bastardbolt2.png";
   colors[0] = "0.584314 0.890196 0.996078 1";
   colors[1] = "0.756863 0.996078 0.886275 0.637795";
   colors[2] = "0.996078 0.992157 0.992157 0.330709";
   times[3] = "0.541667";
   dragCoefficient = "0.375";
   gravityCoefficient = "1";
   constantAcceleration = "-10";
};

datablock SphereEmitterData(LightningBolt : DefaultEmitter)
{
   particles = "LightningRod LightningRod1 LightningRod2";
   thetaMax = "0";
   phiVariance = "0";
   ejectionPeriodMS = "25";
   periodVarianceMS = "0";
   ejectionVelocity = "1";
   velocityVariance = "0";
   ejectionOffset = "0";
   softnessDistance = "20";
   softParticles = "1";
};
*/