
singleton Material(WollemiPine_01_PreHistTrunk)
{
   mapTo = "PreHistTrunk";
   diffuseMap[0] = "deadWood";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "deadWood_NRM.png";
   useAnisotropic[0] = "1";
};

singleton Material(WollemiPine_01_DeadWood_Hoz)
{
   mapTo = "DeadWood_Hoz";
   diffuseMap[0] = "deadWood_Horz";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "deadWood_Horz_NRM.png";
   useAnisotropic[0] = "1";
};

singleton Material(WollemiPine_01_PreHist_Leaf)
{
   mapTo = "PreHist_Leaf";
   diffuseMap[0] = "AncientPine_01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   normalMap[0] = "AncientPine_01_NRM.png";
   specularMap[0] = "AncientPine_01_SPEC.png";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "140";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.996078 0.921569 0.211765 1";
};
