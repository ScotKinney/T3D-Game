

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
   mapTo = "Pistol_color";
   diffuseMap[0] = "Pistol_dif";
   normalMap[0] = "Pistol_nm";
   pixelSpecular[0] = "1";
   specularMap[0] = "Pistol_spec";
   useAnisotropic[0] = "1";
   materialTag0 = "Guns";
};

new Material(mat_5_56_ammo)
{
   mapTo = "tracer";
   diffuseMap[0] = "tracer";
   emissive = true;
   Glow[0] = true;
   castShadows = "0";
   translucent = "1";
   translucentBlendOp = "Add";
   alphaRef = "0";
   materialTag0 = "Guns";
};



singleton Material(mat_XR75)
{
   mapTo = "XR75";
   diffuseMap[0] = "XR75";
   normalMap[0] = "XR75_nm.dds";
   specularMap[0] = "XR75_spec.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "Guns";
};
