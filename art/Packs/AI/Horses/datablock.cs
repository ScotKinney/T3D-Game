//----------------------------------------------------------------------------
// Horse Audio Profiles
//----------------------------------------------------------------------------

//----------------------------------------------------------------------------
datablock SFXProfile(SteedDeathCrySound)
{
   filename    = "art/Packs/AI/Horses/sound/Horse_pain.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(SteedPainCrySound)
{
   filename    = "art/Packs/AI/Horses/sound/HorsePainCry.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(SteedRearCrySound)
{
   filename    = "art/Packs/AI/Horses/sound/HorseRearCry.wav";
   description = AudioClose3d;
   preload = true;
};

datablock SFXProfile(SteedMoveBubblesSound)
{
   filename    = "art/sound/water_splash.ogg";
   description = "AudioCloseLoop3D";
   preload = true;
};

datablock SFXProfile(SteedWaterBreathSound)
{
   filename    = "art/sound/footsteps/water_wl1";
   description = "AudioClose3D";
   preload = true;
};

//----------------------------------------------------------------------------
// Splash
//----------------------------------------------------------------------------
datablock ParticleData(HorseSplashMist)
{
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.05;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "art/Packs/AI/Horses/splash";
   colors[0]     = "0.7 0.8 1.0 1.0";
   colors[1]     = "0.7 0.8 1.0 0.5";
   colors[2]     = "0.7 0.8 1.0 0.0";
   sizes[0]      = 0.5;
   sizes[1]      = 0.5;
   sizes[2]      = 0.8;
   times[0]      = 0.0;
   times[1]      = 0.5;
   times[2]      = 1.0;
};

datablock SphereEmitterData(HorseSplashMistEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 3.0;
   velocityVariance = 2.0;
   ejectionOffset   = 0.0;
   thetaMin         = 85;
   thetaMax         = 85;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   lifetimeMS       = 250;
   particles = "HorseSplashMist";
};


datablock ParticleData(HorseBubbleParticle)
{
   dragCoefficient      = 0.0;
   gravityCoefficient   = -0.50;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   textureName          = "art/Packs/AI/Horses/splash";
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

datablock SphereEmitterData(HorseBubbleEmitter)
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
   particles = "HorseBubbleParticle";
};

datablock ParticleData(HorseFoamParticle)
{
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.05;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 400;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = false;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   textureName          = "art/Packs/AI/Horses/splash";
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

datablock SphereEmitterData(HorseFoamEmitter)
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
   particles = "HorseFoamParticle";
};

datablock ParticleData( HorseFoamDropletsParticle )
{
   dragCoefficient      = 1;
   gravityCoefficient   = 0.2;
   inheritedVelFactor   = 0.2;
   constantAcceleration = -0.0;
   lifetimeMS           = 600;
   lifetimeVarianceMS   = 0;
   textureName          = "art/Packs/AI/Horses/splash";
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

datablock SphereEmitterData( HorseFoamDropletsEmitter )
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
   particles = "HorseFoamDropletsParticle";
};

datablock ParticleData( HorseWakeParticle )
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

datablock SphereEmitterData( HorseWakeEmitter )
{
   ejectionPeriodMS = "200";
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

   particles = "HorseWakeParticle";
};

datablock ParticleData( HorseSplashParticle )
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

datablock SphereEmitterData( HorseSplashEmitter )
{
   ejectionPeriodMS = 1;
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
   lifetimeMS       = 100;
   particles = "HorseSplashParticle";
};

datablock SplashData(HorseSplash)
{
   numSegments = 15;
   ejectionFreq = 15;
   ejectionAngle = 40;
   ringLifetime = 0.5;
   lifetimeMS = 300;
   velocity = 4.0;
   startRadius = 0.0;
   acceleration = -3.0;
   texWrap = 5.0;

   texture = "art/Packs/AI/Horses/splash";

   emitter[0] = HorseSplashEmitter;
   emitter[1] = HorseSplashMistEmitter;

   colors[0] = "0.7 0.8 1.0 0.0";
   colors[1] = "0.7 0.8 1.0 0.3";
   colors[2] = "0.7 0.8 1.0 0.7";
   colors[3] = "0.7 0.8 1.0 0.0";
   times[0] = 0.0;
   times[1] = 0.4;
   times[2] = 0.8;
   times[3] = 1.0;
};

//----------------------------------------------------------------------------
// Foot puffs
//----------------------------------------------------------------------------
datablock ParticleData(HorsePuff)
{
   textureName = "core/art/effects/dustParticle";
   dragCoefficient      = 2.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.6;
   constantAcceleration = 0.0;
   lifetimeMS           = 800;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -35.0;
   spinRandomMax        = 35.0;
   colors[0]     = "1.0 1.0 1.0 1.0";
   colors[1]     = "1.0 1.0 1.0 0.0";
   sizes[0]      = 0.1;
   sizes[1]      = 0.8;
   times[0]      = 0.3;
   times[1]      = 1.0;
   times[2]      = 1.0;
};

datablock SphereEmitterData(HorsePuffEmitter)
{
   ejectionPeriodMS = 35;
   periodVarianceMS = 10;
   ejectionVelocity = 0.2;
   velocityVariance = 0.1;
   ejectionOffset   = 0.0;
   thetaMin         = 20;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   useEmitterColors = true;
   particles = "HorsePuff";
};

//----------------------------------------------------------------------------
// Liftoff dust
//----------------------------------------------------------------------------
datablock ParticleData(HorseDust)
{
   dragCoefficient      = 1.0;
   gravityCoefficient   = -0.01;
   inheritedVelFactor   = 0.0;
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 100;
   useInvAlpha          = true;
   spinRandomMin        = -90.0;
   spinRandomMax        = 500.0;
   colors[0]     = "1.0 1.0 1.0 1.0";
   sizes[0]      = 1.0;
   times[0]      = 1.0;
   textureName = "art/Packs/AI/Horses/dustParticle";
};

datablock SphereEmitterData(HorseDustEmitter)
{
   ejectionPeriodMS = 5;
   periodVarianceMS = 0;
   ejectionVelocity = 2.0;
   velocityVariance = 0.0;
   ejectionOffset   = 0.0;
   thetaMin         = 90;
   thetaMax         = 90;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   useEmitterColors = true;
   particles = "HorseDust";
};

//----------------------------------------------------------------------------
datablock DecalData(HorseFootprint)
{
   size = 0.35;
   material = HorseFootprintMaterial;
};

//----------------------------------------------------------------------------
datablock PlayerData(DefaultHorse)
{
   renderFirstPerson = true;
   emap = true;
   
   className = Steed;
   isHorse = true;
   shapeFile = "art/Packs/AI/Horses/horse.dts";
   computeCRC = true;

   // 3rd person camera settings
   cameraRoll = false;         // Roll the camera with the vehicle
   cameraMaxDist = 4;        // Far distance from vehicle
   cameraOffset = 1.0;        // Vertical offset from camera mount point
   useEyePoint = false;        // Set to true unless you want a bumpy 3rd person cam, first person is always bumpy
   headEffectsCamera = false; // Rotation of head effects camera
   minRotationTime = 12.0;     // seconds to make a full rotation

   // RFB -> conform to ground
   conformToGround = 0; // or 0 by default
   // RFB -> smoothCamera effects conform to ground. Lower values conform to terrain more
   smoothCamera = 0.8; // or 0 by default -- 0 is no smoothing, 1 is so smooth the camera won´t rotate... 
   // <- RFB
  
   cameraDefaultFov = 45.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 120.0;
   
   aiAvoidThis = true;

   // RFB ->
   autoInputDamping = 0.1; // Dampen control input for slower turning
   // <- RFB
   //minLookAngle = -1.4;
   //maxLookAngle = 1.4;
   minLookAngle = -1;
   maxLookAngle = 1;
   maxFreelookAngle = 3.0;

   mass = 150;
   drag = 0.3;
   maxdrag = 0.4;
   density = 10;
   maxDamage = 200;
   maxEnergy =  60;
   repairRate = 0.33;
   energyPerDamagePoint = 75.0;

   rechargeRate = 0.05;

   runForce = 48 * 90;
   runEnergyDrain = 0.0; // RFB -> setting this higher than 0.0 causes AIHorses to skate slowly forward
   minRunEnergy = 0.1;
   maxForwardSpeed = 25; //20 - Scot
   maxBackwardSpeed = 10; 
   maxSideSpeed = 4; // RFB -> horses don't normally strafe

   // Switch forward animations above these speeds
   run2Speed = 8.5;
   run3Speed = 16;

   maxUnderwaterForwardSpeed = 8.4;
   maxUnderwaterBackwardSpeed = 5.0; 
   maxUnderwaterSideSpeed = 0; // RFB -> horses don't normally strafe

   jumpForce = 20 * 90; //15 - Scot
   standJumpForce = 0;
   jumpEnergyDrain = 5.0;
   minJumpEnergy = 2.5;
   jumpDelay = 15;

   recoverDelay = 4;
   recoverRunForceScale = 1.2;

   minImpactSpeed = 15;
   speedDamageScale = 0.9;

   boundingBox = "2.0 3.25 3.5";
   swimBoundingBox = "2.0 3.25 3.5";
   pickupRadius = 0.75;
   
   // Damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.49;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   // Foot Prints
   decalData   = HorseFootprint;
   decalOffset = 0.25;
   
   FootPuffEmitter = HorsePuffEmitter;
   FootPuffNumParts = 10;
   FootPuffRadius = 0.25;

   dustEmitter = HorseDustEmitter;

   splash = HorseSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = HorseWakeEmitter;
   splashEmitter[1] = HorseFoamEmitter;
   splashEmitter[2] = HorseBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;   
   hardSplashSoundVelocity = 20.0;   
   exitSplashSoundVelocity = 5.0;
   surfaceSwim = true;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 40;
   jumpSurfaceAngle = 50;

   minJumpSpeed = 20;
   maxJumpSpeed = 25;

   horizMaxSpeed = 30;
   horizResistSpeed = 20;
   horizResistFactor = 0.35;

   upMaxSpeed = 80;
   upResistSpeed = 25;
   upResistFactor = 0.3;
   
   FootstepSplashHeight = 0.35;

   numDeathAnims = 1;   // Only one death anim for the horse
   numDamageAnims = 1;  // and one damage anim
   DeathSound = SteedDeathCrySound;
   PainSound = SteedPainCrySound;

   // Footstep Sounds
   FootSoftSound        = HoofLightSoftSound;
   FootHardSound        = HoofLightHardSound;
   FootMetalSound       = HoofLightMetalSound;
   FootSnowSound        = HoofLightSnowSound;
   FootShallowSound     = HoofLightShallowSplashSound;
   FootWadingSound      = HoofLightWadingSound;
   //FootUnderwaterSound  = HoofLightUnderwaterSound;
   //FootBubblesSound     = HoofLightBubblesSound;
   movingBubblesSound   = SteedMoveBubblesSound;
   //waterBreathSound     = SteedWaterBreathSound;

   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;
   
   exitingWater         = ExitingWaterLightSound;
   
   observeParameters = "0.5 4.5 4.5";

   mountable = true; // Players can mount this AI
   driverNode = 0;
   riderNode = 5;
   mountPose[0]	= H_Root; // Driver
   mountPose[5]	= H_Root; // Passenger
};

datablock PlayerData(BayHorse : DefaultHorse)
{
   skinName = "bay";
};

datablock PlayerData(ArabianHorse : DefaultHorse)
{
   skinName = "arabian";
};

datablock PlayerData(PaliminoHorse : DefaultHorse)
{
   skinName = "palimino";
};

datablock PlayerData(IndianHorse : DefaultHorse)
{
   skinName = "indian";
};


datablock PlayerData(LightHorse : DefaultHorse)
{
   skinName = "light";
};

datablock PlayerData(MustangHorse : DefaultHorse)
{
   skinName = "mustang";
};

datablock PlayerData(WildHorse : DefaultHorse)
{
   skinName = "mustang";
};

exec("./horseScript.cs");
