/////////////////////////////////////
////WistWoods Amb
///////////////////////////////////////////////

singleton SFXProfile(WistWoodsEnvSound)   
{      
   fileName = "art/Worlds/DalRiata/sound/WistWoodsAmb.ogg";   
   description = AudioLoop2D;   
   preload = true;   
}; 

singleton SFXPlayList(WistWoodsEnvList)   
{   
   description = AudioLoop2D;   
   track[0] = WistWoodsEnvSound;   
}; 

singleton SFXAmbience( AudioAmbienceWistWoods )
{
   environment = AudioEnvPlain;
   states[ 0 ] = AudioLocationOutside;
   soundTrack = WistWoodsEnvList;
};