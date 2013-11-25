//
// 
///////////FootStep Sounds///////////////////////////

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
   footstepSoundId = 3;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};
///////////////////////////////////////////////////////



new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Valhalla/Terrain/GravelCobbleX_SPEC";
   detailMap = "art/Worlds/valhalla/Terrain/tex_volcanic_cliffrock_dif";
   detailSize = "80";
   detailDistance = "2000";
   internalName = "RockFar";
   normalMap = "art/Worlds/valhalla/Terrain/tex_volcanic_cliffrock_nrm";
   parallaxScale = "0";
   diffuseSize = "10";
   detailStrength = "0.6";
   useSideProjection = "1";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   internalName = "RockClose";
   diffuseMap = "art/Worlds/Valhalla/Terrain/GravelCobbleX_SPEC";
   diffuseSize = "10";
   normalMap = "art/Worlds/valhalla/Terrain/tex_volcanic_cliffrock_nrm";
   detailMap = "art/Worlds/valhalla/Terrain/tex_volcanic_cliffrock_dif";
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
   diffuseMap = "art/Worlds/Valhalla/Terrain/clearTerrain001";
   diffuseSize = "200";
   detailMap = "art/Worlds/Valhalla/Terrain/Seaweed_detail";
   detailDistance = "100";
   detailSize = "8";
   useAnisotropic[0] = "1"; 
   normalMap = "art/Worlds/Valhalla/Terrain/Seaweed_nrm_displacement";
   parallaxScale = "0.01";
   enabled = "1";
   isManaged = "1";
   detailBrightness = "1";
   detailStrength = "0.2";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Valhalla/Terrain/snow_detail";
   diffuseSize = "256";
   normalMap = "art/Worlds/Valhalla/Terrain/Seaweed_nrm_displacement";
   detailMap = "art/Worlds/Valhalla/Terrain/Seaweed_detail";
   detailSize = "10";
   detailStrength = "0.1";
   detailDistance = "100";
   parallaxScale = "0.1";
   internalName = "NewSnow";
   enabled = "1";
   isManaged = "1";
   detailBrightness = "1";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Valhalla/Terrain/forestMix_base";
   diffuseSize = "20";
   normalMap = "art/Worlds/Valhalla/Terrain/Seaweed_nrm_displacement";
   detailMap = "art/Worlds/Valhalla/Terrain/Seaweed_detail";
   detailSize = "7";
   detailStrength = "0.2";
   detailDistance = "100";
   parallaxScale = "0";
   internalName = "Path";
   enabled = "1";
   isManaged = "1";
   detailBrightness = "1";
   useAnisotropic0 = "1";
};
