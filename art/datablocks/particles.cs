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

datablock ParticleEmitterNodeData(DefaultEmitterNodeData)
{
   timeMultiple = 1;
};

//------------------------------------------------------------------------------
datablock ParticleEmitterNodeData(DefaultNodeTwentyTM)
{
   timeMultiple = 20;
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

/////////////////////// Lightning Flash////////////////////////////
datablock BillboardParticleData(LightningBlast0)
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

datablock BillboardParticleData(LightningRod0)
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

//////////////////////DamageNumberEmitter//////////////

datablock SpriteParticleData(damageAmountParticle)
{
   textureName          = "core/art/particles/SpriteNumbers01";
   gridSize             = "8 12";
   gravityCoefficient   = -0.03;
   inheritedVelFactor   = "0.8";
   constantAcceleration = "0";
   lifetimeMS           = "3000";
   lifetimeVarianceMS   = "500";
   useInvAlpha =  false;
   spinRandomMin = -5;
   spinRandomMax = 5;

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
};

datablock SpriteEmitterData(DamageNumberEmitter)
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
   useEmitterColors = true;
};

/////////////////GENERIC SMOKE//////////////////////

datablock BillboardParticleData(GenericSmoke)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient     = 0.3;
   gravityCoefficient   = -0.5;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 250;
   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   //colors[0]     = "0.0 0.0 0.0 0.0";
   //colors[1]     = "0.2 0.2 0.2 0.1";
   //colors[2]     = "0.0 0.0 0.0 0.0";

   sizes[0]      = 1.5;
   sizes[1]      = 2.75;
   sizes[2]      = 6.5;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(GenericSmokeEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 1;
   velocityVariance = 0.00;
   ejectionOffset = 1.0;

   thetaMin         = 1.0;
   thetaMax         = 100.0;

   particles = "GenericSmoke";
   blendStyle = "NORMAL";
};

/////////////////SmokeEmitter//////////////////////////

datablock BillboardParticleData(Smoke)
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

/////////////////////////Large Smoke Emitter/////////////////////////////

datablock BillboardParticleData(LargeSmoke)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient     = 0.3;
   gravityCoefficient   = -0.5;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 250;
   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "0.0 0.0 0.0 0.0";
   colors[1]     = "0.2 0.2 0.2 0.1";
   colors[2]     = "0.0 0.0 0.0 0.0";

   sizes[0]      = 7.5;
   sizes[1]      = 12.75;
   sizes[2]      = 19.5;

   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(LargeSmokeEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 0.55;
   velocityVariance = 0.00;
   ejectionOffset = 2.0;
   
   //highResOnly = false;

   thetaMin         = 1.0;
   thetaMax         = 120.0;

   particles = "LargeSmoke";
};

/////////////////////BIG SMOKE////////////////////////////

datablock BillboardParticleData(BigSmoke)
{
   textureName          = "core/art/particles/smoke";
   animTexName="core/art/particles/smoke";
   HighResTexture = "core/art/particles/smoke";
   dragCoefficient     = "0";
   gravityCoefficient   = "-0.879336";   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 9000;
   lifetimeVarianceMS   = 250;
   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;
   //colors[0]     = "0.0 0.0 0.0 0.0";
   //colors[1]     = "0.2 0.2 0.2 0.1";
   //colors[2]     = "0.0 0.0 0.0 0.0";
   sizes[0]      = "50";
   sizes[1]      = "41.6667";
   sizes[2]      = "26.0417";
   times[0]      = "0.104167";
   times[1]      = "0.1875";
   times[2]      = "0.291667";
   colors[0] = "1 0.905882 0 1";
   colors[2] = "0.352941 0.352941 0.352941 0.73";
   colors[3] = "0.00787402 0.00787402 0.00787402 0";
   sizes[3] = "21.8733";
   sizes[4] = "20.4997";
   sizes[5] = "20.5";
   sizes[6] = "20.5";
   sizes[7] = "20.5";
   times[3] = "0.458333";
   times[4] = "5";
   times[5] = "5";
   times[6] = "5";
   times[7] = "5";
   colors[1] = "1 0.396078 0 1";
   spinSpeed = "0.458";
};

