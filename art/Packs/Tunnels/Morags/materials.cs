singleton Material(mat_lavafall)
{
   mapTo = "lavafall";
   diffuseMap[0] = "lava.png";
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

singleton Material(mat_bones)
{
   mapTo = "bones";
   diffuseMap[0] = "bones.jpg";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_rivergrass)
{
   mapTo = "rivergrass";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/rivergrass_diffuse_transparency.dds";
   translucent = "1";
   materialTag0 = "trees";
   emissive[0] = "1";
   useAnisotropic[0] = "1";
   diffuseColor[0] = "0.552941 0.552941 0.552941 1";
};

singleton Material(mat_Barrel01_D)
{
   mapTo = "Barrel01_D";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/Barrel01_D";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MoragsForge";
   useAnisotropic[0] = "1";
   emissive[0] = "1";
   diffuseColor[0] = "1 1 1 1";
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

singleton Material(mat_PlanksOld0348_L)
{
   mapTo = "PlanksOld0348_L";
   diffuseMap[0] = "PlanksOld0348_L";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MoragsForge";
   diffuseColor[0] = "0.698039 0.698039 0.698039 1";
   emissive[0] = "1";
};

singleton Material(fencePostBasic00A_mat)
{
   mapTo = "fencePostBasic00A";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/fencePostBasic00A.png";
   useAnisotropic[0] = "1";
   emissive[0] = "1";
   materialTag0 = "Miscellaneous";
};

////////////////////////////////

singleton Material(mat_metalPole)
{
   mapTo = "metalPole0";
   diffuseMap[0] = "3TD_MetalPoles_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "74";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   detailSize = "4";
   materialTag0 = "MoragsForge";
   diffuseSize = "128";
   detailStrength = "0.5";
   detailDistance = "500";
   diffuseColor[0] = "0.619608 0.619608 0.619608 1";
};

singleton Material(mat_chainlink01)
{
   mapTo = "chainlink01";
   diffuseMap[0] = "3td_chainLink01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "91";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "20";
   detailSize = "4";
   materialTag0 = "MoragsForge";
   diffuseSize = "128";
   detailStrength = "0.5";
   detailDistance = "500";
};

singleton Material(mat_Corrigate01)
{
   mapTo = "Corrigate01";
   diffuseMap[0] = "3TD_Corrigate_Rust_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "6";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_Corrigate_Rust_01_NRM.png";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   alphaRef = "0";
   specularStrength[0] = "0.196078";
   detailSize = "4";
   materialTag0 = "MoragsForge";
   diffuseSize = "128";
   detailStrength = "0.5";
   detailDistance = "500";
   diffuseColor[0] = "0.619608 0.619608 0.619608 1";
};

singleton Material(mat_WoodPlank01)
{
   mapTo = "WoodPlank01";
   diffuseMap[0] = "3td_WoodPlank_02";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "111";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   specularStrength[0] = "0.196078";
   detailSize = "4";
   materialTag0 = "MoragsForge";
   diffuseSize = "128";
   detailStrength = "0.5";
   detailDistance = "500";
   diffuseColor[0] = "0.615686 0.615686 0.615686 1";
};

singleton Material(mat_5_-_Default_mat)
{
   mapTo = "_5_-_Default";
   diffuseColor[0] = "0.145098 0.145098 0.145098 1";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_DrumMetal)
{
   mapTo = "DrumMetal_01";
   diffuseColor[0] = "0.619608 0.619608 0.619608 1";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "24";
   translucentBlendOp = "None";
   diffuseMap[0] = "3td_DrumMetal_01";
   normalMap[0] = "3td_DrumMetal_01_NRM.png";
   specularStrength[0] = "1.17647";
   pixelSpecular[0] = "1";
   specularMap[0] = "3td_DrumMetal_01_SPEC.png";
   useAnisotropic[0] = "1";
   detailSize = "4";
   diffuseSize = "128";
   materialTag0 = "MoragsForge";
   detailStrength = "0.5";
   detailDistance = "500";
};

singleton Material(mat_OilDrumTop)
{
   mapTo = "OilDrumTop_01";
   diffuseMap[0] = "3td_OilDrumTop_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "3td_OilDrumTop_01_NRM.png";
   specularMap[0] = "3td_OilDrumTop_01_SPEC.png";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepMetal1Sound";
};

singleton Material(mat_ColorEffectR28G89B177)
{
   mapTo = "ColorEffectR28G89B177-material";
   diffuseColor[0] = "0.109804 0.34902 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(mat_ColorEffectR228G184B153)
{
   mapTo = "ColorEffectR228G184B153-material";
   diffuseColor[0] = "0.894118 0.721569 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(mat_PalletWood01)
{
   mapTo = "PalletWood01";
   diffuseColor[0] = "0.627451 0.627451 0.627451 1";
   diffuseMap[0] = "3td_PalletWood_01.jpg";
   normalMap[0] = "3td_PalletWood_01_NRM.png";
   specularMap[0] = "3td_PalletWood_01_SPEC.png";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "Miscellaneous";
};

singleton Material(mat_FenceCorrigate01)
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

singleton Material(mat_ColorEffectR176G26B26)
{
   mapTo = "ColorEffectR176G26B26-material";
   diffuseColor[0] = "0.690196 0.101961 0.101961 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(mat_RustyMetal05)
{
   mapTo = "RustyMetal05";
   diffuseMap[0] = "3td_RustMetal_05";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "1";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
};

singleton Material(mat_Corrigate02)
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

singleton Material(mat_Corigate04)
{
   mapTo = "Corigate04";
   diffuseColor[0] = "0.619608 0.619608 0.619608 1";
   specularPower[0] = "29";
   translucentBlendOp = "None";
   diffuseMap[0] = "3TD_Corrigate_Rust_04";
   normalMap[0] = "3TD_Corrigate_Rust_04_NRM.png";
   specular[0] = "0.9 0.9 0.9 1";
   pixelSpecular[0] = "1";
   detailSize = "4";
   diffuseSize = "128";
   materialTag0 = "MoragsForge";
   detailStrength = "0.5";
   detailDistance = "500";
};

singleton Material(mat_MoragsForgePointer)
{
   mapTo = "MoragsForgePointer";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/MoragsForgePointer";
   useAnisotropic[0] = "1";
   emissive[0] = "1";
   materialTag0 = "Miscellaneous";
};

singleton Material(mat_ColorEffectR140G88B225)
{
   mapTo = "ColorEffectR140G88B225-material";
   diffuseColor[0] = "0.54902 0.345098 0.882353 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};


//////////TunnelRocks////////////////


singleton Material(mat_LavaRock_dif)
{
   mapTo = "LavaRock_dif";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/LavaRock_dif.dds";
   normalMap[0] = "art/Packs/Tunnels/Morags/LavaRock_nm.dds";
   specularPower[0] = "6";
   specularStrength[0] = "0.0980392";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/Tunnels/Morags/LavaRock_spec.dds";
   useAnisotropic[0] = "1";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0.02 0";
   scrollSpeed[0] = "0.1";
   materialTag0 = "MoragsForge";
   glow[0] = "0";
};

singleton Material(mat_BraceWood_dif)
{
   mapTo = "BraceWood_dif";
   diffuseMap[0] = "BraceWood_dif";
   diffuseColor[0] = "0.27451 0.27451 0.27451 1";
   normalMap[0] = "BraceWood_nm.png";
   useAnisotropic[0] = "1";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_ForgeFromLandPic)
{
   mapTo = "ForgeFromLandPic";
   diffuseMap[0] = "ForgeFromLandPic";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   emissive[0] = "1";
   useAnisotropic[0] = "1";
   diffuseColor[0] = "0.54902 0.54902 0.54902 1";
   materialTag0 = "MoragsForge";
};

singleton Material(mat_LandFromForgePic)
{
   mapTo = "LandFromForgePic";
   diffuseMap[0] = "LandFromForgePic";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   emissive[0] = "1";
};

singleton Material(mat_MK4_Vine)
{
   mapTo = "MK4_Vine";
   diffuseMap[0] = "MK4_lianas";
   normalMap[0] = "MK4_lianas_nmp.dds";
   useAnisotropic[0] = "1";
   specular[0] = "0 0 0 1";
   specularPower[0] = "1";
   translucent = "1";
   emissive[0] = "1";
   doubleSided = "1";
};

singleton Material(mat_CrateSimple)
{
   mapTo = "CratesSimple0001stain4";
   diffuseColor[0] = "0.407843 0.407843 0.407843 1";
   diffuseMap[0] = "art/Packs/Tunnels/Morags/CratesSimple0001stain4";
   normalMap[0] = "art/Packs/Tunnels/Morags/CratesSimple0001stain4_NORM.png";
  useAnisotropic[0] = "1";
   emissive[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};


