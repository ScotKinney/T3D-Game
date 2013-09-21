//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(volcano_tex_volcano_cave_1)
{
   mapTo = "tex_volcano_cave_1";
   diffuseMap[0] = "cas_cobble2_shadow.dds";
   detailMap[0] = "tex_volcanic_rock_dif.dds";
   detailScale[0] = "7 7";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "Volcano";
};

//--- volcano.DAE MATERIALS BEGIN ---
singleton Material(volcano_tex_volcano_cave_3)
{
	mapTo = "tex_volcano_cave_3";

	diffuseMap[0] = "volcano_cave_3_dif";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   detailMap[0] = "rockydirt_detail";
   detailScale[0] = "12 12";
   customFootstepSound = "FootStepSand1Sound";
   detailNormalMap[0] = "rockydirt_normal";
   materialTag0 = "Volcano";
};

//--- volcano.DAE MATERIALS BEGIN ---
singleton Material(volcano_tex_volcano_cave_2)
{
	mapTo = "tex_volcano_cave_2";

   diffuseMap[0] = "cas_cobble2_shadow.dds";
   detailMap[0] = "tex_volcanic_rock_dif.dds";
   detailScale[0] = "7 7";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "Volcano";
};

//--- volcano.DAE MATERIALS END ---



singleton Material(volcano_lavaflow)
{
	mapTo = "lavaflow_material";

	diffuseMap[0] = "lava_denser_diffuse.png";
	normalMap[0] = "lava_denser_normal_disp.png";
	specularMap[0] = "lava_denser_specular.png";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.00784314 0.996078 0.00784314 1";
	specularPower[0] = "34";

	doubleSided = false;
	translucent = "0";
	translucentBlendOp = "Mul";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "-1 0";
   scrollSpeed[0] = "0.01";
   emissive[0] = "0";
   castShadows = "0";
   parallaxScale[0] = "0.0138889";
   pixelSpecular[0] = "0";
   alphaRef = "80";
   glow[1] = "1";
   forestWindEnabled = "1";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "Volcano";
};
//--- lavaglow.DAE MATERIALS BEGIN ---
singleton Material(lavaglow_ColorEffectR6G135B113_material)
{
	mapTo = "ColorEffectR6G135B113-material";

	diffuseMap[0] = "";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "0.0235294 0.529412 0.443137 1";
	specular[0] = "1 1 1 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   materialTag0 = "Volcano";
};

singleton Material(lavaglow)
{
	mapTo = "lavaglow";

	diffuseMap[0] = "lavaglow_diffuse";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = "1";
	translucentBlendOp = "Add";
   glow[0] = "1";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   emissive[0] = "1";
   castShadows = "0";
   materialTag0 = "Volcano";
};

//--- lavafall.DAE MATERIALS BEGIN ---
singleton Material(lavafall)
{
	mapTo = "lavafall";

	diffuseMap[0] = "lava.png";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "0.588235 0.588235 0.588235 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -0.14";
   scrollSpeed[0] = "1.882";
   emissive[0] = "1";
   glow[0] = "1";
   vertColor[0] = "1";
   materialTag0 = "Volcano";
};

//--- lavafall.DAE MATERIALS END ---
