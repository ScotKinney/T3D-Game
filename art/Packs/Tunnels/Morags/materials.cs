singleton Material(volcano_tex_volcano_cave_2)
{
	mapTo = "tex_volcano_cave_2";

   diffuseMap[0] = "lavaBarkB005.jpg";
   detailMap[0] = "tex_volcanic_cliffrock_dif.dds";
   detailScale[0] = "7 7";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "MoragsForge";
};

singleton Material(tex_volcano_cave_1_mat)
{
   mapTo = "tex_volcano_cave_1";
   diffuseMap[0] = "lavaBarkB005.jpg";
   detailMap[0] = "tex_volcanic_cliffrock_dif.dds";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   materialTag0 = "MoragsForge";
};

singleton Material(tex_volcano_cave_3_mat)
{
   mapTo = "tex_volcano_cave_3";
   diffuseMap[0] = "groundCoverDetail5.png";
   detailMap[0] = "dryground_detail.dds";
   normalMap[0] = "dryground_normal.dds";
   materialTag0 = "MoragsForge";
};

singleton Material(tex_volcanic_rock_base_mat)
{
   mapTo = "tex_volcanic_rock_base";
   diffuseMap[0] = "lavaBarkB005.jpg";
   detailMap[0] = "tex_volcanic_cliffrock_dif.dds";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   materialTag0 = "MoragsForge";
};

//--- lavafall.DAE MATERIALS BEGIN ---
singleton Material(lavafall)
{
   mapTo = "lavafall";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/lava.png";
   diffuseColor[0] = "0.588235 0.588235 0.588235 1";
    specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "41";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -0.14";
   scrollSpeed[0] = "0.882";
   materialTag0 = "Morags";
   emissive[0] = "1";
   glow[0] = "1";
   vertColor[0] = "1";
   useAnisotropic[0] = "1";
   pixelSpecular[0] = "1";
};

//--- lavafall.DAE MATERIALS END ---

//////////////////////////////////////////////////////////////////////////


singleton Material(mat_BrickFloorRock)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "Brick_Floor.png";
   detailScale[0] = "6 6";
   normalMap[0] = "Brick_Floor_N.png";
   customFootstepSound = "FootStepRock1Sound";
   specularMap[0] = "Brick_Floor_s.png";
   specularPower[0] = "39";
   pixelSpecular[0] = "1";
   parallaxScale[0] = "0";
   materialTag0 = "MoragsForge";
   useAnisotropic[0] = "1";
};

singleton Material(mat_wooden_opora)
{
   mapTo = "wooden_opora";
   diffuseMap[0] = "woodset01.jpg";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_VolcanoTunnels_rock01)
{
   mapTo = "rock01";
   diffuseMap[0] = "lavaBarkB005.jpg";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   castShadows = "1";
   materialTag0 = "MoragsForge";
   customFootstepSound = "FootStepRock1Sound";
   customImpactSound = "FootStepRock1Sound";
   specularPower[0] = "1";
   pixelSpecular[0] = "0";
   parallaxScale[0] = "0.0416667";
   useAnisotropic[0] = "1";
   detailMap[0] = "tex_volcanic_cliffrock_dif.dds";
   detailScale[0] = "2 2";
};

singleton Material(mat_VolcanoTunnels_rock_road)
{
   mapTo = "rock-road";
   diffuseMap[0] = "groundCoverDetail5.png";
   normalMap[0] = "dryground_normal.dds";
   castShadows = "1";
   materialTag0 = "MoragsForge";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   customImpactSound = "FootStepRock1Sound";
   detailMap[0] = "dryground_detail.dds";
   detailScale[0] = "10 10";
};

singleton Material(mat_VolcanoTunnels_Material__3)
{
   mapTo = "Material__3";
   diffuseMap[0] = "lavaBarkB005.jpg";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   castShadows = "1";
   materialTag0 = "MoragsForge";
   customFootstepSound = "FootStepRock1Sound";
   customImpactSound = "FootStepRock1Sound";
   specularPower[0] = "1";
   pixelSpecular[0] = "0";
   parallaxScale[0] = "0.0416667";
   useAnisotropic[0] = "1";
   detailMap[0] = "tex_volcanic_cliffrock_dif.dds";
};

