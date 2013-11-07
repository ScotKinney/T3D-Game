// skies/default - All datablocks needed for the default homestead sky

datablock LightFlareData( DefaultSunFlare )
{      
   overallScale = 4.0;
   flareEnabled = true;
   renderReflectPass = false;
   flareTexture = "./lensFlareSheet0";  

   elementRect[0] = "512 0 512 512";
   elementDist[0] = 0.0;
   elementScale[0] = 2.0;
   elementTint[0] = "0.6 0.6 0.6";
   elementRotate[0] = true;
   elementUseLightColor[0] = true;
   
   elementRect[1] = "1152 0 128 128";
   elementDist[1] = 0.3;
   elementScale[1] = 0.7;
   elementTint[1] = "1.0 1.0 1.0";
   elementRotate[1] = true;
   elementUseLightColor[1] = true;
   
   elementRect[2] = "1024 0 128 128";
   elementDist[2] = 0.5;
   elementScale[2] = 0.25;   
   elementTint[2] = "1.0 1.0 1.0";
   elementRotate[2] = true;
   elementUseLightColor[2] = true;
   
   elementRect[3] = "1024 128 128 128";
   elementDist[3] = 0.8;
   elementScale[3] = 0.7;   
   elementTint[3] = "1.0 1.0 1.0";
   elementRotate[3] = true;
   elementUseLightColor[3] = true;
   
   elementRect[4] = "1024 0 128 128";
   elementDist[4] = 1.18;
   elementScale[4] = 0.5;   
   elementTint[4] = "1.0 1.0 1.0";
   elementRotate[4] = true;
   elementUseLightColor[4] = true;
   
   elementRect[5] = "1152 128 128 128";
   elementDist[5] = 1.25;
   elementScale[5] = 0.25;   
   elementTint[5] = "1.0 1.0 1.0";
   elementRotate[5] = true;
   elementUseLightColor[5] = true;
   
   elementRect[6] = "1024 0 128 128";
   elementDist[6] = 2.0;
   elementScale[6] = 0.25;      
   elementTint[6] = "1.0 1.0 1.0";
   elementRotate[6] = true;
   elementUseLightColor[6] = true;
};

datablock LightFlareData( ScatterskyFlareExample )
{      
   overallScale = 2.0;
   flareEnabled = true;
   renderReflectPass = false;
   flareTexture = "./lensFlareSheet0";  
   
   elementRect[0] = "1024 0 128 128";
   elementDist[0] = 0.5;
   elementScale[0] = 0.25;   
   elementTint[0] = "1.0 1.0 1.0";
   elementRotate[0] = true;
   elementUseLightColor[0] = true;
   
   elementRect[1] = "1024 128 128 128";
   elementDist[1] = 0.8;
   elementScale[1] = 0.7;   
   elementTint[1] = "1.0 1.0 1.0";
   elementRotate[1] = true;
   elementUseLightColor[1] = true;
   
   elementRect[2] = "1024 0 128 128";
   elementDist[2] = 1.18;
   elementScale[2] = 0.5;   
   elementTint[2] = "1.0 1.0 1.0";
   elementRotate[2] = true;
   elementUseLightColor[2] = true;
   
   elementRect[3] = "1152 128 128 128";
   elementDist[3] = 1.25;
   elementScale[3] = 0.25;   
   elementTint[3] = "1.0 1.0 1.0";
   elementRotate[3] = true;
   elementUseLightColor[3] = true;
   
   elementRect[4] = "1024 0 128 128";
   elementDist[4] = 2.0;
   elementScale[4] = 0.25;      
   elementTint[4] = "0.7 0.7 0.7";
   elementRotate[4] = true;
   elementUseLightColor[4] = true;
};

function AlterVerseTime::onAdd(%this)
{
   %this.clockSynchEvent = %this.schedule((%this.dayLength / 6) * 1000, "AdjustTime");
}

function AlterVerseTime::onRemove(%this)
{
   if ( isEventPending(%this.clockSynchEvent) )
      cancel(%this.clockSynchEvent);
}

function AlterVerseTime::AdjustTime(%this)
{  // This synchronizes the TimeOfDay object with the server clock
   // Time of day drifts due to tick rate irregularities, schedule just often
   // enough to keep it close.
   %this.ReSynchClocks();
   %this.clockSynchEvent = %this.schedule((%this.dayLength / 6) * 1000, "AdjustTime");
}

function RunTimeFast()
{
   if ( !isObject(AlterVerseTime) )
      return;

   if ( isEventPending(AlterVerseTime.clockSynchEvent) )
      cancel(AlterVerseTime.clockSynchEvent);

   AlterVerseTime.dayLength = 900;   // 15 minute days.
   AlterVerseTime.SunriseTime = 90;  // sunrise 1.5 mins past the 1/4 hour
   AlterVerseTime.SunsetTime = 810;  // sunset 1.5 min before the 1/4 hour
   AlterVerseTime.AdjustTime();
}

function RunTimeNormal()
{
   if ( !isObject(AlterVerseTime) )
      return;

   if ( isEventPending(AlterVerseTime.clockSynchEvent) )
      cancel(AlterVerseTime.clockSynchEvent);

   AlterVerseTime.dayLength = 86400;   // 24 hour days.
   AlterVerseTime.SunriseTime = 7200;  // sunrise @ 2AM
   AlterVerseTime.SunsetTime = 82800;  // sunset @ 11 PM
   AlterVerseTime.AdjustTime();
}
