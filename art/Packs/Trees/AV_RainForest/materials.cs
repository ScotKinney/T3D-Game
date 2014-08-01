singleton Material(CoconutBrown)
{
   mapTo = "CoconutBrown";
   diffuseMap[0] = "3td_coconut_shell";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "3td_coconut_shell_NRM.png";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(CoconutGreen)
{
   mapTo = "CoconutGreen";
   diffuseMap[0] = "3td_CoconutGreen";
   specular[0] = "0.933333 0.933333 0.933333 1";
   specularPower[0] = "31";
   translucentBlendOp = "None";
   normalMap[0] = "3td_CoconutGreen_NRM.png";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(CopalTree01_Fishtail)
{
   mapTo = "Fishtail";
   diffuseMap[0] = "FishtailFrond.png";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "FishtailFrond_NRM.png";
   specularMap[0] = "FishtailFrond_SPEC.png";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.733333 0.917647 0.423529 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "60";
   subSurfaceRolloff[0] = "0.4";
};

singleton Material(CopalTree01_Vino)
{
   mapTo = "Vino";
   diffuseMap[0] = "Vines02.png";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
   useAnisotropic[0] = "1";
};

singleton Material(CopalTree01_JungleBark02)
{
   mapTo = "JungleBark02";
   diffuseMap[0] = "JungleBark02.jpg";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "21";
   translucentBlendOp = "None";
   normalMap[0] = "JungleBark02_NRM.png";
   specularMap[0] = "JungleBark02_SPEC.png";
};

singleton Material(mat_CrecopiaBark)
{
   mapTo = "JungleBark01";
   diffuseMap[0] = "JungleBark02.jpg";
   normalMap[0] = "JungleBark02_NRM.png";
   specularPower[0] = "25";
   specularMap[0] = "JungleBark02_SPEC.png";
};

singleton Material(mat_CrecopiaLeaf)
{
   mapTo = "BaseLeaf01";
   diffuseMap[0] = "largeFiscus.png";
   normalMap[0] = "largeFiscus_NRM.png";
   specularMap[0] = "largeFiscus_SPEC.png";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.552941 0.666667 0.254902 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "60";
};

singleton Material(mat_Cecropia_Vines02)
{
   mapTo = "C-Vines02";
   diffuseMap[0] = "Vines02.png";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
   normalMap[0] = "Vines02_NRM.png";
};

singleton Material(CecropiaTree01_C_Vines01)
{
   mapTo = "C-Vines01";
   diffuseMap[0] = "GreenVine02.png";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.423529 0.521569 0.101961 1";
   subSurfaceRolloff[0] = "0.1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
   normalMap[0] = "GreenVine02_NRM.png";
};

singleton Material(CecropiaTree01_ColorEffectR87G225B198_material)
{
   mapTo = "ColorEffectR87G225B198-material";
   diffuseColor[0] = "0.341177 0.882353 0.776471 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(CopalTree01_ColorEffectR88G88B225_material)
{
   mapTo = "ColorEffectR88G88B225-material";
   diffuseColor[0] = "0.345098 0.345098 0.882353 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Banana01_bananaBark01)
{
   mapTo = "bananaBark01";
   diffuseMap[0] = "art/Packs/Trees/AV_Rainforest/banana_bark";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Trees/AV_RainForest/banana_bark_NRM.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Banana01_Ban_Leaf_02)
{
   mapTo = "Ban_Leaf_02";
   diffuseMap[0] = "art/Packs/Trees/AV_Rainforest/BananaLeaf02";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "13";
   doubleSided = "1";
   normalMap[0] = "art/Packs/Trees/AV_RainForest/BananaLeaf01_NRM.dds";
};

singleton Material(Banana01_Ban_Leaf_01)
{
   mapTo = "Ban_Leaf_01";
   diffuseMap[0] = "art/Packs/Trees/AV_Rainforest/BananaLeaf01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "67";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   normalMap[0] = "art/Packs/Trees/AV_RainForest/BananaLeaf01_NRM.dds";
};

singleton Material(Banana01_ColorEffectR6G135B58_material)
{
   mapTo = "ColorEffectR6G135B58-material";
   diffuseColor[0] = "0.0235294 0.529412 0.227451 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Banana02_NannerBark02)
{
   mapTo = "NannerBark02";
   diffuseMap[0] = "banana_bark";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Banana02_Nanner02)
{
   mapTo = "Nanner02";
   diffuseMap[0] = "BananaLeaf02";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Banana02_Nanner01)
{
   mapTo = "Nanner01";
   diffuseMap[0] = "BananaLeaf01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Banana02_ColorEffectR177G28B149_material)
{
   mapTo = "ColorEffectR177G28B149-material";
   diffuseColor[0] = "0.694118 0.109804 0.584314 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Banana02_NannerBark01)
{
   mapTo = "NannerBark01";
   diffuseMap[0] = "banana_bark";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
