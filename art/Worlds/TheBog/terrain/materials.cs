
////////////////The Bog Terrain//////////////////
//////////////////////////////////////////////////////


singleton Material(Ter_Grass)   
{   
   mapTo = "clearTerrain001";   
   customFootstepSound = FootStepGrass1Sound;
};

singleton Material(Ter_Path)   
{   
   mapTo = "soil_02";   
   customFootstepSound = FootStepSand1Sound;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
}; 

singleton Material(ter_SwampEdges)   
{   
   mapTo = "ground_02";   
   customFootstepSound = FootStepGrass1Sound;
};


singleton Material( Terrain_SFX_RockTop_Mat )
{
   mapTo = "tex_volcanic_cliffrock_base";
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(Bog_rock_dif)
{
   mapTo = "Bog_rock_dif";
   diffuseMap[0] = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_base";
   specularPower[0] = "128";
   pixelSpecular[0] = "0";
   useAnisotropic[0] = "1";
   materialTag0 = "Rock";
   showFootprints = "1";
   detailNormalMapStrength[0] = "1";
   specularStrength[0] = "0.8";
   detailScale[0] = "3 3";
   detailMap[0] = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_dif";
   diffuseColor[0] = "0.647059 0.384314 0.196078 0";
   customFootstepSound = "FootStepRock1Sound";
   normalMap[0] = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_nrm";
   castShadows = "0";
};


// VolcanicCliffRockTop Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffRockTop";
   diffuseMap = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_base";
   diffuseSize = "300";
   normalMap = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_dif";
   detailSize = "20";
   detailStrength = "0.6";
   detailDistance = "1200";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_base";
   normalMap = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Worlds/TheBog/Terrain/tex_volcanic_cliffrock_dif";
   detailSize = "80";
   detailDistance = "4000";
   useSideProjection = "1";
   diffuseSize = "300";
   detailStrength = "0.6";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "grass";
   diffuseMap = "art/Worlds/TheBog/Terrain/clearTerrain001";
   detailMap = "art/Worlds/TheBog/Terrain/gras_01";
   detailSize = "6";
   detailDistance = "3000";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "400";
   normalMap = "art/Worlds/TheBog/Terrain/gras_01n";
   detailStrength = "0.5";
   useSideProjection = "0";
   parallaxScale = "0";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "Path";
   diffuseMap = "art/Worlds/TheBog/Terrain/soil_02";
   normalMap = "art/Worlds/TheBog/Terrain/rockydirt_normal";
   detailMap = "art/Worlds/TheBog/Terrain/rockydirt_detail";
   detailSize = "5";
   detailDistance = "1000";
   diffuseSize = "60";
   detailStrength = "1.4";
   parallaxScale = "0.1";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "SwampEdges";
   diffuseMap = "art/Worlds/TheBog/Terrain/ground_02";
   detailMap = "art/Worlds/TheBog/Terrain/grass2_d";
   detailDistance = "1500";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};






