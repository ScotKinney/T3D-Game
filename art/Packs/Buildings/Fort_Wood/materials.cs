singleton Material(mat_FortBridge)
{
   mapTo = "Fort_Bridge";
   diffuseMap[0] = "PMat_bridgeFort";
   normalMap[0] = "bridgeWood_Nrm.png";
   customFootstepSound = "FootStepWood1Sound";
   useAnisotropic[0] = "1";
   materialTag0 = "fort";
};

singleton Material(fortLOD_Z__Fort_Wood1501)
{
   mapTo = "_Fort_Wood1501";
   diffuseMap[0] = "wood_5.png";
   normalMap[0] = "wood_5N.png";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "fort";
};

singleton Material(fortLOD_Z__Fort_Mud1501)
{
   mapTo = "_Fort_Mud1501";
   diffuseMap[0] = "colmud.jpg";
   useAnisotropic[0] = "1";
   materialTag0 = "fort";
};

singleton Material(fortLOD_Z__Fort_Logs1501)
{
   mapTo = "_Fort_Logs1501";
   diffuseMap[0] = "barkfort";
   useAnisotropic[0] = "1";
   materialTag0 = "fort";
};

singleton Material(_Fort_Stone1501_mat)
{
   mapTo = "_Fort_Stone1501";
   diffuseMap[0] = "stone_4.jpg";
   normalMap[0] = "stone_4N.png";
   useAnisotropic[0] = "1";
   materialTag0 = "fort";
};

singleton Material(mat_bridgeRope)
{
   mapTo = "tex_bridge";
   diffuseMap[0] = "tex_bridge";
   materialTag0 = "fort";
};

singleton Material(mat_bridgeFort_Collision)
{
   mapTo = "Collision";
   diffuseColor[0] = "0.741176 0.741176 0.741176 1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "fort";
};

singleton Material(mat_Fort_Tops1501)
{
   mapTo = "_Fort_Tops1501";
   diffuseMap[0] = "wood1.JPG";
   materialTag0 = "fort";
};

singleton Material(fortLOD_Z_lambert1)
{
   mapTo = "lambert1";
};

singleton Material(mat_BridgePost)
{
   mapTo = "BridgePost_dif";
   diffuseMap[0] = "BridgePost_dif";
   normalMap[0] = "BridgePost_nm.dds";
   specularPower[0] = "50";
   pixelSpecular[0] = "1";
   specularMap[0] = "BridgePost_spec.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(Fort2_guardtowerbase)
{
   mapTo = "guardtowerbase";
   diffuseMap[0] = "art/Packs/Buildings/Fort_Wood/Base_Wall_GTower_dif";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_Wall_GTower_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Fort2_rope)
{
   mapTo = "rope";
   diffuseMap[0] = "art/Packs/Buildings/Fort_Wood/Base_Rope_GTowerBRN_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_Rope_GTower_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Fort2_tileroof)
{
   mapTo = "tileroof";
   diffuseMap[0] = "art/Packs/Buildings/Fort_Wood/Base_TileRoof_GTower_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_TileRoof_GTower_nm.dds";
   specularMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_TileRoof_GTower_spec.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Fort2_woodplank)
{
   mapTo = "woodplank";
   diffuseMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Source/Base_StairBridge_GTower_dif.jpg";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_StairBridge_GTower_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Fort2_woodroof)
{
   mapTo = "woodroof";
   diffuseMap[0] = "art/Packs/Buildings/Fort_Wood/Base_Ceiling_GTower_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_Ceiling_GTower_nm.dds";
   specularMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_Ceiling_GTower_spec.dds";
   useAnisotropic[0] = "1";
};

singleton Material(Fort2_Fort_Wood1501)
{
   mapTo = "Fort_Wood1501";
   diffuseMap[0] = "art/Packs/Buildings/Fort_Wood/PMat_bridgeFort";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Fort_Wood/bridgeWood_Nrm.png";
   useAnisotropic[0] = "1";
};

singleton Material(Fort1_Kardia_PMat_bridgeFort)
{
   mapTo = "PMat_bridgeFort";
   diffuseMap[0] = "art/Packs/Buildings/Fort_Wood/PMat_bridgeFort";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Fort_Wood/PMat_bridgeFortN.dds";
   useAnisotropic[0] = "1";
   materialTag0 = "GuardTower_Sparta";
   showFootprints = "0";
   customFootstepSound = "FootStepWood1Sound";
};

singleton Material(Fort1_Kardia_collisionmesh)
{
   mapTo = "collisionmesh";
   diffuseColor[0] = "0 0.00392157 0.00392157 1";
   specularPower[0] = "128";
   translucentBlendOp = "Add";
   translucent = "1";
   materialTag0 = "GuardTower_Sparta";
};

singleton Material(Fort1_Kardia1_collision_1)
{
   mapTo = "collision-1";
   diffuseColor[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
};

singleton Material(Fort1_kardiaRopes1_cube6_auv)
{
   mapTo = "cube6_auv";
   diffuseMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_Rope_GTower_dif.dds";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Spartan_GuardTowers/Base_Rope_GTower_nm.dds";
   materialTag0 = "GuardTower_Sparta";
   useAnisotropic[0] = "1";
};
