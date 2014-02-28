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
   diffuseMap = "art/Worlds/Akropolis/terrain/clearTerrain001";
   diffuseSize = "300";
   normalMap = "art/Worlds/Akropolis/terrain/gras_01n";
   detailMap = "art/Worlds/Akropolis/terrain/gras_01";
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
   diffuseMap = "art/Worlds/Akropolis/terrain/dirtysand_base";
   diffuseSize = "900";
   normalMap = "art/Worlds/Akropolis/terrain/dirtysand_2_nrm";
   detailMap = "art/Worlds/Akropolis/terrain/dirtysand_detail";
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
   diffuseMap = "art/Worlds/Akropolis/terrain/dirtyandmix_base";
   diffuseSize = "500";
   normalMap = "art/Worlds/Akropolis/terrain/dirtsandmix_nrm";
   detailMap = "art/Worlds/Akropolis/terrain/dirtsandmix_detail";
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
   diffuseMap = "art/Worlds/Akropolis/terrain/cas_cobble2_shadow";
   diffuseSize = "300";
   normalMap = "art/Worlds/Akropolis/terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Worlds/Akropolis/terrain/tex_volcanic_cliffrock_dif";
   detailSize = "10";
   detailStrength = "0.6";
   detailDistance = "1000";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
};

// VolcanicCliffSide Terrain

new TerrainMaterial()
{
   internalName = "SeaweedMain";
   diffuseMap = "art/Worlds/Akropolis/terrain/Seaweed_base";
   normalMap = "art/Worlds/Akropolis/terrain/Seaweed_nrm_displacement";
   detailMap = "art/Worlds/Akropolis/terrain/Seaweed_detail";
   detailSize = "5.5";
   detailDistance = "1000";
   useSideProjection = "0";
   diffuseSize = "500";
   detailStrength = "0.4";
   useAnisotropic[0] = "1";
   useAnisotropic0 = "1";
   parallaxScale = "0.03";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Akropolis/terrain/Seaweed_base";
   normalMap = "art/Worlds/Akropolis/terrain/Seaweed_nrm_displacement";
   detailMap = "art/Worlds/Akropolis/terrain/Seaweed_detail";
   detailSize = "5.5";
   detailStrength = "0.4";
   detailDistance = "1000";
   parallaxScale = "0.03";
   internalName = "Seaweed_base";
};

new TerrainMaterial()
{
   diffuseMap = "Seaweed_base";
   normalMap = "Seaweed_nrm_displacement";
   detailMap = "Seaweed_detail";
   detailSize = "5.5";
   detailStrength = "0.4";
   detailDistance = "1000";
   parallaxScale = "0.03";
   internalName = "Seaweed_base";
};
