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
   diffuseMap[0] = "art/Packs/Terrains/Kardia/Spartan_Rock_dif.dds";
   specularPower[0] = "128";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Rock";
   showFootprints = "1";
   detailNormalMapStrength[0] = "1";
   specularStrength[0] = "0.8";
   detailScale[0] = "3 3";
   detailMap[0] = "art/Packs/Terrains/Kardia/Spartan_Rock_det.dds";
   diffuseColor[0] = "0.647059 0.384314 0.196078 0";
   customFootstepSound = "FootStepRock1Sound";
   normalMap[0] = "art/Packs/Terrains/Kardia/Spartan_Rock_nm.dds";
   specularMap[0] = "art/Packs/Terrains/Kardia/Spartan_Rock_spec.png";
};
////////////////////////////////////////////////////////////

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Kardia/Kard_Overlay_dif";
   diffuseSize = "2048";
   normalMap = "art/Packs/Terrains/Kardia/Spartan_Grass_nmp";
   detailMap = "art/Packs/Terrains/Kardia/Kard_Overlay_det";
   detailSize = "6";
   detailStrength = "0.1";
   detailDistance = "200";
   parallaxScale = "0.03";
   useAnisotropic0 = "1";
   internalName = "TextureMap";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Kardia/Spartan_Rock_dif";
   diffuseSize = "128";
   detailMap = "art/Packs/Terrains/Kardia/Spartan_Rock_det";
   detailStrength = "0.4";
   detailDistance = "1500";
   parallaxScale = "0.01";
   detailSize = "16";
   macroMap = "art/Packs/Terrains/Kardia/Kard_Overlay_dif";
   macroStrength = "0.01";
   macroSize = "2048";
   macroDistance = "500";
   useAnisotropic0 = "1";
   internalName = "Rock_Low";
   normalMap = "art/Packs/Terrains/Kardia/Spartan_Rock_nm";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Kardia/Kard_Overlay_dif";
   diffuseSize = "2048";
   detailDistance = "1500";
   detailSize = "4";
   detailStrength = "0.5";
   parallaxScale = "0";
   macroSize = "12";
   macroStrength = "0.4";
   macroDistance = "1500";
   useAnisotropic0 = "1";
   internalName = "Grass";
   detailMap = "art/Packs/Terrains/Kardia/Spartan_Grass_det";
   macroMap = "art/Packs/Terrains/Kardia/Spartan_Grass_dif";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Kardia/Spartan_Sand_dif";
   diffuseSize = "128";
   normalMap = "art/Packs/Terrains/Kardia/Spartan_Sand_nmp";
   detailMap = "art/Packs/Terrains/Kardia/Spartan_Sand_det";
   detailSize = "6";
   detailStrength = "0.4";
   detailDistance = "200";
   parallaxScale = "0.03";
   macroMap = "art/Packs/Terrains/Kardia/Kard_Overlay_dif";
   macroSize = "2048";
   macroStrength = "0.3";
   macroDistance = "1500";
   useAnisotropic0 = "1";
   internalName = "Sand_Beach";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Kardia/Spartan_Path_dif";
   diffuseSize = "32";
   detailMap = "art/Packs/Terrains/Kardia/Spartan_Path_det";
   detailSize = "7";
   detailStrength = "0.3";
   detailDistance = "200";
   macroMap = "art/Packs/Terrains/Kardia/Kard_Overlay_dif";
   macroSize = "2048";
   macroStrength = "0.2";
   macroDistance = "2500";
   parallaxScale = "0.02";
   useAnisotropic0 = "1"; 
   internalName = "Path"; 
   normalMap = "art/Packs/Terrains/Kardia/Spartan_Path_nmp";
};

new TerrainMaterial()
{
   diffuseMap = "art/Packs/Terrains/Kardia/Kard_Overlay_dif";
   diffuseSize = "2048";
   detailMap = "art/Packs/Terrains/Kardia/Spartan_Rock_det";
   detailSize = "16";
   detailStrength = "0.4";
   detailDistance = "500";
   parallaxScale = "0.01";
   useAnisotropic0 = "1";
   internalName = "Rock_High"; 
   macroMap = "art/Packs/Terrains/Kardia/Spartan_Rock_dif";
   macroStrength = "0.15";
   macroSize = "128";
   macroDistance = "2500";
   normalMap = "art/Packs/Terrains/Kardia/Spartan_Rock_nm";
};
