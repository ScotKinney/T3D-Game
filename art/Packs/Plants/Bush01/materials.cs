
singleton Material(Bush01_mat)
{
   mapTo = "Bush01";
   diffuseMap[0] = "largeFiscus2.dds";
   translucent = "1";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "107";
   normalMap[0] = "largeFiscus2_NRM.dds";
   specularMap[0] = "largeFiscus2_SPEC.dds";
};

singleton Material(Bush01)
{
   mapTo = "Bush01";
   diffuseMap[0] = "largeFiscus2.dds";
   specular[0] = "0.968628 0.996078 0.901961 0.726";
   specularPower[0] = "128";
   translucentBlendOp = "LerpAlpha";
   normalMap[0] = "largeFiscus2_NRM.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "largeFiscus2_SPEC.dds";
   alphaTest = "1";
   alphaRef = "174";
   showFootprints = "0";
   diffuseColor[0] = "0.686275 0.596078 0.211765 1";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.623529 0.690196 0.282353 1";
   doubleSided = "1";
};
