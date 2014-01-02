
singleton Material(mat_GA_Body)
{
   mapTo = "GA_body_dif";
   diffuseMap[0] = "art/Packs/AI/Gnomes/Archer/GA_body_dif";
   normalMap[0] = "art/Packs/AI/Gnomes/Archer/GA_body_nm.dds";
   specularPower[0] = "2";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/AI/Gnomes/Archer/GA_body_spec.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_GA_Armor)
{
   mapTo = "GA_Armor_dif";
   diffuseMap[0] = "art/Packs/AI/Gnomes/Archer/GA_Armor_dif";
   normalMap[0] = "art/Packs/AI/Gnomes/Archer/GA_Armor_nm.dds";
   specularPower[0] = "2";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/AI/Gnomes/Archer/GA_Armor_Spec.dds";
   useAnisotropic[0] = "1";
};

singleton Material(GA_Crossbow_dif_mat)
{
   mapTo = "GA_Crossbow_dif";
   diffuseColor[0] = "0.992157 0.992157 0.992157 1";
   diffuseMap[0] = "art/Packs/AI/Gnomes/Archer/GA_Crossbow_color_B.dds";
   detailScale[0] = "1 1";
   normalMap[0] = "art/Packs/AI/Gnomes/Archer/GA_Crossbow_nm.dds";
   detailNormalMapStrength[0] = "10";
   specularPower[0] = "59";
   specularStrength[0] = "1.56863";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/AI/Gnomes/Archer/GA_Crossbow_spec.dds";
};