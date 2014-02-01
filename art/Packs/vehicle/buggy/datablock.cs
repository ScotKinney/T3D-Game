//-----------------------------------------------------------------------------
// Copyright (c) 2012 GarageGames, LLC
//-----------------------------------------------------------------------------

//-----------------------------------------------------------------------------

// Information extacted from the shape.
//
// Wheel Sequences
//    spring#        Wheel spring motion: time 0 = wheel fully extended,
//                   the hub must be displaced, but not directly animated
//                   as it will be rotated in code.
// Other Sequences
//    steering       Wheel steering: time 0 = full right, 0.5 = center
//    breakLight     Break light, time 0 = off, 1 = breaking
//
// Wheel Nodes
//    hub#           Wheel hub, the hub must be in it's upper position
//                   from which the springs are mounted.
//
// The steering and animation sequences are optional.
// The center of the shape acts as the center of mass for the car.

//-----------------------------------------------------------------------------
/*
datablock SFXProfile(buggyEngineSound)
{
   filename    = "art/sound/vehicles/buggy/engine_idle";
   description = AudioClosestLooping3d;
   preload = true;
};
*/
datablock SFXProfile(buggyEngineSound)
{
   preload = "1";
   description = "AudioCloseLoop3D";
   fileName = "art/Packs/vehicle/buggy/sound/buggy_engine.ogg";
};

datablock SFXProfile(BuggySqueal)
{
   preload = "1";
   description = "AudioDefault3D";
   fileName = "art/Packs/vehicle/buggy/sound/buggy_squeal.ogg";
};

datablock SFXProfile(BuggyhardImpact)
{
   preload = "1";
   description = "AudioDefault3D";
   fileName = "art/Packs/vehicle/buggy/sound/hardImpact.ogg";
};

datablock SFXProfile(BuggysoftImpact)
{
   preload = "1";
   description = "AudioDefault3D";
   fileName = "art/Packs/vehicle/buggy/sound/softImpact.ogg";
};


datablock ParticleData(TireParticle)
{
   textureName = "core/art/particles/dustParticle";
   dragCoefficient      = "1.99902";
   gravityCoefficient   = "-0.100122";
   inheritedVelFactor   = "0.0998043";
   constantAcceleration = 0.0;
   lifetimeMS           = 1000;
   lifetimeVarianceMS   = 400;
   colors[0]            = "0.456693 0.354331 0.259843 1";
   colors[1]            = "0.456693 0.456693 0.354331 0";
   sizes[0]             = "0.997986";
   sizes[1]             = "3.99805";
   sizes[2]             = "1.0";
   sizes[3]             = "1.0";
   times[0]             = "0.0";
   times[1]             = "1";
   times[2]             = "1";
   times[3]             = "1";
   ambientFactor        = 1;
};

datablock SphereEmitterData(TireEmitter)
{
   ejectionPeriodMS = 20;
   periodVarianceMS = 10;
   ejectionVelocity = "14.57";
   velocityVariance = 1.0;
   ejectionOffset   = 0.0;
   thetaMin         = 0;
   thetaMax         = 60;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvance = false;
   particles = "TireParticle";
   blendStyle = "ADDITIVE";
};


//----------------------------------------------------------------------------

datablock WheeledVehicleTire(DefaultCarTire)
{
   // Tires act as springs and generate lateral and longitudinal
   // forces to move the vehicle. These distortion/spring forces
   // are what convert wheel angular velocity into forces that
   // act on the rigid body.
   shapeFile = "art/Packs/vehicle/buggy/wheel.dts";
   staticFriction = 20;
   kineticFriction = 15;

   // Spring that generates lateral tire forces
   lateralForce = 18000;
   lateralDamping = 6000;
   lateralRelaxation = 1;

   // Spring that generates longitudinal tire forces
   longitudinalForce = 18000;
   longitudinalDamping = 4000;
   longitudinalRelaxation = 1;
   radius = "0.4";
};

datablock WheeledVehicleSpring(DefaultCarSpring)
{
   // Wheel suspension properties
   length = 0.85;             // Suspension travel
   force = 2800;              // Spring force
   damping = 3600;             // Spring damping
   antiSwayForce = 3;         // Lateral anti-sway force
};

datablock WheeledVehicleData(DefaultCar)
{
   category = "Vehicles";
   shapeFile = "art/Packs/vehicle/buggy/buggy.dts";
   emap = true;

   mountPose[0] = "gargsitfull";
   numMountPoints = 1;

   maxSteeringAngle = 0.385;  // Maximum steering angle, should match animation
   tireEmitter = TireEmitter; // All the tires use the same dust emitter

   // 3rd person camera settings
   cameraRoll = true;         // Roll the camera with the vehicle
   cameraMaxDist = 4.8;         // Far distance from vehicle
   cameraOffset = 1.5;        // Vertical offset from camera mount point
   cameraLag = 0.26;           // Velocity lag of camera
   cameraDecay = 1.25;        // Decay per sec. rate of velocity lag

   // Rigid Body
   mass = 380;
   massCenter = "0 -0.1 0";    // Center of mass for rigid body
   massBox = "0 0 0";         // Size of box used for moment of inertia,
                              // if zero it defaults to object bounding box
   drag = 0.6;                // Drag coefficient
   bodyFriction = 0.6;
   bodyRestitution = 0.4;
   minImpactSpeed = 5;        // Impacts over this invoke the script callback
   softImpactSpeed = 5;       // Play SoftImpact Sound
   hardImpactSpeed = 15;      // Play HardImpact Sound
   integration = 8;           // Physics integration: TickSec/Rate
   collisionTol = 0.1;        // Collision distance tolerance
   contactTol = 0.1;          // Contact velocity tolerance

   // Engine
   engineTorque = 6000;       // Engine power
   engineBrake = 1000;         // Braking when throttle is 0
   brakeTorque = 8000;        // When brakes are applied
   maxWheelSpeed = 60;        // Engine scale by current speed / max speed

   // Energy
   maxEnergy = 100;
   jetForce = 3000;
   minJetEnergy = 30;
   jetEnergyDrain = 2;

   // Sounds
//   jetSound = ScoutThrustSound;
   engineSound = BuggyEngineSound;
   squealSound = BuggySqueal;
   softImpactSound = BuggySoftImpact;
   hardImpactSound = BuggyHardImpact;
   wheelImpactSound = BuggySoftImpact;

//   explosion = VehicleExplosion;

   // Dynamic fields accessed via script
   nameTag = "";
   maxDismountSpeed = 10;
   maxMountSpeed = 5;

   // Absolute rotation tracking modes
   fpAbsRotationMode = "TurnCamera";
   tpAbsRotationMode = "TurnCamera";
};
