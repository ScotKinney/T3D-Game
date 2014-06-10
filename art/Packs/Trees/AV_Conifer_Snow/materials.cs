/////////////////////////////////////////

singleton Material(LushPine_Snow)
{
   mapTo = "LushPine_Snow";
   diffuseMap[0] = "LushPine_Snow";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   normalMap[0] = "LushPine_Snow_NRM.dds";
};

singleton Material(ScottPineBark)
{
   mapTo = "ScottPineBark";
   diffuseMap[0] = "ScottPineBark";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "ScottPineBark_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(DryPine2_Snow)
{
   mapTo = "DryPine2_Snow";
   diffuseMap[0] = "DryPine2_Snow";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "1";
   normalMap[0] = "DryPine2_Snow_NRM.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(BareBranch1_Wint)
{
   mapTo = "BareBranch1_Wint";
   diffuseMap[0] = "BareBranch1_Wint";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "0";
   normalMap[0] = "BareBranch1_Wint_nm.dds";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "12";
};

singleton Material(Pine_Bark3_Wint)
{
   mapTo = "Pine_Bark03_Wint";
   diffuseMap[0] = "Pine_Bark3_Wint";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "Pine_Bark3_Wint_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(PineBranch_Wint)
{
   mapTo = "PineBranch_Wint";
   diffuseMap[0] = "PineBranch_Wint";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "0";
   normalMap[0] = "PineBranch_Wint_nm.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
};

singleton Material(PineLight_Wint)
{
   mapTo = "PineLight_Wint";
   diffuseMap[0] = "PineLight_Wint";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "PineLight_Wint_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Pine_Snow)
{
   mapTo = "Pine_Snow";
   diffuseMap[0] = "Pine_Snow";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "0";
   normalMap[0] = "Pine_Snow_NRM.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "144";
};

singleton Material(DeadBranch02)
{
   mapTo = "DeadBranch02";
   diffuseMap[0] = "DeadBranch02";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "1";
   useAnisotropic[0] = "1";
};

singleton Material(DeadBranch01)
{
   mapTo = "DeadBranch01";
   diffuseMap[0] = "DeadBranch01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "1";
   useAnisotropic[0] = "1";
};

singleton Material(SequiaBark_Wint)
{
   mapTo = "SequiaBark_Wint";
   diffuseMap[0] = "SequiaBark_Wint";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "SequiaBark_Wint_nm.dds";
   useAnisotropic[0] = "1";
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