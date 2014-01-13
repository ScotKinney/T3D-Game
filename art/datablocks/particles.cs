//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

datablock SphereEmitterNodeData(DefaultEmitterNodeData)
{
   timeMultiple = 1;
};

//------------------------------------------------------------------------------
datablock GraphEmitterNodeData(g_DefaultNode)
{
   timeMultiple = 1;
};


datablock GraphEmitterNodeData(g_nodeLightning)
{
   timeMultiple = 20;
};

datablock GraphEmitterNodeData(g_nodeAxelTest01)
{
   timeMultiple = 20;
};

datablock GraphEmitterNodeData(g_nodeAxelTest02)
{
   timeMultiple = 20;
};
datablock GraphEmitterNodeData(g_nodeAxelTest03)
{
   timeMultiple = 20;
};

datablock GroundEmitterNodeData(gr_DefaultNode)
{
   timeMultiple = 1;
};

datablock MaskEmitterNodeData(msk_DefaultNode)
{
   timeMultiple = 1;
};

datablock GraphEmitterData(g_DefaultEmitter)
{
   ejectionPeriodMS = "4";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
};

// Lightning Flash
datablock ParticleData(LightningBlast0)
{
   sizes[0] = "1.2";
   sizes[1] = "1";
   sizes[2] = "1";
   sizes[3] = "1";
   times[1] = "0.229167";
   times[2] = "0.333333";
   HighResTexture = "art/SpellSystem/ParticleTextures/Lightning/bastardbolt0.png";
   textureName = "art/SpellSystem/ParticleTextures/Lightning/bastardbolt0.png";
   animTexName = "art/SpellSystem/ParticleTextures/Lightning/bastardbolt0.png";
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

datablock ParticleData(LightningRod0)
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
   HighResTexture = "art/SpellSystem/ParticleTextures/Lightning/bastardbolt1.png";
   textureName = "art/SpellSystem/ParticleTextures/Lightning/bastardbolt1.png";
   animTexName = "art/SpellSystem/ParticleTextures/Lightning/bastardbolt1.png";
   colors[0] = "0.584314 0.890196 0.996078 1";
   colors[1] = "0.756863 0.996078 0.886275 0.637795";
   colors[2] = "0.996078 0.992157 0.992157 0.330709";
   times[3] = "0.541667";
   dragCoefficient = "0.375";
   gravityCoefficient = "1";
   constantAcceleration = "-10";
};

datablock GraphEmitterData(LightningFlashData)
{
   xFunc = "cos(t/50)*t*0.0012";
   yFunc = "sin(t/50)*t*0.0012";
   zFunc = "t/800";
   funcMax = 3000;
   timeScale = 1.25;
   ProgressMode = "ByTime";
   Reverse = false;
   Loop = true;
   particles = "LightningRod0";
};

datablock ParticleData(AxelTestParticle01)
{
   textureName          = "core/art/particles/ember";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = "-0.051282";   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   spinSpeed            = 0;

   colors[0]     = "1 0.795276 0 0.795276";
   colors[1]     = "1 0.692913 0 0.795276";
   colors[2]     = "1 0 0 0.5";

   sizes[0]      = "0.0488311";
   sizes[1]      = "0.0976622";
   sizes[2]      = "0.0488311";

   times[0]      = 0.0;
   times[1]      = "0.498039";
   times[2]      = 1.0;
   HighResTexture = "core/art/particles/ember";
   animTexName = "core/art/particles/ember";
};

