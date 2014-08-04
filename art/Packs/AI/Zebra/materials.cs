singleton Material(mat_ZebraTRS)
{
   mapTo = "ZebraTRS";
   diffuseMap[0] = "Zebra";
   specularPower[0] = "100";
   translucent = "1";
};

singleton Material(mat_Zebra)
{
   mapTo = "Zebra";
   diffuseMap[0] = "art/Packs/AI/Zebra/Zebra";
   specularPower[0] = "100";
   translucent = "0";
   useAnisotropic[0] = "1";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "120";
   normalMap[0] = "art/Packs/AI/Zebra/Zebra_NRM.dds";
};
