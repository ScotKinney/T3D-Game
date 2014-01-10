
singleton Material(DeadStandingPine01_ColorEffectR28G28B177_material)
{
   mapTo = "ColorEffectR28G28B177-material";
   diffuseColor[0] = "0.109804 0.109804 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(DeadStandingPine01_DeadBark01)
{
   mapTo = "DeadBark01";
   diffuseMap[0] = "pine_bark03.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "pine_bark03_NRM.dds";
   useAnisotropic[0] = "1";
};

singleton Material(DeadStandingPine02_ColorEffectR154G185B229_material)
{
   mapTo = "ColorEffectR154G185B229-material";
   diffuseColor[0] = "0.603922 0.72549 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(DeadStandingPine02_DeadPineStand02)
{
   mapTo = "DeadPineStand02";
   diffuseMap[0] = "pine_bark03.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "pine_bark03_NRM.dds";
};

singleton Material(DriPine01_DarkPineBark)
{
   mapTo = "DarkPineBark";
   diffuseMap[0] = "pine_bark03.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "pine_bark03_NRM.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(DriPine01_DriPine)
{
   mapTo = "DriPine";
   diffuseMap[0] = "art/Packs/Forests/trees/pines/DryPine2.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.596078 0.552941 0.282353 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "82";
   normalMap[0] = "art/Packs/Forests/trees/pines/DryPine2_NRM.dds";
   subSurfaceRolloff[0] = "1";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/Forests/trees/pines/DryPine2_SPEC.dds";
   showFootprints = "0";
};

singleton Material(DriPine01_DarkDriBare)
{
   mapTo = "DarkDriBare";
   diffuseMap[0] = "art/Packs/Forests/trees/pines/Pinebarebranch01.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "51";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Forests/trees/pines/Pinebarebranch01_NRM.dds";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "76";
   showFootprints = "0";
};

singleton Material(DriPine01_ColorEffectR6G135B6_material)
{
   mapTo = "ColorEffectR6G135B6-material";
   diffuseColor[0] = "0.0235294 0.529412 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(PinTree002_PineBark02)
{
   mapTo = "PineBark02";
   diffuseMap[0] = "PineLight2_DIF.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "PineLight2_NRM.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(PinTree002_PineNeedles02)
{
   mapTo = "PineNeedles02";
   diffuseMap[0] = "pinetree002.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "pinetree002_NRM.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.768628 0.909804 0.356863 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "100";
};

singleton Material(PinTree002_DeadPineNeedles02)
{
   mapTo = "DeadPineNeedles02";
   diffuseMap[0] = "PineBranch2_DIF.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "PineBranch2_NRM.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
};

singleton Material(Pine001_DeadPineNeedles)
{
   mapTo = "DeadPineNeedles";
   diffuseMap[0] = "PineBranch_DIF.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "LerpAlpha";
   doubleSided = "1";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "181";
   normalMap[0] = "PineBranch_NRM.dds";
   useAnisotropic[0] = "1";
};

singleton Material(SoftPine2_Winter_mat)
{
   mapTo = "SoftPine2_Winter";
   diffuseMap[0] = "art/Packs/Forests/trees/pines/LushPine_Snow.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.996078 0.992157 0.992157 1";
   subSurfaceRolloff[0] = "0.5";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "102";
   normalMap[0] = "art/Packs/Forests/trees/pines/LushPine_Snow_NRM.dds";
   specularPower[0] = "128";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/Forests/trees/pines/LushPine_Snow.dds";
   showFootprints = "0";
};

singleton Material(scrubPine_SoftPineBark)
{
   mapTo = "SoftPineBark";
   diffuseMap[0] = "art/Packs/Forests/trees/pines/Piney.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/trees/pines/Piney_NRM.dds";
   doubleSided = "1";
};

singleton Material(scrubPine_ColorEffectR225G88B199_material)
{
   mapTo = "ColorEffectR225G88B199-material";
   diffuseColor[0] = "0.882353 0.345098 0.780392 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(scrubPine_ColorEffectR135G6B6_material)
{
   mapTo = "ColorEffectR135G6B6-material";
   diffuseColor[0] = "0.529412 0.0235294 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(scrubPine_ColorEffectR6G135B113_material)
{
   mapTo = "ColorEffectR6G135B113-material";
   diffuseColor[0] = "0.0235294 0.529412 0.443137 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(scrubPine_SoftPine2)
{
	mapTo = "SoftPine2";

	diffuseMap[0] = "LushPine.dds";
	normalMap[0] = "LushPine_NRM.dds";
   //specularMap[0] = "LushPine_SPEC.dds";

	diffuseColor[0] = "0.996078 0.992157 0.992157 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "0";

	doubleSided = 1;
	translucent = 0;
	translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   alphaTest = "1";
   alphaRef = "50";
   pixelSpecular[0] = "0";
   showFootprints = "0";
   subSurfaceColor[0] = "0.537255 0.619608 0.121569 1";
   subSurfaceRolloff[0] = "1";
};

singleton Material(ShortPine001_PineBark01)
{
   mapTo = "PineBark01";
   diffuseMap[0] = "PineLight_DIF.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "PineLight_NRM.dds";
};

singleton Material(ShortPine001_HighPine01)
{
   mapTo = "HighPine01";
   diffuseMap[0] = "pinetree001.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "pinetree001_NRM.dds";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.772549 0.847059 0.45098 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
   useAnisotropic[0] = "1";
   subSurfaceRolloff[0] = "0.7";
};

singleton Material(ShortPine001_BarePine)
{
   mapTo = "BarePine";
   diffuseMap[0] = "PineBranch_DIF.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "PineBranch_NRM.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "100";
};

singleton Material(Win_DryPine01_DriPine_Win)
{
   mapTo = "DriPine-Win";
   diffuseMap[0] = "art/Packs/Forests/trees/pines/DryPine2_Snow.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Forests/trees/pines/DryPine2_Snow_NRM.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
};

singleton Material(Pine001_PineBark)
{
   mapTo = "PineBark";
   diffuseMap[0] = "PineLight_DIF.dds";
   specular[0] = "0.435294 0.360784 0.223529 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "PineLight_NRM.dds";
   doubleSided = "1";
   useAnisotropic[0] = "1";
   showFootprints = "0";
   detailScale[0] = "1 1";
   pixelSpecular[0] = "0";
};

singleton Material(Win_Pine01_PineNeedles_Win)
{
   mapTo = "PineNeedles-Win";
   diffuseMap[0] = "Pine_Snow.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "Pine_Snow_NRM.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.968628 0.964706 0.964706 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
   subSurfaceRolloff[0] = "0.5";
};

singleton Material(TallPine01_TallPineBark)
{
	mapTo = "TallPineBark";

	diffuseMap[0] = "SequiaBark_DIF.dds";
	normalMap[0] = "SequiaBark_NRM.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.45098 0.380392 0.254902 1";
	specularPower[0] = "0";

	doubleSided = "1";
	translucent = false;
	translucentBlendOp = "None";
   pixelSpecular[0] = "0";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(TallPine01_TallPineBare)
{
	mapTo = "TallPineBare";

	diffuseMap[0] = "PineBranch_DIF.dds";
	normalMap[0] = "PineBranch_NRM.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "0";

	doubleSided = 1;
	translucent = "1";
	translucentBlendOp = "LerpAlpha";
   alphaTest = "1";
   alphaRef = "140";
   useAnisotropic[0] = "1";
};

singleton Material(Win_Sequia01_TallPineNeed_Win)
{
   mapTo = "TallPineNeed-Win";
   diffuseMap[0] = "Pine_Snow.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "Pine_Snow_NRM.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.996078 0.992157 0.992157 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
   subSurfaceRolloff[0] = "0.5";
};

singleton Material(DTSSequia_Dead02)
{
   mapTo = "Dead02";
   diffuseMap[0] = "DeadBranch02.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "40";
};

singleton Material(DTSSequia_Dead01)
{
   mapTo = "Dead01";
   diffuseMap[0] = "DeadBranch01.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "40";
};

singleton Material(Sequia_02_ColorEffectR227G153B153_material)
{
   mapTo = "ColorEffectR227G153B153-material";
   diffuseColor[0] = "0.890196 0.6 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Sequia_02_Seq02Bark)
{
   mapTo = "Seq02Bark";
   diffuseMap[0] = "SequiaBark_DIF.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "SequiaBark_NRM.dds";
   doubleSided = "1";
};

singleton Material(Sequia_02_Broken01)
{
   mapTo = "Broken01";
   diffuseMap[0] = "DeadBranch01a.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "25";
};

singleton Material(Sequia_02_Broken02)
{
   mapTo = "Broken02";
   diffuseMap[0] = "DeadBranch02a.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "25";
   useAnisotropic[0] = "1";
};

singleton Material(Win_Sequia02_Seq01Branch_Win)
{
   mapTo = "Seq01Branch-Win";
   diffuseMap[0] = "Pine_Snow.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "Pine_Snow_NRM.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.992157 0.992157 0.992157 1";
   subSurfaceRolloff[0] = "0.5";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
};

singleton Material(Sequia_02_Seq01Branch)
{
   mapTo = "Seq01Branch";
   diffuseMap[0] = "pinetree001.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "0";
   translucentBlendOp = "None";
   normalMap[0] = "pinetree001_NRM.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.827451 0.878431 0.431373 1";
   subSurfaceRolloff[0] = "0.8";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "120";
};

singleton Material(Win_Pine01_ColorEffectR87G224B143_material)
{
   mapTo = "ColorEffectR87G224B143-material";
   diffuseColor[0] = "0.341177 0.878431 0.560784 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(Win_Sequia01_ColorEffectR27G177B88_material)
{
   mapTo = "ColorEffectR27G177B88-material";
   diffuseColor[0] = "0.105882 0.694118 0.345098 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(TallPine01_TallPineNeed)
{
	mapTo = "TallPineNeed";

	diffuseMap[0] = "pinetree001.dds";
	normalMap[0] = "pinetree001_NRM.dds";
   specularMap[0] = "DryPine2_SPEC.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "1";

	doubleSided = 1;
	translucent = false;
	translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.627451 0.768628 0.0117647 1";
   alphaTest = "1";
   alphaRef = "140";
   subSurfaceRolloff[0] = "0.4";
};
