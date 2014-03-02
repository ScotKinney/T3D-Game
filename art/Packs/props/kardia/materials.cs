singleton Material(amphora3)
{
   mapTo = "amphora3";
   diffuseMap[0] = "amphora3.dds";
   specular[0] = "0.992157 0.992157 0.992157 1";
   specularPower[0] = "104";
   translucent = "0";
   specularStrength[0] = "5";
   pixelSpecular[0] = "1";
   materialTag0 = "Kardia";
   useAnisotropic[0] = "1";
};


singleton Material(mat_docks)
{
   mapTo = "docks1_diff";
   diffuseMap[0] = "docks1_diff";
   translucent = "0";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(mat_CratesSimple0001Fragile2Stain)
{
   mapTo = "CratesSimple0001Fragile2Stain";
   diffuseMap[0] = "CratesSimple0001Fragile2Stain";
   normalMap[0] = "CratesSimple0001Fragile2Stain_NORM.png";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "GoldMine";
};

//--- WaterFallWall.dae MATERIALS BEGIN ---
singleton Material(mat_WaterFall2)
{
	mapTo = "PMat_WaterFall2";

	diffuseMap[0] = "core/art/transparent.png";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0 0 0 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = 1;
	translucentBlendOp = "LerpAlpha";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "1 0";
   scrollSpeed[0] = "0.353";
   materialTag0 = "Props";
};

singleton Material(mat_WaterFall1)
{
	mapTo = "PMat_WaterFall1";

	diffuseMap[0] = "scrollingwater.dds";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "0.505882 0.537255 0.545098 1";
	specular[0] = "0 0 0 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = 1;
	translucentBlendOp = "LerpAlpha";
   showFootprints = "0";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -1";
   scrollSpeed[0] = "0.4";
   glow[0] = "1";
   emissive[0] = "1";
   materialTag0 = "Props";
   detailNormalMapStrength[0] = "10";
};

singleton Material(mat_KardToBogScreen)
{
   mapTo = "PMat_KardToBogScreen";
   diffuseMap[0] = "KardToBogScreen";
   specular[0] = "0 0 0 1";
   translucentBlendOp = "None";
   emissive[0] = "1";
};




