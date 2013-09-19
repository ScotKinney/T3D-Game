//------------------------------------------------------------------------------
//----------------------------- PROJECTILE EMITTERS ----------------------------
//------------------------------------------------------------------------------

datablock ParticleData(FireballParticles)
{
   HighResTexture       = "core/art/particles/fireball.png";
   //MidResTexture        = "art/shapes/particles/smokeM";
   //LowResTexture        = "art/shapes/particles/smokeL";
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = "400";  // lasts 0.4 second
   lifetimeVarianceMS   = "0";   // ... precisely
   useInvAlpha = "1";
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "1 0.254902 0 1";
   colors[1]     = "1 0.603922 0 0.755906";
   colors[2]     = "0.666667 0.666667 0.666667 0.207";
   colors[3]     = "0.396078 0.396078 0.396078 0";

   sizes[0]      = "1.49545";
   sizes[1]      = "1.49545";
   sizes[2]      = "1.49545";
   sizes[3]      = "1.49545";

   times[0]      = 0.0;
   times[1]      = "0.291667";
   times[2]      = "0.520833";
   spinSpeed     = "2";
};

datablock SphereEmitterData(FireballEmitter)
{
   ejectionVelocity = 0.25;
   velocityVariance = 0.10;
   thetaMin = 0.0;
   thetaMax = 180;
   particles = FireballParticles;
   ejectionOffset   = "0";
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = 0;
   orientParticles  = true;
   ejectionPeriodMS = 20;
   blendStyle = "Normal";
   softParticles = "1";
   softnessDistance = "1";
};

//------------------------------------------------------------------------------
//----------------------------- EXPLOSION EMITTERS -----------------------------
//------------------------------------------------------------------------------

datablock ParticleData(FireballBlastParticles)
{
   HighResTexture       = "core/art/particles/fire.png";
   //MidResTexture        = "art/shapes/particles/smokeM";
   //LowResTexture        = "art/shapes/particles/smokeL";
   dragCoeffiecient     = 0;
   gravityCoefficient   = 0;   // rises slowly
   inheritedVelFactor   = 0.00;
   lifetimeMS           = "800";  // lasts 0.7 second
   lifetimeVarianceMS   = "0";   // ...more or less
   useInvAlpha = false;
   spinRandomMin = -30.0;
   spinRandomMax = 30.0;

   colors[0]     = "1 0.15748 0 0.9";
   colors[1]     = "1 0.440945 0 0.573";
   colors[2]     = "0.598425 0.149606 0 0.328";
   colors[3]     = "0.267717 0.267717 0.267717 0";

   sizes[0]      = "0";
   sizes[1]      = "1.99902";
   sizes[2]      = "1.99902";
   sizes[3]      = "1.99902";

   times[0]      = 0.0;
   times[1]      = "0.164706";
   times[2]      = "0.643137";
   spinSpeed     = "2";
};

datablock SphereEmitterData(FireballBlastEmitter)
{
   ejectionVelocity = 0.25;
   velocityVariance = 0.10;
   thetaMin = 0.0;
   thetaMax = 180;
   particles = FireballBlastParticles;
   ejectionOffset   = 0;
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = false;
   orientParticles  = true;
   
   ejectionPeriodMS = 10;
   softnessDistance = "2";
   blendStyle = "ADDITIVE";
   softParticles = "1";
   overrideAdvances = "0";
   softnessDistance = "2";
};

//------------------------------------------------------------------------------
//----------------------------- CHANNELING EMITTERS ----------------------------
//------------------------------------------------------------------------------

datablock ParticleData(FireballChannelParticle : FireballParticles){ 
   lifetimeMS = 800;
   sizes[0]      = "0";
   sizes[1]      = "1";
   sizes[2]      = "1";
   sizes[3]      = "1";
   useInvAlpha = "0";
   colors[0] = "1 0.0551181 0 1";
   colors[1] = "1 0.299213 0 0.755906";
   colors[2] = "1 0.417323 0 0.188976";
   times[1] = "0.286275";
   times[2] = "0.513726";
};

datablock SphereEmitterData(FireballChannelEmitterHAND)
{
   ejectionVelocity = 0.25;
   velocityVariance = 0.10;
   thetaMin = 0.0;
   thetaMax = 180;
   particles = FireballChannelParticle;
   ejectionOffset   = "0";
   phiReferenceVel  = 0;
   phiVariance      = 360;
   overrideAdvances = 0;
   orientParticles  = true;
   thetaMax = "180";
   ejectionPeriodMS = "70";
   blendStyle = "ADDITIVE";
   softParticles = "1";
   softnessDistance = "2";
};

datablock GraphEmitterData(FireballChannelEmitterBASE)
{
   ejectionPeriodMS = "10";
   periodVarianceMS = "0";
   ejectionVelocity = "0";
   velocityVariance = "0";
   ejectionOffset = "0.01";
   particles = FireballChannelParticle;
   blendStyle = "NORMAL";
   softParticles = "0";
   softnessDistance = "0.4";
   
   Grounded = true;
   ProgressMode = 0;
   Loop = true;
   
   xFunc = "cos(t)*t*0.0015";
   yFunc = "sin(t)*t*0.0015";
   zFunc = "0.2";
   funcMax = "1600";
   timeScale = "10";
};