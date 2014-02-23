//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------


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
   specularMap[0] = "palmfrond_specular.dds";
   materialTag0 = "Trees";
};

singleton Material(mat_palm_bark)
{
   mapTo = "palm_bark";
   diffuseMap[0] = "palmbark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   normalMap[0] = "palmbark_normal.dds";
   specularMap[0] = "palmbark_specular.dds";
   materialTag0 = "Trees";
};

singleton Material(mat_palm_fronds)
{
   mapTo = "palm_fronds";
   diffuseMap[0] = "palmfrond_diffuse_transparency";
   normalMap[0] = "palmfrond_normal.dds";
   specularMap[0] = "palmfrond_specular.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "LerpAlpha";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "84";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees";
};

//////////Color Effects

singleton Material(palmtree_tall_ColorEffectR224G86B86_material)
{
   mapTo = "ColorEffectR224G86B86-material";
   diffuseColor[0] = "0.878431 0.337255 0.337255 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
