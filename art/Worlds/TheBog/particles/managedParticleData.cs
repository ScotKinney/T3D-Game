//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

// This is the default save location for any Particle datablocks created in the
// Particle Editor (this script is executed from onServerCreated())

datablock BillboardParticleData(PCO_ExplosionFire_pRot_P)
{
  textureName          = "art/Worlds/TheBog/particles/PCO_tiled_parts";
  textureCoords[0]     = "0.0 0.5";
  textureCoords[1]     = "0.0 1.0";
  textureCoords[2]     = "0.5 1.0";
  textureCoords[3]     = "0.5 0.5";

  dragCoeffiecient     = 100;
  gravityCoefficient   = "-3.00122"; //0;
  inheritedVelFactor   = "0.248532";
  constantAcceleration = 0.1;
  lifetimeMS           = 600; //1200;
  lifetimeVarianceMS   = 150; //300;
  useInvAlpha          =  false;
  spinRandomMin        = "-208";
  spinRandomMax        = "375.3";
  colors[0]            = "1.0 1.0 1.0 1.0"; //"1.0 1.0 1.0 1.0";
  colors[1]            = "0.748031 0.748031 0.748031 0.748031"; //"1.0 1.0 0.0 1.0";
  colors[2]            = "0.496063 0.496063 0.496063 0.496063"; //"1.0 0.0 0.0 1.0";
  colors[3]            = "0.244094 0.244094 0.244094 0"; //"1.0 0.0 0.0 0.0";
  sizes[0]             = "3.125"; //3.0*0.5*0.5;
  sizes[1]             = "4.49989"; //5.0*0.5;
  sizes[2]             = "6.25"; //7.0*0.5;
  sizes[3]             = "7.29167";
  times[0]             = 0.0;
  times[1]             = 0.4;//0.2;
  times[2]             = "0.698039";
  times[3]             = 1.0;   
};

datablock BillboardParticleData(PCO_ExplosionFire_nRot_P : PCO_ExplosionFire_pRot_P)
{
  spinRandomMin        = -900.0;
  spinRandomMax        = -700.0;
};

datablock BillboardParticleData(PCO_SparkleA_P)
{
   dragCoeffiecient     = 0.5;
   gravityCoefficient   = 1.0;
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   spinRandomMin        = 0.0;
   spinRandomMax        = 0.0;
   colors[0]            = "1 1 1 1";
   colors[1]            = "1 1 1 0.5";
   colors[2]            = "0 0 0 0";
   sizes[0]             = 1.0;
   sizes[1]             = 1.0;
   sizes[2]             = 1.0;
   times[0]             = 0.0;
   times[1]             = 0.5;
   times[2]             = 1.0;

   textureName          = "art/Worlds/TheBog/particles/PCO_tiled_parts";
   textureCoords[0]     = "0.0 0.0";
   textureCoords[1]     = "0.0 0.5";
   textureCoords[2]     = "0.5 0.5";
   textureCoords[3]     = "0.5 0.0";
};

datablock BillboardParticleData(PCO_SparkleB_P : PCO_SparkleA_P)
{ 
  sizes[0]             = 0.5;
  sizes[1]             = 0.5;
  sizes[2]             = 0.5;   

  textureName          = "art/Worlds/TheBog/particles/PCO_tiled_parts";
  textureCoords[0]     = "0.50 0.00";
  textureCoords[1]     = "0.50 0.25";
  textureCoords[2]     = "0.75 0.25";
  textureCoords[3]     = "0.75 0.00";
};

datablock BillboardParticleData(PCO_SparkleA_pink_P : PCO_SparkleA_P)
{
  gravityCoefficient   = -3*1.25;
  lifetimeMS           = 400*1.5;
  lifetimeVarianceMS   = 100*1.5;
  
  textureCoords[0]     = "0.5 0.5";
  textureCoords[1]     = "0.5 1.0";
  textureCoords[2]     = "1.0 1.0";
  textureCoords[3]     = "1.0 0.5";
};

datablock BillboardParticleData(PCO_SparkleB_pink_P : PCO_SparkleB_P)
{
  gravityCoefficient   = -3*1.6;
  lifetimeMS           = 400*2.5;
  lifetimeVarianceMS   = 100*2.5;

  textureCoords[0]     = "0.75 0.00";
  textureCoords[1]     = "0.75 0.25";
  textureCoords[2]     = "1.00 0.25";
  textureCoords[3]     = "1.00 0.00";
};

datablock SphereEmitterData(PCO_ExplosionSpirals_E)
{
   ejectionOffset        = 0.0;
   ejectionPeriodMS      = "42";
   periodVarianceMS      = "0";
   ejectionVelocity      = "0";
   velocityVariance      = "0";  
   particles             = "PCO_ExplosionFire_pRot_P PCO_ExplosionFire_nRot_P" SPC
                           "PCO_SparkleA_pink_P PCO_SparkleA_pink_P" SPC
                           "PCO_SparkleB_pink_P" SPC
                           "PCO_SparkleA_pink_P PCO_SparkleA_pink_P" SPC
                           "PCO_SparkleB_pink_P PCO_SparkleB_pink_P";

   vector = "0 0 1";
   radiusMin = 0.0;
   radiusMax = "1.79";
   thetaMax = "0";
   blendStyle = "ADDITIVE";
   alignParticles = "1";
   alignDirection = "0 0 1";
   softParticles = "0";
};

