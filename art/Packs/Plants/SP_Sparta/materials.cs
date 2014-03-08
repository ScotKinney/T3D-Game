
singleton Material(TropicFern01)
{
   mapTo = "TropicFern01";
   diffuseMap[0] = "fern_image2";
   normalMap[0] = "fern_image2_NRM.dds";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   specularMap[0] = "fern_image2_SPEC.dds";
   subSurface[0] = "0";
   subSurfaceColor[0] = "0.643137 0.815686 0.321569 1";
   doubleSided = "1";
   translucentBlendOp = "Sub";
   alphaTest = "1";
   alphaRef = "147";
   diffuseColor[0] = "1 0.858824 0 1";
   forestWindEnabled = 1;
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(TropicFern01_FernSprout01)
{
   mapTo = "FernSprout01";
   diffuseMap[0] = "ferntop";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   translucentBlendOp = "Sub";
   alphaTest = "1";
   alphaRef = "167";
   diffuseColor[0] = "1 0.882353 0 1";
   normalMap[0] = "ferntop.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "ferntop.dds";
   showFootprints = "0";
};

singleton Material(TropicFern01)
{
   mapTo = "TropicFern01";
   diffuseMap[0] = "fern_image2";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "Sub";
   translucent = "0";
   alphaTest = "1";
   alphaRef = "140";
};
