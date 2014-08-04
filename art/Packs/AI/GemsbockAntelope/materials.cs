singleton Material(mat_GemsbockAntelope)
{
   mapTo = "GemsbockAntelope";
   diffuseMap[0] = "GemsbockAntelope";
   normalMap[0] = "GemsbockAntelope_NRM";
   useAnisotropic[0] = "1";
};

new Material(GemsbockAntelopeFootprint)
{
   diffuseMap[0] = "art/Packs/AI/GemsbockAntelope/FP_Antelope";
   normalMap[0] = "art/Packs/AI/GemsbockAntelope/FP_Antelope";
   translucent = true;
   translucentZWrite = "1";
   materialTag0 = "footprints";
};