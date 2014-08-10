
singleton Material(palmtree_tall_palm_bark)
{
   mapTo = "palm_bark";
   diffuseMap[0] = "art/Packs/Trees/AV_Tropical/palmbark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   castShadows = "0";
   alphaTest = "1";
};

singleton Material(palmtree_tall_palm_fronds)
{
   mapTo = "palm_fronds";
   diffuseMap[0] = "art/Packs/Trees/AV_Tropical/palmfrond_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
   translucent = "0";
   alphaRef = "20";
   castShadows = "1";
   alphaTest = "1";
};

singleton Material(bananatree_mature_bananatree)
{
   mapTo = "bananatree";
   diffuseMap[0] = "art/Packs/Trees/AV_Tropical/bananatree_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   castShadows = "0";
   alphaTest = "1";
   alphaRef = "234";
};

singleton Material(bananatree_mature_ColorEffectR87G225B198_material)
{
   mapTo = "ColorEffectR87G225B198-material";
   diffuseColor[0] = "0.341177 0.882353 0.776471 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(bananatree_mature_ColorEffectR153G228B153_material)
{
   mapTo = "ColorEffectR153G228B153-material";
   diffuseColor[0] = "0.6 0.894118 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
