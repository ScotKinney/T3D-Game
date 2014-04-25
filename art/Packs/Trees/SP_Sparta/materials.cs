//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton Material(mat_palmFronds)
{
   mapTo = "palm_fronds";
   pixelSpecular = 0;
   specular = "1 1 1 0"; // 1 1 0 0 = pure yellow
   specularPower = 1;
   translucent = "0";
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1;   
   diffuseMap[0] = "art/Packs/Trees/SP_Sparta/palmfrond_diffuse_transparency.dds";
   overlayMap[0] = "art/Packs/Trees/SP_Sparta/palmfrond_diffuse_transparency.dds";
   normalMap[0] = "art/Packs/Trees/SP_Sparta/palmfrond_normal.dds";
   specularMap[0] = "art/Packs/Trees/SP_Sparta/palmfrond_specular.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees_PalmFronds_GG";
};

singleton Material(mat_palmFrondsuv2)
{
   mapTo = "palm_fronds_uv2";
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
   specularMap[0] = "palmfrond_specular.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees_GG";
};

singleton Material(mat_palmBark)
{
   mapTo = "palm_bark";
   specular = "1 1 1 0";
   specularPower = 1;
   diffuseMap[0] = "palmbark_diffuse.dds";
   overlayMap[0] = "palmfrond_diffuse_transparency.dds";
   detailMap[0] = "palmbark_detail.dds";
   detailScale[0] = "4 4";
   normalMap[0] = "palmbark_normal.dds";
   specularMap[0] = "palmbark_specular.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees_GG";
};

singleton Material(mat_bananatree)
{
   mapTo = "bananatree";   
   diffuseMap[0] = "art/Packs/Trees/SP_Sparta/bananatree_diffuse.dds";
   normalMap[0] = "art/Packs/Trees/SP_Sparta/bananatree_normal.dds";
   specularMap[0] = "art/Packs/Trees/SP_Sparta/bananatree_specular.dds";
   specular = "0.988235 0.988235 0.976471 1";
   specularPower = 1; 
   translucent = "0";
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 107;
   forestWindEnabled = 1;
   useAnisotropic[0] = "1";   
   materialTag0 = "Trees_GG";
};

//////////////Color Effects

singleton Material(bananatree_mature_ColorEffectR153G228B153_material)
{
   mapTo = "ColorEffectR153G228B153-material";
   diffuseColor[0] = "0.6 0.894118 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(bananatree_mature_ColorEffectR87G225B198_material)
{
   mapTo = "ColorEffectR87G225B198-material";
   diffuseColor[0] = "0.341177 0.882353 0.776471 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};


singleton Material(palmtree_tall_ColorEffectR224G86B86_material)
{
   mapTo = "ColorEffectR224G86B86-material";
   diffuseColor[0] = "0.878431 0.337255 0.337255 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

