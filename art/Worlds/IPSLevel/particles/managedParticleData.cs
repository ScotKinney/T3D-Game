//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

// This is the default save location for any Particle datablocks created in the
// Particle Editor (this script is executed from onServerCreated())

datablock ParticleData(ParticleRockImpactInner01)
{
   textureName = "art/Worlds/IPSLevel/particles/rock_impact_1_inner.png";
   animTexName = "art/Worlds/IPSLevel/particles/rock_impact_1_inner.png";
   gravityCoefficient = "0.541667";
   inheritedVelFactor = "1.875";
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

datablock GraphEmitterData(g_backburner : g_DefaultEmitter)
{
   xFunc = "cos(t*c)/4";
   yFunc = "sin(t*c)/4";
   zFunc = "(1+(t^2/(v<6?0.4:(v/15))))/15000";
   xVar1c = "1";
   yVar1c = "1";
   zVar1v = "0";
   funcMax = 100;
   timeScale = 8;
   sa_ejectionOffset = 10;
};

datablock GraphEmitterData(advSp_1 : g_DefaultEmitter)
{
   xFunc = "t<1 ? cos(o*1*2*_pi/5)*r : "@
            "t<2 ? cos(o*2*2*_pi/5)*r : "@
            "t<3 ? cos(o*3*2*_pi/5)*r : "@
            "t<4 ? cos(o*4*2*_pi/5)*r : "@
            "cos(o*5*2*_pi/5)*r";
   yFunc = "t<1 ? sin(o*1*2*_pi/5)*r : "@
            "t<2 ? sin(o*2*2*_pi/5)*r : "@
            "t<3 ? sin(o*3*2*_pi/5)*r : "@
            "t<4 ? sin(o*4*2*_pi/5)*r : "@
            "sin(o*5*2*_pi/5)*r";
   zFunc = "h+0.1"; // Offset it just a bit over the ground so it is not partially hidden
   Reverse = true;
   Loop = false;
   xVar1r = 2;
   yVar1r = 2;
   xVar2o = 1;
   yVar2o = 1;
   zVar1h = 0;
   funcMax = 4;
   funcMin = 0;
   timeScale = 1;
   active = true;
   Loop = true;
   sa_ejectionOffset = 1;
};

datablock GraphEmitterData(g_MarsTeleport : g_DefaultEmitter)
{
   xFunc = "cos(t/25)*(2000-t)*0.0005";
   yFunc = "sin(t/25)*(2000-t)*0.0005";
   zFunc = "t/400";
   funcMax = 2000;
   timeScale = 1.25;
   //ProgressMode = "ByTime";
   Reverse = true;
};

