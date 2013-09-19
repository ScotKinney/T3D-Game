//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton Material(longleaf_fronds)
{
   mapTo = "longleaf_fronds";
   
   baseTex[0] = "";
//   overlayTex[0] = "longleafleaves_diffuse_transparency.dds";
   bumpTex[0] = "";

//  ADDING DETAIL KILLS TRANSPARENCY HERE  
//   detailTex[0] = "palmfrond_detail.dds";
//   detailScale[0] = "4 4";
//   detailBumpMap[0] = true;

   pixelSpecular = 0;
   specular = "1 1 1 0"; // 1 1 0 0 = pure yellow
   specularPower = 12;

   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;

   forestWindEnabled = 1;   
   diffuseMap[0] = "longleafleaves_diffuse_transparency.dds";
   normalMap[0] = "longleafleaves_normal.dds";
   specularMap[0] = "longleafleaves_specular.dds";
   materialTag1 = "Vegetation";
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_LongLeaf";
};

