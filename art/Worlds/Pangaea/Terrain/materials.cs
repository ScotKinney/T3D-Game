
//////////Footstep Sounds/////////////////////////////

singleton Material(Ter_Grass)   
{   
   mapTo = "groundCoverDetail3";   
  customFootstepSound = FootStepGrass1Sound;
  
};
 
singleton Material(Ter_RockTop)
{
   mapTo = "rockfromabovebrown";
   customFootstepSound = FootStepSand1Sound;

};

singleton Material(Ter_DarkDirt)
{
   mapTo = "soil_02";
   customFootstepSound = FootStepSand1Sound;

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

// GrayRockNear Terrain


new TerrainMaterial()
{
   internalName = "GrayRockNear";
   diffuseMap = "art/Worlds/Pangaea/Terrain/rock01a";
   detailMap = "art/Worlds/Pangaea/Terrain/rock01";   
   detailSize = "25";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "512";
   normalMap = "art/Worlds/Pangaea/Terrain/rock01_NRM2a";
   detailDistance = "400";
   parallaxScale = "0.05";
   useSideProjection = "0";
   detailStrength = "1";
   macroMap = "art/Worlds/Pangaea/Terrain/rock01";
   macroSize = "256";
   macroDistance = "800";
};


//Grayrockfar Terrain


new TerrainMaterial()
{
   diffuseSize = "256";
   detailSize = "12";
   detailDistance = "400";
   useSideProjection = "0";
   internalName = "SeaweedMain";
   detailStrength = "0.5";
   parallaxScale = "0.02";
   macroSize = "50";
   macroDistance = "500";
   macroStrength = "0.7";
   diffuseMap = "art/Worlds/Pangaea/Terrain/Terra_048A";
   detailMap = "art/Worlds/Pangaea/Terrain/Terra_048A_det";
   normalMap = "art/Worlds/Pangaea/Terrain/Terra_048A_NRM";
};

//SeaweedMain Terrain

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Pangaea/Terrain/Terra_048A";
   normalMap = "art/Worlds/Pangaea/Terrain/Terra_048A_NRM";
   detailMap = "art/Worlds/Pangaea/Terrain/Terra_048A";
   detailSize = "8";
   detailStrength = "1";
   detailDistance = "400";
   parallaxScale = "0.02";
   internalName = "SeaweedMain";
   diffuseSize = "100";
   macroMap = "art/Worlds/Pangaea/Terrain/Terra_048A";
   macroSize = "50";
};




new TerrainMaterial()
{
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
   internalName = "GrayRockFar";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Pangaea/Terrain/soil_02";
   diffuseSize = "256";
   normalMap = "art/Worlds/Pangaea/Terrain/3TD_Talus_01_NRM";
   detailMap = "art/Worlds/Pangaea/Terrain/3TD_Talus_01";
   detailSize = "8";
   detailDistance = "400";
   parallaxScale = "0.05";
   internalName = "SlopeTalus";
   detailStrength = "0.5";
   useSideProjection = "0";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Pangaea/Terrain/3TD_Crevice_01";
   normalMap = "art/Worlds/Pangaea/Terrain/3TD_Crevice_01_NRM";
   detailMap = "art/Worlds/Pangaea/Terrain/3TD_Crevice_01_DET";
   parallaxScale = "0.05";
   internalName = "CliffColor2";
   diffuseSize = "500";
   detailSize = "25";
   detailStrength = "0.7";
   detailDistance = "1000";
   useSideProjection = "0";
};

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Pangaea/Terrain/3TD_Gravel_005";
   normalMap = "art/Worlds/Pangaea/Terrain/3TD_Talus_01_NRM";
   detailMap = "art/Worlds/Pangaea/Terrain/3TD_Gravel_005";
   parallaxScale = "0.02";
   internalName = "TrailMat";
};
