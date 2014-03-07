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

singleton Material(Ter_Snow)   
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

singleton Material(Spartan_rock_dif)
{
   mapTo = "Spartan_rock_dif";
   customFootstepSound = FootStepRock1Sound;
   diffuseMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif.dds";
   detailScale[0] = "4 4";
   normalMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Ter_DarkDirt)
{
   mapTo = "forestmix_base";
   customFootstepSound = FootStepSand1Sound;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};



// Rock_Top Terrain

new TerrainMaterial()
{
   internalName = "Rock_Top";
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif";
   diffuseSize = "400";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nm";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_det";
   detailSize = "10";
   detailStrength = "0.6";
   detailDistance = "4000";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};

// Rock_Side Terrain

new TerrainMaterial()
{
   internalName = "Rock_Side";
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif";
   diffuseSize = "400";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nm";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_det";
   detailSize = "80";
   detailDistance = "4000";
   useSideProjection = "1";
   detailStrength = "0.6";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};


new TerrainMaterial()
{
   internalName = "Grass";
   diffuseMap = "art/Packs/Terrains/SP_Sparta/clearTerrain001";
   diffuseSize = "300";
   normalMap = "art/Packs/Terrains/SP_Sparta/gras_01n";
   detailMap = "art/Packs/Terrains/SP_Sparta/gras_01";
   detailScale = "512";
   detailSize = "4";
   detailStrength = "0.4";
   detailBrightness = "1";
   detailDistance = "800";
   parallaxScale = "0.01";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "DryGround";
   diffuseMap = "art/packs/terrains/SP_Sparta/dryground_base";
   diffuseSize = "400";
   normalMap = "art/packs/terrains/SP_Sparta/dryground_normal";
   detailMap = "art/packs/terrains/SP_Sparta/dryground_detail";
   detailSize = "3";
   detailStrength = "0.5";
   parallaxScale = "0.1";
   detailDistance = "400";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "DirtySand";
   diffuseMap = "art/packs/terrains/SP_Sparta/dirtysand_base";
   diffuseSize = "900";
   normalMap = "art/packs/terrains/SP_Sparta/dirtysand_nrm";
   detailMap = "art/packs/terrains/SP_Sparta/dirtysand_detail";
   detailSize = "4";
   detailStrength = "0.8";
   detailDistance = "100";
   parallaxScale = "0.02";
   detailScale = "512";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "Snow";
   diffuseMap = "art/packs/terrains/SP_Sparta/snow_detail";
   diffuseSize = "200";
   detailMap = "art/packs/terrains/SP_Sparta/grass2_d";
   detailDistance = "1500";
   detailSize = "20";
   useAnisotropic[0] = "1"; 
};

new TerrainMaterial()
{
   internalName = "DarkDirt";
   diffuseMap = "art/packs/terrains/SP_Sparta/forestmix_base";
   diffuseSize = "500";
   normalMap = "art/packs/terrains/SP_Sparta/soil_02n";
   detailMap = "art/packs/terrains/SP_Sparta/soil_02";
   detailSize = "6";
   detailStrength = "0.3";
   detailDistance = "400";
   parallaxScale = "0.01";
   detailScale = "512";
   detailBrightness = "1";
   useAnisotropic0 = "1";
};


