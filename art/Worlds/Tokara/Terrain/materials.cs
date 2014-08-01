
//////////Footstep Sounds/////////////////////////////

singleton Material(Ter_Grass)   
{   
   mapTo = "groundCoverDetail3";   
  customFootstepSound = FootStepGrass1Sound; 
};
 
singleton Material(Ter_Rock)
{
   mapTo = "Terra_046";
   customFootstepSound = FootStepRock1Sound;
};

singleton Material(Ter_Path)
{
   mapTo = "forestMix_base";
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(Ter_Sand)
{
   mapTo = "dirtysand_base";
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(Spartan_rock_dif)
{
   mapTo = "Spartan_rock_dif";
   diffuseMap[0] = "art/packs/terrains/tokara/BrownRock_diffuse.dds";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   normalMap[0] = "art/packs/terrains/tokara/grayrock_normal.dds";
   specularMap[0] = "art/packs/terrains/tokara/grayrock_specular.dds";
   detailNormalMap[0] = "art/packs/terrains/tokara/grayrock_detailnormal.dds";
   detailNormalMapStrength[0] = "0.1";
   pixelSpecular[0] = "0";
   specularStrength[0] = "0.0980392";
   specular[0] = "1 1 1 0";
   specularPower[0] = "49";
   useAnisotropic[0] = "1";
   materialTag0 = "Rock";
   showFootprints = "1";
   customFootstepSound = "FootStepRock1Sound";
};


//////////////////Textures////////////////////


//Grass

new TerrainMaterial()
{
   diffuseMap = "art/packs/terrains/tokara/groundCoverDetail3";
   normalMap = "art/packs/terrains/tokara/Seaweed_nrm_displacement";
   detailMap = "art/packs/terrains/tokara/Seaweed_detail";
   detailSize = "10";
   detailStrength = "0.2";
   detailDistance = "800";
   parallaxScale = "0.03";
   internalName = "SeaweedMain";
   diffuseSize = "100";
   useAnisotropic[0] = "1";
};

///Sand

new TerrainMaterial()
{
   internalName = "DirtySand";
   diffuseMap = "art/packs/terrains/tokara/dirtysand_base";
   diffuseSize = "900";
   normalMap = "art/packs/terrains/tokara/dirtysand_nrm";
   detailMap = "art/packs/terrains/tokara/dirtysand_detail";
   detailSize = "4";
   detailStrength = "0.8";
   detailDistance = "100";
   parallaxScale = "0.02";
   detailScale = "512";
   useAnisotropic[0] = "1";
};

///Rock Close

new TerrainMaterial()
{
   internalName = "VolcanicCliffRockTop";
   diffuseMap = "art/packs/terrains/tokara/Terra_046";
   diffuseSize = "400";
   normalMap = "art/packs/terrains/tokara/tex_volcanic_cliffrock_nrm";
   detailMap = "art/packs/terrains/tokara/tex_volcanic_cliffrock_dif";
   detailSize = "20";
   detailStrength = "0.7";
   detailDistance = "4000";
   useAnisotropic[0] = "1"; 
};

///Rock Far

new TerrainMaterial()
{
   internalName = "VolcanicCliffSide";
   diffuseMap = "art/packs/terrains/tokara/Terra_046";
   normalMap = "art/packs/terrains/tokara/tex_volcanic_cliffrock_nrm";
   detailMap = "art/packs/terrains/tokara/tex_volcanic_cliffrock_dif";
   detailSize = "80";
   detailDistance = "2000";
   useSideProjection = "1";
   diffuseSize = "400";
   detailStrength = "0.7";
   useAnisotropic[0] = "1"; 
};

///Path

new TerrainMaterial()
{
   diffuseMap = "art/packs/terrains/tokara/forestMix_base";
   diffuseSize = "20";
   normalMap = "art/packs/terrains/tokara/Seaweed_nrm_displacement";
   detailMap = "art/packs/terrains/tokara/Seaweed_detail";
   detailSize = "12";
   detailStrength = "0.2";
   detailDistance = "100";
   parallaxScale = "0";
   internalName = "TokPath";
   useAnisotropic[0] = "1";
};

