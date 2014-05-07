
/////MK4_AneityumPalm

singleton Material(MK4_AneityumLeaf)
{
   mapTo = "MK4_AneityumLeaf";
   diffuseMap[0] = "MK4_Aneityum_Palm_leafs.dds";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
   alphaTest = "0";
   alphaRef = "0";
   doubleSided = "1";
   translucent = "1";
   forestWindEnabled = "1";
   materialTag0 = "Trees_PalmFronds_GG";
};

singleton Material(MK4_AneityumBark)
{
   mapTo = "MK4_AneityumBark";
   diffuseMap[0] = "MK4_Aneityum_Palm_bark";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
};

singleton Material(MK4_AneityumPalm_ColorEffectR214G229B166)
{
   mapTo = "ColorEffectR214G229B166-material";
   diffuseColor[0] = "0.839216 0.898039 0.65098 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

//////MK4_Areca Palms

singleton Material(MK4_ArecaLeaf)
{
   mapTo = "MK4_ArecaLeaf";
   diffuseMap[0] = "MK4_Areca_Leafs";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "130";
   translucent = "0";
   forestWindEnabled = "1";
   materialTag0 = "Trees_PalmFronds_GG";
};

singleton Material(MK4_ArecaTrunk)
{
   mapTo = "MK4_ArecaTrunk";
   diffuseMap[0] = "MK4_Areca_trunk.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Miscellaneous";
   normalMap[0] = "MK4_Areca_trunk_nmp.dds";
};

singleton Material(MK4_ArecaPalm1_ColorEffectR213G154B229)
{
   mapTo = "ColorEffectR213G154B229-material";
   diffuseColor[0] = "0.835294 0.603922 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(MK4_ArecaPalm2_ColorEffectR88G177B27)
{
   mapTo = "ColorEffectR88G177B27-material";
   diffuseColor[0] = "0.345098 0.694118 0.105882 0";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(MK4_ArecaPalm3_ColorEffectR87G225B87)
{
   mapTo = "ColorEffectR87G225B87-material";
   diffuseColor[0] = "0.341177 0.882353 0.341177 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

////MK4_BallPalms

singleton Material(MK4_BallPalm_Bark)
{
   mapTo = "MK4_BallPalm_Bark";
   diffuseMap[0] = "MK4_BallPalm";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "MK4_BallPalm_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(MK4_BallPalm_Leaf)
{
   mapTo = "MK4_BallPalm_Leaf";
   diffuseMap[0] = "MK4_BallPalm";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "130";
   normalMap[0] = "MK4_BallPalm_nm.dds";
   doubleSided = "1";
};

singleton Material(MK4_BallPalm1_ColorEffectR88G199B225)
{
   mapTo = "ColorEffectR88G199B225-material";
   diffuseColor[0] = "0.345098 0.780392 0.882353 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(MK4_BallPalm2_ColorEffectR28G149B177)
{
   mapTo = "ColorEffectR28G149B177-material";
   diffuseColor[0] = "0.109804 0.584314 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

////MK4_Banana Trees

singleton Material(MK4_BananaTree_Leaf)
{
   mapTo = "MK4_BananaTree_Leaf";
   diffuseMap[0] = "MK4_BananaTree.dds";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "130";
};

singleton Material(MK4_BananaTree_Bark)
{
   mapTo = "MK4_BananaTree_Bark";
   diffuseMap[0] = "MK4_BananaTree";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "130";
};

singleton Material(MK4_BananaTree2_ColorEffectR88G144B225)
{
   mapTo = "ColorEffectR88G144B225-material";
   diffuseColor[0] = "0.345098 0.564706 0.882353 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(MK4_BananaTree3_ColorEffectR61G135B6)
{
   mapTo = "ColorEffectR61G135B6-material";
   diffuseColor[0] = "0.239216 0.529412 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

/////MK4_Coco Palms

singleton Material(MK4_CocoBark1)
{
   mapTo = "MK4_CocoBark1";
   diffuseMap[0] = "MK4_cocos_bark1";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "MK4_cocos_bark1_nmp.dds";
   useAnisotropic[0] = "1";
};

singleton Material(MK4_CocoBark2)
{
   mapTo = "MK4_CocoBark2";
   diffuseMap[0] = "MK4_cocos_bark2";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "MK4_cocos_bark2_nmp.dds";
};

singleton Material(MK4_Cocos_Leafs)
{
   mapTo = "MK4_Cocos_Leafs";
   diffuseMap[0] = "MK4_Cocos_Leafs";
   doubleSided = "1";
   translucent = "1";
   alphaRef = "0";
};

singleton Material(MK4_CocoPalm_ColorEffectR227G153B153)
{
   mapTo = "ColorEffectR227G153B153-material";
   diffuseColor[0] = "0.890196 0.6 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

////MK4_Disopyros


singleton Material(MK4_Disophyros_bark)
{
   mapTo = "MK4_Disophyros_bark";
   diffuseMap[0] = "MK4_Disophyros_bark";
   normalMap[0] = "MK4_Disophyros_bark_nmp.dds";
   useAnisotropic[0] = "1";
};

singleton Material(MK4_Disophyros_leafs)
{
   mapTo = "MK4_Disophyros_leafs";
   diffuseMap[0] = "MK4_Disophyros_leafs";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   translucent = "0";
   alphaTest = "1";
   alphaRef = "150";
};

singleton Material(MK4_DisopyrosChloroxylon1_ColorEffectR145G28B177)
{
   mapTo = "ColorEffectR145G28B177-material";
   diffuseColor[0] = "0.568627 0.109804 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(MK4_DisopyrosChloroxylon2_ColorEffectR225G198B87)
{
   mapTo = "ColorEffectR225G198B87-material";
   diffuseColor[0] = "0.882353 0.776471 0.341177 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

//////MK4_Fan Palms

singleton Material(MK4_washingtonia_bark1)
{
   mapTo = "MK4_washingtonia_bark1";
   diffuseMap[0] = "MK4_washingtonia_bark1";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
};

singleton Material(MK4_washingtonia_bark2)
{
   mapTo = "MK4_washingtonia_bark2";
   diffuseMap[0] = "MK4_washingtonia_bark2";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "MK4_washingtonia_bark2_nmp.dds";
   useAnisotropic[0] = "1";
   forestWindEnabled = "1";
};

singleton Material(MK4_washingtonia_leafs)
{
   mapTo = "MK4_washingtonia_leafs";
   diffuseMap[0] = "MK4_washingtonia_leafs";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   translucent = "0";
   alphaTest = "1";
   alphaRef = "150";
   forestWindEnabled = "1";
   materialTag0 = "Trees_PalmFronds_GG";
};

singleton Material(MK4_FanPalm2_ColorEffectR177G28B149)
{
   mapTo = "ColorEffectR177G28B149-material";
   diffuseColor[0] = "0.694118 0.109804 0.584314 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

///////MK4_Ficus

singleton Material(MK4_ficus_bark)
{
   mapTo = "MK4_ficus_bark";
   diffuseMap[0] = "MK4_ficus_bark";
   normalMap[0] = "MK4_ficus_bark_nmp.dds";
   useAnisotropic[0] = "1";
};

singleton Material(MK4_ficus_branch)
{
   mapTo = "MK4_ficus_branch";
   diffuseMap[0] = "MK4_ficus_branch";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "150";
};

singleton Material(MK4_Ficus1_ColorEffectR141G7B58_material)
{
   mapTo = "ColorEffectR141G7B58-material";
   diffuseColor[0] = "0.552941 0.027451 0.227451 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "Rock";
};

////MK4_Ivy Plant

singleton Material(MK4_ivy_plant)
{
   mapTo = "MK4_ivy_plant";
   diffuseMap[0] = "MK4_ivy_plant";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "0";
   normalMap[0] = "MK4_ivy_plant_nmp.dds";
   translucent = "1";
   alphaRef = "0";
};

/////////MK4_Latania

singleton Material(MK4_Latania_leafs)
{
   mapTo = "MK4_Latania_leafs";
   diffuseMap[0] = "MK4_Latania_leafs";
   specularPower[0] = "1";
   pixelSpecular[0] = "0";
   useAnisotropic[0] = "1";
   translucent = "0";
   alphaTest = "1";
   alphaRef = "214";
   doubleSided = "1";
};

singleton Material(MK4_Latania_bark)
{
   mapTo = "MK4_Latania_bark";
   diffuseMap[0] = "MK4_Latania_bark";
   useAnisotropic[0] = "1";
};

////////MK4_MacArthur Palm

singleton Material(MK4_MacArthurPalm_leaf)
{
   mapTo = "MK4_MacArthurPalm_leaf";
   diffuseMap[0] = "MK4_Macarthur_Palm";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "130";
   translucent = "0";
};

singleton Material(MK4_MacArthurPalm_Bark)
{
   mapTo = "MK4_MacArthurPalm_Bark";
   diffuseMap[0] = "MK4_Macarthur_Palm";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
};

////MK4_Orange Palm

singleton Material(MK4_OrangePalm)
{
   mapTo = "MK4_OrangePalm";
   diffuseMap[0] = "MK4_Orange_palm";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "130";
};

////MK4_Windmill Palm


singleton Material(MK4_Windmill_Palm_trunk)
{
   mapTo = "MK4_Windmill_Palm_trunk";
   diffuseMap[0] = "MK4_Windmill_Palm_trunk";
   useAnisotropic[0] = "1";
};

singleton Material(MK4_Windmill_Palm_leafs)
{
   mapTo = "MK4_Windmill_Palm_leafs";
   diffuseMap[0] = "MK4_Windmill_Palm_leafs";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "130";
};

////MK4_Yucca Tree

singleton Material(MK4_Yucca)
{
   mapTo = "MK4_yucca";
   diffuseMap[0] = "MK4_yucca";
   normalMap[0] = "MK4_yucca_nmp.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "130";
};

singleton Material(MK4_Yucca_Bark)
{
   mapTo = "MK4_Yucca_Bark";
   diffuseMap[0] = "MK4_yucca_bark";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "MK4_yucca_bark_nmp.dds";
   useAnisotropic[0] = "1";
};
