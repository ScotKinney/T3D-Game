
singleton Material(mat_Elephant)
{
   mapTo = "AsianElephant";
   diffuseMap[0] = "AsianElephant";
   normalMap[0] = "AsianElephant_NRM";
   useAnisotropic[0] = "1";
};

new Material(ElephantFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Elephant/FP_Elephant";
   normalMap[0] = "art/Packs/AI/Elephant/FP_Elephant";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "footprint";
};