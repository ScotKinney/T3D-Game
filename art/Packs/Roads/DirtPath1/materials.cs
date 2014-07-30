singleton Material( mat_DirtPath1 )
{
   baseTex[0] = "";
   mapTo = "DirtPath1";
   diffuseMap[0] = "DirtPath1_dif";
   normalMap[0] = "DirtPath1_nmp.dds";
   specularMap[0] = "DirtPath1_spec";
   specularPower[0] = "1";
   translucent = true;
   translucentBlendOp = LerpAlpha;
   translucentZWrite = true;
   alphaTest = true; 
   alphaRef = 75;
   materialTag0 = "RoadAndPath";
};