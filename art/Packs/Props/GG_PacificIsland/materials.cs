
singleton Material(mat_GGvolcano_cave1)
{
   mapTo = "tex_volcano_cave_1";
   diffuseMap[0] = "art/Packs/Terrains/Tortuga/TortRock_diffuse.dds";
   detailMap[0] = "art/Packs/Terrains/Tortuga/grayrock_detail.dds";
   detailScale[0] = "3 3";
   normalMap[0] = "art/Packs/Terrains/Tortuga/grayrock_normal.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "GG_PacificIsland";
   detailNormalMap[0] = "art/Packs/Terrains/Tortuga/grayrock_detailnormal.dds";
   specularPower[0] = "12";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/Terrains/Tortuga/grayrock_specular.dds";
};

singleton Material(mat_GGvolcano_cave3)
{
   mapTo = "tex_volcano_cave_3";
   diffuseMap[0] = "volcano_cave_3_dif";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = 10;
   detailMap[0] = "rockydirt_detail";
   detailScale[0] = "12 12";
   customFootstepSound = "FootStepSand1Sound";
   detailNormalMap[0] = "rockydirt_normal";
   useAnisotropic[0] = "1";
   materialTag0 = "GG_PacificIsland";
};

singleton Material(mat_GGvolcano_cave2)
{
   mapTo = "tex_volcano_cave_2";
   diffuseMap[0] = "art/Packs/Terrains/Tortuga/TortRock_diffuse.dds";
   detailMap[0] = "art/Packs/Terrains/Tortuga/grayrock_detail.dds";
   detailScale[0] = "3 3";
   normalMap[0] = "art/Packs/Terrains/Tortuga/grayrock_normal.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "GG_PacificIsland";
   detailNormalMap[0] = "art/Packs/Terrains/Tortuga/grayrock_detailnormal.dds";
   specularMap[0] = "art/Packs/Terrains/Tortuga/grayrock_specular.dds";
};

singleton Material(mat_GGvolcano_lavaflow)
{
   mapTo = "lavaflow_material";
   diffuseMap[0] = "lava_denser_diffuse.png";
   normalMap[0] = "lava_denser_normal_disp.png";
   specularMap[0] = "lava_denser_specular.png";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "0.00784314 0.996078 0.00784314 1";
   specularPower[0] = "34";
   translucentBlendOp = "Mul";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "-1 0";
   scrollSpeed[0] = "0.01";
   emissive[0] = "0";
   castShadows = "0";
   parallaxScale[0] = "0.0138889";
   pixelSpecular[0] = "0";
   alphaRef = "80";
   glow[1] = "1";
   forestWindEnabled = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "GG_PacificIsland";
};

singleton Material(lavaglow_ColorEffectR6G135B113_material)
{
   mapTo = "ColorEffectR6G135B113-material";
   diffuseMap[0] = "";
   normalMap[0] = "";
   specularMap[0] = "";
   diffuseColor[0] = "0.0235294 0.529412 0.443137 1";
   specular[0] = "1 1 1 1";
   specularPower[0] = 10;
   materialTag0 = "GG_PacificIsland";
};

singleton Material(mat_GGlavaGlow)
{
   mapTo = "lavaglow";
   diffuseMap[0] = "lavaglow_diffuse";
   normalMap[0] = "";
   specularMap[0] = "";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = 10;
   translucent = "1";
   translucentBlendOp = "Add";
   glow[0] = "1";
   emissive[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "GG_PacificIsland";
};

singleton Material(mat_GGlavafall)
{
   mapTo = "lavafall";
   diffuseMap[0] = "art/Packs/Props/GG_PacificIsland/lava.png";
   diffuseColor[0] = "1 0.141176 0 1";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = 10;
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -0.14";
   scrollSpeed[0] = "1.882";
   emissive[0] = "1";
   glow[0] = "0";
   vertColor[0] = "0";
   useAnisotropic[0] = "1";
   materialTag0 = "GG_PacificIsland";
   subSurface[0] = "1";
};

singleton Material(mat_GGtorch)
{
   mapTo = "torch";
   diffuseMap[0] = "tex_torch_dif";
   normalMap[0] = "tex_torch_nrm.dds";
   specularMap[0] = "";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = 10;
   alphaTest = "1";
   alphaRef = "65";
   useAnisotropic[0] = "1";
   materialTag0 = "GG_PacificIsland";
};
singleton Material(mat_tex_volcano_rocks)
{
   mapTo = "tex_volcano_rocks";
   diffuseMap[0] = "cas_cobble2_shadow.dds";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   materialTag0 = "Rocks";
   detailMap[0] = "tex_volcanic_rock_dif.dds";
   materialTag0 = "GG_PacificIsland";
};
