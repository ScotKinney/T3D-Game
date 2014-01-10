singleton Material(Terrain_SFX_CliffRockTop_Mat)
{
   mapTo = "greyrock";
   diffuseMap[0] = "art/Packs/Forests/rocks/tex_volcanic_rock_base.dds";
   detailMap[0] = "art/Packs/Forests/rocks/tex_volcanic_rock_dif.dds";
   detailScale[0] = "7 7";
   normalMap[0] = "art/Packs/Forests/rocks/tex_volcanic_rock_nrm.dds";
   customFootstepSound = "FootStepRock1Sound";
   useAnisotropic[0] = "1";
   materialTag0 = "Rocks";
   specularPower[0] = "128";
   specularMap[0] = "art/Packs/Forests/rocks/tex_volcanic_rock_dif.dds";
   customImpactSound = "FootStepRock1Sound";
};

singleton Material(greyrock_mat)
{
   mapTo = "greyrock";
   diffuseMap[0] = "grayrock_diffuse.dds";
   normalMap[0] = "grayrock_normal1024.dds";
   customFootstepSound = "FootStepRock1Sound";
   useAnisotropic[0] = "1";
   materialTag0 = "Rocks";
};


singleton Material(_04_peakone_ColorEffectR229G166B215_material)
{
   mapTo = "ColorEffectR229G166B215-material";
   diffuseColor[0] = "0.898039 0.65098 0.843137 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
