
singleton Material(mat_Deer)
{
   mapTo = "FallowDeer";
   diffuseMap[0] = "FallowDeer";
   translucent = "0";
};

new Material(DeerFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Deer/FP_Antelope";
   normalMap[0] = "art/Packs/AI/Deer/FP_Antelope";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "decal";
};