datablock SphereEmitterData(BigSmokeEmitter)
{
   ejectionPeriodMS = 120;
   periodVarianceMS = 5;

   ejectionVelocity = 0.2;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 160.0;

   particles = BigSmoke;
   blendStyle = "NORMAL";
};

/////////////////////Huge SMOKE////////////////////////////

datablock BillboardParticleData(HugeSmoke)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient     = "0";
   gravityCoefficient   = "-0.886447";   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 9000;
   lifetimeVarianceMS   = 250;
   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   //colors[0]     = "0.0 0.0 0.0 0.0";
   //colors[1]     = "0.2 0.2 0.2 0.1";
   //colors[2]     = "0.0 0.0 0.0 0.0";

   sizes[0]      = "50";
   sizes[1]      = "37.4998";
   sizes[2]      = "29.1661";

   times[0]      = 0.0;
   times[1]      = "0.364706";
   times[2]      = "0.576471";
   animTexName = "core/art/particles/smoke";
   colors[0] = "1 0.708661 0 1";
   colors[2] = "0.905512 0.905512 0.905512 0.00787402";
   colors[3] = "0.00787402 0.00787402 0.00787402 0";
   sizes[3] = "21.8746";
   sizes[4] = "20.4997";
   sizes[5] = "20.5";
   sizes[6] = "20.5";
   sizes[7] = "20.5";
   times[3] = "1";
   times[4] = "5";
   times[5] = "5";
   times[6] = "5";
   times[7] = "5";
   colors[1] = "0.456693 0.456693 0.456693 1";
   spinSpeed = "0.458";
};

datablock SphereEmitterData(HugeSmokeEmitter)
{
   ejectionPeriodMS = 120;
   periodVarianceMS = 5;
   ejectionVelocity = 0.2;
   velocityVariance = 0.0;
   thetaMin         = 0.0;
   thetaMax         = 160.0;
   particles = HugeSmoke;
   blendStyle = "NORMAL";
};

/////////////////////MoragVolcanoSmoke////////////////////////////

datablock BillboardParticleData(MoragVolcanoSmoke)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient     = "0";
   gravityCoefficient   = "-0.886447";   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 9000;
   lifetimeVarianceMS   = 250;
   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   //colors[0]     = "0.0 0.0 0.0 0.0";
   //colors[1]     = "0.2 0.2 0.2 0.1";
   //colors[2]     = "0.0 0.0 0.0 0.0";

   sizes[0]      = "50";
   sizes[1]      = "37.4998";
   sizes[2]      = "29.1661";

   times[0]      = 0.0;
   times[1]      = "0.364706";
   times[2]      = "0.576471";
   animTexName = "core/art/particles/smoke";
   colors[0] = "1 0.708661 0 1";
   colors[2] = "0.905512 0.905512 0.905512 0.00787402";
   colors[3] = "0.00787402 0.00787402 0.00787402 0";
   sizes[3] = "21.8746";
   sizes[4] = "20.4997";
   sizes[5] = "20.5";
   sizes[6] = "20.5";
   sizes[7] = "20.5";
   times[3] = "1";
   times[4] = "5";
   times[5] = "5";
   times[6] = "5";
   times[7] = "5";
   colors[1] = "0.456693 0.456693 0.456693 1";
   spinSpeed = "0.458";
};

datablock SphereEmitterData(MoragVolcanoSmokeEmitter)
{
   ejectionPeriodMS = 120;
   periodVarianceMS = 5;
   ejectionVelocity = 0.2;
   velocityVariance = 0.0;
   thetaMin         = 0.0;
   thetaMax         = 160.0;
   particles = MoragVolcanoSmoke;
   blendStyle = "NORMAL";
};

