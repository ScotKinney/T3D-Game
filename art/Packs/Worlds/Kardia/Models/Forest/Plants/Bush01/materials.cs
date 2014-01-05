
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
   diffuseMap[0] = "Birch_Raw";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
