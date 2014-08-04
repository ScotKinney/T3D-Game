singleton Material(mat_Impala)
{
   mapTo = "Impala";
   diffuseMap[0] = "Impala";
   normalMap[0] = "Impala_NRM";
   useAnisotropic[0] = "1";
};

new Material(ImpalaFootprint)
{
   diffuseMap[0] = "art/Packs/AI/Impala/FP_Antelope";
   normalMap[0] = "art/Packs/AI/Impala/FP_Antelope";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "footprint";
};
