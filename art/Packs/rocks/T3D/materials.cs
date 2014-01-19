
singleton Material(Rock2_mat)
{
	mapTo = "Rock2";

	diffuseMap[0] = "Rock2.jpg";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(MossyRock02_mat)
{
	mapTo = "MossyRock02";

	diffuseMap[0] = "MossyRock02.png";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(Rock2_mat)
{
   mapTo = "tex_volcanic_rock_base";
   diffuseMap[0] = "Rock2.jpg";
   //normalMap[0] = "tex_volcanic_rock_nrm.dds";
   detailNormalMapStrength[0] = "0";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};
