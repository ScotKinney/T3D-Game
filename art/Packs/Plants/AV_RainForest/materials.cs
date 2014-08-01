////////Phila
singleton Material(mat_Phila01)
{
   mapTo = "_1_-_Default";
   diffuseMap[0] = "PhilLeaf01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "Sub";
   normalMap[0] = "PhilLeaf01_NRM.dds";
   specularMap[0] = "PhilLeaf01_SPEC.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.768628 1 0 1";
   alphaTest = "1";
   alphaRef = "127";
   forestWindEnabled = 1;
   pixelSpecular[0] = "1";
   materialTag0 = "Plants_AVRainforest";
};

///////TropicFern

singleton Material(mat_TropicFern01_GG)
{
   mapTo = "TropicFern01";
   diffuseMap[0] = "fern_image2";
   normalMap[0] = "fern_image2_NRM.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   specularMap[0] = "fern_image2_SPEC.dds";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.643137 0.815686 0.321569 1";
   translucentBlendOp = "Sub";
   alphaTest = "1";
   alphaRef = "147";
   diffuseColor[0] = "1 0.858824 0 1";
   forestWindEnabled = 1;
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Plants_AVRainforest";
};

singleton Material(mat_TropFernSprout)
{
   mapTo = "FernSprout01";
   diffuseMap[0] = "ferntop.png";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "60";
   diffuseColor[0] = "1 0.882353 0 1";
   materialTag0 = "Plants_AVRainforest";
};

///////////////BirdNest

singleton Material(mat_BirdNestLeaf01)
{
   mapTo = "BirdNestLeaf01";
   diffuseMap[0] = "BirdsNestFernLeaf2";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "BirdsNestFernLeaf2_NRM.png";
   specularMap[0] = "BirdsNestFernLeaf2_SPEC.png";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "60";
   materialTag0 = "Plants_AVRainforest";
};

singleton Material(mat_BirdNestLeaf)
{
   mapTo = "BirdNestLeaf02";
   diffuseMap[0] = "birdnest01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "25";
   translucentBlendOp = "None";
   normalMap[0] = "birdnest01_NRM";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "60";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.858824 1 0 1";
   specularMap[0] = "birdnest01_SPEC";
   materialTag0 = "Plants_AVRainforest";
};

singleton Material(mat_BirdNestBark)
{
   mapTo = "BirdNestBark01";
   diffuseMap[0] = "banana_bark";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Plants_AVRainforest";
};

////////////////Elephant Ear

singleton Material(mat_ElephantEar_Leaf)
{
   mapTo = "Elephant01";
   diffuseMap[0] = "GreenLeafLong";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "19";
   translucentBlendOp = "None";
   normalMap[0] = "GreenLeafLong_NRM";
   useAnisotropic[0] = "1";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.545098 0.701961 0.25098 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "60";
   diffuseColor[0] = "0.992157 0.992157 0.992157 1";
   pixelSpecular[0] = "1";
   materialTag0 = "Plants_AVRainforest";
};

singleton Material(mat_ElephantEar_Bark)
{
   mapTo = "ElephantBark";
   diffuseMap[0] = "banana_bark.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   materialTag0 = "Plants_AVRainforest";
};

/////////////Bush01

singleton Material(Bush01_mat)
{
   mapTo = "Bush01";
   diffuseMap[0] = "largeFiscus2.dds";
   normalMap[0] = "largeFiscus2_NRM.dds";
   specularMap[0] = "largeFiscus2_SPEC.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.768628 1 0 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "60";
   materialTag0 = "Plants_AVRainforest";
};

//////////////////////Bamboo01

singleton Material(mat_bambooLeaf01)
{
   mapTo = "bambooLeaf01";
   diffuseMap[0] = "3td_BambooLeaf_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.882353 1 0 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "50";
   normalMap[0] = "3td_BambooLeaf_01_NRM";
   specularMap[0] = "3td_BambooLeaf_01_SPEC";
};

singleton Material(mat_BambooBark01)
{
   mapTo = "BambooBark01";
   diffuseMap[0] = "3TD_bambooBark01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_bambooBark01_NRM";
   specularMap[0] = "3TD_bambooBark01_SPEC";
   useAnisotropic[0] = "1";
};

singleton Material(Bamboo01_ColorEffectR225G143B87_material)
{
   mapTo = "ColorEffectR225G143B87-material";
   diffuseColor[0] = "0.882353 0.560784 0.341177 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

///////////////////////Bamboo02

singleton Material(mat_Bamboo_02)
{
   mapTo = "_td_Bamboo_02";
   diffuseMap[0] = "3TD_BambooBark02";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_BambooBark02_NRM";
   useAnisotropic[0] = "1";
};

singleton Material(mat_YoungBamboo_01)
{
   mapTo = "YoungBamboo_01";
   diffuseMap[0] = "3TD_YoungBamboo_01";
   specular[0] = "0.972549 0.972549 0.972549 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.827451 0.862745 0.482353 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "100";
   specularMap[0] = "3TD_YoungBamboo_01_SPEC";
};
