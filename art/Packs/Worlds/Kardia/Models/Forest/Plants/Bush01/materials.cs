
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
   diffuseMap[0] = "art/Packs/veg/bush01/BushLeaf01.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "99";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/veg/bush01/GreenBirch2_NRM.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/veg/bush01/GreenBirch2_SPEC.dds";
   alphaTest = "1";
   alphaRef = "93";
};
