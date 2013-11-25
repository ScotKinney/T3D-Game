
////////////////Kardia Terrain//////////////////
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

};



// VolcanicCliffRockTop Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffRockTop";
   diffuseMap = "art/Packs/Worlds/Kardia/Terrain/tex_volcanic_cliffrock_base";
   diffuseSize = "300";
   normalMap = "art/Packs/Worlds/Kardia/Terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Packs/Worlds/Kardia/Terrain/tex_volcanic_cliffrock_dif";
   detailSize = "20";
   detailStrength = "0.6";
   detailDistance = "4000";
   useAnisotropic[0] = "1"; 
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/Packs/Worlds/Kardia/Terrain/tex_volcanic_cliffrock_base";
   normalMap = "art/Packs/Worlds/Kardia/Terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Packs/Worlds/Kardia/Terrain/tex_volcanic_cliffrock_dif";
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
   diffuseMap = "art/Packs/Worlds/Kardia/Terrain/clearTerrain001";
   diffuseSize = "300";
   normalMap = "art/Packs/Worlds/Kardia/Terrain/gras_01n";
   detailMap = "art/Packs/Worlds/Kardia/Terrain/gras_01";
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
   diffuseMap = "art/Packs/Worlds/Kardia/Terrain/dryground_base";
   normalMap = "art/Packs/Worlds/Kardia/Terrain/dryground_normal";
   detailMap = "art/Packs/Worlds/Kardia/Terrain/dryground_detail";
   detailSize = "3";
   detailStrength = "0.5";
   diffuseSize = "400";
   parallaxScale = "0.1";
   detailDistance = "400";
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

new TerrainMaterial()
{
   internalName = "DirtySand";
   diffuseMap = "art/Packs/Worlds/Kardia/Terrain/dirtysand_base";
   diffuseSize = "900";
   normalMap = "art/Packs/Worlds/Kardia/Terrain/dirtysand_nrm";
   detailMap = "art/Packs/Worlds/Kardia/Terrain/dirtysand_detail";
   detailSize = "4";
   detailStrength = "0.8";
   detailDistance = "100";
   parallaxScale = "0.02";
   detailScale = "512";
   useAnisotropic0 = "1";
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

new TerrainMaterial()
{
   internalName = "ValSnow";
   diffuseMap = "art/Packs/Worlds/Kardia/Terrain/snow_detail";
   diffuseSize = "200";
   detailMap = "art/Packs/Worlds/Kardia/Terrain/grass2_d";
   detailDistance = "1500";
   detailSize = "20";
   useAnisotropic[0] = "1"; 
};

new TerrainMaterial()
{
   internalName = "darkDirt";
   diffuseMap = "art/Packs/Worlds/Kardia/Terrain/forestmix_base";
   diffuseSize = "500";
   normalMap = "art/Packs/Worlds/Kardia/Terrain/soil_02n";
   detailMap = "art/Packs/Worlds/Kardia/Terrain/soil_02";
   detailSize = "6";
   detailStrength = "0.3";
   detailDistance = "400";
   parallaxScale = "0.01";
   enabled = "1";
   useAnisotropic0 = "1";
   isManaged = "1";
   detailScale = "512";
   detailBrightness = "1";
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};
