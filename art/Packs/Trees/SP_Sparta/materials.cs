//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------


singleton Material(LargelICTree_leaves)
{
   mapTo = "leaves";
   diffuseMap[0] = "art/Packs/Trees/SP_Sparta/AV_CypressLeaf_dif.dds";
   specularPower[0] = "128";
   translucentBlendOp = "Sub";
   useAnisotropic[0] = "1";
   castShadows = "0";
   materialTag0 = "Buildings_SP_Sparta";
   backLightFactor = "0.9 1.0 0.2";
   pixelSpecular[0] = "0";
   specular[0] = "0 0 0 1";
   doubleSided = "1";
   translucent = "1";
   alphaRef = "0";
   specularStrength[0] = "1.37255";
};

singleton Material(LargelICTree_leaves)
{
   mapTo = "leaves";
   diffuseMap[0] = "art/Packs/Trees/SP_Sparta/ItalianCypress_Dif.dds";
   specular[0] = "0.831373 0.831373 0.831373 1";
   specularPower[0] = "1";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
   translucent = "1";
   doubleSided = "1";
   specularStrength[0] = "1.37255";
   pixelSpecular[0] = "0";
   alphaTest = "0";
   alphaRef = "0";
   castShadows = "0";
   materialTag0 = "Buildings_SP_Sparta";
   backLightFactor = "0.9 1.0 0.2";
};

singleton Material(LargelICTree_AV_CypressBark_dif)
{
   mapTo = "AV_CypressBark_dif";
   diffuseMap[0] = "AV_CypressBark_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
};
