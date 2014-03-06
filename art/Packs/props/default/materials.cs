
singleton Material(mat_scales)
{
   mapTo = "scales";
   diffuseMap[0] = "scales";
   castShadows = "0";
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


singleton Material(mat_plate)
{
   mapTo = "plate";
   diffuseMap[0] = "plate";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_Sack01D)
{
   mapTo = "Sack01_D";
   diffuseMap[0] = "Sack01_D.png";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_innwd02)
{
   mapTo = "inn_wd02";
   diffuseMap[0] = "inn_wood.dds";
   translucent = "0";
   materialTag0 = "DefaultProps";
};

singleton Material(mat_plate_with_bread)
{
   mapTo = "plate_with_bread";
   diffuseMap[0] = "plate_with_bread.dds";
   materialTag0 = "DefaultProps";
};




