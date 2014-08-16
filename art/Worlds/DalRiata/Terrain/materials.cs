
////////////////Mythriel Terrain//////////////////
//////////////////////////////////////////////////////

//////////Footstep Sounds/////////////////////////////

singleton Material(Ter_Grass)   
{   
   mapTo = "groundCoverDetail3";   
  customFootstepSound = FootStepGrass1Sound;
  
};
 
singleton Material(Ter_RockTop)
{
   mapTo = "rockfromabovebrown";
   customFootstepSound = FootStepGrass1Sound;

};

singleton Material(Spartan_rock_dif)
{
   mapTo = "Spartan_rock_dif";
   diffuseMap = "art/packs/terrains/Dalriata/rockfromabovebrown";
   specularPower[0] = "128";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Rock";
   showFootprints = "1";
   detailNormalMapStrength[0] = "1";
   specularStrength[0] = "0.8";
   detailScale[0] = "3 3";
   detailMap = "art/packs/terrains/Dalriata/grayrock_detail"; 
   diffuseColor[0] = "0.647059 0.384314 0.196078 0";
   customFootstepSound = "FootStepRock1Sound";
   normalMap = "art/packs/terrains/Dalriata/grayrock_normal_specular";
};
//////////////////Textures////////////////////

/////////////////////GrayrockNear

new TerrainMaterial()
{
   internalName = "GrayRockNear";
   diffuseMap = "art/packs/terrains/Dalriata/rockfromabovebrown";
   detailMap = "art/packs/terrains/Dalriata/grayrock_detail";   
   detailSize = "10";
   isManaged = "1";
   detailBrightness = "1";
   Enabled = "1";
   diffuseSize = "100";
   normalMap = "art/packs/terrains/Dalriata/grayrock_normal_specular";
   detailDistance = "1000";
   parallaxScale = "0.03";
   useSideProjection = "0";
   detailStrength = "1";
};

/////////////////////Grayrockfar Terrain

new TerrainMaterial()
{
   diffuseMap = "art/packs/terrains/Dalriata/rockfromabovebrown";
   diffuseSize = "64";
   normalMap = "art/packs/terrains/Dalriata/grayrock_normal_specular";
   detailMap = "art/packs/terrains/Dalriata/grayrock_detail";
   detailSize = "30";
   detailDistance = "1500";
   useSideProjection = "1";
   internalName = "GrayRockFar";
   detailStrength = "0.5";
   parallaxScale = "0.05";
};

//////////////////////Grass

new TerrainMaterial()
{
   diffuseMap = "art/packs/terrains/Dalriata/groundCoverDetail3";
   diffuseSize = "100";
   normalMap = "art/packs/terrains/Dalriata/Seaweed_nrm_displacement";
   detailMap = "art/packs/terrains/Dalriata/rockygroundwithgrass_detail";
   detailSize = "8";
   detailStrength = "0.1";
   detailDistance = "1000";
   parallaxScale = "0.01";
   internalName = "Grass";
};

/////////////////////Path

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/DalRiata/rockfromabovebrown";
   diffuseSize = "20";
   normalMap = "art/packs/terrains/Dalriata/rockygroundwithgrass_normal_displacement";
   detailMap = "art/packs/terrains/Dalriata/rockygroundwithgrass_detail";
   detailSize = "7";
   detailStrength = "0.3";
   detailDistance = "800";
   parallaxScale = "0";
   internalName = "Path";
   detailScale = "256";
};
