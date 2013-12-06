
datablock ParticleData(TeleporterFlash : DefaultParticle)
{
   dragCoefficient = "5";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   lifetimeMS = "500";
   spinRandomMin = "-90";
   spinRandomMax = "90";
   textureName = "core/art/particles/flare.png";
   animTexName = "core/art/particles/flare.png";
   colors[0] = "0.678431 0.686275 0.913726 0.207";
   colors[1] = "0 0.543307 1 0.759";
   colors[2] = "0.0472441 0.181102 0.92126 0.838";
   colors[3] = "0.141732 0.0393701 0.944882 0";
   sizes[0] = "0";
   sizes[1] = "0";
   sizes[2] = "4";
   sizes[3] = "0.1";
   times[1] = "0.166667";
   times[2] = "0.666667";
   lifetimeVarianceMS = "0";
   gravityCoefficient = "-9";
};

datablock SphereEmitterData(TeleportFlash_Emitter : DefaultEmitter)
{
   ejectionVelocity = "0.1";
   particles = "TeleporterFlash";
   thetaMax = "180";
   softnessDistance = "1";
   ejectionOffset = "0.417";
};

// Particles to use for the emitter at the teleporter
datablock ParticleData(TeleporterParticles)
{
   lifetimeMS = "750";
   lifetimeVarianceMS = "100";
   textureName = "core/art/particles/Streak.png";
   useInvAlpha = "0";
   gravityCoefficient = "-1";
   spinSpeed = "0";
   spinRandomMin = "0";
   spinRandomMax = "0";
   colors[0]     = "0.0980392 0.788235 0.92549 1";
   colors[1]     = "0.0627451 0.478431 0.952941 1";
   colors[2]     = "0.0509804 0.690196 0.964706 1";
   sizes[0]      = "1";
   sizes[1]      = "1";
   sizes[2]      = "1";
   times[0]      = 0.0;
   times[1]      = "0.415686";
   times[2]      = "0.74902";
   animTexName = "core/art/particles/Streak.png";
   inheritedVelFactor = "0.0998043";
   constantAcceleration = "-2";
   colors[3] = "0.694118 0.843137 0.945098 0";
   sizes[3] = "1";
};

// Particle Emitter to be played when a teleport occours.
datablock SphereEmitterData(TeleportEmitter)
{
   ejectionPeriodMS = "25";
   periodVarianceMS = "2";
   ejectionVelocity = "0.25";
   velocityVariance = "0.1";
   ejectionOffset   = "0.25";
   thetaMin         = "90";
   thetaMax         = "90";
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   lifetimeMS       = "1000";
   particles = "TeleporterParticles";
   blendStyle = "ADDITIVE";
};

datablock ParticleData(RocketSplashParticle)
{
   dragCoefficient = 1;
   windCoefficient = 0.9;
   gravityCoefficient = 0.3;
   inheritedVelFactor = 0.2;
   constantAcceleration = -1.4;
   lifetimeMS = 600;
   lifetimeVarianceMS = 200;
   textureName = "core/art/particles/droplet";
   colors[0] = "0.7 0.8 1.0 1.0";
   colors[1] = "0.7 0.8 1.0 0.5";
   colors[2] = "0.7 0.8 1.0 0.0";
   sizes[0] = 0.5;
   sizes[1] = 0.25;
   sizes[2] = 0.25;
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;
};

datablock SphereEmitterData(RocketSplashEmitter)
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionVelocity = 7.3;
   velocityVariance = 2.0;
   ejectionOffset = 0.0;
   thetaMin = 30;
   thetaMax = 80;
   phiReferenceVel = 00;
   phiVariance = 360;
   overrideAdvance = false;
   orientParticles = true;
   orientOnVelocity = true;
   lifetimeMS = 100;
   particles = "RocketSplashParticle";
};

