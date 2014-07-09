///////Torches Entry Caves

datablock ParticleData(ECaveFireParticle)
{
   textureName          = "art/worlds/bugcaves/particles/smoke";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = "-0.0512821";   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = "2000";
   lifetimeVarianceMS   = 1000;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   spinSpeed            = 1.0;

   colors[0]     = "0.19685 0.19685 0 0.19685";
   colors[1]     = "0.598425 0.19685 0 0.19685";
   colors[2]     = "0.393701 0 0 0.0944882";
   colors[3]     = "0.0944882 0.0393701 0 0.299213";

   sizes[0]      = "2.08333";
   sizes[1]      = "1.04167";
   sizes[2]      = "2.08333";
   sizes[3]      = "3.125";

   times[0]      = 0.0;
   times[1]      = "0.0980392";
   times[2]      = 0.2;
   times[3]      = "0.375";
   animTexName = "art/worlds/bugcaves/particles/smoke";
   colors[4] = "0.0944882 0.0393701 0 0.299213";
   colors[5] = "0.0944882 0.0393701 0 0.299213";
   colors[6] = "0.0944882 0.0393701 0 0.299213";
   colors[7] = "0.0944882 0.0393701 0 0.299213";
   sizes[4] = "5.99985";
   sizes[5] = "5.99985";
   sizes[6] = "5.99985";
   sizes[7] = "5.99985";
   times[4] = "0.375";
   times[5] = "0.375";
   times[6] = "0.375";
   times[7] = "0.375";
};

datablock ParticleEmitterData(ECaveFireEmitter)
{
   ejectionPeriodMS = 50;
   periodVarianceMS = 0;

   ejectionVelocity = 0.55;
   velocityVariance = 0.00;
   ejectionOffset   = 1.0;


   thetaMin         = 1.0;
   thetaMax         = "52.5";

   particles        = "ECaveFireParticle";
   blendStyle = "ADDITIVE";
};

datablock ParticleEmitterNodeData(ECaveFireNode)
{
   timeMultiple = 1;
};

datablock ParticleEmitterNodeData(TorchFireEmitterNode)
{
   timeMultiple = 1;
};


///////////////////////////WATER FX//////////////////////
datablock BillboardParticleData(ParticleRockImpactInner01)
{
   textureName = "art/worlds/tortuga/particles/rock_impact_1_inner.png";
   animTexName = "art/worlds/tortuga/particles/rock_impact_1_inner.png";
   gravityCoefficient = "0.541667";
   inheritedVelFactor = "1";
   spinSpeed = "0.229167";
   spinRandomMin = "-416";
   spinRandomMax = "541.9";
   colors[2] = "1 1 1 0.124481";
   colors[3] = "1 1 1 0.136929";
   sizes[1] = "3";
   sizes[2] = "3";
   sizes[3] = "3";
   times[1] = "0.25";
   times[2] = "0.6875";
};

datablock SphereEmitterData(EmitterRockImpact)
{
   particles = "ParticleRockImpactInner01";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "167";
   velocityVariance = "0";
   softParticles = "1";
   softnessDistance = "1";
   ambientFactor = "0";
};

datablock BillboardParticleData(ParticleRockImpactInner01_Cave)
{
   textureName = "art/worlds/tortuga/particles/rock_impact_1_inner.png";
   animTexName = "art/worlds/tortuga/particles/rock_impact_1_inner.png";
   gravityCoefficient = "0.541667";
   inheritedVelFactor = "1";
   spinSpeed = "0.229167";
   spinRandomMin = "-416";
   spinRandomMax = "541.9";
   colors[2] = "1 1 1 0.124481";
   colors[3] = "1 1 1 0.136929";
   sizes[1] = "3";
   sizes[2] = "3";
   sizes[3] = "3";
   times[1] = "0.25";
   times[2] = "0.6875";
};

datablock SphereEmitterData(EmitterRockImpact_Cave)
{
   particles = "ParticleRockImpactInner01_Cave";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "167";
   velocityVariance = "0";
   softParticles = "1";
   softnessDistance = "1";
   ambientFactor = "0.416667";
};