datablock ParticleData(AxelTestParticle02)
{
   textureName          = "core/art/particles/waterDrip";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.05;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   spinSpeed            = 0;

   colors[0]     = "1.000000 0.800000 0.000000 0.800000";
   colors[1]     = "1.000000 0.700000 0.000000 0.800000";
   colors[2]     = "1.000000 0.000000 0.000000 0.200000";

   sizes[0]      = 0.05;
   sizes[1]      = 0.1;
   sizes[2]      = 0.05;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleData(AxelTestParticle03)
{
   textureName          = "core/art/particles/sparkle";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.05;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 0;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   spinSpeed            = 0;

   colors[0]     = "1.000000 0.800000 0.000000 0.800000";
   colors[1]     = "1.000000 0.700000 0.000000 0.800000";
   colors[2]     = "1.000000 0.000000 0.000000 0.200000";

   sizes[0]      = 0.05;
   sizes[1]      = 0.1;
   sizes[2]      = 0.05;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

// Smoke

datablock ParticleData(Smoke)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient      = 0.3;
   gravityCoefficient   = -0.2;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 250;
   useInvAlpha          = true;
   spinRandomMin        = -30.0;
   spinRandomMax        = 30.0;

   sizes[0]      = 1.5;
   sizes[1]      = 2.75;
   sizes[2]      = 6.5;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(SmokeEmitter)
{
   ejectionPeriodMS = 400;
   periodVarianceMS = 5;

   ejectionVelocity = 0.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 90.0;

   particles        = Smoke;
};

datablock SphereEmitterNodeData(SmokeEmitterNode)
{
   timeMultiple = 1;
};

// Ember

datablock ParticleData(EmberParticle)
{
   textureName          = "core/art/particles/ember";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.05;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 0;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   spinSpeed            = 1;

   colors[0]     = "1.000000 0.800000 0.000000 0.800000";
   colors[1]     = "1.000000 0.700000 0.000000 0.800000";
   colors[2]     = "1.000000 0.000000 0.000000 0.200000";

   sizes[0]      = 0.05;
   sizes[1]      = 0.1;
   sizes[2]      = 0.05;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(EmberEmitter)
{
   ejectionPeriodMS = 100;
   periodVarianceMS = 0;

   ejectionVelocity = 0.75;
   velocityVariance = 0.00;
   ejectionOffset   = 2.0;

   thetaMin         = 1.0;
   thetaMax         = 100.0;

   particles        = "EmberParticle";
};

datablock SphereEmitterNodeData(EmberNode)
{
   timeMultiple = 1;
};

// Fire

datablock ParticleData(FireParticle)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.05;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 1000;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 90.0;
   spinSpeed            = 1.0;

   colors[0]     = "0.2 0.2 0.0 0.2";
   colors[1]     = "0.6 0.2 0.0 0.2";
   colors[2]     = "0.4 0.0 0.0 0.1";
   colors[3]     = "0.1 0.04 0.0 0.3";

   sizes[0]      = 0.5;
   sizes[1]      = 4.0;
   sizes[2]      = 5.0;
   sizes[3]      = 6.0;

   times[0]      = 0.0;
   times[1]      = 0.1;
   times[2]      = 0.2;
   times[3]      = 0.3;
};

datablock SphereEmitterData(FireEmitter)
{
   ejectionPeriodMS = 50;
   periodVarianceMS = 0;

   ejectionVelocity = 0.55;
   velocityVariance = 0.00;
   ejectionOffset   = 1.0;


   thetaMin         = 1.0;
   thetaMax         = 100.0;

   particles        = "FireParticle";
};

datablock SphereEmitterNodeData(FireNode)
{
   timeMultiple = 1;
};

// Torch Fire

datablock ParticleData(TorchFire1)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.3;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 500;
   lifetimeVarianceMS   = 250;
   useInvAlpha          = false;
   spinRandomMin        = -30.0;
   spinRandomMax        = 30.0;
   spinSpeed            = 1;

   colors[0]     = "0.6 0.6 0.0 0.1";
   colors[1]     = "0.8 0.6 0.0 0.1";
   colors[2]     = "0.0 0.0 0.0 0.1";

   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 2.4;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock ParticleData(TorchFire2)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.5;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 800;
   lifetimeVarianceMS   = 150;
   useInvAlpha          = false;
   spinRandomMin        = -30.0;
   spinRandomMax        = 30.0;
   spinSpeed            = 1;

   colors[0]     = "0.8 0.6 0.0 0.1";
   colors[1]     = "0.6 0.6 0.0 0.1";
   colors[2]     = "0.0 0.0 0.0 0.1";

   sizes[0]      = 0.3;
   sizes[1]      = 0.3;
   sizes[2]      = 0.3;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(TorchFireEmitter)
{
   ejectionPeriodMS = 15;
   periodVarianceMS = 5;

   ejectionVelocity = 0.25;
   velocityVariance = 0.10;

   thetaMin         = 0.0;
   thetaMax         = 45.0;

   particles        = "TorchFire1" TAB "TorchFire2";
};

datablock SphereEmitterNodeData(TorchFireEmitterNode)
{
   timeMultiple = 1;
};

datablock ParticleData(shrinefireparticle)
{
   textureName          = "core/art/particles/explosion";
   dragCoeffiecient     = 0;
   gravityCoefficient   = -0.5;
   inheritedVelFactor   = "0.8";
   constantAcceleration = "-3";
   lifetimeMS           = "950";
   lifetimeVarianceMS   = 400;
   useInvAlpha =  false;
   spinRandomMin = -280.0;
   spinRandomMax =  280.0;

   colors[0]     = "0.992126 0.937008 0.566929 0.0944882";
   colors[1]     = "1 0.496063 0 0.299213";
   colors[2]     = "0.0944882 0.0944882 0.0944882 0";
   colors[3]     = "0.992157 0.992157 0.992157 0";

   sizes[0]      = "0.6";
   sizes[1]      = "1.3";
   sizes[2]      = 0.4;

   times[0]      = 0.0;
   times[1]      = "0.33";
   times[2]      = "1";
   dragCoefficient = 0.25;
   spinSpeed = "0.5";
   animTexName = "core/art/particles/explosion";
   sizes[3] = "0";
   times[3] = "1";
};

datablock SphereEmitterData(shrine_fire_emitter)
{
   ejectionPeriodMS = 25;
   ejectionVelocity = 0.5;
   velocityVariance = "0";
   ejectionOffset = 0;
   thetaMax = "100";
   particles = "shrinefireparticle";
   blendStyle = "ADDITIVE";
   softParticles = "1";
   softnessDistance = 1;
   periodVarianceMS = "23";
   thetaMin = "0";
};

datablock ParticleData(damageAmountParticle)
{
   textureName          = "core/art/particles/SpriteNumbers01";
   dragCoeffiecient     = 0;
   gravityCoefficient   = -0.03;
   inheritedVelFactor   = "0.8";
   constantAcceleration = "0";
   lifetimeMS           = "3000";
   lifetimeVarianceMS   = "500";
   useInvAlpha =  false;
   spinRandomMin = -5;
   spinRandomMax = 5;

   colors[0]     = "0.5 0.1 0.1 0.8";
   colors[1]     = "0.9 0.25 0.25 1.0";
   colors[2]     = "0.75 0.1 0.1 0.9";
   colors[3]     = ".5 0 0 0";

   sizes[0]      = 0.1;
   sizes[1]      = 0.4;
   sizes[2]      = 0.3;
   sizes[3]      = 0;

   times[0]      = 0.0;
   times[1]      = 0.35;
   times[2]      = 0.8;
   times[3]      = 1;
   
   dragCoefficient = 0.25;
   spinSpeed = "1.0";
   animTexName = "core/art/particles/SpriteNumbers01";
   textureCoords[0]     = "0.375 0.166667";
   textureCoords[1]     = "0.375 0.2474";
   textureCoords[2]     = "0.4974 0.2474";
   textureCoords[3]     = "0.4974 0.166667";
};

datablock SphereEmitterData(NumberTestEmitter)
{
   particles = "damageAmountParticle";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "2000";
   ejectionVelocity = "0.5";
   velocityVariance = "0.1";
   softParticles = "0";
   softnessDistance = "1";
   thetaMin = "15";
   thetaMax = "30";
   phiVariance = "360";
};
