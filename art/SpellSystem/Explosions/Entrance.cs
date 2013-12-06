// Ignore the name "explosion" for this. An Explosion in T3D
// is really an effect that plays a SFXProfile, particle emitters,
// point light, debris, and camera shake. Things normally associated with
// an explosion, such as damage and pushback, are calculated outside of the
// explosion object itself.

//-----------------------------------------------------------------------------
// Explosion sounds
datablock SFXProfile(TeleportEntrance)  
{  
   fileName = "art/sound/waterout"; 
   description = AudioDefault3D;  
   preload = true;
}; 

datablock ExplosionData(EntranceEffect)
{
   soundProfile = TeleportEntrance;

   particleEmitter = "TeleportEmitter";
   
   lifeTimeMS = "288";

   lightStartRadius = "0";
   lightEndRadius = "2.82353";
   lightStartColor = "0.992126 0.992126 0.992126 1";
   lightEndColor = "0 0.102362 0.992126 1";
   lightStartBrightness = "0.784314";
   lightEndBrightness = "4";
   lightNormalOffset = "0";
   emitter[0] = "RocketSplashEmitter";
   emitter[1] = "TeleportFlash_Emitter";
   times[0] = "0.247059";
   particleRadius = "0.1";
   particleDensity = "10";
   playSpeed = "1";
};

