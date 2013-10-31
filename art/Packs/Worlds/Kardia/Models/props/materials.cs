
singleton Material(basket)
{
   mapTo = "basket";
   diffuseMap[0] = "basket";
   specular[0] = "0.15 0.15 0.15 1";
   specularPower[0] = "100";
   translucent = "0";
   castShadows = "0";
   materialTag0 = "food";
   forestWindEnabled = "1";
};

singleton Material(amphora3)
{
   mapTo = "amphora3";
   diffuseMap[0] = "amphora3";
   specular[0] = "0.15 0.15 0.15 1";
   specularPower[0] = "100";
   translucent = "0";
};

singleton Material(mat_CounterTop)
{
   mapTo = "PMat_CounterTop";
   diffuseMap[0] = "aurgranite27";
   materialTag0 = "Props";
};

singleton Material(mat_CounterFront)
{
   mapTo = "PMat_CounterFront";
   diffuseMap[0] = "aurgranite20";
   materialTag0 = "Props";
};

singleton Material(ladder)
{
   mapTo = "ladder";
   diffuseMap[0] = "vi_int_flooor";
   specular[0] = "0.992157 0.992157 0.992157 1";
   specularPower[0] = "100";
   translucent = "1";
};

singleton Material(mat_RopeCoil)
{
   mapTo = "PMat_RopeCoilObject";
   diffuseMap[0] = "RopeCoil";
   materialTag0 = "Props";
   useAnisotropic[0] = "1";
};

//--- WaterFallWall.dae MATERIALS BEGIN ---
singleton Material(mat_WaterFall2)
{
	mapTo = "PMat_WaterFall2";

	diffuseMap[0] = "transparent.png";
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

singleton Material(mat_fencepostbasic)
{
   mapTo = "fencePostBasic00A";
   diffuseMap[0] = "fencePostBasic00A.png";
};

singleton Material(mat_Target)
{
   mapTo = "TargetFace";
   diffuseMap[0] = "TargetFace";
   translucent = "0";
};

singleton Material(mat_WhiteSquare)
{
   mapTo = "WhiteSquare";
   diffuseMap[0] = "WhiteSquare";
   translucent = "0";
};

singleton Material(mat_scales)
{
   mapTo = "scales";
   diffuseMap[0] = "scales";
   castShadows = "0";
   materialTag0 = "Props";
};

singleton Material(mat_choppingBoard)
{
   mapTo = "chopping_board";
   diffuseMap[0] = "chopping_board";
   castShadows = "0";
   materialTag0 = "Props";
};

singleton Material(mat_BanquetChair)
{
   mapTo = "ornate_banquet_chair";
   diffuseMap[0] = "ornate_banquet_chair";
   castShadows = "0";
   materialTag0 = "food";
   forestWindEnabled = "1";
};

singleton Material(mat_docks)
{
   mapTo = "docks1_diff";
   diffuseMap[0] = "docks1_diff";
   translucent = "0";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(mat_crateSimple001Fragile2Stain)
{
   mapTo = "CratesSimple0001Fragile2Stain";
   diffuseMap[0] = "CratesSimple0001Fragile2Stain";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(mat_cratesSimple001stain4)
{
   mapTo = "CratesSimple0001stain4";
   diffuseMap[0] = "CratesSimple0001stain4";
   translucent = "0";
};

singleton Material(mat_barrell1)
{
   mapTo = "barrell1";
   diffuseMap[0] = "barrell1";
   translucent = "0";
   materialTag0 = "food";
   forestWindEnabled = "1";
};

new Material(mat_Barrel01_D)
{
   diffuseMap[0] = "Barrel01_D";
   mapTo = "Barrel01_D";
   customFootstepSound = "FootStepWood1Sound";
   customImpactSound = "FootStepWood1Sound";
   materialTag0 = "Props";
};

singleton Material(mat_ornateTable)
{
   mapTo = "ornate_table";
   diffuseMap[0] = "ornate_table";
   translucent = "0";
   materialTag0 = "Kardia";
};

singleton Material(mat_plate)
{
   mapTo = "plate";
   diffuseMap[0] = "plate";
   translucent = "0";
   materialTag0 = "Props";
};

singleton Material(mat_dinnerChair)
{
   mapTo = "dinner_chair";
   diffuseMap[0] = "dinner_chair";
   translucent = "0";
   materialTag0 = "Props";
};

singleton Material(interior_props_2_mat)
{
   mapTo = "interior_props_2";
   diffuseMap[0] = "interior_props_2.jpg";
   castShadows = "0";
   showFootprints = "0";
   materialTag0 = "Props";
};

singleton Material(interior_props_1_mat)
{
   mapTo = "interior_props_1";
   diffuseMap[0] = "interior_props_1.jpg";
   translucent = "0";
   materialTag0 = "Props";
};

singleton Material(mat_fenceSection2Post2)
{
   mapTo = "fenceSection2Post2";
   diffuseMap[0] = "fenceSection2Post2";
   normalMap[0] = "fenceSection2Post2_NORM.png";
   materialTag0 = "Props";
};

singleton Material(PMat_FJCave_mat)
{
   mapTo = "PMat_FJCave";
   diffuseMap[0] = "art/Packs/Worlds/Kardia/Models/Rocks/tex_volcanic_rock_base.dds";
   detailMap[0] = "art/Packs/Worlds/Kardia/Models/Rocks/tex_volcanic_rock_dif.dds";
   detailScale[0] = "3 3";
   normalMap[0] = "art/Packs/Worlds/Kardia/Models/Rocks/tex_volcanic_rock_nrm.dds";
   customFootstepSound = "FootStepRock1Sound";
   useAnisotropic[0] = "1";
   materialTag0 = "Rocks";
};


singleton Material(mat_KardToBogScreen)
{
   mapTo = "PMat_KardToBogScreen";
   diffuseMap[0] = "KardToBogScreen";
   specular[0] = "0 0 0 1";
   translucentBlendOp = "None";
   emissive[0] = "1";
};

singleton Material(mat_woodbarrel01C)
{
   mapTo = "woodBarrel01C";
   diffuseMap[0] = "woodBarrel01C.jpg";
   materialTag0 = "props";
};

singleton Material(KardToBogScreen_PMat_KardToBogScreen)
{
   mapTo = "PMat_KardToBogScreen";
   diffuseMap[0] = "KardToBogScreen";
   specular[0] = "0 0 0 1";
   translucentBlendOp = "None";
};

singleton Material(cave_entrance_PMat_FJCave)
{
   mapTo = "PMat_FJCave";
   diffuseMap[0] = "cave1";
   specular[0] = "0 0 0 1";
   translucentBlendOp = "None";
};
