singleton Material(mat_Wildebeest)
{
   mapTo = "Wildebeest";
   diffuseMap[0] = "art/Packs/AI/Wildebeest/Wildebeest";
   normalMap[0] = "art/Packs/AI/Wildebeest/Wildebeest_NRM";
   useAnisotropic[0] = "1";
};

singleton Material(mat_WildebeestTRS_mat)
{
   mapTo = "WildebeestTRS";
   diffuseMap[0] = "art/Packs/AI/Wildebeest/WildebeestTRS";
   normalMap[0] = "art/Packs/AI/Wildebeest/WildebeestTRS_NRM";
   useAnisotropic[0] = "1";
   translucent = "1";
};

new Material(WildebeestFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Wildebeest/FP_Wildebeest";
   normalMap[0] = "art/Packs/AI/Wildebeest/FP_Wildebeest";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "footprint";
};