//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------


//-------------------------------------------------------------
//Custom Sound and effects for Terrain Materials
//-------------------------------------------------------------

singleton Material(AfrikaGrass)  
{  
   mapTo = "3td_RedDirt_03_Tile";  
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(AfrikaSand)  
{  
   mapTo = "dryground_base";  
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(AfrikaRock)  
{  
   mapTo = "AfriRock_diffuse";  
   customFootstepSound = FootStepGrass1Sound;
};

singleton Material(Spartan_Rock_dif)
{

   mapTo = "Spartan_rock_dif"; 
   diffuseMap[0] = "art/packs/terrains/sudarak/afrirock_diffuse.dds";
   normalMap[0] = "art/packs/terrains/sudarak/grayrock_normal.dds";
   pixelSpecular[0] = "1";
   specular[0] = "0.956863 0.933333 0.913726 1";
   specularPower [0] = 12;
   specularPower[0] = "1";
   detailNormalMap[0] = "art/packs/terrains/sudarak/grayrock_detailnormal.dds";
   detailNormalMapStrength[0] = "0.1";
   materialTag0 = "Rock_Sudarak";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   specularMap[0] = "art/packs/terrains/sudarak/grayrock_specular.dds";
   customFootstepSound = "FootStepRock1Sound";
   useAnisotropic[0] = "1";
};

//-------------------------------------------------------------
//Terrain materials
//-------------------------------------------------------------

new TerrainMaterial()
{
   internalName = "Afrika_Grass";
   diffuseMap = "art/packs/terrains/sudarak/3td_RedDirt_03_Tile";
   diffuseSize = "256";
   normalMap = "art/packs/terrains/sudarak/3td_AfricaGrass_Dry_NRM";
   detailMap = "art/packs/terrains/sudarak/3td_AfricaGrass_Dry_DET";
   detailSize = "10";
   detailStrength = "0.25";
   detailDistance = "1500";
   parallaxScale = "0.02";
};

new TerrainMaterial()
{
   internalName = "Afrika_SideRock";
   diffuseMap = "art/packs/terrains/sudarak/AfriRock_diffuse";
   diffuseSize = "1024";
   normalMap = "art/packs/terrains/sudarak/3td_RockGround_01_NRM";
   detailMap = "art/packs/terrains/sudarak/3td_RockGround_01";
   detailSize = "100";
   detailDistance = "2000";
   parallaxScale = "0.01";
   useSideProjection = "1";
   detailStrength = "0.25";
};

new TerrainMaterial()
{
   internalName = "Afrika_Rock";
   diffuseMap = "art/packs/terrains/sudarak/AfriRock_diffuse";
   diffuseSize = "2048";
   normalMap = "art/packs/terrains/sudarak/grayrock_normal_specular";
   detailMap = "art/packs/terrains/sudarak/grayrock_detail";
   detailSize = "20";
   detailStrength = "0.25";
   detailDistance = "1000";
   parallaxScale = "0.05";
   useSideProjection = "0";
};

new TerrainMaterial()
{
   internalName = "Afrika_Sands";
   diffuseMap = "art/packs/terrains/sudarak/dryground_base";
   diffuseSize = "1024";
   normalMap = "art/packs/terrains/sudarak/dryground_normal";
   detailMap = "art/packs/terrains/sudarak/dryground_detail";
   detailSize = "12";
   detailStrength = "0.3";
   detailDistance = "300";
   parallaxScale = "0.03";
};

new TerrainMaterial()
{
   internalName = "Afrika_RedSand";
   diffuseMap = "art/packs/terrains/sudarak/3td_RedDirt_03_Tile";
   diffuseSize = "1024";
   normalMap = "art/packs/terrains/sudarak/dryground_normal";
   detailMap = "art/packs/terrains/sudarak/dryground_detail";
   detailSize = "8";
   detailStrength = "0.5";
   detailDistance = "300";
   parallaxScale = "0.02";
};
