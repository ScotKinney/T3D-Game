//------------------------------------------------------------------------------
//---------------------- Teleport Particles and Emitters -----------------------
//------------------------------------------------------------------------------

datablock ParticleData(APParticle : DefaultParticle)
{
   textureName = "core/art/particles/flare.png";
   animTexName = "core/art/particles/flare.png";
   colors[0] = "0.678431 0.686275 0.913726 0.207";
   colors[1] = "0.10 0.0393701 0.944882 1";
   colors[2] = "0.0472441 0.181102 0.92126 0.838";
   colors[3] = "0 0.543307 1 0.759";
   sizes[0] = "0";
   sizes[1] = "0.1";
   sizes[2] = "0.15";
   sizes[3] = "0.15";
   times[0] = 0.0;
   times[1] = 0.247059;
   times[2] = 0.494118;
   times[3] = 1;
   lifetimeMS = 700;
   gravityCoefficient = -0.25;
};

datablock SphereEmitterData(APCloudEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0.2";
   thetaMin = 90;
   thetaMax = 90;
   particles = "APParticle";
   blendStyle = "ADDITIVE";
   softnessDistance = "0.01";
   lifetimeMS = 2000;
};

datablock ParticleData(APSpiralParticle : DefaultParticle)
{
   textureName = "core/art/particles/sparkle.png";
   animTexName = "core/art/particles/sparkle.png";
   colors[0] = "0.678431 0.686275 0.913726 0.207";
   colors[1] = "0.10 0.0393701 1 1";
   colors[2] = "0.0472441 0.181102 0.92126 0.838";
   colors[3] = "0 0.543307 1 0";
   sizes[0] = "0";
   sizes[1] = "0.2";
   sizes[2] = "0.5";
   sizes[3] = "0.4";
   times[0] = 0.0;
   times[1] = 0.25;
   times[2] = 0.8;
   times[3] = 1;

   lifetimeMS = 400;
   lifetimeVarianceMS = 50;
   gravityCoefficient = 0;
};

datablock GraphEmitterData(AP_L_UpSpiralEmitter : g_DefaultEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0";

   particles = "APSpiralParticle";
   blendStyle = "ADDITIVE";

   // 2 second emitter with t incremented by time
   funcMax = 2000;
   funcMin = 0;
   timeScale = 1.00;
   ProgressMode = "ByTime";
   Reverse = true;
   Loop = false;

   // Circle the player about 8 times
   // 8 x 2pi ~= 50
   // 2000 / 50 = 40 <-- This gives us the t/40 in the x and y functions
   // Maximum radius of 0.6, 0.6/2000 = .0003
   xFunc = "cos(t/40)*t*0.0003";
   yFunc = "sin(t/40)*t*0.0003";
   // The player is about 2 units tall. So go from .1 up to 2.1
   zFunc = "2.1-t*.001";
};

datablock GraphEmitterData(AP_L_DnSpiralEmitter : AP_L_UpSpiralEmitter)
{
   zFunc = "0.1+t*.001";
};

datablock GraphEmitterData(AP_A_UpSpiralEmitter : AP_L_UpSpiralEmitter)
{
   Reverse = false;
};

datablock GraphEmitterData(AP_A_DnSpiralEmitter : AP_L_DnSpiralEmitter)
{
   Reverse = false;
};

datablock ParticleData(APMaskParticle : DefaultParticle)
{
   textureName = "core/art/particles/sparkle.png";
   animTexName = "core/art/particles/sparkle.png";
   colors[0] = "0.678431 0.686275 0.913726 0.207";
   colors[1] = "0 0.543307 1 0.759";
   colors[2] = "0.0472441 0.181102 0.92126 0.838";
   colors[3] = "0.141732 0.0393701 0.944882 1";
   sizes[0] = "0";
   sizes[1] = "0.5";
   sizes[2] = "0.5";
   sizes[3] = "0.5";
   times[0] = 0.0;
   times[1] = 0.247059;
   times[2] = 0.494118;
   times[3] = 1;

   lifetimeMS = 400;
   lifetimeVarianceMS = 50;
   gravityCoefficient = 0;
};

datablock PixelMask(APMask1)
{
	MaskPath = "core/art/particles/sparkle.png";
};

datablock MaskEmitterData(APMaskEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = ".2";
   velocityVariance = ".05";
   ejectionOffset = "0";
   particles = "APMaskParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
   PixelMask = "APMask1";
   Alpha_min = 50;
   Alpha_max = 255;
   Grounded = false;
   lifetimeMS = 500;
};
