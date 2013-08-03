//------------------------------------------------------------------------------
//------------------------------ SPHERE EMITTERS -------------------------------
//------------------------------------------------------------------------------
datablock SphereEmitterNodeData(s_DefaultNode)
{
   timeMultiple = 1;
};

//------------------------------------------------------------------------------
//------------------------------- GRAPH EMITTERS -------------------------------
//------------------------------------------------------------------------------
datablock GraphEmitterNodeData(g_DefaultNode)
{
   timeMultiple = 1;
   
   funcMax = 2000;
   funcMin = 0;
   timeScale = 1;
   ProgressMode = 0;

   standAloneEmitter = false;   
   
   sa_ejectionPeriodMS = "1";
   sa_periodVarianceMS = "0";
   sa_ejectionVelocity = "0";
   sa_velocityVariance = "0";
   sa_ejectionOffset = "0.08";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softnessDistance = "0.01";
};

datablock GraphEmitterData(g_DefaultEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
};

//---------------------GRAPH EMITTER SAMPLES---------------------

// Used by the testEffects
datablock GraphEmitterData(g_sampleEmitter : g_DefaultEmitter)
{
   ejectionOffset = "0.08";
   softnessDistance = "0.01";
};

datablock SphereEmitterNodeData( pEffecTest : s_DefaultNode )
{   
   sa_ejectionVelocity = 0;
   sa_ejectionPeriodMS = "50";
   standAloneEmitter = 1;
   sa_periodVarianceMS = "0";
   sa_velocityVariance = "0";
   sa_ejectionOffset = "0";
};

//------------------------------------------------------------------------------
//-------------------------------- MESH EMITTERS -------------------------------
//------------------------------------------------------------------------------
datablock MeshEmitterData(m_DefaultEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softnessDistance = "0.01";
};

//------------------------------------------------------------------------------
//----------------------------- RADIUSMESH EMITTERS ----------------------------
//------------------------------------------------------------------------------
datablock RadiusMeshEmitterData(rm_DefaultEmitter)
{
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softnessDistance = "0.01";
};

//------------------------------------------------------------------------------
//------------------------------- GROUND EMITTERS ------------------------------
//------------------------------------------------------------------------------
datablock GroundEmitterNodeData(gr_DefaultNode)
{
   timeMultiple = 1;
   
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   blendStyle = "ADDITIVE";
   softnessDistance = "0.01";
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

//------------------------------------------------------------------------------
//-------------------------------- MASK EMITTERS -------------------------------
//------------------------------------------------------------------------------
datablock PixelMask(pMask1)
{
	MaskPath = "./IPS.png";
	Treshold = 125;
};

datablock MaskEmitterData(msk_DefaultEmitter)
{
   ejectionPeriodMS = "500";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "0.1";
   PixelMask = "pMask1";
};

datablock MaskEmitterNodeData(msk_DefaultNode)
{
   timeMultiple = 1;
   
   ejectionPeriodMS = "1";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "1";
   blendStyle = "ADDITIVE";
   softnessDistance = "0.01";
};

//------------------------------------------------------------------------------
//------------------------------- SPHERE EMITTERS ------------------------------
//------------------------------------------------------------------------------
datablock SphereEmitterData(SampleEmitter)
{
   ejectionPeriodMS = "50";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0.2";
   thetaMax = "40";
   particles = "DefaultParticle";
   blendStyle = "ADDITIVE";
   softParticles = "0";
   softnessDistance = "1";
};

//------------------------------------------------------------------------------
//------------------------------- PARTICLEEFFECTS ------------------------------
//------------------------------------------------------------------------------
datablock ParticleEffectData(DefaultEffect)
{
   pEffect = "./testEffect.pEffect";
   lifeTimeMS = 20000;
};

datablock ParticleEffectData(DefaultEffect2)
{
   pEffect = "./testEffect_2.pEffect";
   lifeTimeMS = 20000;
};