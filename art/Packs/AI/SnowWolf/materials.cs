
singleton Material(SnowWolf_Mat)
{
   mapTo = "SnowWolf";
   diffuseMap[0] = "art/Packs/AI/SnowWolf/SnowWolf";
   translucent = "1";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "13";
   useAnisotropic[0] = "1";
};

new Material(SnowWolfFootprint)
{
   diffuseMap[0] = "art/Packs/AI/SnowWolf/FP_Wildebeest";
   normalMap[0] = "art/Packs/AI/SnowWolf/FP_Wildebeest";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};
