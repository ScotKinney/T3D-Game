// Beam: Base Beam Portion
// ---------------
datablock BillboardParticleData(BeamParticle)
{
   textureName          = "core/art/particles/orb";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = 0.0;   // rises slowly
   inheritedVelFactor   = 1.00;
   constantAcceleration = 5;
   lifetimeMS           = 16000;
   lifetimeVarianceMS   = 0;
   useInvAlpha = true;
   spinRandomMin = 0.0;
   spinRandomMax = 0.0;

   colors[0]     = "0.4 0.5 1 1 ";
   colors[1]     = "0.9 0.95 1 0.5";
   colors[2]     = "1 1 1 0.0";

   sizes[0]      = 15.0;
   sizes[1]      = 10.0;
   sizes[2]      = 8.0;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(BeamEmitter)
{
   ejectionPeriodMS = 50;
   periodVarianceMS = 0;

   ejectionVelocity = 0.57;
   velocityVariance = 0.00;

   thetaMin         = 0.0;
   thetaMax         = 0.0;  
   phiReferenceVelocity = 0.0;
   phiVariance = 1.0;

   particles = "BeamParticle";
};

// Haze particle
datablock BillboardParticleData(CK_SnowHazeA_P)
{
  textureName          = "art/Worlds/Illura/particles/ck_snow_haze";
  dragCoeffiecient     = 0.5;
  gravityCoefficient   = 0.1;
  //windCoefficient      = 0;
  inheritedVelFactor   = 0.00;
  lifetimeMS           = 1600;
  lifetimeVarianceMS   = 300;

  // TGE blendType            = normal;

  spinRandomMin        = -200;
  spinRandomMax        = 200;

  colors[0]            = "1.0 1.0 1.0 0.7";
  colors[1]            = "1.0 1.0 1.0 0.7";
  colors[2]            = "1.0 1.0 1.0 0.0";

  sizes[0]             = 2.0;
  sizes[1]             = 2.5; 
  sizes[2]             = 3.0;

  times[0]             = 0.0;
  times[1]             = 0.5;
  times[2]             = 1.0;
};

// Haze emitter, standard "sprinkler" type
datablock SphereEmitterData(CK_SnowFormationHaze_E)
{
  ejectionPeriodMS      = 20;
  periodVarianceMS      = 10;
  ejectionVelocity      = 1.5; 
  velocityVariance      = 0.75; 
  thetaMin              = 0.0;
  thetaMax              = 180.0;
  particles             = "CK_SnowHazeA_P";

  blendStyle = "NORMAL";
};

datablock BillboardParticleData(SSJ_HandBoneGlow_D_P)
{
   textureName          = "art/Worlds/Illura/particles/ssj_hand_glow";
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;
   inheritedVelFactor   = 0.00;
   lifetimeMS           = (2/30)*1000;
   lifetimeVarianceMS   = 0;
   spinRandomMin        = 0;
   spinRandomMax        = 0;
   times[0]             = 0.0;
   times[1]             = 0.2;
   times[2]             = 0.8;
   times[3]             = 1.0;
   colors[0]            = "1.0 1.0 1.0 0.0";
   colors[1]            = "1.0 1.0 1.0 0.5";
   colors[2]            = "1.0 1.0 1.0 0.5";
   colors[3]            = "1.0 1.0 1.0 0.0";
   sizes[0]             = 0.6;
   sizes[1]             = 0.6;
   sizes[2]             = 0.6;
   sizes[3]             = 0.6;
};

datablock SphereEmitterData(SSJ_BoneGlow_D_E)
{
   ejectionOffset    = 0;
   ejectionPeriodMS  = 20;
   periodVarianceMS  = 0;
   ejectionVelocity  = 5;
   velocityVariance  = 0;
   particles         = "SSJ_HandBoneGlow_D_P";
   blendStyle = "ADDITIVE";
   vector = "0.0 1.0 0.0";
};
