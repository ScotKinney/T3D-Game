singleton Material(mat_bigleaf_GG)
{
   mapTo = "bigleaf";
   diffuseMap[0] = "art/Packs/Plants/AV_Tropical/bigleaf_diffuse_transparency.dds";
   specular = "1 1 0.75 0.25";
   specularPower = 10;
   translucent = "0";
   translucentZWrite = "0";
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1;
   useAnisotropic[0] = "1";   
   materialTag0 = "Plants_AVTrop";
   castShadows = "0";
};
singleton Material(mat_broadleaf_GG)
{
   mapTo = "broadleaf";
   diffuseMap[0] = "broadleaf_diffuse_transparency.dds";
   specular = "1 1 0.85 0"; // 1 1 0 0 = pure yellow
   specularPower = 1;
   translucent = "0";
   translucentZWrite = "0";
   alphaTest = "0";
   alphaRef = "0";
   forestWindEnabled = 1;   
   materialTag0 = "Plants_AVTrop";
   useAnisotropic[0] = "1";
   castShadows = "0";
   showFootprints = "0";
};
singleton Material(mat_deadbush_GG)
{
   mapTo = "deadbush";
   diffuseMap[0] = "deadbush_diffuse_transparency.dds";
   normalMap[0] = "deadbush_normals.dds";  
   translucent = true;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   specularPower[0] = "54";
   forestWindEnabled = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Plants_AVTrop";
};
singleton Material(mat_fern_GG)
{
   mapTo = "fern";   
   diffuseMap[0] = "fern_diffuse_transparency.dds";
   specular = "1 1 0.85 0.25";
   specularPower = 10;
   translucent = "0";
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1; 
   materialTag0 = "Plants_AVTrop";
   useAnisotropic[0] = "1";
};
singleton Material(mat_longleaf_GG)
{
   mapTo = "longleaf_fronds";
   diffuseMap[0] = "longleafleaves_diffuse_transparency.dds";
   pixelSpecular = "0";
   specular = "1 1 1 0"; // 1 1 0 0 = pure yellow
   specularPower = "128";
   translucent = "0";
   translucentZWrite = "0";
   alphaTest = true;
   alphaRef = "114";
   forestWindEnabled = 1;   
   useAnisotropic[0] = "1";
   materialTag0 = "Plants_AVTrop";
   castShadows = "0";
};

singleton Material(bigleaf_ColorEffectR227G153B153_material)
{
   mapTo = "ColorEffectR227G153B153-material";
   diffuseColor[0] = "0.890196 0.6 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};


