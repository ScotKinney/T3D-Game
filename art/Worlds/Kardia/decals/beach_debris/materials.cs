singleton Material(DECAL_beachdebris01)
{
   mapTo = "sedimentary.png";   
   diffuseMap[0] = "beachdebris_01_diffuse_transparency.dds";
   normalMap[0] = "beachdebris_01_normals.dds";
   translucent = 1;
   translucentBlendOp = LerpAlpha;
   translucentZWrite = 1;
   alphaTest = 0;
   alphaRef = 1;
   specularPower[0] = "91";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = true;
   vertColor[0] = "1";
   materialTag0 = "decal_BeachDebris";
};
