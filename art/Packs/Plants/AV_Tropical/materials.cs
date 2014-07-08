
singleton Material(mat_Phila01)
{
   mapTo = "_1_-_Default";
   diffuseMap[0] = "PhilLeaf01";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "Sub";
   normalMap[0] = "PhilLeaf01_NRM.dds";
   specularMap[0] = "PhilLeaf01_SPEC.dds";
   useAnisotropic[0] = "1";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.768628 1 0 1";
   alphaTest = "1";
   alphaRef = "127";
   forestWindEnabled = 1;
   pixelSpecular[0] = "1";
   materialTag0 = "Plants_Phila_AV";
};

singleton Material(mat_TropicFern01_GG)
{
   mapTo = "TropicFern01";
   diffuseMap[0] = "fern_image2";
   normalMap[0] = "fern_image2_NRM.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   specularMap[0] = "fern_image2_SPEC.dds";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.643137 0.815686 0.321569 1";
   translucentBlendOp = "Sub";
   alphaTest = "1";
   alphaRef = "147";
   diffuseColor[0] = "1 0.858824 0 1";
   forestWindEnabled = 1;
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Plants_TropicFern_AV";
};

singleton Material(mat_TropicFernSprout_GG)
{
   mapTo = "FernSprout01";
   diffuseMap[0] = "ferntop";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   useAnisotropic[0] = "1";
   translucentBlendOp = "Sub";
   alphaTest = "1";
   alphaRef = "167";
   diffuseColor[0] = "1 0.882353 0 1";
   normalMap[0] = "ferntop.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "ferntop.dds";
   materialTag0 = "Plants_TropicFernSprout_AV";
};

singleton Material(mat_bigleaf_GG)
{
   mapTo = "bigleaf";
   diffuseMap[0] = "bigleaf_diffuse_transparency.dds";
   normalMap[0] = "bigleaf_normals_specular.dds";
   specularMap[0] = "bigleaf_specular.dds";
   specular = "1 1 0.75 0.25";
   specularPower = 10;
   translucent = "0";
   translucentZWrite = "0";
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1;
   useAnisotropic[0] = "1";   
   materialTag0 = "Plants_GG";
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
   materialTag0 = "Plants_GG";
};

singleton Material(mat_longleaf_GG)
{
   mapTo = "longleaf_fronds";
   diffuseMap[0] = "longleafleaves_diffuse_transparency.dds";
   normalMap[0] = "longleafleaves_normal_specular.dds";
   specularMap[0] = "longleafleaves_normal.dds";
   pixelSpecular = "1";
   specular = "1 1 1 0"; // 1 1 0 0 = pure yellow
   specularPower = "128";
   translucent = "0";
   translucentZWrite = "0";
   alphaTest = true;
   alphaRef = "114";
   forestWindEnabled = 1;   
   useAnisotropic[0] = "1";
   materialTag0 = "Plants_GG";
};

singleton Material(bigleaf_ColorEffectR227G153B153_material)
{
   mapTo = "ColorEffectR227G153B153-material";
   diffuseColor[0] = "0.890196 0.6 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(mat_broadleaf_GG)
{
   mapTo = "broadleaf";
   diffuseMap[0] = "broadleaf_diffuse_transparency.dds";
   normalMap[0] = "broadleaf_normal_specular.dds";
   specularMap[0] = "broadleaf_specular.dds";
   specular = "1 1 0.85 0"; // 1 1 0 0 = pure yellow
   specularPower = 1;
   translucent = true;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1;   
   materialTag0 = "Plants_BroadLeaf_GG";
};

singleton Material(mat_fern_GG)
{
   mapTo = "fern";   
   diffuseMap[0] = "fern_diffuse_transparency.dds";
   normalMap[0] = "fern_normal.dds";
   specularMap[0] = "fern_specular.dds";
   specular = "1 1 0.85 0.25";
   specularPower = 10;
   translucent = true;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   forestWindEnabled = 1; 
   materialTag0 = "Plants_Fern_GG";
};