// ----------------------------------------------------------------------------
// Rain
// ----------------------------------------------------------------------------

datablock SFXProfile(HeavyRainSound)
{
   filename = "art/Packs/env/rain/sound/amb";
   description = AudioLoop2d;
};

datablock PrecipitationData(HeavyRain)
{
   soundProfile = "HeavyRainSound";

   dropTexture = "art/Packs/env/rain/rain";
   splashTexture = "art/Packs/env/rain/water_splash";
   dropSize = 0.35;
   splashSize = 0.1;
   useTrueBillboards = false;
   splashMS = 500;
};

// ----------------------------------------------------------------------------
// Lightning
// ----------------------------------------------------------------------------

// When setting up thunder sounds for lightning it should be known that:
// - strikeSound is a 3d sound
// - thunderSounds[n] are 2d sounds

datablock SFXProfile(ThunderCrash1Sound)
{
   filename = "art/Packs/env/rain/sound/thunder1";
   description = Audio2d;
};

datablock SFXProfile(ThunderCrash2Sound)
{
   filename = "art/Packs/env/rain/sound/thunder2";
   description = Audio2d;
};

datablock SFXProfile(ThunderCrash3Sound)
{
   filename = "art/Packs/env/rain/sound/thunder3";
   description = Audio2d;
};

datablock SFXProfile(ThunderCrash4Sound)
{
   filename = "art/Packs/env/rain/sound/thunder4";
   description = Audio2d;
};


datablock LightningData(DefaultStorm)
{
   thunderSounds[0] = ThunderCrash1Sound;
   thunderSounds[1] = ThunderCrash2Sound;
   thunderSounds[2] = ThunderCrash3Sound;
   thunderSounds[3] = ThunderCrash4Sound;
};
