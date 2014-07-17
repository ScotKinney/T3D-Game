singleton Material(WhitePineBarkMat)
{
   mapTo = "pineBark";
   diffuseMap[0] = "whitePine_bark_diffuse";
   normalMap[0] = "whitePine_bark_normal.png";
   materialTag0 = "MythTrees";
};

singleton Material(WhitePineBranchMat)
{
   mapTo = "pineBranch";
   translucentBlendOp = "None";
   diffuseMap[0] = "whitePine_branch_diffuse.png";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "70";
   materialTag0 = "MythTrees";
   normalMap[0] = "whitePine_branch_normal.png";
};

singleton Material(MapleBranchMat)
{
   mapTo = "mapleBranch";
   diffuseMap[0] = "maple_branch_diffuse.png";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "100";
   materialTag0 = "MythTrees";
   normalMap[0] = "maple_branch_normal.png";
   specularMap[0] = "maple_branch_spec.png";
};

singleton Material(MapleBarkMat)
{
   mapTo = "mapleBark";
   diffuseMap[0] = "maple_bark_diffuse";
   normalMap[0] = "maple_bark_normal.png";
   materialTag0 = "MythTrees";
};