//-----------------------------------------------------------------------------
// Torque 3D
// Copyright (C) GarageGames.com, Inc.
//-----------------------------------------------------------------------------


singleton Material(Ter_Grass)   
{   
   mapTo = "clearTerrain001";   
   footstepSoundId = 0;
};

singleton Material(Ter_DirtySand)
{
   mapTo = "dirtysand_base";
   footstepSoundId = 3;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

singleton Material(Ter_DirtySandmix)
{
   mapTo = "dirtyandmix_base";
   footstepSoundId = 3;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

singleton Material(Ter_Rock)
{
   mapTo = "cas_cobble2_shadow";
   footstepSoundId = 1;
};

singleton Material(Ter_Seaweed)   
{   
   mapTo = "Seaweed_base";   
   footstepSoundId = 0;
};

singleton Material(Spartan_rock_dif)
{
   mapTo = "Spartan_rock_dif";
   diffuseMap[0] = "art/packs/terrains/tortuga/cas_cobble2_shadow.dds";
   specularPower[0] = "128";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Rock";
   showFootprints = "1";
   detailNormalMapStrength[0] = "1";
   specularStrength[0] = "0.8";
   detailScale[0] = "3 3";
   detailMap[0] = "art/packs/terrains/tortuga/tex_volcanic_cliffrock_dif";
   diffuseColor[0] = "0.647059 0.384314 0.196078 0";
   customFootstepSound = "FootStepRock1Sound";
   normalMap[0] = "art/packs/terrains/tortuga/tex_volcanic_cliffrock_nrm";
};
//////////////////////////////////////////////////////////
new TerrainMaterial()
{
   internalName = "grass";
   diffuseMap = "art/packs/terrains/tortuga/clearTerrain001";
   diffuseSize = "300";
   normalMap = "art/packs/terrains/tortuga/gras_01n";
   detailMap = "art/packs/terrains/tortuga/gras_01";
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


//DirtySand Terrain

new TerrainMaterial()
{
   internalName = "DirtySand";
   diffuseMap = "art/packs/terrains/tortuga/dirtysand_base";
   diffuseSize = "900";
   normalMap = "art/packs/terrains/tortuga/dirtysand_2_nrm";
   detailMap = "art/packs/terrains/tortuga/dirtysand_detail";
   detailSize = "4";
   detailStrength = "0.8";
   detailDistance = "100";
   parallaxScale = "0.02";
   detailScale = "512";
};


//DirtSandMix Terrain

new TerrainMaterial()
{
   internalName = "DirtSandMix";
   diffuseMap = "art/packs/terrains/tortuga/dirtyandmix_base";
   diffuseSize = "500";
   normalMap = "art/packs/terrains/tortuga/dirtsandmix_nrm";
   detailMap = "art/packs/terrains/tortuga/dirtsandmix_detail";
   detailSize = "3";
   detailStrength = "0.7";
   detailDistance = "100";
   parallaxScale = "0.02";
   detailScale = "512";
};


// VolcanicCliffRockTop Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffRockTop";
   diffuseMap = "art/packs/terrains/tortuga/cas_cobble2_shadow.dds";
   diffuseSize = "300";
   normalMap = "art/packs/terrains/tortuga/tex_volcanic_cliffrock_nrm";
   detailMap = "art/packs/terrains/tortuga/tex_volcanic_cliffrock_dif";
   detailSize = "10";
   detailStrength = "0.6";
   detailDistance = "1000";
   useAnisotropic[0] = "1"; 
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/packs/terrains/tortuga/cas_cobble2_shadow.dds";
   normalMap = "art/packs/terrains/tortuga/tex_volcanic_cliffrock_nrm";
   detailMap = "art/packs/terrains/tortuga/tex_volcanic_cliffrock_dif";
   detailSize = "20";
   detailDistance = "4000";
   useSideProjection = "1";
   diffuseSize = "300";
   detailStrength = "0.6";
   useAnisotropic[0] = "1";
};

new TerrainMaterial()
{
   diffuseMap = "art/packs/terrains/tortuga/Seaweed_base";
   normalMap = "art/packs/terrains/tortuga/Seaweed_nrm_displacement";
   detailMap = "art/packs/terrains/tortuga/Seaweed_detail";
   detailSize = "5.5";
   detailStrength = "0.4";
   detailDistance = "1000";
   parallaxScale = "0.03";
   internalName = "SeaweedMain";
};

new TerrainMaterial()
{
   diffuseMap = "art/packs/terrains/tortuga/Seaweed_base";
   normalMap = "art/packs/terrains/tortuga/Seaweed_nrm_displacement";
   detailMap = "art/packs/terrains/tortuga/Seaweed_detail";
   detailSize = "5.5";
   detailStrength = "0.4";
   detailDistance = "1000";
   parallaxScale = "0.03";
   internalName = "Seaweed_base";
};
