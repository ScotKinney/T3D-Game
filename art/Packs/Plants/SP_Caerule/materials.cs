singleton Material(mat_broadleaf_GG)
{
   mapTo = "broadleaf";
   specular = "1 1 0.85 0"; // 1 1 0 0 = pure yellow
   specularPower = 1;
   translucent = true;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1;   
   diffuseMap[0] = "broadleaf_diffuse_transparency.dds";
   normalMap[0] = "broadleaf_normal_specular.dds";
   specularMap[0] = "broadleaf_specular.dds";
   materialTag0 = "Plants_BroadLeaf_GG";
};

singleton Material(mat_fern_GG)
{
   mapTo = "fern";   
   diffuseMap[0] = "fern_diffuse_transparency.dds";
   normalMap[0] = "fern_normal.dds";
   specular = "1 1 0.85 0.25";
   specularPower = 10;
   translucent = true;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1; 
   specularMap[0] = "fern_specular.dds";
   materialTag0 = "Plants_Fern_GG";
};