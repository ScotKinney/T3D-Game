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
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
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
   //showDust = true;
};

singleton Material(Ter_Rock)
{
   mapTo = "cas_cobble2_shadow";
   footstepSoundId = 1;
};

singleton Material(Ter_Seaweed)
{
   mapTo = "Seaweed_base";
   footstepSoundId = 2;
};

//////////////////////////////////////////////////////////
new TerrainMaterial()
{
   internalName = "grass";
   diffuseMap = "art/Worlds/AI_Parade/terrain/clearTerrain001";
   diffuseSize = "300";
   normalMap = "art/Worlds/AI_Parade/terrain/gras_01n";
   detailMap = "art/Worlds/AI_Parade/terrain/gras_01";
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
   diffuseMap = "art/Worlds/AI_Parade/terrain/dirtysand_base";
   diffuseSize = "900";
   normalMap = "art/Worlds/AI_Parade/terrain/dirtysand_2_nrm";
   detailMap = "art/Worlds/AI_Parade/terrain/dirtysand_detail";
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
   diffuseMap = "art/Worlds/AI_Parade/terrain/dirtyandmix_base";
   diffuseSize = "500";
   normalMap = "art/Worlds/AI_Parade/terrain/dirtsandmix_nrm";
   detailMap = "art/Worlds/AI_Parade/terrain/dirtsandmix_detail";
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
   diffuseMap = "art/Worlds/AI_Parade/terrain/cas_cobble2_shadow.dds";
   diffuseSize = "300";
   normalMap = "art/Worlds/AI_Parade/terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Worlds/AI_Parade/terrain/tex_volcanic_cliffrock_dif";
   detailSize = "10";
   detailStrength = "0.6";
   detailDistance = "1000";
   useAnisotropic[0] = "1"; 
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/Worlds/AI_Parade/terrain/cas_cobble2_shadow.dds";
   normalMap = "art/Worlds/AI_Parade/terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Worlds/AI_Parade/terrain/tex_volcanic_cliffrock_dif";
   detailSize = "20";
   detailDistance = "4000";
   useSideProjection = "1";
   diffuseSize = "300";
   detailStrength = "0.6";
   useAnisotropic[0] = "1";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/AI_Parade/terrain/Seaweed_base";
   normalMap = "art/Worlds/AI_Parade/terrain/Seaweed_nrm_displacement";
   detailMap = "art/Worlds/AI_Parade/terrain/Seaweed_detail";
   detailSize = "5.5";
   detailStrength = "0.4";
   detailDistance = "1000";
   parallaxScale = "0.03";
   internalName = "SeaweedMain";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/AI_Parade/terrain/Seaweed_base";
   normalMap = "art/Worlds/AI_Parade/terrain/Seaweed_nrm_displacement";
   detailMap = "art/Worlds/AI_Parade/terrain/Seaweed_detail";
   detailSize = "5.5";
   detailStrength = "0.4";
   detailDistance = "1000";
   parallaxScale = "0.03";
   internalName = "Seaweed_base";
};
