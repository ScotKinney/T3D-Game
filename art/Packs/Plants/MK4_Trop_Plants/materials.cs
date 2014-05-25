singleton Material(MK4_CoverGround1)
{
   mapTo = "groundcover1";
   diffuseMap[0] = "MK4_Coverground1";
   normalMap[0] = "MK4_Coverground1_nmp.dds";
   translucent = "1";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
};

singleton Material(MK4_Coverground2)
{
   mapTo = "MK4_CoverGround2";
   diffuseMap[0] = "MK4_Coverground2";
   normalMap[0] = "MK4_Coverground2_nmp.dds";
   translucent = "1";
   translucentBlendOp = "LerpAlpha";
   useAnisotropic[0] = "1";
};

singleton Material(MK4_Trop_Plant1_MK4_PlantsA)
{
   mapTo = "MK4_PlantsA";
   diffuseMap[0] = "MK4_Plants_A";
   normalMap[0] = "MK4_Plants_A_nmp.dds";
   useAnisotropic[0] = "1";
   castShadows = "0";
   alphaTest = "1";
   alphaRef = "130";
};

singleton Material(MK4_Licuala_dif)
{
   mapTo = "MK4_Licuala_dif";
   diffuseMap[0] = "art/Packs/Plants/MK4_Trop_Plants/MK4_Licuala";
   specular[0] = "0.960784 0.960784 0.960784 1";
   specularPower[0] = "1";
   translucent = "0";
   specularStrength[0] = "0";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "150";
};
