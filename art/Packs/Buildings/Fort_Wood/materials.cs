singleton Material(mat_FortBridge)
{
   mapTo = "Fort_Bridge";
   diffuseMap[0] = "PMat_bridgeFort";
   materialTag0 = "fort";
   customImpactSound = "FootStepWood1Sound";
   customFootstepSound = "FootStepWood1Sound";
   useAnisotropic[0] = "1";
   normalMap[0] = "bridgeWood_Nrm.png";
   materialTag0 = "fort";
};

singleton Material(fortLOD_Z__Fort_Wood1501)
{
   mapTo = "_Fort_Wood1501";
   diffuseMap[0] = "wood_5.png";
   translucentBlendOp = "None";
   customFootstepSound = "FootStepWood1Sound";
   normalMap[0] = "wood_5N.png";
   useAnisotropic[0] = "1";
   customImpactSound = "FootStepWood1Sound";
   materialTag0 = "fort";
};

singleton Material(fortLOD_Z__Fort_Mud1501)
{
   mapTo = "_Fort_Mud1501";
   diffuseMap[0] = "colmud.jpg";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   materialTag0 = "fort";
};

singleton Material(fortLOD_Z__Fort_Logs1501)
{
   mapTo = "_Fort_Logs1501";
   diffuseMap[0] = "barkfort";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   materialTag0 = "fort";
};

singleton Material(_Fort_Stone1501_mat)
{
   mapTo = "_Fort_Stone1501";
   diffuseMap[0] = "stone_4.jpg";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
   normalMap[0] = "stone_4N.png";
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

singleton Material(mat_PropsA)
{
   mapTo = "PropsA";
   diffuseMap[0] = "PropsA.dds";
   customFootstepSound = "FootStepWood1Sound";
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
customImpactSound = "FootStepWood1Sound";
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


singleton Material(PMat_RopeCoilObject_mat)
{
   mapTo = "PMat_RopeCoilObject";
   diffuseMap[0] = "RopeCoil.jpg";
   translucent = "0";
};

// Could not find this texture anywhere
//singleton Material(lambert1_mat)
//{
   //mapTo = "lambert1";
   //diffuseMap[0] = "lambert1";
   //customFootstepSound = "FootStepWood1Sound";
   //customImpactSound = "FootStepWood1Sound";
   //materialTag0 = "Fort";
//};

singleton Material(fortLOD_Z_lambert1)
{
   mapTo = "lambert1";
   diffuseColor[0] = "0.4 0.4 0.4 1";
   translucentBlendOp = "None";
};