datablock BillboardParticleData(ParticleRockImpactTop)
{
   textureName = "art/worlds/bugcaves/particles/topandtopspray.png";
   animTexName = "art/worlds/bugcaves/particles/topandtopspray.png";
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

datablock BillboardParticleData(ParticleMainFalls01)
{
   textureName = "art/worlds/bugcaves/particles/mainfalls01.png";
   animTexName = "art/worlds/bugcaves/particles/mainfalls01.png";
   gravityCoefficient = "0.788767";
   sizes[0] = "1.99902";
   sizes[1] = "7.99915";
   constantAcceleration = "0.416666";
   sizes[2] = "0";
   sizes[3] = "0";
   lifetimeMS = "2064";
};

datablock SphereEmitterData(EmitterMainFalls)
{
   particles = "ParticleMainFalls01";
   blendStyle = "NORMAL";
   ejectionVelocity = "3.5";
   velocityVariance = "0";
   thetaMax = "10";
   ejectionPeriodMS = "146";
   softnessDistance = "1";
   orientParticles = "1";
   softParticles = "1";
   lifetimeMS = "0";
   ambientFactor = "0";
};

datablock BillboardParticleData(ParticleMainFalls02)
{
   textureName = "art/worlds/bugcaves/particles/mainfalls02.png";
   animTexName = "art/worlds/bugcaves/particles/mainfalls02.png";
   gravityCoefficient = "0.788767";
   sizes[0] = "1.99902";
   sizes[1] = "7.99915";
   constantAcceleration = "0.416666";
   sizes[2] = "0";
   sizes[3] = "0";
   lifetimeMS = "2064";
};

datablock SphereEmitterData(EmitterMainFalls02)
{
   particles = "ParticleMainFalls02";
   blendStyle = "NORMAL";
   ejectionVelocity = "3.5";
   velocityVariance = "0";
   thetaMax = "10";
   ejectionPeriodMS = "146";
   softnessDistance = "1";
   orientParticles = "1";
   softParticles = "1";
   lifetimeMS = "0";
   ambientFactor = "0";
};

datablock BillboardParticleData(ParticleMainFalls03)
{
   textureName = "art/worlds/bugcaves/particles/mainfalls03.png";
   animTexName = "art/worlds/bugcaves/particles/mainfalls03.png";
   gravityCoefficient = "0.788767";
   sizes[0] = "1.99902";
   sizes[1] = "7.99915";
   constantAcceleration = "0.416666";
   sizes[2] = "0";
   sizes[3] = "0";
   lifetimeMS = "2064";
};

datablock SphereEmitterData(EmitterMainFalls03)
{
   particles = "ParticleMainFalls03";
   blendStyle = "NORMAL";
   ejectionVelocity = "3.5";
   velocityVariance = "0";
   thetaMax = "25";
   ejectionPeriodMS = "146";
   softnessDistance = "1";
   orientParticles = "1";
   softParticles = "1";
   lifetimeMS = "0";
   ambientFactor = "0";
};

datablock BillboardParticleData(ParticleMainFalls01_Cave)
{
   textureName = "art/worlds/bugcaves/particles/mainfalls01.png";
   animTexName = "art/worlds/bugcaves/particles/mainfalls01.png";
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

datablock BillboardParticleData(ParticleMainFalls02_Cave)
{
   textureName = "art/worlds/bugcaves/particles/mainfalls02.png";
   animTexName = "art/worlds/bugcaves/particles/mainfalls02.png";
   gravityCoefficient = "0.788767";
   sizes[0] = "1.99902";
   sizes[1] = "7.99915";
   constantAcceleration = "0.416666";
   sizes[2] = "0";
   sizes[3] = "0";
   lifetimeMS = "2064";
};

datablock SphereEmitterData(EmitterMainFalls02_Cave)
{
   particles = "ParticleMainFalls02_Cave";
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

datablock BillboardParticleData(ParticleMainFalls03_Cave)
{
   textureName = "art/worlds/bugcaves/particles/mainfalls03.png";
   animTexName = "art/worlds/bugcaves/particles/mainfalls03.png";
   gravityCoefficient = "0.788767";
   sizes[0] = "1.99902";
   sizes[1] = "7.99915";
   constantAcceleration = "0.416666";
   sizes[2] = "0";
   sizes[3] = "0";
   lifetimeMS = "2064";
};

datablock SphereEmitterData(EmitterMainFalls03_Cave)
{
   particles = "ParticleMainFalls03_Cave";
   blendStyle = "NORMAL";
   ejectionVelocity = "3.5";
   velocityVariance = "0";
   thetaMax = "25";
   ejectionPeriodMS = "146";
   softnessDistance = "1";
   orientParticles = "1";
   softParticles = "1";
   lifetimeMS = "0";
   ambientFactor = "0.416667";
};

datablock BillboardParticleData(ParticleMist)
{
   textureName = "art/worlds/bugcaves/particles/mist.png";
   animTexName = "art/worlds/bugcaves/particles/mist.png";
   dragCoeffiecient = 0;
   gravityCoefficient = "-0.0854701";
   inheritedVelFactor = 0;
   constantAcceleration = -1;
   lifetimeMS = 2500;
   lifetimeVarianceMS = 0;
   useInvAlpha = 0;
   spinRandomMin = -125;
   spinRandomMax = 125;
   spinSpeed = 0.520833;

   colors[0] = "0.992126 0.992126 0.992126 0.436";
   colors[1] = "0.992126 0.992126 0.992126 0.465";
   colors[2] = "0.992126 0.992126 0.992126 0.668";
   colors[3] = "0.992126 0.992126 0.992126 0.23622";
   
   sizes[0] = 2;
   sizes[1] = 8;
   sizes[2] = 9;
   sizes[3] = "10.5";
   
   times[0] = 0.0;
   times[1] = "0.4";
   times[2] = "0.5";
   times[3] = "0.6";
      
   dragCoefficient = "0.889541";
};

datablock SphereEmitterData(EmitterMist)
{
   particles = "ParticleMist";
   blendStyle = "NORMAL";
   ejectionVelocity = "5.11";
   velocityVariance = "0";
   thetaMax = "165";
   softParticles = "1";
   ambientFactor = "0.416667";
   ejectionPeriodMS = "167";
};

datablock BillboardParticleData(ParticleMist_Cave)
{
   textureName = "art/worlds/bugcaves/particles/mist.png";
   animTexName = "art/worlds/bugcaves/particles/mist.png";
   dragCoeffiecient = 0;
   gravityCoefficient = "-0.0854701";
   inheritedVelFactor = 0;
   constantAcceleration = -1;
   lifetimeMS = 2500;
   lifetimeVarianceMS = 0;
   useInvAlpha = 0;
   spinRandomMin = -125;
   spinRandomMax = 125;
   spinSpeed = 0.520833;

   colors[0] = "0.992126 0.992126 0.992126 0.436";
   colors[1] = "0.992126 0.992126 0.992126 0.465";
   colors[2] = "0.992126 0.992126 0.992126 0.668";
   colors[3] = "0.992126 0.992126 0.992126 0.23622";
   
   sizes[0] = 2;
   sizes[1] = 8;
   sizes[2] = 9;
   sizes[3] = "10.5";
   
   times[0] = 0.0;
   times[1] = "0.4";
   times[2] = "0.5";
   times[3] = "0.6";
      
   dragCoefficient = "0.889541";
};

datablock SphereEmitterData(EmitterMist_Cave)
{
   particles = "ParticleMist_Cave";
   blendStyle = "NORMAL";
   ejectionVelocity = "5.11";
   velocityVariance = "0";
   thetaMax = "165";
   softParticles = "1";
   ambientFactor = "0.416667";
   ejectionPeriodMS = "167";
};

datablock BillboardParticleData(ParticleWaterDisturbance)
{
   textureName = "art/worlds/bugcaves/particles/ripple.png";
   animTexName = "art/worlds/bugcaves/particles/ripple.png";
   lifetimeMS = "2626";
   lifetimeVarianceMS = "49";
   spinRandomMin = "0";
   spinRandomMax = "5";
   colors[0] = "1 1 1 0.173228";
   colors[1] = "1 1 1 1";
   colors[2] = "1 1 1 0.409449";
   colors[3] = "1 1 1 0.0393701";
   sizes[1] = "10.6543";
   sizes[2] = "15.9952";
   sizes[3] = "18.6565";
   times[1] = "0.247059";
   times[2] = "0.513726";
   times[3] = "1";
   spinSpeed = "0";
   sizes[0] = "5.32564";
};

datablock SphereEmitterData(EmitterWaterDisturbance)
{
   particles = "ParticleWaterDisturbance";
   blendStyle = "NORMAL";
   thetaMin = "7";
   thetaMax = "180";
   orientParticles = "0";
   ejectionPeriodMS = "646";
   periodVarianceMS = "24";
   ejectionVelocity = "0";
   velocityVariance = "0";
   phiVariance = "1";
   alignParticles = "1";
   softnessDistance = "1";
   ambientFactor = "0";
   softParticles = "0";
   alignDirection = "0 0 1";
};

datablock BillboardParticleData(ParticleWaterDisturbance_Cave)
{
   textureName = "art/worlds/bugcaves/particles/ripple.png";
   animTexName = "art/worlds/bugcaves/particles/ripple.png";
   lifetimeMS = "2626";
   lifetimeVarianceMS = "49";
   spinRandomMin = "0";
   spinRandomMax = "5";
   colors[0] = "1 1 1 0.173228";
   colors[1] = "1 1 1 1";
   colors[2] = "1 1 1 0.409449";
   colors[3] = "1 1 1 0.0393701";
   sizes[1] = "10.6543";
   sizes[2] = "15.9952";
   sizes[3] = "18.6565";
   times[1] = "0.247059";
   times[2] = "0.513726";
   times[3] = "1";
   spinSpeed = "0";
   sizes[0] = "5.32564";
};

datablock SphereEmitterData(EmitterWaterDisturbance_Cave)
{
   particles = "ParticleWaterDisturbance_Cave";
   blendStyle = "NORMAL";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionPeriodMS = "646";
   ambientFactor = "0.416667";
   periodVarianceMS = "24";
   thetaMin = "7";
   thetaMax = "180";
   phiVariance = "1";
   alignParticles = "1";
   softParticles = "0";
   alignDirection = "0 0 1";
};

datablock BillboardParticleData(WaterVortexParticle)
{
   textureName = "art/worlds/bugcaves/particles/rock_impacttopandsidespray.png";
   animTexName = "art/worlds/bugcaves/particles/rock_impacttopandsidespray.png";
   lifetimeMS = "8000";
   lifetimeVarianceMS = "4800";
   spinRandomMin = "-100";
   spinRandomMax = "120";
   colors[0] = "0.643137 0.643137 0.643137 0.141";
   colors[1] = "0.913726 0.909804 0.909804 0.763";
   colors[2] = "0.917647 0.913726 0.913726 0.726";
   colors[3] = "0.933333 0.929412 0.929412 0.11811";
   sizes[1] = "8";
   sizes[2] = "4";
   sizes[3] = "2";
   times[1] = "0.25";
   times[2] = "0.5";
   times[3] = "0.8";
   spinSpeed = "0.4";
   sizes[0] = "11";
   constantAcceleration = "-2.5";
   inheritedVelFactor = "1";
};

datablock SphereEmitterData(WaterVortexEmitter)
{
   particles = "WaterVortexParticle";
   blendStyle = "NORMAL";
   thetaMin = "7";
   thetaMax = "180";
   orientParticles = "0";
   ejectionPeriodMS = "646";
   periodVarianceMS = "24";
   ejectionVelocity = "0";
   velocityVariance = "0";
   phiVariance = "360";
   alignParticles = "0";
   softnessDistance = "1";
   ambientFactor = "0";
   softParticles = "1";
   ejectionOffset = "0";
};
