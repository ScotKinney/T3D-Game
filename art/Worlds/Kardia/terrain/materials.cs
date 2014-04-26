////////////////Spartan Terrain//////////////////
//////////////////////////////////////////////////////


singleton Material(Ter_Kard_Overlay_dif)   
{   
   mapTo = "Kard_Overlay_dif";   
   customFootstepSound = FootStepGrass1Sound;
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

singleton Material(Spartan_rock_dif_mat)
{
   mapTo = "Spartan_rock_dif";
   diffuseMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif";
   normalMap[0] = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nmp";
   specularPower[0] = "128";
   pixelSpecular[0] = "0";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "Rock";
};
////////////////////////////////////////////////////////////

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_dif";
   diffuseSize = "2048";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Grass_nmp";
   detailMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_det";
   detailSize = "6";
   detailStrength = "0.1";
   detailDistance = "200";
   parallaxScale = "0.03";
   useAnisotropic0 = "1";
   internalName = "TextureMap";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif";
   diffuseSize = "128";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nmp";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_det";
   detailStrength = "0.3";
   detailDistance = "1200";
   parallaxScale = "0.01";
   detailSize = "16";
   macroMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_dif";
   macroStrength = "0.1";
   macroSize = "2048";
   macroDistance = "500";
   useAnisotropic0 = "1";
   internalName = "Rock_Low";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_dif";
   diffuseSize = "2048";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Grass_nmp";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Grass_det";
   detailDistance = "100";
   detailSize = "4";
   detailStrength = "0.4";
   parallaxScale = "0.01";
   macroMap = "art/Packs/Terrains/SP_Sparta/Spartan_Grass_dif";
   macroSize = "12";
   macroStrength = "0.5";
   macroDistance = "1500";
   useAnisotropic0 = "1";
   internalName = "Grass";
};

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
   diffuseSize = "12";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Path_nmp";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Path_det";
   detailSize = "5";
   detailStrength = "0.5";
   detailDistance = "100";
   macroMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_dif";
   macroSize = "2048";
   macroStrength = "0.2";
   macroDistance = "2500";
   parallaxScale = "0.03";
   useAnisotropic0 = "1"; 
   internalName = "Path"; 
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/SP_Sparta/Kard_Overlay_dif";
   diffuseSize = "2048";
   normalMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_nmp";
   detailMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_det";
   detailSize = "16";
   detailStrength = "0.4";
   detailDistance = "200";
   parallaxScale = "0.01";
   useAnisotropic0 = "1";
   internalName = "Rock_High"; 
   macroMap = "art/Packs/Terrains/SP_Sparta/Spartan_Rock_dif";
   macroStrength = "0.15";
   macroSize = "128";
   macroDistance = "2500";
};
