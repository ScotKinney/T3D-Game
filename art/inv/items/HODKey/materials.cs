////////////////////////////////////////////
///////////////HOD Key
///////////////////////////////////////////////////////

//--- HoDKey.dae MATERIALS BEGIN ---
singleton Material(mat_KeyObject2)
{
	mapTo = "PMat_KeyObject2";

	diffuseMap[0] = "art/inv/items/HODKey/HoDKey.png";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0 0 0 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = 1;
	translucentBlendOp = "LerpAlpha";
};

singleton Material(mat_KeyObject1)
{
	mapTo = "PMat_KeyObject1";

	diffuseMap[0] = "art/inv/items/HODKey/HoDKey.png";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0 0 0 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = 1;
	translucentBlendOp = "LerpAlpha";
   castShadows = "0";
};

//--- HoDKey.dae MATERIALS END ---
