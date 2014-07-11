
singleton Material(DungeonLevel_Altar)
{
   mapTo = "Altar";
   diffuseMap[0] = "StoneAltarSmall_D.dds";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "StoneAltarSmall_N.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};

singleton Material(DungeonLevel_StoneFloorDark)
{
   mapTo = "StoneFloorDark";
   diffuseMap[0] = "StoneFloor1Dark_D.dds";
   specular[0] = "0.917647 0.917647 0.917647 1";
   specularPower[0] = "19";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   normalMap[0] = "OldStone1_N.dds";
};

singleton Material(DungeonLevel_StoneFloor1)
{
   mapTo = "StoneFloor1";
   diffuseMap[0] = "StoneFloor1_D.dds";
   specular[0] = "0.905882 0.905882 0.905882 1";
   specularPower[0] = "4";
   translucentBlendOp = "None";
   normalMap[0] = "StoneFloor1_N.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "StoneFloor1_S.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};

singleton Material(DungeonLevel_BrickWall1)
{
   mapTo = "BrickWall1";
   diffuseMap[0] = "BrickWall1_Diff.dds";
   specular[0] = "0.921569 0.921569 0.921569 1";
   specularPower[0] = "11";
   translucentBlendOp = "None";
   normalMap[0] = "BrickWall1_N.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "BrickWall1_S.dds";
   useAnisotropic[0] = "1";
};

singleton Material(DungeonLevel_OldStone1Dark)
{
   mapTo = "OldStone1Dark";
   diffuseMap[0] = "OldStone1Dark_D.dds";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};

singleton Material(DungeonLevel_OldStone1)
{
   mapTo = "OldStone1";
   diffuseMap[0] = "OldStone1_D.dds";
   specular[0] = "0.917647 0.917647 0.917647 1";
   specularPower[0] = "26";
   translucentBlendOp = "None";
   normalMap[0] = "OldStone1_N.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "OldStone1_S.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};

singleton Material(DungeonLevel_Torch)
{
   mapTo = "Torch";
   diffuseMap[0] = "Torch_D.dds";
   specular[0] = "0.937255 0.937255 0.937255 1";
   specularPower[0] = "16";
   translucentBlendOp = "None";
   normalMap[0] = "Torch_N.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "Torch_S.dds";
   useAnisotropic[0] = "1";
};


singleton Material(DungeonLevel_default)
{
   mapTo = "default";
   diffuseColor[0] = "0.789854 0.813333 0.694044 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
};

singleton Material(Barrel_WoodPlanks1)
{
   mapTo = "WoodPlanks1";
   diffuseMap[0] = "WoodPlanks1_D";
   specular[0] = "0.02 0.02 0.02 1";
   specularPower[0] = "100";
   translucent = "0";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};
