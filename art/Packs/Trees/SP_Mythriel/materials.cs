singleton Material(MapleBranchMat)
{
   mapTo = "mapleBranch";
   diffuseMap[0] = "art/Packs/Trees/SP_Mythriel/maple_branch_diffuse";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "255";
   materialTag0 = "MythTrees";
   useAnisotropic[0] = "1";
   specularPower[0] = "59";
};

singleton Material(MapleBarkMat)
{
   mapTo = "mapleBark";
   diffuseMap[0] = "art/Packs/Trees/SP_Mythriel/MapleBark_dif.dds";
   normalMap[0] = "art/Packs/Trees/SP_Mythriel/MapleBark_nm.dds";
   materialTag0 = "MythTrees";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   specularPower[0] = "71";
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
   diffuseMap[0] = "art/Packs/Trees/SP_Mythriel/whitePine_branch_diffuse.dds";
   specular[0] = "0 0 0 1";
   specularPower[0] = "128";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "255";
   materialTag0 = "MythTrees";
};

singleton Material(mat_ColorEffectR204G204B204)
{
   mapTo = "ColorEffectR204G204B204-material";
   diffuseColor[0] = "0.8 0.8 0.8 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
