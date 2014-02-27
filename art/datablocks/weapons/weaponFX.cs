// Weapon effects that are used by multiple inventory weapons

//----------------------------------------------------------------------------
// Impact Decals
//----------------------------------------------------------------------------
datablock DecalData(ScorchRXDecal)
{
   Material = "DECAL_RocketEXP";
   size = "2.0";
   lifeSpan = "50000";
   randomize = "1";
   texRows = "2";
   texCols = "2";
   clippingAngle = "60";
};

datablock DecalData(ScorchRXDecalSmall)
{
   Material = "DECAL_RocketEXP";
   size = "0.15";
   lifeSpan = "50000";
   randomize = "1";
   texRows = "2";
   texCols = "2";
   clippingAngle = "60";
};

// ----------------------------------------------------------------------------
// Lights for the projectile(s)
// ----------------------------------------------------------------------------
datablock LightDescription(ProjectileLightDesc)
{
   range = 4.0;
   color = "1 1 0";
   brightness = 5.0;
   animationType = PulseLightAnim;
   animationPeriod = 0.25;
};

// ----------------------------------------------------------------------------
// Sound profiles
// ----------------------------------------------------------------------------
datablock SFXProfile(BaseThrowSound)
{
   filename = "art/sound/weapons/Throw_Javelin";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ThrowDartSound)
{
   filename = "art/sound/weapons/Throw_SlingDart";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(BaseFireSound)
{
   filename = "art/sound/weapons/arrow";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(flintlockFireSound)
{
   filename = "art/sound/weapons/flintlockfire";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(BaseReloadSound)
{
   filename = "art/sound/weapons/Crossbow_reload";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(XR75FireSound)
{
   filename = "art/sound/weapons/droidGun5";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ProjectileExplosionSound)
{
   filename = "art/sound/weapons/Crossbow_explosion";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(flintlockhitSound)
{
   filename = "art/sound/weapons/ricochet";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ProjectileHitSound)
{
   filename = "art/sound/weapons/arrowThud";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(AxeHitLiveSound)
{
   filename = "art/sound/weapons/AxeHitLive";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(AxeHitStaticSound)
{
   filename = "art/sound/weapons/AxeHitStatic";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(JavelinHitStaticSound)
{
   filename = "art/sound/weapons/Hit_Javelin";
   description = AudioClosest3d;
   preload = false;
};
datablock SFXProfile(BowFireSound)
{
   filename = "art/sound/weapons/Fire_Bow";
   description = AudioClosest3d;
   preload = false;
};

datablock SFXProfile(ArrowHitStaticSound)
{
   filename = "art/sound/weapons/Hit_ArrowStatic";
   description = AudioClosest3d;
   preload = false;
};


//----------------------------------------------------------------------------
// Debris
//----------------------------------------------------------------------------
datablock ParticleData(ProjectileTrailParticle)
{
   textureName = "core/art/particles/impact";
   dragCoeffiecient = 0;
   inheritedVelFactor = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS = 1200;//1000;
   lifetimeVarianceMS = 299;//500;
   useInvAlpha = true;//false;
   spinSpeed = 1;
   spinRandomMin = -300.0;
   spinRandomMax = 0;
   colors[0] = "1 0.897638 0.795276 0.4";
   colors[1] = "0.795276 0.795276 0.795276 0.6";
   colors[2] = "0 0 0 0";
   sizes[0] = 0.5;//1.0;
   sizes[1] = 2;
   sizes[2] = 1;//1.0;
   times[0] = 0.0;
   times[1] = 0.498039;
   times[2] = 1.0;
   animTexName = "core/art/particles/impact";
   times[3] = "1";
};

//datablock ParticleData(ProjectileDebrisTrailParticle)
//{
   //textureName = "core/art/particles/impact";
   //dragCoeffiecient = 0;
   //inheritedVelFactor = 0.0;
   //constantAcceleration = 0.0;
   //lifetimeMS = 1200;//1000;
   //lifetimeVarianceMS = 299;//500;
   //useInvAlpha = true;//false;
   //spinSpeed = 1;
   //spinRandomMin = -300.0;
   //spinRandomMax = 0;
   //colors[0] = "1 0.897638 0.795276 0.4";
   //colors[1] = "0.795276 0.795276 0.795276 0.6";
   //colors[2] = "0 0 0 0";
   //sizes[0] = 0.5;//1.0;
   //sizes[1] = 2;
   //sizes[2] = 1;//1.0;
   //times[0] = 0.0;
   //times[1] = 0.498039;
   //times[2] = 1.0;
   //animTexName = "core/art/particles/impact";
   //times[3] = "1";
//};

datablock SphereEmitterData(ProjectileDebrisTrailEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 0;
   ejectionVelocity = 0.5;
   velocityVariance = 0.25;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = false;
   lifetimeMS       = 300;
   particles = "ProjectileTrailParticle";
};

datablock DebrisData(ProjectileDebris)
{
   shapeFile = "core/art/effects/debris_player.dts";
   emitters[0] = ProjectileDebrisTrailEmitter;
   elasticity = 0.5;
   friction = 0.5;
   numBounces = 1;//2;
   bounceVariance = 1;
   explodeOnMaxBounce = true;
   staticOnMaxBounce = false;
   snapOnMaxBounce = false;
   minSpinSpeed = 400;
   maxSpinSpeed = 800;
   render2D = false;
   lifetime = 0.25;//0.5;//1;//2;
   lifetimeVariance = 0.0;//0.25;//0.5;
   velocity = 35;//30;//15;
   velocityVariance = 10;//5;
   fade = true;
   useRadiusMass = true;
   baseRadius = 0.3;
   gravModifier = 1.0;
   terminalVelocity = 45;
   ignoreWater = false;
};

// ----------------------------------------------------------------------------
// Particles and Emitters
// ----------------------------------------------------------------------------
datablock ParticleData(ProjectileExpFire)
{
   gravityCoefficient = "-0.50061";
   lifetimeMS = "400";
   lifetimeVarianceMS = "299";
   spinSpeed = "1";
   spinRandomMin = "-200";
   spinRandomMax = "0";
   textureName = "core/art/particles/smoke";
   animTexName = "core/art/particles/smoke";
   colors[0] = "1 0.897638 0.795276 1";
   colors[1] = "0.795276 0.393701 0 0.6";
   colors[2] = "0 0 0 0";
   sizes[0] = "1.99902";
   sizes[1] = "7.99915";
   sizes[2] = "3.99805";
   times[1] = "0.392157";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(ProjectileExpFireEmitter)
{
   ejectionPeriodMS = "10";
   periodVarianceMS = "5";
   ejectionVelocity = "3";
   velocityVariance = "2";
   particles = "ProjectileExpFire";
   blendStyle = "ADDITIVE";
};

datablock ParticleData(ProjectileExpFireball)
{
   textureName = "core/art/particles/fireball.png";
   lifetimeMS = "300";
   lifetimeVarianceMS = "299";
   spinSpeed = "1";
   spinRandomMin = "-400";
   spinRandomMax = "0";
   animTexName = "core/art/particles/fireball.png";
   colors[0] = "1 0.897638 0.795276 0.2";
   colors[1] = "1 0.496063 0 0.6";
   colors[2] = "0.0944882 0.0944882 0.0944882 0";
   sizes[0] = "0.997986";
   sizes[1] = "1.99902";
   sizes[2] = "2.99701";
   times[1] = "0.498039";
   times[2] = "1";
   times[3] = "1";
   gravityCoefficient = "-1";
};

datablock SphereEmitterData(ProjectileExpFireballEmitter)
{
   particles = "ProjectileExpFireball";
   blendStyle = "ADDITIVE";
   ejectionPeriodMS = "10";
   periodVarianceMS = "5";
   ejectionVelocity = "4";
   velocityVariance = "2";
   ejectionOffset = "2";
   thetaMax = "120";
};

datablock ParticleData(ProjectileExpSmoke)
{
   lifetimeMS = 1200;//"1250";
   lifetimeVarianceMS = 299;//200;//"250";
   textureName = "core/art/particles/smoke";
   animTexName = "core/art/particles/smoke";
   useInvAlpha = "1";
   gravityCoefficient = "-0.100122";
   spinSpeed = "1";
   spinRandomMin = "-100";
   spinRandomMax = "0";
   colors[0] = "0.897638 0.795276 0.692913 0.4";//"0.192157 0.192157 0.192157 0.0944882";
   colors[1] = "0.897638 0.897638 0.897638 0.8";//"0.454902 0.454902 0.454902 0.897638";
   colors[2] = "0.4 0.4 0.4 0";//"1 1 1 0";
   sizes[0] = "1.99597";
   sizes[1] = "3.99805";
   sizes[2] = "7.99915";
   times[1] = "0.494118";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(ProjectileExpSmokeEmitter)
{
   ejectionPeriodMS = "15";
   periodVarianceMS = "5";
   //ejectionOffset = "1";
   thetaMax = "180";
   particles = "ProjectileExpSmoke";
   blendStyle = "NORMAL";
};

datablock ParticleData(ProjectileExpSparks)
{
   textureName = "core/art/particles/droplet.png";
   lifetimeMS = "100";
   lifetimeVarianceMS = "50";
   animTexName = "core/art/particles/droplet.png";
   inheritedVelFactor = "0.391389";
   sizes[0] = "1.99902";
   sizes[1] = "2.49954";
   sizes[2] = "0.997986";
   colors[0] = "1.0 0.9 0.8 0.2";
   colors[1] = "1.0 0.9 0.8 0.8";
   colors[2] = "0.8 0.4 0.0 0.0";
   times[0] = "0";
   times[1] = "0.34902";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(ProjectileExpSparksEmitter)
{
   particles = "ProjectileExpSparks";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "10";
   periodVarianceMS = "5";
   ejectionVelocity = "60";
   velocityVariance = "10";
   thetaMax = "120";
   phiReferenceVel = 0;
   phiVariance = "360";
   ejectionOffset = "0";
   orientParticles = true;
   orientOnVelocity = true;
};

datablock ParticleData(ProjectileExpSubFireParticles)
{
   textureName = "core/art/particles/fireball.png";
   gravityCoefficient = "-0.202686";
   lifetimeMS = "400";
   lifetimeVarianceMS = "299";
   spinSpeed = "1";
   spinRandomMin = "-200";
   spinRandomMax = "0";
   animTexName = "core/art/particles/fireball.png";
   colors[0] = "1 0.897638 0.795276 0.2";
   colors[1] = "1 0.496063 0 1";
   colors[2] = "0.0944882 0.0944882 0.0944882 0";
   sizes[0] = "0.997986";
   sizes[1] = "1.99902";
   sizes[2] = "2.99701";
   times[1] = "0.498039";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(ProjectileExpSubFireEmitter)
{
   particles = "ProjectileExpSubFireParticles";
   blendStyle = "ADDITIVE";
   ejectionPeriodMS = "10";
   periodVarianceMS = "5";
   ejectionVelocity = "4";
   velocityVariance = "2";
   thetaMax = "120";
};

datablock ParticleData(ProjectileExpSubSmoke)
{
   textureName = "core/art/particles/smoke";
   gravityCoefficient = "-0.40293";
   lifetimeMS = "800";
   lifetimeVarianceMS = "299";
   spinSpeed = "1";
   spinRandomMin = "-200";
   spinRandomMax = "0";
   animTexName = "core/art/particles/smoke";
   colors[0] = "0.4 0.35 0.3 0.393701";
   colors[1] = "0.45 0.45 0.45 0.795276";
   colors[2] = "0.4 0.4 0.4 0";
   sizes[0] = "1.99902";
   sizes[1] = "3.99805";
   sizes[2] = "7.99915";
   times[1] = "0.4";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(ProjectileExpSubSmokeEmitter)
{
   particles = "ProjectileExpSubSmoke";
   ejectionPeriodMS = "30";
   periodVarianceMS = "10";
   ejectionVelocity = "2";
   velocityVariance = "1";
   ejectionOffset = 1;//"2";
   blendStyle = "NORMAL";
};

datablock ParticleData(ProjectileSmokeTrail)
{
   textureName = "core/art/particles/smoke";
   dragCoeffiecient = 0;
   gravityCoefficient = -0.202686;
   inheritedVelFactor = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS = 750;
   lifetimeVarianceMS = 749;
   useInvAlpha = true;
   spinRandomMin = -60;
   spinRandomMax = 0;
   spinSpeed = 1;

   colors[0] = "0.3 0.3 0.3 0.30";
   colors[1] = "0.9 0.9 0.9 0.45";
   colors[2] = "0.9 0.9 0.9 0";

   sizes[0] = 0.12;
   sizes[1] = 0.25;
   sizes[2] = 0.35;

   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 1.0;
   animTexName = "core/art/particles/smoke";
   times[3] = "1";
};

datablock SphereEmitterData(ProjectileProjSmokeTrailEmitter)
{
   ejectionPeriodMS = 1;
   periodVarianceMS = 0;
   ejectionVelocity = 0.75;
   velocityVariance = 0;
   thetaMin = 0.0;
   thetaMax = 0.0;
   phiReferenceVel = 90;
   phiVariance = 0;
   particles = "ProjectileSmokeTrail";
};

datablock ParticleData(ProjectileTrailWaterParticle)
{
   textureName = "core/art/particles/bubble";
   dragCoefficient = 0.0;
   gravityCoefficient = 0.1;
   inheritedVelFactor = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS = 1500;
   lifetimeVarianceMS = 600;
   useInvAlpha = false;
   spinRandomMin = -100.0;
   spinRandomMax = 100.0;
   spinSpeed = 1;

   colors[0] = "0.7 0.8 1.0 1.0";
   colors[1] = "0.7 0.8 1.0 0.4";
   colors[2] = "0.7 0.8 1.0 0.0";

   sizes[0] = 0.05;
   sizes[1] = 0.05;
   sizes[2] = 0.05;

   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;
};

datablock SphereEmitterData(ProjectileTrailWaterEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 1.0;
   ejectionOffset = 0.1;
   velocityVariance = 0.5;
   thetaMin = 0.0;
   thetaMax = 80.0;
   phiReferenceVel = 0;
   phiVariance = 360;
   overrideAdvances = false;
   particles = ProjectileTrailWaterParticle;
};

datablock ParticleData(DefaultSparks)
{
   textureName = "core/art/particles/droplet.png";
   lifetimeMS = "50";
   lifetimeVarianceMS = "10";
   inheritedVelFactor = "0.1";
   sizes[0] = "0.25";
   sizes[1] = "0.5";
   sizes[2] = "0.125";
   colors[0] = "1.0 0.9 0.8 0.2";
   colors[1] = "1.0 0.9 0.8 0.8";
   colors[2] = "0.8 0.4 0.0 0.0";
   times[0] = "0";
   times[1] = "0.34902";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(DefaultSparksEmitter)
{
   particles = "DefaultSparks";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "5";
   periodVarianceMS = "1";
   ejectionVelocity = "10";
   velocityVariance = "1";
   thetaMax = "120";
   phiReferenceVel = 0;
   phiVariance = "360";
   ejectionOffset = "0";
   orientParticles = true;
   orientOnVelocity = true;
};

datablock ParticleData(Basefiring2Particle)
{
   textureName = "core/art/particles/impact";
   dragCoefficient = 5.0;
   gravityCoefficient = -0.5;//0.0;
   inheritedVelFactor = 0.25;//1.0;
   constantAcceleration = 0.1;
   lifetimeMS = 1600;//400;
   lifetimeVarianceMS = 400;//100;
   useInvAlpha = false;
   spinSpeed = 1;
   spinRandomMin = -200;
   spinRandomMax = 200;
   colors[0] = "0.4 0.4 0.4 0.2";
   colors[1] = "0.4 0.4 0.4 0.1";
   colors[2] = "0.0 0.0 0.0 0.0";
   sizes[0] = 0.2;//1;
   sizes[1] = 0.15;//0.75;
   sizes[2] = 0.1;//0.5;
   times[0] = 0.0;
   times[1] = 0.5;//0.294118;
   times[2] = 1.0;
};

datablock SphereEmitterData(Basefiring2Emitter)
{
   ejectionPeriodMS = 15;//75;
   periodVarianceMS = 5;
   ejectionVelocity = 1;
   ejectionOffset = 0.0;
   velocityVariance = 0;
   thetaMin = 0.0;
   thetaMax = 180;//10.0;
   particles = "Basefiring2Particle";
   blendStyle = "NORMAL";
};

// ----------------------------------------------------------------------------
// Splash effects
// ----------------------------------------------------------------------------
datablock ParticleData(ProjectileSplashMist)
{
   dragCoefficient = 1.0;
   windCoefficient = 2.0;
   gravityCoefficient = 0.3;
   inheritedVelFactor = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS = 600;
   lifetimeVarianceMS = 100;
   useInvAlpha = false;
   spinRandomMin = -90.0;
   spinRandomMax = 500.0;
   spinSpeed = 1;
   textureName = "core/art/particles/smoke";
   colors[0] = "0.7 0.8 1.0 1.0";
   colors[1] = "0.7 0.8 1.0 0.5";
   colors[2] = "0.7 0.8 1.0 0.0";
   sizes[0] = 0.1; //0.2;
   sizes[1] = 0.2; //0.4;
   sizes[2] = 0.4; //0.8;
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;
};

datablock SphereEmitterData(ProjectileSplashMistEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 1.5; //3.0;
   velocityVariance = 1.0; //2.0;
   ejectionOffset = 0.15;
   thetaMin = 85;
   thetaMax = 85;
   phiReferenceVel = 0;
   phiVariance = 360;
   overrideAdvance = false;
   lifetimeMS = 250;
   particles = "ProjectileSplashMist";
};

datablock ParticleData(ProjectileSplashParticle)
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
   sizes[0] = 0.25; //0.5;
   sizes[1] = 0.125; //0.25;
   sizes[2] = 0.125; //0.25;
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;
};

datablock SphereEmitterData(ProjectileSplashEmitter)
{
   ejectionPeriodMS = 4;
   periodVarianceMS = 0;
   ejectionVelocity = 3.0; //7.3;
   velocityVariance = 1.0; //2.0;
   ejectionOffset = 0.0;
   thetaMin = 30;
   thetaMax = 80;
   phiReferenceVel = 00;
   phiVariance = 360;
   overrideAdvance = false;
   orientParticles = true;
   orientOnVelocity = true;
   lifetimeMS = 100;
   particles = "ProjectileSplashParticle";
};

datablock ParticleData(ProjectileSplashRingParticle)
{
   textureName = "core/art/particles/wake";
   dragCoefficient = 0.0;
   gravityCoefficient = 0.0;
   inheritedVelFactor = 0.0;
   lifetimeMS = 2500;
   lifetimeVarianceMS = 200;
   windCoefficient = 0.0;
   useInvAlpha = 1;
   spinRandomMin = 30.0;
   spinRandomMax = 30.0;
   spinSpeed = 1;
   animateTexture = true;
   framesPerSec = 1;
   animTexTiling = "2 1";
   animTexFrames = "0 1";
   colors[0] = "0.7 0.8 1.0 1.0";
   colors[1] = "0.7 0.8 1.0 0.5";
   colors[2] = "0.7 0.8 1.0 0.0";
   sizes[0] = 1.0; //2.0;
   sizes[1] = 2.0; //4.0;
   sizes[2] = 3.0; //8.0;
   times[0] = 0.0;
   times[1] = 0.5;
   times[2] = 1.0;
};

datablock SphereEmitterData(ProjectileSplashRingEmitter)
{
   lifetimeMS = "100";//yorks new      
   ejectionPeriodMS = 200;
   periodVarianceMS = 10;
   ejectionVelocity = 0;
   velocityVariance = 0;
   ejectionOffset = 0;
   thetaMin = 89;
   thetaMax = 90;
   phiReferenceVel = 0;
   phiVariance = 1;
   alignParticles = 1;
   alignDirection = "0 1 0";
   particles = "ProjectileSplashRingParticle";
};

datablock SplashData(ProjectileSplash)
{
   emitter[0] = ProjectileSplashEmitter;
   emitter[1] = ProjectileSplashMistEmitter;
   emitter[2] = ProjectileSplashRingEmitter;
};

// ----------------------------------------------------------------------------
// Explosion Objects
// ----------------------------------------------------------------------------
datablock ExplosionData(ProjectileSubExplosion)
{
   lifeTimeMS = 100;
   offset = 0.4;
   emitter[0] = ProjectileExpSubFireEmitter;
   emitter[1] = ProjectileExpSubSmokeEmitter;
};


datablock ExplosionData(ProjectileExplosion)
{
   soundProfile = ProjectileExplosionSound;
   lifeTimeMS = 200; // I want a quick bang and dissipation, not a slow burn-out

   // Volume particles
   particleEmitter = ProjectileExpSmokeEmitter;
   particleDensity = 10;//20;
   particleRadius = 1;//2;

   // Point emission
   emitter[0] = ProjectileExpFireEmitter;
   emitter[1] = ProjectileExpSparksEmitter;
   emitter[2] = ProjectileExpSparksEmitter;
   emitter[3] = ProjectileExpFireballEmitter;

   // Sub explosion objects
   subExplosion[0] = ProjectileSubExplosion;

   // Camera Shaking
   shakeCamera = true;
   camShakeFreq = "10.0 11.0 9.0";
   camShakeAmp = "15.0 15.0 15.0";
   camShakeDuration = 1.5;
   camShakeRadius = 10;

   // Exploding debris
   debris = ProjectileDebris;
   debrisThetaMin = 0;//10;
   debrisThetaMax = 90;//80;
   debrisNum = 5;
   debrisNumVariance = 2;
   debrisVelocity = 1;//2;
   debrisVelocityVariance = 0.2;//0.5;

   lightStartRadius = 6.0;
   lightEndRadius = 0.0;
   lightStartColor = "1.0 0.7 0.2";
   lightEndColor = "0.9 0.7 0.0";
   lightStartBrightness = 2.5;
   lightEndBrightness = 0.0;
   lightNormalOffset = 3.0;
};

datablock ExplosionData(DefaultHitExplosion)
{
   soundProfile = ProjectileHitSound;
   lifeTimeMS = 200; // I want a quick bang and dissipation, not a slow burn-out

   // Volume particles
   particleEmitter = DefaultSparksEmitter;
   particleDensity = 10;//20;
   particleRadius = 1;//2;

   // Point emission
   emitter[0] = DefaultSparksEmitter;

   // Camera Shaking
   shakeCamera = false;

   lightStartRadius = 6.0;
   lightEndRadius = 0.0;
   lightStartColor = "1.0 0.7 0.2";
   lightEndColor = "0.9 0.7 0.0";
   lightStartBrightness = 2.5;
   lightEndBrightness = 0.0;
   lightNormalOffset = 3.0;
};

datablock ExplosionData(AxeHitExplosion : DefaultHitExplosion)
{
   soundProfile = AxeHitLiveSound;
};

datablock ExplosionData(AxeHitLiveExplosion)
{
   soundProfile = AxeHitLiveSound;
};

datablock ExplosionData(AxeHitStaticExplosion)
{
   soundProfile = AxeHitStaticSound;
};

datablock ExplosionData(JavelinHitStaticExplosion)
{
   soundProfile = JavelinHitStaticSound;
};

datablock ExplosionData(FlintlockHitExplosion)
{
   soundProfile = flintlockHitSound;
};

datablock ExplosionData(ProjectileHitExplosion)
{
   soundProfile = ProjectileHitSound;
};

datablock ExplosionData(ArrowHitStaticExplosion)
{
   soundProfile = ArrowHitStaticSound;
};

datablock ProjectileData(BaseProjectile)
{
   projectileShapeName = "core/art/effects/debris_player.dts";
   scale = "1 1 1";
   directDamage = 30;
   directImpulse = 0;
   radiusDamage = 0;
   damageRadius = 0;
   areaImpulse = 0;

   explosion = ProjectileExplosion;
   waterExplosion = "";

   decal = ScorchRXDecal;
   splash = ProjectileSplash;

   particleEmitter = ProjectileProjSmokeTrailEmitter;
   particleWaterEmitter = ProjectileTrailWaterEmitter;

   muzzleVelocity = 100;
   velInheritFactor = 0.3;

   armingDelay = 0;
   lifetime = 5000; //(500m / 100m/s = 5000ms)
   fadeDelay = 4500;

   bounceElasticity = 0;
   bounceFriction = 0;
   isBallistic = true;
   gravityMod = 0.80;

   lightDesc = ProjectileLightDesc;
   damageType = "ProjectileDamage";
   retrievable = "";
};

//-------------------
// XR75 Laser Gun
datablock ParticleData(XRBoltsSparks)
{
   textureName = "core/art/particles/droplet.png";
   lifetimeMS = "50";
   lifetimeVarianceMS = "10";
   inheritedVelFactor = "0.1";
   sizes[0] = "0.25";
   sizes[1] = "0.5";
   sizes[2] = "0.125";
   colors[0] = "1.0 0.9 0.8 0.2";
   colors[1] = "1.0 0.9 0.8 0.8";
   colors[2] = "0.8 0.4 0.0 0.0";
   times[0] = "0";
   times[1] = "0.34902";
   times[2] = "1";
   times[3] = "1";
};

datablock SphereEmitterData(XRBoltsSparksEmitter)
{
   particles = "XRBoltsSparks";
   blendStyle = "NORMAL";
   ejectionPeriodMS = "5";
   periodVarianceMS = "1";
   ejectionVelocity = "10";
   velocityVariance = "1";
   thetaMax = "120";
   phiReferenceVel = 0;
   phiVariance = "360";
   ejectionOffset = "0";
   orientParticles = true;
   orientOnVelocity = true;
};

datablock ExplosionData(XRBoltsHitExplosion)
{
   soundProfile = ProjectileHitSound;
   lifeTimeMS = 200; // I want a quick bang and dissipation, not a slow burn-out

   // Volume particles
   particleEmitter = XRBoltsSparksEmitter;
   particleDensity = 10;//20;
   particleRadius = 1;//2;

   // Point emission
   emitter[0] = XRBoltsSparksEmitter;

   // Camera Shaking
   shakeCamera = false;

   lightStartRadius = 6.0;
   lightEndRadius = 0.0;
   lightStartColor = "1.0 0.7 0.2";
   lightEndColor = "0.9 0.7 0.0";
   lightStartBrightness = 2.5;
   lightEndBrightness = 0.0;
   lightNormalOffset = 3.0;
};

datablock ProjectileData(XRBoltsProjectile : BaseProjectile)
{
   projectileShapeName = "art/inv/weapons/Guns/5_56.dts";
   scale="0.5 0.5 0.5";
   muzzleVelocity = 50;
   directDamage = 100;
   particleEmitter = 0;
   particleWaterEmitter = 0;
   radiusDamage = 0;
   damageRadius = 0;
   explosion = XRBoltsHitExplosion;
   waterExplosion = 0;
   lightDesc = 0;
   gravityMod = 0.0;
   decal = ScorchRXDecalSmall;

   retrievable = "";
};
