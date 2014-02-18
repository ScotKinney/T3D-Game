
//////////Footstep Sounds/////////////////////////////

singleton Material(Ter_SeaweedMain)   
{   
   mapTo = "Terra_048A";   
  customFootstepSound = FootStepGrass1Sound;
  
};
 
singleton Material(Ter_GrayRockFar)
{
   mapTo = "rock01a";
   customFootstepSound = FootStepSand1Sound;

};

singleton Material(Ter_soil_02)
{
   mapTo = "soil_02";
   customFootstepSound = FootStepSand1Sound;

};

singleton Material(Ter_CliffColor2)
{
   mapTo = "3TD_Crevice_01";
   customFootstepSound = FootStepRock1Sound;

};



//////////////////Textures////////////////////

new TerrainMaterial()
{
   internalName = "RockGroundWithGrass";
   diffuseMap = "art/Worlds/Pangaea/Terrain/soil_02";
   normalMap = "art/Worlds/Pangaea/Terrain/rockygroundwithgrass_normal_displacement";
   detailMap = "art/Worlds/Pangaea/Terrain/rockygroundwithgrass_detail";
   detailScale = "256";
   detailDistance = "800";
   parallaxScale = "0.02";
   detailStrength = "0.5";
   detailSize = "20";
   diffuseSize = "100";
};


new TerrainMaterial()
{
   internalName = "SeaweedMain";
   diffuseSize = "256";
   detailSize = "12";
   detailDistance = "400";
   useSideProjection = "0";
   detailStrength = "0.5";
   parallaxScale = "0.02";
   macroSize = "50";
   macroDistance = "500";
   macroStrength = "0.7";
   diffuseMap = "art/Worlds/Pangaea/Terrain/Terra_048A";
   detailMap = "art/Worlds/Pangaea/Terrain/Terra_048A_det";
   normalMap = "art/Worlds/Pangaea/Terrain/Terra_048A_NRM";
};

new TerrainMaterial()
{
   internalName = "GrayRockFar";   
   diffuseMap = "art/Worlds/Pangaea/Terrain/rock01a";
   diffuseSize = "150";
   normalMap = "art/Worlds/Pangaea/Terrain/rock01_NRM2a";
   detailMap = "art/Worlds/Pangaea/Terrain/rock01";
   detailSize = "75";
   detailStrength = "0.5";
   detailDistance = "4000";
   useSideProjection = "1";
   macroSize = "100";
   macroStrength = "0.8";
   macroDistance = "4000";
   parallaxScale = "0.5";
};

new TerrainMaterial()
{
   internalName = "SlopeTalus";
   diffuseMap = "art/Worlds/Pangaea/Terrain/soil_02";
   diffuseSize = "256";
   normalMap = "art/Worlds/Pangaea/Terrain/3TD_Talus_01_NRM";
   detailMap = "art/Worlds/Pangaea/Terrain/3TD_Talus_01";
   detailSize = "8";
   detailDistance = "400";
   parallaxScale = "0.05";
   detailStrength = "0.5";
   useSideProjection = "0";
};

new TerrainMaterial()
{
   internalName = "CliffColor2";
   diffuseMap = "art/Worlds/Pangaea/Terrain/3TD_Crevice_01";
   normalMap = "art/Worlds/Pangaea/Terrain/3TD_Crevice_01_NRM";
   detailMap = "art/Worlds/Pangaea/Terrain/3TD_Crevice_01_DET";
   parallaxScale = "0.05";
   diffuseSize = "500";
   detailSize = "25";
   detailStrength = "0.7";
   detailDistance = "1000";
   useSideProjection = "0";
};

new TerrainMaterial()
{
   internalName = "TrailMat";
   diffuseMap = "art/Worlds/Pangaea/Terrain/3TD_Gravel_005";
   normalMap = "art/Worlds/Pangaea/Terrain/3TD_Talus_01_NRM";
   detailMap = "art/Worlds/Pangaea/Terrain/3TD_Gravel_005";
   parallaxScale = "0.02";
};