singleton Material(mat_VolcanoTunnels_magma)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "LAVA.JPG";
   normalMap[0] = "lavanormal.jpg";
   materialTag0 = "MoragsForge";
   specularPower[0] = "29";
   pixelSpecular[0] = "1";
   parallaxScale[0] = "0.138889";
   useAnisotropic[0] = "1";
   glow[0] = "1";
};

singleton Material(torch_fw)
{
   mapTo = "fw";
   diffuseMap[0] = "woodsmpl01";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_lavadisk2)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "LAVA";
   normalMap[0] = "lavanormal.jpg";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "1 0.976471 0 1";
   specularPower[0] = "36";
   detailNormalMap[0] = "lavabump.jpg";
   detailNormalMapStrength[0] = "10";
   emissive[0] = "1";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0.034 0";
   scrollSpeed[0] = "0.235";
   materialTag0 = "MoragsForge";
   useAnisotropic[0] = "1";
   detailSize = "4";
   diffuseSize = "128";
   detailStrength = "0.5";
   detailDistance = "500";
};

singleton Material(mat_lavadisk1)
{
   mapTo = "unmapped_mat";
   diffuseMap[0] = "LAVA";
   normalMap[0] = "lavanormal.jpg";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "0 0 0 1";
   specularPower[0] = 8;
   materialTag0 = "MoragsForge";
   detailSize = "4";
   diffuseSize = "128";
   detailStrength = "0.5";
   detailDistance = "500";
};

singleton Material(mat_ForgeSouthExit)
{
   mapTo = "PMat_MythrielFromForgeSouthWall";
   diffuseMap[0] = "MythSFromForge";
   emissive[0] = "1";
   castShadows = "0";
   materialTag0 = "MoragsForge";
};

singleton Material(bones)
{
   mapTo = "bones";
   diffuseMap[0] = "bones.jpg";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_rivergrass)
{
   mapTo = "rivergrass";
   diffuseMap[0] = "rivergrass_diffuse_transparency.dds";
   translucent = "1";
   materialTag0 = "trees";
};

singleton Material(mat_CrateSimple001stain4)
{
   mapTo = "CratesSimple0001stain4";
   diffuseMap[0] = "CratesSimple0001stain4";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_Barrel01_D)
{
   mapTo = "Barrel01_D";
   diffuseMap[0] = "Barrel01_D";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_PropsA)
{
   mapTo = "PropsA";
   diffuseMap[0] = "PropsA.dds";
   materialTag0 = "MoragsForge";
};

singleton Material(PLANKBridge001_PlanksOld0348_L)
{
   mapTo = "PlanksOld0348_L";
   diffuseMap[0] = "PlanksOld0348_L";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MoragsForge";
};

singleton Material(fencePostBasic00A_mat)
{
   mapTo = "fencePostBasic00A";
   diffuseMap[0] = "fencePostBasic00A.png";
};

singleton Material(lavaRockBasic2)
{
   mapTo = "PMat_lavadisk2";
   diffuseMap[0] = "lava_old";
   detailMap[0] = "art/Packs/Terrains/Morags/dryground_detail";
   detailScale[0] = "3 3";
   normalMap[0] = "art/Packs/Terrains/Morags/dryground_normal";
   specular[0] = "1 0.905882 0 1";
   specularPower[0] = "1";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "1 0.67451 0 1";
   subSurfaceRolloff[0] = "0.9";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "-0.02 0";
   scrollSpeed[0] = "0.1";
   customFootstepSound = "FootStepSand1Sound";
   materialTag0 = "MoragsForge";
   detailSize = "4";
   diffuseSize = "128";
   detailStrength = "0.5";
   detailDistance = "500";
};

singleton Material(PMat_TPWallForgeToMythNorth_mat)
{
   mapTo = "PMat_TPWallForgeToMythNorth";
   diffuseMap[0] = "MythrielNorth.jpg";
};

////////////////////////////////

singleton Material(Kennel01_metalPole0)
{
   mapTo = "metalPole0";
   diffuseMap[0] = "3TD_MetalPoles_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "24";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
};

