
singleton Material(EC_Stone_01)
{
   mapTo = "stone_01";
   diffuseMap[0] = "stone_01";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
};

singleton Material(EC_Arena)
{
   mapTo = "arena";
   diffuseMap[0] = "art/Packs/Caves/BugCaves/arena_dif.dds";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
   useAnisotropic[0] = "1";
   backLightFactor = "0.9 1.0 0.2";
   normalMap[0] = "art/Packs/Caves/BugCaves/arena_nm.dds";
   specularPower[0] = "1";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/Caves/BugCaves/arena_spec.dds";
};

singleton Material(EC_Ent)
{
   mapTo = "ent";
   diffuseMap[0] = "ent";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
   specular[0] = "1 0.509804 0 1";
   specularPower[0] = "34";
   pixelSpecular[0] = "1";
   specularMap[0] = "ent-ilum.jpg";
};

singleton Material(EC_ScrollingWater)
{
   mapTo = "lava";
   diffuseMap[0] = "scrollingwater.dds";
   doubleSided = "1";
   backLightFactor = "0.9 1.0 0.2";
   materialTag0 = "EntryCaves";
   specularPower[0] = "1";
   glow[0] = "0";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -0.07";
   scrollSpeed[0] = "4.706";
   castShadows = "1";
   translucent = "1";
   showFootprints = "0";
   diffuseColor[0] = "0.854902 0.941177 0.996078 1";
   vertColor[0] = "1";
   minnaertConstant[0] = "10";
   subSurfaceColor[0] = "0 0.301961 1 1";
   subSurfaceRolloff[0] = "20";
   emissive[0] = "1";
   rotSpeed[0] = "0.353";
   useAnisotropic[0] = "1";
};


singleton Material(EntryLevel_stone)
{
   mapTo = "stone";
   diffuseMap[0] = "art/Packs/Caves/BugCaves/stone_01.dds";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
   useAnisotropic[0] = "1";
   backLightFactor = "0.9 1.0 0.2";
   normalMap[0] = "art/Packs/Caves/BugCaves/stone_01_nm.dds";
   specularPower[0] = "1";
   pixelSpecular[0] = "1";
   specularStrength[0] = "0.196078";
   specularMap[0] = "art/Packs/Caves/BugCaves/stone_01_Spec.dds";
};

singleton Material(EntryLevel_statueA)
{
   mapTo = "statueA";
   diffuseMap[0] = "statue1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
   useAnisotropic[0] = "1";
   backLightFactor = "0.9 1.0 0.2";
};

singleton Material(EntryLevel_statueB)
{
   mapTo = "statueB";
   diffuseMap[0] = "statue2";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
   useAnisotropic[0] = "1";
   backLightFactor = "0.9 1.0 0.2";
};

singleton Material(EntryLevel_statueC)
{
   mapTo = "statueC";
   diffuseMap[0] = "statue3";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
   useAnisotropic[0] = "1";
};


singleton Material(statueD_mat)
{
   mapTo = "statueD";
   diffuseMap[0] = "statue4";
   materialTag0 = "EntryCaves";
   useAnisotropic[0] = "1";
};


singleton Material(wall_mat)
{
   mapTo = "wall";
   diffuseMap[0] = "art/Packs/Caves/BugCaves/wall_01.dds";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "EntryCaves";
   useAnisotropic[0] = "1";
   backLightFactor = "0.9 1.0 0.2";
   normalMap[0] = "art/Packs/Caves/BugCaves/wall_01_nm.dds";
   specular[0] = "0.882353 0.882353 0.882353 1";
   specularPower[0] = "19";
   pixelSpecular[0] = "1";
   specularStrength[0] = "0.294118";
   specularMap[0] = "art/Packs/Caves/BugCaves/wall_01_spec.dds";
};


singleton Material(EntryLevel1_collision_1)
{
   mapTo = "collision-1";
   diffuseColor[0] = "0.8 0.8 0.8 1";
   specular[0] = "0.5 0.5 0.5 1";
   specularPower[0] = "128";
   doubleSided = "1";
   translucentBlendOp = "None";
};


singleton Material(gate_mat)
{
   mapTo = "gate";
   diffuseMap[0] = "art/Packs/Caves/BugCaves/ent.jpg";
   specularPower[0] = "36";
   pixelSpecular[0] = "0";
   materialTag0 = "EntryCaves";
   backLightFactor = "0.9 1.0 0.2";
   customFootstepSound = "FootStepRock1Sound";
   useAnisotropic[0] = "1";
};

singleton Material(EntryLevel1_collision_001)
{
   mapTo = "collision.001";
   diffuseColor[0] = "0.8 0.8 0.8 1";
   specular[0] = "0.5 0.5 0.5 1";
   specularPower[0] = "128";
   doubleSided = "1";
   translucentBlendOp = "None";
};
