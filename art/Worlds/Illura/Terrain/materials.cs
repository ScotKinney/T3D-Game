
////////////////Illura Terrain//////////////////
//////////////////////////////////////////////////////



singleton Material( Ter_Rock )
{
   mapTo = "aurgranite10";
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(Ter_IlluraGrass)   
{   
   mapTo = "clearTerrain001";   
   customFootstepSound = FootStepGrass1Sound;
};

singleton Material(Ter_DarkDirt)   
{   
   mapTo = "dryground_base";   
   customFootstepSound = FootStepSand1Sound; 
}; 


new TerrainMaterial()
{
   internalName = "VolcanicCliffRockTop";
   diffuseMap = "art/packs/terrains/illura/aurgranite10";
   diffuseSize = "300";
   normalMap = "art/packs/terrains/illura/sediment_01_nrm";
   detailMap = "art/packs/terrains/illura/sediment_01_detail";
   detailSize = "80";
   detailStrength = "0.4";
   detailDistance = "1000";
   useSideProjection = "1";
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/packs/terrains/illura/aurgranite10";
   normalMap = "art/packs/terrains/illura/sediment_01_nrm";
   detailMap = "art/packs/terrains/illura/sediment_01_detail";
   detailSize = "80";
   detailDistance = "1500";
   useSideProjection = "1";
   diffuseSize = "300";
   detailStrength = "0.4";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "darkDirt";
   diffuseMap = "art/packs/terrains/illura/dryground_base";
   diffuseSize = "500";
   normalMap = "art/packs/terrains/illura/soil_02n";
   detailMap = "art/packs/terrains/illura/soil_02";
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

//RockGroundWithGrassTerrain

new TerrainMaterial()
{
   internalName = "RockGroundWithGrass";
   diffuseMap = "art/packs/terrains/illura/clearTerrain001";
   normalMap = "art/packs/terrains/illura/rockygroundwithgrass_normal_displacement";
   detailMap = "art/packs/terrains/illura/rockygroundwithgrass_detail";
   detailScale = "256";
   detailDistance = "1000";
   parallaxScale = "0";
   detailSize = "7";
   detailStrength = "0.5";
};

new TerrainMaterial()
{
   internalName = "IlluraGrass";
   diffuseMap = "art/packs/terrains/illura/clearTerrain001";
   diffuseSize = "10";
   normalMap = "art/packs/terrains/illura/Seaweed_nrm_displacement";
   detailMap = "art/packs/terrains/illura/Seaweed_detail";
   detailSize = "15";
   detailStrength = "0.4";
   detailDistance = "800";
   parallaxScale = "0.03";

};
