//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton Material(longleaf_fronds)
{
   mapTo = "longleaf_fronds";
   
//   overlayTex[0] = "longleafleaves_diffuse_transparency.dds";

//  ADDING DETAIL KILLS TRANSPARENCY HERE  
//   detailTex[0] = "palmfrond_detail.dds";
//   detailScale[0] = "4 4";
//   detailBumpMap[0] = true;

   pixelSpecular = "1";
   specular = "1 1 1 0"; // 1 1 0 0 = pure yellow
   specularPower = "128";

   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = "114";

   forestWindEnabled = 1;   
   diffuseMap[0] = "art/Packs/trees/longleaf/longleafleaves_diffuse_transparency.dds";
   normalMap[0] = "art/Packs/trees/longleaf/longleafleaves_normal_specular.dds";
   specularMap[0] = "art/Packs/trees/longleaf/longleafleaves_normal.dds";
   materialTag1 = "Vegetation";
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_LongLeaf";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

