singleton Material( ShoreDebrisMaterial )
{
   baseTex[0] = "";
   mapTo = "shore_debris.png";
   translucent = true;
   translucentBlendOp = LerpAlpha;
   translucentZWrite = true;
   alphaTest = true; 
   alphaRef = 75;
   diffuseMap[0] = "shore_debris.dds";
   materialTag0 = "RoadAndPath";
   normalMap[0] = "shore_debris_nrm.dds";
   specularPower[0] = "1";
   materialTag1 = "Vegetation";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
};