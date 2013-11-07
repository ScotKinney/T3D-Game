
new Material(mat_Barrel01_D)
{
   diffuseMap[0] = "Barrel01_D";
   mapTo = "Barrel01_D";
   customFootstepSound = "FootStepWood1Sound";
   customImpactSound = "FootStepWood1Sound";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_woodbarrel01C)
{
   mapTo = "woodBarrel01C";
   diffuseMap[0] = "woodBarrel01C.jpg";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_cratesSimple001stain4)
{
   mapTo = "CratesSimple0001stain4";
   diffuseMap[0] = "CratesSimple0001stain4";
   normalMap[0] = "CratesSimple0001stain4_NORM";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(interior_props_1_mat)
{
   mapTo = "interior_props_1";
   diffuseMap[0] = "interior_props_1.jpg";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(interior_props_2_mat)
{
   mapTo = "interior_props_2";
   diffuseMap[0] = "interior_props_2.jpg";
   castShadows = "0";
   showFootprints = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_cart2)
{
   mapTo = "cart1";
   diffuseMap[0] = "cart2";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_Cart3)
{
   mapTo = "cart3";
   diffuseMap[0] = "cart3";
   translucent = "0";
   useAnisotropic[0] = "1";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_ale_jug)
{
   mapTo = "ale_jug";
   diffuseMap[0] = "ale_jug";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_scales)
{
   mapTo = "scales";
   diffuseMap[0] = "scales";
   castShadows = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_bowl)
{
   mapTo = "bowl";
   diffuseMap[0] = "bowl";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(basket)
{
   mapTo = "basket";
   diffuseMap[0] = "basket";
   specular[0] = "0.15 0.15 0.15 1";
   specularPower[0] = "100";
   translucent = "0";
   castShadows = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_grainbags)
{
   mapTo = "grainbags";
   diffuseMap[0] = "grainbags";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

//--- torch.DAE MATERIALS BEGIN ---
singleton Material(torch_torch)
{
	mapTo = "torch";

	diffuseMap[0] = "tex_torch_dif";
	normalMap[0] = "tex_torch_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "65";
   castShadows = "0";
   materialTag0 = "DefaultProps";
};
//--- torch.DAE MATERIALS END ---

singleton Material(mat_fencepostbasic)
{
   mapTo = "fencePostBasic00A";
   diffuseMap[0] = "fencePostBasic00A.png";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_firepit_diff)
{
   diffuseMap[0] = "firepit_diff";
   mapTo = "firepit_diff";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_ornateTable)
{
   mapTo = "ornate_table";
   diffuseMap[0] = "ornate_table";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_BanquetChair)
{
   mapTo = "ornate_banquet_chair";
   diffuseMap[0] = "ornate_banquet_chair";
   castShadows = "0";
   forestWindEnabled = "1";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_plate)
{
   mapTo = "plate";
   diffuseMap[0] = "plate";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_bench)
{
   mapTo = "bench";
   diffuseMap[0] = "bench";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_Ballista)
{
   mapTo = "ballista";
   diffuseMap[0] = "ballista.png";
	normalMap[0] = "ballista_normals.png";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_Sack01D)
{
   mapTo = "Sack01_D";
   diffuseMap[0] = "Sack01_D.png";
   translucent = "0";
};

singleton Material(mat_innwd02)
{
   mapTo = "inn_wd02";
   diffuseMap[0] = "inn_wood.dds";
   translucent = "0";
   materialTag0 = "IndoorProps";
};

