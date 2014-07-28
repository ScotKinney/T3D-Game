singleton Material( Ter_RockLow )
{
   mapTo = "MoRock1_dif";
   customFootstepSound = FootStepRock1Sound;
};

singleton Material(Ter_Ground)   
{   
   mapTo = "MoRockGrey_dif";   
   customFootstepSound = FootStepSand1Sound; 
}; 

singleton Material(Spartan_rock_dif)
{
   mapTo = "Spartan_rock_dif";
   diffuseColor[0] = "0.0980392 0.0980392 0.0980392 1";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/CaveWall_dif.dds";
   normalMap[0] = "art/Packs/Tunnels/Morags/CaveWall_nmp.dds";
   pixelSpecular[0] = "0";
   specularMap[0] = "art/Packs/Tunnels/Morags/CaveWall_spec.dds";
   specularPower[0] = "1";
   specularStrength[0] = "0.08";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "MoragsForge";
   castShadows = "0";
   parallaxScale[0] = "0";
   detailNormalMap[0] = "art/Packs/Tunnels/Morags/CaveWall_detNm.dds";
   detailNormalMapStrength[0] = "2";
};

////////////////////////////////////////////////////////

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Morags/MoRock1_dif";
   diffuseSize = "64";
   detailSize = "32";
   detailStrength = "0.1";
   detailDistance = "1000";
   parallaxScale = "0";
   internalName = "Rock_Low";
   materialTag0 = "MoragsForge";
   detailMap = "art/Packs/Terrains/Morags/MoRock1_det";
   normalMap = "art/Packs/Terrains/Morags/MoRock1_nmp";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Morags/MoRockGrey_dif";
   diffuseSize = "128";
   detailMap = "art/Packs/Terrains/Morags/MoRock1_det";
   detailSize = "16";
   detailStrength = "0.1";
   detailDistance = "500";
   parallaxScale = "0.03";
   internalName = "Ground";
   materialTag0 = "MoragsForge";
   normalMap = "art/Packs/Terrains/Morags/MoRock1_nmp";
};
