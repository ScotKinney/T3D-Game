singleton Material(mat_SVPergTrim)
{
   mapTo = "SVPergolaTrim_dif";
   diffuseMap[0] = "SVPergolaTrim_dif";
   normalMap[0] = "SVPergolaTrim_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(mat_SVPergWall)
{
   mapTo = "SVPergolaWall_dif";
   diffuseMap[0] = "SVPergolaWall_dif";
   normalMap[0] = "SVPergolaWall_nm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};

singleton Material(svpergola8_SVPergolaWall2_diff)
{
   mapTo = "SVPergolaWall2_diff";
   diffuseMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaWall2_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaWall2_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(svpergola8_SvPergolaIonic_diff)
{
   mapTo = "SvPergolaIonic_diff";
   diffuseMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaIonic_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaIonic_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(svpergola8_SCPergolaWall_diff)
{
   mapTo = "SCPergolaWall_diff";
   diffuseMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaWall_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaWall_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(svpergola10_SVPergola_trim_diff)
{
   mapTo = "SVPergola_trim_diff";
   diffuseMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaTrim_dif";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaTrim_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(DefaultMaterial3)
{
   mapTo = "SVPergolaIonic_dif";
   diffuseMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaIonic_dif";
   normalMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaIonic_nm.dds";
   useAnisotropic[0] = "1";
};

singleton Material(DefaultMaterial4)
{
   mapTo = "SVPergolaWall2_dif";
   diffuseMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaWall2_dif";
   normalMap[0] = "art/Packs/Buildings/Sh3D_Pergola/SVPergolaWall2_nm.dds";
   useAnisotropic[0] = "1";
};
