
singleton Material(NipaPlant_01_Dirt_01)
{
   mapTo = "Dirt_01";
   diffuseMap[0] = "3TD_Dirt_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_Dirt_01_NRM.png";
   useAnisotropic[0] = "1";
};

singleton Material(NipaPlant_01_NipaLeaf01)
{
   mapTo = "NipaLeaf01";
   diffuseMap[0] = "3TD_NipaLeaf_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "3TD_NipaLeaf_01_NRM.png";
   specularMap[0] = "3TD_NipaLeaf_01_SPEC.png";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "100";
};
