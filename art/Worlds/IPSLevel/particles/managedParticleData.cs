//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// This is the default save location for any Particle datablocks created in the
// Particle Editor (this script is executed from onServerCreated())

datablock BillboardParticleData(ParticleRockImpactInner01)
{
   textureName = "art/Worlds/IPSLevel/particles/rock_impact_1_inner.png";
   animTexName = "art/Worlds/IPSLevel/particles/rock_impact_1_inner.png";
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

datablock GraphEmitterData(g_wavesEmitter : g_DefaultEmitter)
{
   xFunc = "cos(t)*t*0.02";
   yFunc = "sin(t)*t*0.02";
   zFunc = "0.1"; // Offset it just a bit over the ground so it is not partially hidden
};

datablock GraphEmitterData(g_squareSpiralEmitter : g_DefaultEmitter)
{
   xFunc = "cos(t/50)*t*0.02";
   yFunc = "sin(t)*t*0.02";
   zFunc = "0";
};

datablock GraphEmitterData(g_spiralEmitter : g_DefaultEmitter)
{
   xFunc = "cos(t/50)*t*0.02";
   yFunc = "sin(t/50)*t*0.02";
   zFunc = "0";
};

datablock GraphEmitterData(g_upWavesEmitter : g_DefaultEmitter)
{
   xFunc = "cos(t)*t*0.02";
   yFunc = "sin(t)*t*0.02";
   zFunc = "t/20";
};

datablock GraphEmitterData(g_upSpiralEmitter : g_DefaultEmitter)
{
   xFunc = "cos(t/50)";
   yFunc = "sin(t/50)";
   zFunc = "t/200";
   funcMax = 500;
};

datablock GraphEmitterData(g_compSpiralEmitter : g_DefaultEmitter)
{
   xFunc = "t<500 ? cos(t/50)*t*0.02 : t<1000 ? cos(t/50)*t*0.1 : t<1500 ? cos(t/50)*t*0.02 : cos(t/50)*t*0.1";
   yFunc = "t<500 ? sin(t/50)*t*0.02 : t<1000 ? sin(t/50)*t*0.1 : t<1500 ? sin(t/50)*t*0.02 : sin(t/50)*t*0.1";
   zFunc = "t/20";
};

datablock GraphEmitterData(g_downSpiralEmitter : g_DefaultEmitter)
{
   xFunc = "cos(t/50)*t*0.02";
   yFunc = "sin(t/50)*t*0.02";
   zFunc = "t/20";
   Reverse = true;
   Loop = false;
};

datablock GraphEmitterData(g_MarsTeleport : g_DefaultEmitter)
{
   xFunc = "cos(t/25)*(2000-t)*0.0005";
   yFunc = "sin(t/25)*(2000-t)*0.0005";
   zFunc = "t/400";
   funcMax = 2000;
   timeScale = 1.25;
   ProgressMode = "ByTime";
   Reverse = true;
   Loop = true;
};

datablock GroundEmitterData(gr_DefaultEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
   radius = "1";
};

datablock BillboardParticleData(StarMaskParticle : DefaultParticle)
{
   textureName = "core/art/particles/flare.png";
   animTexName = "core/art/particles/flare.png";
   colors[0] = "0.678431 0.686275 0.913726 0.207";
   colors[1] = "0 0.543307 1 0.759";
   colors[2] = "0.0472441 0.181102 0.92126 0.838";
   colors[3] = "0.141732 0.0393701 0.944882 1";
   sizes[0] = "0";
   sizes[1] = "0.1";
   sizes[2] = "0.1";
   sizes[3] = "0.1";
   times[0] = 0.0;
   times[1] = 0.247059;
   times[2] = 0.494118;
   times[3] = 1;
};

datablock PixelMask(ipsMask1)
{
	MaskPath = "./IPS.png";
};

datablock PixelMask(starMask1)
{
	MaskPath = "core/art/defaultParticle.png";
};

datablock MaskEmitterData(msk_DefaultEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   particles = "StarMaskParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
   PixelMask = "ipsMask1";
   Alpha_min = 125;
   Alpha_max = 255;
   Grounded = false;
};

datablock MaskEmitterData(StarMaskEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   particles = "StarMaskParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
   PixelMask = "starMask1";
   Alpha_min = 125;
   Alpha_max = 225;
   Grounded = false;
   //lifetimeMS = "1000";
};


datablock GraphEmitterData(AxelTestEmitter01Data)
{
   xFunc = "cos(t/50)*t*0.0012";
   yFunc = "sin(t/50)*t*0.0012";
   zFunc = "t/800";
   funcMax = 3000;
   timeScale = 1.25;
   ProgressMode = "ByTime";
   Reverse = false;
   Loop = true;
   particles = "AxelTestParticle01";// TAB "AxelTestParticle02" TAB "AxelTestParticle03";
};

datablock SphereEmitterData(AxelSTestEmitter01Data)
{
   particles = "AxelTestParticle01";// TAB "AxelTestParticle02" TAB "AxelTestParticle03";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "10";
   velocityVariance = "0";
   softParticles = "1";
   softnessDistance = "1";
};