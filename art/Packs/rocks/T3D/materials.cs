singleton Material(Rock2_mat)
{
	mapTo = "Rock2";

	diffuseMap[0] = "Rock2.jpg";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "128";

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   materialTag0 = "Rocks";
   normalMap[0] = "grayrock_normal1024.dds";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   detailNormalMap[0] = "grayrock_normal1024.dds";
   detailNormalMapStrength[0] = "3";
   specularMap[0] = "grayrock_normal1024.dds";
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
