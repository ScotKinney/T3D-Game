

//--- shot.dae MATERIALS BEGIN ---
singleton Material(shot_PMat_shot)
{
	mapTo = "PMat_shot";

	diffuseMap[0] = "black";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.1625 0.1625 0.1625 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
};

//--- shot.dae MATERIALS END ---



singleton Material(mat_Flintlock)
{
   mapTo = "PIRATE_P";
   diffuseMap[0] = "art/inv/weapons/flintloc/PIRATE_P";
   materialTag0 = "Weapons";
};
