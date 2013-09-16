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
