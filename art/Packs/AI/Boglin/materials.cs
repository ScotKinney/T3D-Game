
singleton Material(mat_BoglinArmor)
{
   mapTo = "goblin_war_armor_color";
   diffuseMap[0] = "art/Packs/AI/Boglin/goblin_war_armor_color";
   normalMap[0] = "art/Packs/AI/Boglin/goblin_war_armor_normals.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/AI/Boglin/goblin_war_armor_specular.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_Boglin)
{
   mapTo = "goblin_color";
   diffuseMap[0] = "art/Packs/AI/Boglin/goblin_color";
   normalMap[0] = "art/Packs/AI/Boglin/goblin_normals.dds";
   specularStrength[0] = "0.686275";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/AI/Boglin/goblin_specular.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_BoglinShield)
{
   mapTo = "shield_color";
   diffuseMap[0] = "art/Packs/AI/Boglin/shield_color";
   normalMap[0] = "art/Packs/AI/Boglin/shield_normals.dds";
   specularPower[0] = "1";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/AI/Boglin/shield_specular.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   customImpactSound = "FootStepWood1Sound";
};