/////////////////////////EmberEmitter/////////////////////////////////////

datablock BillboardParticleData(EmberParticle)
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

//////////////////////FireEmitter////////////////////////

datablock BillboardParticleData(FireParticle)
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

///////////////////Large Fire Emitter//////////////////////////////////

// LargeFire

datablock BillboardParticleData(LargeFire)
{
   textureName          = "core/art/particles/smoke";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.05;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 7000;
   lifetimeVarianceMS   = 1000;
   useInvAlpha = 0;
   spinRandomMin = -90.0;
   spinRandomMax = 90.0;
   spinSpeed = 1.0;

   colors[0]     = "0.2 0.2 0.0 0.2";
   colors[1]     = "0.6 0.2 0.0 0.2";
   colors[2]     = "0.4 0.0 0.0 0.1";
   colors[3]     = "0.1 0.04 0.0 0.3";

   sizes[0]      = 1.5;
   sizes[1]      = 1.0;
   sizes[2]      = 5.0;
   sizes[3]      = 6.0;

   times[0]      = 0.0;
   times[1]      = 0.1;
   times[2]      = 0.2;
   times[3]      = 0.3;
};

datablock SphereEmitterData(LargeFireEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 0.55;
   velocityVariance = 0.00;
   ejectionOffset = 2.0;
   
   //highResOnly = false;

   thetaMin         = 1.0;
   thetaMax         = 120.0;

   particles = "LargeFire";
};

///////////////////TorchFireEmitter/////////////////////////////////////

datablock BillboardParticleData(TorchFire1)
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

datablock BillboardParticleData(TorchFire2)
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

////////////////////////Shrine_Fire_Emitter//////////////////////////////////////

datablock BillboardParticleData(shrinefireparticle)
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

////////////////////Mist//////////////////

