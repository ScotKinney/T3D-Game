
singleton Material(Rock2_mat)
{
	mapTo = "Rock2";

	diffuseMap[0] = "art/Packs/rocks/T3D/Rock2.jpg";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "128";

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   materialTag0 = "Rocks";
   normalMap[0] = "art/Packs/rocks/grayrock_normal1024.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/rocks/tex_volcanic_rock_nrm.dds";
   useAnisotropic[0] = "1";
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
