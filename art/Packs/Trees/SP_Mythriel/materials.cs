singleton Material(MapleBranchMat)
{
   mapTo = "mapleBranch";
   diffuseMap[0] = "maple_branch_diffuse";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "100";
   materialTag0 = "MythTrees";
};

singleton Material(MapleBarkMat)
{
   mapTo = "mapleBark";
   diffuseMap[0] = "maple_bark_diffuse.dds";
   normalMap[0] = "maple_bark_nm.dds";
   materialTag0 = "MythTrees";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
};

////////////////////White Pine///////////////////////////////////

singleton Material(mat_WhitePineBark)
{
   mapTo = "WhitePineBark_dif";
   diffuseMap[0] = "WhitePineBark_dif";
   normalMap[0] = "WhitePineBark_nm.dds";
   specular[0] = "0.921569 0.921569 0.921569 1";
   specularPower[0] = "46";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "MythTrees";
};

singleton Material(mat_whitePine_Branch)
{
   mapTo = "whitePine_Branch_diffuse";
   diffuseMap[0] = "whitePine_branch_diffuse";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "52";
   materialTag0 = "MythTrees";
};

singleton Material(mat_ColorEffectR204G204B204)
{
   mapTo = "ColorEffectR204G204B204-material";
   diffuseColor[0] = "0.8 0.8 0.8 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};