singleton Material(Kennel01_chainlink01)
{
   mapTo = "chainlink01";
   diffuseMap[0] = "3td_chainLink01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "9";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "20";
};

singleton Material(Kennel01_Corrigate01)
{
   mapTo = "Corrigate01";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/3TD_Corrigate_Rust_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "6";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Tunnels/Morags/3TD_Corrigate_Rust_01_NRM.png";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   alphaRef = "0";
};

singleton Material(Kennel01_WoodPlank01)
{
   mapTo = "WoodPlank01";
   diffuseMap[0] = "3td_WoodPlank_02";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
};

singleton Material(Kennel01__5___Default)
{
   mapTo = "_5_-_Default";
   diffuseColor[0] = "0.588235 0.588235 0.588235 1";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(singletunnel_magma)
{
   mapTo = "magma";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/LAVA";
   specular[0] = "1 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   glow[0] = "1";
   materialTag0 = "MoragsForge";
};

singleton Material(lavadisk_PMat_lavadisk1)
{
   mapTo = "PMat_lavadisk1";
   diffuseMap[0] = "LAVA";
   specular[0] = "0 0 0 1";
   translucentBlendOp = "None";
};

singleton Material(_3td_Barrel01_DrumMetal_01)
{
   mapTo = "DrumMetal_01";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/3td_DrumMetal_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "69";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Tunnels/Morags/3td_DrumMetal_01_NRM.png";
   specularStrength[0] = "2.94118";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/Tunnels/Morags/3td_DrumMetal_01_SPEC.png";
   useAnisotropic[0] = "1";
};

singleton Material(_3td_Barrel01_OilDrumTop_01)
{
   mapTo = "OilDrumTop_01";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/3td_OilDrumTop_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Tunnels/Morags/3td_OilDrumTop_01_NRM.png";
   specularMap[0] = "art/Packs/Tunnels/Morags/3td_OilDrumTop_01_SPEC.png";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepMetal1Sound";
};

singleton Material(_3td_Barrel01_ColorEffectR28G89B177_material)
{
   mapTo = "ColorEffectR28G89B177-material";
   diffuseColor[0] = "0.109804 0.34902 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(_3td_Pallet01_ColorEffectR228G184B153_material)
{
   mapTo = "ColorEffectR228G184B153-material";
   diffuseColor[0] = "0.894118 0.721569 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(_3td_Pallet01_PalletWood01)
{
   mapTo = "PalletWood01";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/3td_PalletWood_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Tunnels/Morags/3td_PalletWood_01_NRM.png";
   specularMap[0] = "art/Packs/Tunnels/Morags/3td_PalletWood_01_SPEC.png";
   useAnisotropic[0] = "1";
};

singleton Material(MetalFence01_FenceCorrigate01)
{
   mapTo = "FenceCorrigate01";
   diffuseMap[0] = "3TD_Corrigate_Rust_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "14";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_Corrigate_Rust_01_NRM.png";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   pixelSpecular[0] = "1";
};

singleton Material(MetalFence01_ColorEffectR176G26B26_material)
{
   mapTo = "ColorEffectR176G26B26-material";
   diffuseColor[0] = "0.690196 0.101961 0.101961 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(MetalFence01_RustyMetal05)
{
   mapTo = "RustyMetal05";
   diffuseMap[0] = "3td_RustMetal_05";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "1";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
};

singleton Material(MetalFence01_Corrigate02)
{
   mapTo = "Corrigate02";
   diffuseMap[0] = "3TD_Corrigate_Rust_04";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_Corrigate_Rust_04_NRM.png";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(MetalFence01_ColorEffectR154G185B229_material)
{
   mapTo = "ColorEffectR154G185B229-material";
   diffuseColor[0] = "0.603922 0.72549 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(MetalFence01_Corigate04)
{
   mapTo = "Corigate04";
   diffuseMap[0] = "3TD_Corrigate_Rust_04";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "29";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_Corrigate_Rust_04_NRM.png";
   pixelSpecular[0] = "1";
};

singleton Material(DefaultMaterial3)
{
   mapTo = "MoragsForgePointer";
   diffuseMap[0] = "art/packs/tunnels/morags/MoragsForgePointer";
   useAnisotropic[0] = "1";
};
