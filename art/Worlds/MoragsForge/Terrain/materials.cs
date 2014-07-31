singleton Material(Ter_Ground)   
{   
   mapTo = "MoRockGrey_dif";   
   customFootstepSound = FootStepSand1Sound; 
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
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
   customFootstepSound = "FootStepCaveSound";
   materialTag0 = "MoragsForge";
   castShadows = "0";
   parallaxScale[0] = "0";
   detailNormalMap[0] = "art/Packs/Tunnels/Morags/CaveWall_detNm.dds";
   detailNormalMapStrength[0] = "2";
};

////////////////////////////////////////////////////////

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Morags/MoRockGrey_dif";
   diffuseSize = "128";
   detailSize = "4";
   detailStrength = "0.1";
   detailDistance = "500";
   parallaxScale = "0.01";
   internalName = "Rock_Low";
   materialTag0 = "MoragsForge";
   normalMap = "art/Packs/Terrains/Morags/MoRock1_nmp";
   detailMap = "art/Packs/Terrains/Morags/MoRock1_det";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Morags/MoRockGrey_dif";
   diffuseSize = "128";
   detailSize = "16";
   detailStrength = "0.2";
   detailDistance = "500";
   parallaxScale = "0.05";
   internalName = "Ground";
   materialTag0 = "MoragsForge";
   normalMap = "art/Packs/Terrains/Morags/MoGround_nmp";
   detailMap = "art/Packs/Terrains/Morags/MoGround_det";
};
