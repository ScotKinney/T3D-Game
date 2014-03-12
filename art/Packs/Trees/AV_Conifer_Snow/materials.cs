singleton Material(mat_DriPine_Win_AV)
{
   mapTo = "DriPine-Win";
   diffuseMap[0] = "DryPine2_Snow.dds";
   normalMap[0] = "DryPine2_Snow_NRM.dds";
   specularMap[0] = "DryPine2_Snow_SPEC.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   alphaTest = "1";
   alphaRef = "70";
   doubleSided = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees";
};

singleton Material(mat_TallPineNeed_Win)
{
   mapTo = "TallPineNeed-Win";
   diffuseMap[0] = "Pine_Snow.dds";
   normalMap[0] = "Pine_Snow_NRM.dds";
   specularMap[0] = "Pine_Snow_SPEC.dds";
   alphaTest = "1";
   alphaRef = "51";
   doubleSided = "1";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.996078 0.992157 0.992157 1";
   subSurfaceRolloff[0] = "0.5";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees";
};

singleton Material(mat_Seq01Branch_Win)
{
   mapTo = "Seq01Branch-Win";
   diffuseMap[0] = "Pine_Snow.dds";
   normalMap[0] = "Pine_Snow_NRM.dds";
   specularMap[0] = "Pine_Snow_SPEC.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.992157 0.992157 0.992157 1";
   alphaTest = "1";
   alphaRef = "49";
   subSurfaceRolloff[0] = "0.5";
   doubleSided = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees";
};

singleton Material(mat_SoftPine2_Winter)
{
   mapTo = "SoftPine2_Winter";
   diffuseMap[0] = "LushPine_Snow.dds";
   normalMap[0] = "LushPine_Snow_NRM.dds";
   specularMap[0] = "LushPine_Snow_SPEC.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   doubleSided = "1";
   alphaTest = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees";
};

singleton Material(mat_PineNeedles_Win)
{
   mapTo = "PineNeedles-Win";
   diffuseMap[0] = "Pine_Snow.dds";
   normalMap[0] = "Pine_Snow_NRM.dds";
   specularMap[0] = "Pine_Snow_SPEC.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.968628 0.964706 0.964706 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
   subSurfaceRolloff[0] = "0.5";
   useAnisotropic[0] = "1";
   materialTag0 = "Trees";
};

/////////////////////Color Effects

singleton Material(Win_Pine01_ColorEffectR87G224B143)
{
   mapTo = "ColorEffectR87G224B143-material";
   diffuseColor[0] = "0.341177 0.878431 0.560784 1";
   specularPower[0] = "10";
};

singleton Material(Win_Sequia01_ColorEffectR27G177B88)
{
   mapTo = "ColorEffectR27G177B88-material";
   diffuseColor[0] = "0.105882 0.694118 0.345098 1";
   specularPower[0] = "10";
};


singleton Material(Win_Sequia03_ColorEffectR227G153B153_material)
{
   mapTo = "ColorEffectR227G153B153_material";
   diffuseColor[0] = "0.890196 0.6 0.6 1";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "1";
};