datablock BillboardParticleData(ParticleMist)
{
   textureName="core/art/particles/mist.png";
   animTexName="core/art/particles/mist.png";
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

////////////////////WaterFall1////////////////

datablock BillboardParticleData(ParticleMainFalls01)
{
   textureName="core/art/particles/mainfalls01.png";
   animTexName="core/art/particles/mainfalls01.png";
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

//////////////////////////WaterFall2//////////////////////////

datablock BillboardParticleData(ParticleMainFalls02)
{
   textureName="core/art/particles/mainfalls02.png";
   animTexName="core/art/particles/mainfalls02.png";
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

////////////////////////WaterFall3///////////////////////////

datablock BillboardParticleData(ParticleMainFalls03)
{
   textureName="core/art/particles/mainfalls03.png";
   animTexName="core/art/particles/mainfalls03.png";
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

//////////////////////////////////RockImpact////////////////

datablock BillboardParticleData(ParticleRockImpactInner01)
{
   textureName="core/art/particles/rock_impact_1_inner.png";
   animTexName="core/art/particles/rock_impact_1_inner.png";
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

/////////////////////////////////TopSpray////////////////////////

datablock BillboardParticleData(ParticleRockImpactTop)
{
   textureName="core/art/particles/topandtopspray.png";
   animTexName="core/art/particles/topandtopspray.png";
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

/////////////////////////////WaterDisturbance//////////////

datablock BillboardParticleData(ParticleWaterDisturbance)
{
   textureName="core/art/particles/ripple.png";
   animTexName="core/art/particles/ripple.png";
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

///////////////////////////////Steam//////////////

datablock BillboardParticleData(ParticleSteamData)
{
   textureName="core/art/particles/smoke2.png";
   animTexName="core/art/particles/smoke2.png";
   lifetimeMS = "5000";
   lifetimeVarianceMS = "250";
   spinRandomMin = "-25";
   spinRandomMax = "25";
   colors[0] = "0.992126 0.992126 0.992126 0";
   colors[1] = "0.992126 0.992126 0.992126 0.207";
   colors[2] = "0.992126 0.992126 0.992126 0";
   colors[3] = "0.992126 0.992126 0.992126 1";
   sizes[1] = "33.3303";
   sizes[2] = "31.2489";
   sizes[3] = "0";
   times[1] = "0.498039";
   times[2] = "1";
   times[3] = "1";
   spinSpeed = "0.05";
   sizes[0] = "27.083";
   gravityCoefficient = "0";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
};

datablock SphereEmitterData(ParticleSteamEmitter)
{
   ejectionPeriodMS = 625;
   periodVarianceMS = 10;
   ejectionVelocity = 0;
   velocityVariance = 0;
   thetaMin         = 0.0;
   thetaMax         = 39;
   lifetimeMS       = 0;
   particles = "ParticleSteamData";
   blendStyle = "NORMAL";
   ejectionOffset = "40";
   softnessDistance = "1";
   softParticles = "1";
   lifetimeVarianceMS = "0";
};

//////////////////////////////WaterVortex/////////////////

datablock BillboardParticleData(WaterVortexParticle)
{
   textureName="core/art/particles/rockimpacttopandsidespray.png";
   animTexName="core/art/particles/rockimpacttopandsidespray.png";
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

////////////////////////////BUBBLE////////////////////////////////

datablock BillboardParticleData(BubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.50;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   textureName          = "core/art/particles/splash";
   colors[0]     = "0.7 0.8 1.0 0.4";
   colors[1]     = "0.7 0.8 1.0 0.4";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.1;
   sizes[1]      = 0.3;
   sizes[2]      = 0.3;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(BubbleEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 2.0;
   ejectionOffset   = 0.5;
   velocityVariance = 0.5;
   thetaMin         = 0;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "BubbleParticle";
};

//////////////////////FOAM//////////////////////////////////////

datablock BillboardParticleData(FoamParticle)
{
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.05;
   inheritedVelFactor   = 0.1;
   constantAcceleration = 0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "core/art/particles/millsplash01";
   colors[0]     = "0.7 0.8 1.0 0.20";
   colors[1]     = "0.7 0.8 1.0 0.20";
   colors[2]     = "0.7 0.8 1.0 0.00";
   sizes[0]      = 0.2;
   sizes[1]      = 0.4;
   sizes[2]      = 1.6;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(FoamEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;
   ejectionVelocity = 3.0;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 85;
   thetaMax         = 85;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "FoamParticle";
};

/////////////////////FOAM DROPLETS////////////////////////////

datablock BillboardParticleData(FoamDropletsParticle)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 0;
   textureName          = "core/art/particles/splash";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.8;
   sizes[1]      = 0.3;
   sizes[2]      = 0.0;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(FoamDropletsEmitter)
{
   ejectionPeriodMS = 7;
   periodVarianceMS = 0;
   ejectionVelocity = 2;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 60;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   orientParticles  = true;
   particles = "FoamDropletsParticle";
};

/////////////////////////WAKE///////////////////////////////////

datablock BillboardParticleData(WakeParticle)
{
   textureName          = "core/art/particles/wake";
   dragCoefficient     = "0.0";
   gravityCoefficient   = "0.0";
   inheritedVelFactor   = "0.0";
   lifetimeMS           = "2500";
   lifetimeVarianceMS   = "200";
   windCoefficient = "0.0";
   useInvAlpha = "1";
   spinRandomMin = "30.0";
   spinRandomMax = "30.0";

   animateTexture = true;
   framesPerSec = 1;
   animTexTiling = "2 1";
   animTexFrames = "0 1";

   colors[0]     = "1 1 1 0.1";
   colors[1]     = "1 1 1 0.7";
   colors[2]     = "1 1 1 0.3";
   colors[3]     = "0.5 0.5 0.5 0";

   sizes[0]      = "1.0";
   sizes[1]      = "2.0";
   sizes[2]      = "3.0";
   sizes[3]      = "3.5";

   times[0]      = "0.0";
   times[1]      = "0.25";
   times[2]      = "0.5";
   times[3]      = "1.0";
};

datablock SphereEmitterData(WakeEmitter)
{
   ejectionPeriodMS = "188";
   periodVarianceMS = "10";

   ejectionVelocity = "0";
   velocityVariance = "0";

   ejectionOffset   = "0";

   thetaMin         = "89";
   thetaMax         = "90";

   phiReferenceVel  = "0";
   phiVariance      = "1";

   alignParticles = "1";
   alignDirection = "0 1 0";

   particles = "WakeParticle";
   softnessDistance = "20.8333";
   blendStyle = "NORMAL";
};

////////////////////SPLASH//////////////////////////

datablock BillboardParticleData(SplashParticle)
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 0;
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 0.5;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(SplashEmitter)
{
   ejectionPeriodMS = 354;
   periodVarianceMS = 0;
   ejectionVelocity = 3;
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 60;
   thetaMax         = 80;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   orientParticles  = true;
   lifetimeMS       = 0;
   particles = "SplashParticle";
   blendStyle = "ADDITIVE";
};



//////////////////////SLOW STEAM///////////////

datablock BillboardParticleData(SlowSteamParticle)
{
   textureName          = "core/art/particles/steam";
   dragCoefficient      = 0.3;
   gravityCoefficient   = -0.1;   // rises slowly
   inheritedVelFactor   = 0.00;
   windCoefficient      = 0;
   lifetimeMS           = 3000;
   lifetimeVarianceMS   = 250;
   useInvAlpha = true;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "1 1 1 0.0";
   colors[1]     = "1 1 1 0.1";
   colors[2]     = "1 1 1 0.0";

   sizes[0]      = 0.25;
   sizes[1]      = 1.5;
   sizes[2]      = 2.0;

   times[0]      = 0.0;
   times[1]      = 0.3;
   times[2]      = 1.0;
};

datablock SphereEmitterData(SlowSteamEmitter)
{
   ejectionPeriodMS = 100;
   periodVarianceMS = 25;

   ejectionVelocity = 0.0;
   velocityVariance = 0.0;

   thetaMin         = 0.0;
   thetaMax         = 90.0;  

   particles = SlowSteamParticle;
};

///////////////////////////GENERIC FIRE//////////////////////////////////////

datablock BillboardParticleData(GenericFire)
{
   textureName          = "core/art/particles/smokeCampFire";
   dragCoefficient      = 0.0;
   windCoefficient      = 0.0;
   gravityCoefficient   = -0.05;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = 5000;
   lifetimeVarianceMS   = 1000;
   useInvAlpha = false;
   spinRandomMin = -90.0;
   spinRandomMax = 90.0;
   spinSpeed = 1.0;

   colors[0]     = "0.2 0.2 0.0 0.2";
   colors[1]     = "0.6 0.2 0.0 0.2";
   colors[2]     = "0.4 0.0 0.0 0.1";
   colors[3]     = "0.1 0.04 0.0 0.3";

   sizes[0]      = 0.5;
   sizes[1]      = 2.0;
   sizes[2]      = 3.0;
   sizes[3]      = 4.0;

   times[0]      = 0.0;
   times[1]      = 0.1;
   times[2]      = 0.2;
   times[3]      = 0.3;
};

datablock SphereEmitterData(GenericFireEmitter)
{
   ejectionPeriodMS = 42;
   periodVarianceMS = 0;

   ejectionVelocity = 0.55;
   velocityVariance = 0.00;
   ejectionOffset = 1.0;

   thetaMin         = 1.0;
   thetaMax         = 52.5;

   particles = "GenericFire";
   blendStyle = "ADDITIVE";
   softParticles = "0";
};

//////////////////////////////LavaSpray/////////////////

datablock BillboardParticleData(lavaParticle)
{
   textureName="core/art/particles/waterspray.png";
   animTexName="core/art/particles/waterspray.png";
   dragCoefficient = "0.591398";
   gravityCoefficient = "0.290598";
   lifetimeMS = "3750";
   lifetimeVarianceMS = "3000";
   colors[0] = "1 0.519685 0 1";
   colors[1] = "1 0.0472441 0 1";
   colors[2] = "1 0.0705882 0 0.797";
   sizes[0] = "1.04071";
   sizes[1] = "3.99805";
   sizes[3] = "0";
   colors[3] = "1 0.207843 0 0.299";
   spinRandomMin = "0";
   spinRandomMax = "2";
   times[3] = "2";
   inheritedVelFactor = "1";
   constantAcceleration = "0.1";
   times[0] = "0";
   times[2] = "1";
};

datablock SphereEmitterData(LavaSprayEmitter)
{
   ejectionPeriodMS = "85";
   periodVarianceMS = "40";
   ejectionVelocity = "2";
   velocityVariance = "2";
   thetaMax = "45";
   particles = "lavaParticle";
   blendStyle = "NORMAL";
   ejectionOffset = "0";
   phiVariance = "10";
   softnessDistance = "10";
   softParticles = "1";
   alignDirection = "1 0 0";
   thetaMin = "5";
};

//////////////////////////////LavaSprayTop/////////////////////////

datablock BillboardParticleData(lavaParticleTop)
{
   textureName="core/art/particles/waterspray.png";
   animTexName="core/art/particles/waterspray.png";
   dragCoefficient = "0.591398";
   gravityCoefficient = "0.290598";
   lifetimeMS = "1126";
   lifetimeVarianceMS = "1125";
   colors[0] = "1 0.580392 0 1";
   colors[1] = "1 0.603922 0 1";
   colors[2] = "1 0.509804 0 1";
   sizes[0] = "0";
   sizes[1] = "1.5";
   sizes[3] = "6";
   colors[3] = "1 0.207843 0 1";
   spinRandomMin = "0";
   spinRandomMax = "2";
   times[3] = "1";
   inheritedVelFactor = "1";
   constantAcceleration = "0.1";
   times[0] = "0";
   times[2] = "1";
   sizes[2] = "4";
   times[1] = "0.291667";
};

datablock SphereEmitterData(LavaSprayTop)
{
   ejectionPeriodMS = "85";
   periodVarianceMS = "40";
   ejectionVelocity = "2";
   velocityVariance = "2";
   thetaMax = "45";
   particles = "lavaParticleTop";
   blendStyle = "NORMAL";
   ejectionOffset = "0.208";
   phiVariance = "10";
   softnessDistance = "10";
   softParticles = "1";
   alignDirection = "1 0 0";
   thetaMin = "5";
};

//////////////////////////////LavaMagma/////////////////////

datablock BillboardParticleData(LavaMagmaParticle)
{
   textureName="core/art/particles/spark.png";
   animTexName="core/art/particles/spark.png";
   dragCoefficient = "0.997067";
   gravityCoefficient = "2";
   lifetimeMS = "3500";
   lifetimeVarianceMS = "1000";
   colors[0] = "1 0.88189 0 1";
   colors[1] = "1 0.834646 0 1";
   colors[2] = "1 0.0551181 0 0.866142";
   sizes[0] = "0.497467";
   sizes[1] = "1.99902";
   sizes[3] = "5.99707";
   colors[3] = "1 0.0551181 0 0.700787";
   spinRandomMin = "0";
   spinRandomMax = "4";
   times[3] = "0.898039";
   inheritedVelFactor = "0.996086";
   constantAcceleration = "0";
   times[0] = "0";
   sizes[2] = "2.99701";
   times[1] = "0.4";
   times[2] = "0.898039";
};

datablock SphereEmitterData(LavaMagmaEmitter)
{
   ejectionPeriodMS = "60";
   periodVarianceMS = "0";
   ejectionVelocity = "7.5";
   velocityVariance = "0.2";
   thetaMax = "20";
   particles = "lavamagmaParticle";
   blendStyle = "NORMAL";
   ejectionOffset = "0";
   phiVariance = "360";
   softnessDistance = "1";
   softParticles = "1";
   alignDirection = "1 0 0";
   thetaMin = "12";
   orientParticles = "1";
   alignParticles = "0";
};

//////////////////////////////LavaSteam/////////////////////////////////////

datablock BillboardParticleData(LavaSteamData)
{
   textureName="core/art/particles/smoke2.png";
   animTexName="core/art/particles/smoke2.png";
   lifetimeMS = "5500";
   lifetimeVarianceMS = "350";
   spinRandomMin = "-28";
   spinRandomMax = "24";
   colors[0] = "0.996078 0.780392 0.458824 0.023622";
   colors[1] = "0.996078 0.698039 0.439216 0.11811";
   colors[2] = "0.996078 0.698039 0.439216 0.0472441";
   colors[3] = "0.988235 0.788235 0.0117647 1";
   sizes[1] = "29.9976";
   sizes[2] = "15.9983";
   sizes[3] = "0";
   times[1] = "0.6";
   times[2] = "1";
   times[3] = "1";
   spinSpeed = "0.1";
   sizes[0] = "19.9994";
   gravityCoefficient = "-0.0708181";
   inheritedVelFactor = "0";
   constantAcceleration = "0";
   dragCoefficient = "0";
};

datablock SphereEmitterData(LavaSteamEmitter)
{
   ejectionPeriodMS = 625;
   periodVarianceMS = 10;
   ejectionVelocity = 0;
   velocityVariance = 0;
   thetaMin         = 0.0;
   thetaMax         = 39;
   lifetimeMS       = 0;
   particles = "LavaSteamData";
   blendStyle = "NORMAL";
   ejectionOffset = "8";
   softnessDistance = "1";
   softParticles = "1";
   lifetimeVarianceMS = "0";
};

//////////////////////////////LavaDisturbance/////////////////////////

datablock BillboardParticleData(LavaDisturbanceParticle)
{
   textureName="core/art/particles/ripple.png";
   animTexName="core/art/particles/ripple.png";
   lifetimeMS = "8000";
   lifetimeVarianceMS = "0";
   spinRandomMin = "0";
   spinRandomMax = "0";
   colors[0] = "1 0.614173 0 1";
   colors[1] = "1 0.322835 0 1";
   colors[2] = "0.992126 0.0551181 0 1";
   colors[3] = "1 0.0472441 0 1";
   sizes[1] = "3.99805";
   sizes[2] = "5.99402";
   sizes[3] = "5.99402";
   times[1] = "0.141176";
   times[2] = "0.286275";
   times[3] = "0.329412";
   spinSpeed = "0";
   sizes[0] = "3.99805";
   constantAcceleration = "0";
};

datablock SphereEmitterData(LavaDisturbanceEmitter)
{
   particles = "LavaDisturbanceParticle";
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

///////////////////////LAVABALL/////////////////////////////


datablock SphereEmitterData(LavaBallEmitter)
{
   ejectionPeriodMS = 10;
   periodVarianceMS = 0;

   ejectionVelocity = 0.55;
   velocityVariance = 0.00;
   ejectionOffset = 2.0;
   
   //highResOnly = false;

   thetaMin         = 1.0;
   thetaMax         = 120.0;
   lifetimeMS       = 20000;

   particles = "LargeFire" TAB "LargeSmoke";
};

//////////////////////////////Axels Tests///////////////////////////////////

datablock BillboardParticleData(AxelTestParticle01)
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

datablock BillboardParticleData(AxelTestParticle02)
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

datablock BillboardParticleData(AxelTestParticle03)
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
