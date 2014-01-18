//-----------------------------------------------------------------------------
// Torque Game Engine
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------

//----------------------------------------------------------------------------
// This is our default player datablock that all others will derive from.
// Inherit and change at least the shapeFile, DeathSound and PainSound
// ----------------------------------------------------------------------------
datablock PlayerData(DefaultPlayerData)
{
   name = "Default Player";
   
   renderFirstPerson = true;

   className = Armor;
   shapeFile = "core/art/effects/debris_player.dts";
   cameraMaxDist = 3;
   computeCRC = false;
   team = 1;

   canObserve = true;
   cmdCategory = "Clients";

   cameraDefaultFov = 65.0;
   cameraMinFov = 5.0;
   cameraMaxFov = 95.0;

   debrisShapeName = "core/art/effects/debris_player.dts";
   debris = DefaultDebris;

   aiAvoidThis = true;
  
   //DeathSound = DeathCrySound;
   //PainSound = PainCrySound;

   minLookAngle = -1;
   maxLookAngle = 1;
   maxFreelookAngle = 3.0;

   mass = 100;
   //drag = 1.3;
   drag = 0.3;
   maxdrag = 0.4;
   density = 1.1;
   maxDamage = 300;
   maxEnergy =  100;
   repairRate = 0.33;
   energyPerDamagePoint = 75.0;

   rechargeRate = 0.256;

   runForce = 48 * 90;
   runEnergyDrain = 0;
   minRunEnergy = 0;
   maxForwardSpeed = 2.5;//6
   maxBackwardSpeed = 2;//5
   maxSideSpeed = 2;//5

   sprintEnergyDrain = 0; //how much energy to drain while printing until player cannot sprint anymore
   minSprintEnergy = 0; //the minimum amount of energy to drain
   maxSprintForwardSpeed = 6;
   maxSprintBackwardSpeed = 5;
   maxSprintSideSpeed = 3;
   sprintForce = 75 * 90;
   sprintYawScale = 0.2;

   crouchForce = 45.0 * 90;
   maxCrouchForwardSpeed = 2.0;//4
   maxCrouchBackwardSpeed = 2.0;
   maxCrouchSideSpeed = 1.0;

   maxUnderwaterForwardSpeed = 3.4;//8.4
   maxUnderwaterBackwardSpeed = 2.8;//7.8
   maxUnderwaterSideSpeed = 2.8;//7.8

   jumpForce = 8.3 * 90;
   standJumpForce = 8.3 * 90;
   jumpEnergyDrain = 0;
   minJumpEnergy = 0;
   jumpDelay = 15;
   airControl = 0.3;

   recoverDelay = 9;
   recoverRunForceScale = 1.2;

   minImpactSpeed = 15; //45;  // minimum speed to generate a collision callback
   speedDamageScale = 0.4;

   boundingBox = ".75 1.25 2.6"; // //LR-FB-UpDN - Torque Physics
   //boundingBox = "0.75 0.75 2";  // Bullet Physics Box Collision
   crouchBoundingBox = "1 0.75 1.5";
   swimBoundingBox = "1 2 0.75";
   pickupRadius = 10;

   // Damage location details
   boxNormalHeadPercentage       = 0.83;
   boxNormalTorsoPercentage      = 0.47;
   boxHeadLeftPercentage         = 0;
   boxHeadRightPercentage        = 1;
   boxHeadBackPercentage         = 0;
   boxHeadFrontPercentage        = 1;

   // Foot Prints
   decalData   = DefaultFootprint;
   decalOffset = 0.25;

   footPuffEmitter = LightPuffEmitter;
   footPuffNumParts = 10;
   footPuffRadius = 0.25;

   dustEmitter = LiftoffDustEmitter;

   splash = DefaultSplash;
   splashVelocity = 4.0;
   splashAngle = 67.0;
   splashFreqMod = 300.0;
   splashVelEpsilon = 0.60;
   bubbleEmitTime = 0.4;
   splashEmitter[0] = DefaultWakeEmitter;
   splashEmitter[1] = DefaultFoamEmitter;
   splashEmitter[2] = DefaultBubbleEmitter;
   mediumSplashSoundVelocity = 10.0;
   hardSplashSoundVelocity = 20.0;
   exitSplashSoundVelocity = 5.0;

   // Controls over slope of runnable/jumpable surfaces
   runSurfaceAngle  = 50;
   jumpSurfaceAngle = 60;
   maxStepHeight = 1.5;
   minJumpSpeed = 20;
   maxJumpSpeed = 30;

   horizMaxSpeed = 68;
   horizResistSpeed = 33;
   horizResistFactor = 0.35;

   upMaxSpeed = 80;
   upResistSpeed = 25;
   upResistFactor = 0.3;

   footstepSplashHeight = 0.35;

   //NOTE:  some sounds commented out until wav's are available

   // Footstep Sounds
   FootSoftSound        = "FootStepGrass1Sound";
   FootHardSound        = "FootStepRock1Sound";
   FootMetalSound       = "FootStepMetal1Sound";
   FootSnowSound        = "FootStepSnow1Sound";
   ImpactSoftSound      = "FootStepGrass1Sound";
   ImpactHardSound      = "FootStepRock1Sound";
   ImpactMetalSound     = "FootStepMetal1Sound";
   ImpactSnowSound      = "FootStepSnow1Sound";

   FootShallowSound     = "FootLightShallowSplashSound";
   FootWadingSound      = "FootLightWadingSound";
   FootUnderwaterSound  = "FootLightUnderwaterSound";
   //exitingWater         = "ExitingWaterHumanSound";


   groundImpactMinSpeed    = 10.0;
   groundImpactShakeFreq   = "4.0 4.0 4.0";
   groundImpactShakeAmp    = "1.0 1.0 1.0";
   groundImpactShakeDuration = 0.8;
   groundImpactShakeFalloff = 10.0;

   observeParameters = "0.5 4.5 4.5";
   
   inNeutralZone = false;
};
