singleton Material(mat_KuduAntelope)
{
   mapTo = "KuduAntelope";
   diffuseMap[0] = "art/Packs/AI/KuduAntelope/KuduAntelope";
   normalMap[0] = "art/Packs/AI/KuduAntelope/KuduAntelope_NRM";
   useAnisotropic[0] = "1";
};

new Material(KuduAntelopeFootprint)
{
   diffuseMap[0] = "art/Packs/AI/KuduAntelope/FP_Antelope";
   normalMap[0] = "art/Packs/AI/KuduAntelope/FP_Antelope";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "footprint";
};
