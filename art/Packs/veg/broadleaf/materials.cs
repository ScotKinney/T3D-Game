//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton Material(broadleaf_plant)
{
   mapTo = "broadleaf";
   
   baseTex[0] = "";
   bumpTex[0] = "";

//  ADDING DETAIL KILLS TRANSPARENCY HERE  
//   detailTex[0] = "palmfrond_detail.dds";
//   detailScale[0] = "4 4";
//   detailBumpMap[0] = true;

   pixelSpecular = 0;
   specular = "1 1 0.85 0"; // 1 1 0 0 = pure yellow
   specularPower = 1;

   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;

   forestWindEnabled = 1;   
   diffuseMap[0] = "broadleaf_diffuse_transparency.dds";
   normalMap[0] = "broadleaf_normal_specular.dds";
   specularMap[0] = "broadleaf_specular.dds";
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Veg_BroadLeaf";
};
