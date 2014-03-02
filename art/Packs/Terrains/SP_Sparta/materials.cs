
////////////////Spartan Terrain//////////////////
//////////////////////////////////////////////////////


singleton Material(Ter_Grass)   
{   
   mapTo = "clearTerrain001";   
   customFootstepSound = FootStepGrass1Sound;
};

singleton Material(Ter_DryGround)   
{   
   mapTo = "dryground_base";   
   customFootstepSound = FootStepSand1Sound;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};  

singleton Material(Ter_ValSnow)   
{   
   mapTo = "snow_detail";   
   customFootstepSound = FootStepSnow1Sound;
};

singleton Material(Ter_DirtySand)
{
   mapTo = "dirtysand_base";
   customFootstepSound = FootStepSand1Sound;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

singleton Material(Ter_RockTop)
{
   mapTo = "tex_volcanic_cliffrock_base";
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(Ter_DarkDirt)
{
   mapTo = "forestmix_base";
   customFootstepSound = FootStepSand1Sound;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};



// VolcanicCliffRockTop Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffRockTop";
   diffuseMap = "tex_volcanic_cliffrock_base";
   diffuseSize = "300";
   normalMap = "tex_volcanic_cliffrock_nrm";
   detailMap = "tex_volcanic_cliffrock_dif";
   detailSize = "20";
   detailStrength = "0.6";
   detailDistance = "4000";
   useAnisotropic[0] = "1"; 
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "tex_volcanic_cliffrock_base";
   normalMap = "tex_volcanic_cliffrock_nrm";
   detailMap = "tex_volcanic_cliffrock_dif";
   detailSize = "80";
   detailDistance = "4000";
   useSideProjection = "1";
   diffuseSize = "300";
   detailStrength = "0.6";
   useAnisotropic[0] = "1"; 
};


new TerrainMaterial()
{
   internalName = "grass";
   diffuseMap = "clearTerrain001";
   diffuseSize = "300";
   normalMap = "gras_01n";
   detailMap = "gras_01";
   detailSize = "4";
   detailStrength = "0.4";
   detailDistance = "1000";
   parallaxScale = "0.01";
   detailScale = "512";
   useAnisotropic[0] = "1"; 
   enabled = "1";
   isManaged = "1";
   useAnisotropic0 = "1";
   detailBrightness = "1";
};

new TerrainMaterial()
{
   internalName = "DryGround";
   diffuseMap = "dryground_base";
   normalMap = "dryground_normal";
   detailMap = "dryground_detail";
   detailSize = "3";
   detailStrength = "0.5";
   diffuseSize = "400";
   parallaxScale = "0.1";
   detailDistance = "400";
};

new TerrainMaterial()
{
   internalName = "DirtySand";
   diffuseMap = "dirtysand_base";
   diffuseSize = "900";
   normalMap = "dirtysand_nrm";
   detailMap = "dirtysand_detail";
   detailSize = "4";
   detailStrength = "0.8";
   detailDistance = "100";
   parallaxScale = "0.02";
   detailScale = "512";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "ValSnow";
   diffuseMap = "snow_detail";
   diffuseSize = "200";
   detailMap = "grass2_d";
   detailDistance = "1500";
   detailSize = "20";
   useAnisotropic[0] = "1"; 
};

new TerrainMaterial()
{
   internalName = "darkDirt";
   diffuseMap = "forestmix_base";
   diffuseSize = "500";
   normalMap = "soil_02n";
   detailMap = "soil_02";
   detailSize = "6";
   detailStrength = "0.3";
   detailDistance = "400";
   parallaxScale = "0.01";
   enabled = "1";
   useAnisotropic0 = "1";
   isManaged = "1";
   detailScale = "512";
   detailBrightness = "1";
};
