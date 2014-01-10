
singleton Material(_04_peakone_ColorEffectR229G166B215_material)
{
   mapTo = "ColorEffectR229G166B215-material";
   diffuseColor[0] = "0.898039 0.65098 0.843137 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};



//UNDERWATER ROCKS -------------------------------------------------------------



singleton Material(_20_smallrocksix_tex_underwater_rock)
{
	mapTo = "tex_underwater_rock";

	diffuseMap[0] = "tex_rock_underwater_dif.dds";
	normalMap[0] = "tex_rock_underwater_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
   materialTag0 = "Rocks";
};

// VOLCANO ROCKS -----------------------------------------------------------------
singleton Material(_23_volcanicrockone_tex_volcano_rocks)
{
	mapTo = "tex_volcano_rocks";

	diffuseMap[0] = "cas_cobble2_shadow.dds";
	normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   detailMap[0] = "tex_volcanic_rock_dif.dds";
   materialTag0 = "Rocks";
};


singleton Material(_11_groupone_ColorEffectR88G199B225_material)
{
	mapTo = "ColorEffectR88G199B225-material";

	diffuseMap[0] = "";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "0.345098 0.780392 0.882353 1";
	specular[0] = "1 1 1 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

//--- 11_groupone.DAE MATERIALS END ---


singleton Material(_20_smallrocksix_ColorEffectR6G134B113_material)
{
   mapTo = "ColorEffectR6G134B113-material";
   diffuseColor[0] = "0.0235294 0.52549 0.443137 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_21_smallrockseven_ColorEffectR154G154B229_material)
{
   mapTo = "ColorEffectR154G154B229-material";
   diffuseColor[0] = "0.603922 0.603922 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_16_smallrocktwo_ColorEffectR196G88B225_material)
{
   mapTo = "ColorEffectR196G88B225-material";
   diffuseColor[0] = "0.768628 0.345098 0.882353 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_19_smallrockfive_ColorEffectR224G143B87_material)
{
   mapTo = "ColorEffectR224G143B87-material";
   diffuseColor[0] = "0.878431 0.560784 0.341177 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_07_shortcone_ColorEffectR228G184B153_material)
{
   mapTo = "ColorEffectR228G184B153-material";
   diffuseColor[0] = "0.894118 0.721569 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_09_layeredtwo_ColorEffectR134G6B6_material)
{
   mapTo = "ColorEffectR134G6B6-material";
   diffuseColor[0] = "0.52549 0.0235294 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_02_prismone_ColorEffectR26G177B26_material)
{
   mapTo = "ColorEffectR26G177B26-material";
   diffuseColor[0] = "0.101961 0.694118 0.101961 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_14_ggrockthree_ColorEffectR87G224B143_material)
{
   mapTo = "ColorEffectR87G224B143-material";
   diffuseColor[0] = "0.341177 0.878431 0.560784 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(Terrain_SFX_CliffRockTop_Mat)
{
   mapTo = "greyrock";
   diffuseColor[0] = "1 1 1 1";
   specularPower[0] = "8";
   translucentBlendOp = "LerpAlpha";
   diffuseMap[0] = "cas_cobble2_shadow.dds";
   detailMap[0] = "tex_volcanic_rock_dif.dds";
   detailScale[0] = "7 7";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "Rocks";
   customImpactSound = "FootStepRock1Sound";
};

singleton Material(_06_towerone_ColorEffectR148G177B26_material)
{
   mapTo = "ColorEffectR148G177B26-material";
   diffuseColor[0] = "0.580392 0.694118 0.101961 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};

singleton Material(_10_outcroppingone_ColorEffectR28G89B177_material)
{
   mapTo = "ColorEffectR28G89B177-material";
   diffuseColor[0] = "0.109804 0.34902 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Rocks";
};
