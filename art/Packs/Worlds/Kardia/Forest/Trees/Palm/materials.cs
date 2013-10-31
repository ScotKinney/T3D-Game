//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton Material(palm_fronds_material)
{
   mapTo = "palm_fronds";
   
   baseTex[0] = "";
   overlayTex[0] = "";
   bumpTex[0] = "";

   pixelSpecular = 0;
   specular = "1 1 1 0"; // 1 1 0 0 = pure yellow
   specularPower = 1;

   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;

   forestWindEnabled = 1;   
   diffuseMap[0] = "palmfrond_diffuse_transparency.dds";
   overlayMap[0] = "palmfrond_diffuse_transparency.dds";
   normalMap[0] = "palmfrond_normal.dds";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Vegetation";
   specularMap[0] = "palmfrond_specular.dds";
   materialTag1 = "Vegetation";
};

singleton Material(palm_frondsuv2_material)
{
   mapTo = "palm_fronds_uv2";
   
   baseTex[0] = "";
   overlayTex[0] = "";
   bumpTex[0] = "";

   pixelSpecular = 0;
   specular = "1 1 1 0"; // 1 1 0 0 = pure yellow
   specularPower = 1;

   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;

   forestWindEnabled = 1;   
   diffuseMap[0] = "palmfrond_diffuse_transparency.dds";
   overlayMap[0] = "palmfrond_diffuse_transparency.dds";
   normalMap[0] = "palmfrond_normal.dds";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Vegetation";
   specularMap[0] = "palmfrond_specular.dds";
   materialTag1 = "Vegetation";
};

singleton Material(palm_bark_material)
{
   detailScale[0] = "4 4";
   
   mapTo = "palm_bark";
     
   pixelSpecular = 0;
   specular = "1 1 1 0";
   specularPower = 1;
   
   forestWindEnabled = 1;
   diffuseMap[0] = "palmbark_diffuse.dds";
   overlayMap[0] = "palmfrond_diffuse_transparency.dds";
   detailMap[0] = "palmbark_detail.dds";
   normalMap[0] = "palmbark_normal.dds";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Vegetation";
   specularMap[0] = "palmbark_specular.dds";
   materialTag1 = "Vegetation";
};


