///////////FootStep Sounds////////////////////////////////////////
//  FootSoftSound   = "FootStepGrass1Sound" =  footstepSoundId = 0;
//  FootHardSound   = "FootStepRock1Sound" =  footstepSoundId = 1;
//  FootMetalSound  = "FootStepMetal1Sound" =  footstepSoundId = 2;
//  FootSnowSound   = "FootStepSnow1Sound" =   footstepSoundId = 3;
///////////////////////////////////////////////////////////////////

singleton Material(Ter_Grass)   
{   
   mapTo = "clearTerrain001";   
   footstepSoundId = 0;
};

singleton Material(Ter_DirtySand)
{
   mapTo = "dirtysand_base";
   footstepSoundId = 0;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

singleton Material(Ter_DirtySandmix)
{
   mapTo = "dirtyandmix_base";
   footstepSoundId = 0;
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
   diffuseMap[0] = "art/Packs/Terrains/Tortuga/TortRock_diffuse.dds";
   diffuseScale[0] = ".1 .1";
   diffuseColor[0] = "0.968628 0.964706 0.964706 1";
   normalMap[0] = "art/Packs/Terrains/Tortuga/grayrock_normal.dds";
   specularMap[0] = "art/Packs/Terrains/Tortuga/grayrock_specular.dds";
   pixelSpecular[0] = "0";
   specular[0] = "0.933333 0.933333 0.933333 1";
   specularPower[0] = "12";
   specularStrength[0] = "1";
   detailNormalMap[0] = "art/Packs/Terrains/Tortuga/grayrock_detailnormal.dds";
   detailNormalMapStrength[0] = "1";
   detailScale[0] = "3 3";
   useAnisotropic[0] = "1";
   materialTag0 = "Rock";
   showFootprints = "1";
   customFootstepSound = "FootStepRock1Sound";
   diffuseScale0 = ".1 .1";
   detailMap[0] = "art/Packs/Terrains/Tortuga/grayrock_detail.dds";
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
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/Packs/Terrains/Tortuga/TortRock_diffuse";
   diffuseSize = "16";
   normalMap = "art/Packs/Terrains/Tortuga/grayrock_normal_specular";
   detailMap = "art/Packs/Terrains/Tortuga/grayrock_detail";
   detailSize = "10";
   detailStrength = "0.5";
   detailDistance = "2000";
   useAnisotropic[0] = "1"; 
   parallaxScale = "0";
   useAnisotropic0 = "1";
   useSideProjection = "1";
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/Packs/Terrains/Tortuga/TortRock_diffuse";
   normalMap = "art/Packs/Terrains/Tortuga/grayrock_normal_specular";
   detailMap = "art/Packs/Terrains/Tortuga/grayrock_detail";
   detailSize = "10";
   detailDistance = "2000";
   useSideProjection = "1";
   diffuseSize = "128";
   detailStrength = "0.5";
   useAnisotropic[0] = "1";
   useAnisotropic0 = "1";
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

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Tortuga/TortRock_diffuse";
   diffuseSize = "128";
   normalMap = "art/Packs/Terrains/Tortuga/grayrock_normal_specular";
   detailMap = "art/Packs/Terrains/Tortuga/grayrock_detail";
   detailSize = "5";
   detailStrength = "0.5";
   detailDistance = "1000";
   parallaxScale = "0";
   internalName = "VolcanicCliffRockTop";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Tortuga/TortRock_diffuse";
   diffuseSize = "128";
   normalMap = "art/Packs/Terrains/Tortuga/grayrock_normal_specular";
   detailMap = "art/Packs/Terrains/Tortuga/grayrock_detail";
   detailStrength = "0.5";
   detailDistance = "1000";
   internalName = "RockNear";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Tortuga/TortRock_diffuse";
   diffuseSize = "128";
   normalMap = "art/Packs/Terrains/Tortuga/grayrock_normal_specular";
   detailMap = "art/Packs/Terrains/Tortuga/grayrock_detail";
   detailSize = "10";
   detailStrength = "0.5";
   detailDistance = "2000";
   useSideProjection = "1";
   internalName = "RockFar";
   useAnisotropic0 = "1";
};
