////////////////Spartan Terrain//////////////////
//////////////////////////////////////////////////////

singleton Material(Ter_Kard_Overlay_dif)   
{   
   mapTo = "Kard_Overlay_dif";   
   customFootstepSound = FootStepSand1Sound;
};

singleton Material(Ter_Spartan_Path_dif)   
{   
   mapTo = "Spartan_Path_dif";   
   customFootstepSound = FootStepSand1Sound;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};  

singleton Material(Ter_Spartan_Sand_dif)
{
   mapTo = "Spartan_Sand_dif";
   customFootstepSound = FootStepSand1Sound;
   showDust = true;
   effectColor[0] = "0.53 0.52 0.46 1.0";
   effectColor[1] = "0.65 0.64 0.58 1.0";
};

singleton Material(Spartan_rock_dif)
{
   mapTo = "Spartan_rock_dif";
   diffuseMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif.dds";
   specularPower[0] = "128";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Rock";
   showFootprints = "1";
   detailNormalMapStrength[0] = "1";
   specularStrength[0] = "0.8";
   detailScale[0] = "3 3";
   detailMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_det.dds";
   diffuseColor[0] = "0.647059 0.384314 0.196078 0";
   customFootstepSound = "FootStepRock1Sound";
   normalMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nm.dds";
   specularMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_spec.png";
};
////////////////////////////////////////////////////////////

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Spartan_Sand_dif";
   diffuseSize = "128";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Sand_nmp";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Sand_det";
   detailSize = "6";
   detailStrength = "0.4";
   detailDistance = "200";
   parallaxScale = "0.03";
   macroMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_dif";
   macroSize = "2048";
   macroStrength = "0.3";
   macroDistance = "1500";
   useAnisotropic0 = "1";
   internalName = "Sand_Beach";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Spartan_Path_dif";
   diffuseSize = "32";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Path_det";
   detailSize = "7";
   detailStrength = "0.3";
   detailDistance = "200";
   macroMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_dif";
   macroSize = "2048";
   macroStrength = "0.2";
   macroDistance = "2500";
   parallaxScale = "0.02";
   useAnisotropic0 = "1"; 
   internalName = "Path"; 
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Path_nmp";
};


new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Spartan_Grass_dif";
   diffuseSize = "512";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Grass_det";
   detailSize = "2";
   detailStrength = "0.5";
   detailDistance = "1500";
   macroSize = "12";
   macroStrength = "0.4";
   macroDistance = "1500";
   internalName = "Spartan_Grass";
   useAnisotropic0 = "1";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif";
   diffuseSize = "128";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nm";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_det";
   detailSize = "16";
   detailStrength = "0.4";
   detailDistance = "1500";
   macroSize = "2048";
   macroStrength = "0.01";
   parallaxScale = "0.01";
   internalName = "Rock";
   useAnisotropic0 = "1";
};
