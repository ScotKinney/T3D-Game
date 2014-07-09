singleton Material(mat_tex_underwater_rock)
{
   mapTo = "tex_underwater_rock";
   diffuseMap[0] = "tex_rock_underwater_dif.dds";
   normalMap[0] = "tex_rock_underwater_nrm.dds";
   materialTag0 = "GG_Rocks";
};

singleton Material(mat_GG_GreyRocks)
{
   mapTo = "greyrock";
   diffuseMap[0] = "cas_cobble2_shadow.dds";
   detailMap[0] = "tex_volcanic_rock_dif.dds";
   detailScale[0] = "7 7";
   normalMap[0] = "tex_volcanic_cliffrock_nrm.dds";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
   materialTag0 = "GG_Rocks";
};


singleton Material(_20_smallrocksix_ColorEffectR6G134B113_material)
{
   mapTo = "ColorEffectR6G134B113-material";
   diffuseColor[0] = "0.0235294 0.52549 0.443137 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(_14_ggrockthree_ColorEffectR87G224B143_material)
{
   mapTo = "ColorEffectR87G224B143-material";
   diffuseColor[0] = "0.341177 0.878431 0.560784 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(_13_ggrocktwo_ColorEffectR229G166B215_material)
{
   mapTo = "ColorEffectR229G166B215-material";
   diffuseColor[0] = "0.898039 0.65098 0.843137 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(_21_smallrockseven_ColorEffectR154G154B229_material)
{
   mapTo = "ColorEffectR154G154B229-material";
   diffuseColor[0] = "0.603922 0.603922 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(_22_smallrockeight_ColorEffectR224G143B87_material)
{
   mapTo = "ColorEffectR224G143B87-material";
   diffuseColor[0] = "0.878431 0.560784 0.341177 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
