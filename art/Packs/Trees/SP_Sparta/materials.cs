
singleton Material(mat_ItalianCypress_bark)
{
   mapTo = "bark";
   diffuseMap[0] = "ItalianCypressBark_dif.dds";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "ItalianCypressBark_nm.dds";
   useAnisotropic[0] = "1";
   diffuseSize = "128";
   detailStrength = "0.5";
   materialTag0 = "Miscellaneous";
   detailDistance = "500";
   detailSize = "4";
};

singleton Material(mat_ItalianCypress_leaves)
{
   mapTo = "leaves";
   diffuseMap[0] = "ItalianCypress_dif.dds";
   specularPower[0] = "1";
   translucentBlendOp = "LerpAlpha";
   normalMap[0] = "ItalianCypress_nm.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "ItalianCypress_spec.dds";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   translucent = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.854902 0.905882 0.356863 1";
   alphaTest = "1";
   alphaRef = "13";
   showFootprints = "0";
};

singleton Material(mat_ItalianCypress_default2)
{
   mapTo = "default2";
   specularPower[0] = "128";
   translucentBlendOp = "None";
};
