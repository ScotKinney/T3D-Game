
//////////Footstep Sounds/////////////////////////////

singleton Material(Ter_Grass)   
{   
   mapTo = "groundCoverDetail3";   
   //customFootstepSound = FootStepGrass1Sound;
   footstepSoundId = 0;
};
 
singleton Material(Ter_RockTop)
{
   mapTo = "rockfromabovebrown";
   //customFootstepSound = FootStepSand1Sound;
   footstepSoundId = 1;
};

singleton Material(Ter_DarkDirt)
{
   mapTo = "soil_02";
   //customFootstepSound = FootStepSand1Sound;
   footstepSoundId = 3;
};

//////////////////Textures////////////////////

new TerrainMaterial()
{
   internalName = "RockGroundWithGrass";
   diffuseMap = "soil_02";
   normalMap = "art/Worlds/Pangaea/Terrain/rockygroundwithgrass_normal_displacement";
   detailMap = "art/Worlds/Pangaea/Terrain/rockygroundwithgrass_detail";
   detailScale = "256";
   detailDistance = "800";
   parallaxScale = "0.01";
   detailStrength = "0.3";
   detailSize = "20";
   diffuseSize = "100";
};

// GrayRockNear Terrain


new TerrainMaterial()
{
   internalName = "GrayRockNear";
   diffuseMap = "art/Worlds/Pangaea/Terrain/rockfromabovebrown";
   detailMap = "art/Worlds/Pangaea/Terrain/grayrock_detail";   
   detailSize = "20";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "100";
   normalMap = "art/Worlds/Pangaea/Terrain/grayrock_normal_specular";
   detailDistance = "1000";
   parallaxScale = "0.03";
   useSideProjection = "0";
   detailStrength = "1";
};


//Grayrockfar Terrain


new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Pangaea/Terrain/rockfromabovebrown";
   diffuseSize = "100";
   normalMap = "art/Worlds/Pangaea/Terrain/grayrock_normal_specular";
   detailMap = "art/Worlds/Pangaea/Terrain/grayrock_detail";
   detailSize = "30";
   detailDistance = "1500";
   useSideProjection = "1";
   internalName = "GrayRockFar";
   detailStrength = "1";
   parallaxScale = "0.05";
};

//SeaweedMain Terrain

new TerrainMaterial()
{
   diffuseMap = "art/Worlds/Pangaea/Terrain/groundCoverDetail3";
   normalMap = "art/Worlds/Pangaea/Terrain/Seaweed_nrm_displacement";
   detailMap = "art/Worlds/Pangaea/Terrain/Seaweed_detail";
   detailSize = "30";
   detailStrength = "0.2";
   detailDistance = "1000";
   parallaxScale = "0.03";
   internalName = "SeaweedMain";
   diffuseSize = "100";
};



