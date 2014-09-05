////////Viking Terrain///////////////////////// 
///////////FootStep Sounds////////////////////////////////////////
//  FootSoftSound   = "FootStepGrass1Sound" =  footstepSoundId = 0;
//  FootHardSound   = "FootStepRock1Sound" =  footstepSoundId = 1;
//  FootMetalSound  = "FootStepMetal1Sound" =  footstepSoundId = 2;
//  FootSnowSound   = "FootStepSnow1Sound" =   footstepSoundId = 3;
///////////////////////////////////////////////////////////////////

singleton Material(ter_snow_detail)   
{   
   mapTo = "snow_detail";   
   footstepSoundId = 3;
};

singleton Material( Ter_GravelCobbleX_SPEC )
{
   mapTo = "GravelCobbleX_SPEC";
   footstepSoundId = 1;
};

singleton Material( Ter_ClearTerrain001 )
{
   mapTo = "ClearTerrain001";
   footstepSoundId = 3;
};

singleton Material( Ter_ForestMix_Base )
{
   mapTo = "ForestMix_Base";
   footstepSoundId = 0;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

singleton Material(mat_GravelCobbleX_SPEC)//material for sp_rocks
{
   mapTo = "Spartan_rock_dif";
   footstepSoundId = 1;
   diffuseMap = "art/Packs/Terrains/SP_Viking/GravelCobbleX_SPEC";
   normalMap = "art/Packs/Terrains/SP_Viking/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Packs/Terrains/SP_Viking/tex_volcanic_cliffrock_dif";
   detailScale[0] = "3 3";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

///////////////////////////////////////////////////////

new TerrainMaterial()
{
   internalName = "RockFar";
   diffuseMap = "art/Packs/Terrains/SP_Viking/GravelCobbleX_SPEC";
   detailMap = "art/Packs/Terrains/SP_Viking/tex_volcanic_cliffrock_dif";
   detailSize = "80";
   detailDistance = "2000";
   normalMap = "art/Packs/Terrains/SP_Viking/tex_volcanic_cliffrock_nrm";
   parallaxScale = "0";
   diffuseSize = "10";
   detailStrength = "0.6";
   useSideProjection = "1";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "RockClose";
   diffuseMap = "art/Packs/Terrains/SP_Viking/GravelCobbleX_SPEC";
   diffuseSize = "10";
   normalMap = "art/Packs/Terrains/SP_Viking/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Packs/Terrains/SP_Viking/tex_volcanic_cliffrock_dif";
   detailSize = "20";
   detailStrength = "0.6";
   detailDistance = "600";
   useAnisotropic[0] = "1"; 
   useAnisotropic0 = "1";
   useSideProjection = "0";
};

new TerrainMaterial()
{
   internalName = "grass1";
   diffuseMap = "art/Packs/Terrains/SP_Viking/clearTerrain001";
   diffuseSize = "200";
   detailMap = "art/Packs/Terrains/SP_Viking/Seaweed_detail";
   detailDistance = "100";
   detailSize = "8";
   useAnisotropic[0] = "1"; 
   normalMap = "art/Packs/Terrains/SP_Viking/Seaweed_nrm_displacement";
   parallaxScale = "0.01";
   enabled = "1";
   isManaged = "1";
   detailBrightness = "1";
   detailStrength = "0.2";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "NewSnow";
   diffuseMap = "art/Packs/Terrains/SP_Viking/snow_detail";
   diffuseSize = "256";
   normalMap = "art/Packs/Terrains/SP_Viking/Seaweed_nrm_displacement";
   detailMap = "art/Packs/Terrains/SP_Viking/Seaweed_detail";
   detailSize = "10";
   detailStrength = "0.1";
   detailDistance = "100";
   parallaxScale = "0.01";
   enabled = "1";
   isManaged = "1";
   detailBrightness = "1";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "Path";
   diffuseMap = "art/Packs/Terrains/SP_Viking/forestMix_base";
   diffuseSize = "20";
   normalMap = "art/Packs/Terrains/SP_Viking/Seaweed_nrm_displacement";
   detailMap = "art/Packs/Terrains/SP_Viking/Seaweed_detail";
   detailSize = "7";
   detailStrength = "0.2";
   detailDistance = "100";
   parallaxScale = "0";
   enabled = "1";
   isManaged = "1";
   detailBrightness = "1";
   useAnisotropic0 = "1";
};
