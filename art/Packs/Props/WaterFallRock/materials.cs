singleton Material(mat_suds_scrollingwater)
{
   mapTo = "scrollingwater";
   diffuseMap[0] = "scrollingwater.dds";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "1 1 1 1";
   specularPower[0] = "8";
   translucent = "1";
   translucentBlendOp = "LerpAlpha";
   alphaRef = "1";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -1.1";
   scrollSpeed[0] = "0.5";
   animFlags[1] = "0x00000001";
   scrollDir[1] = "0 -1";
   scrollSpeed[1] = "0.5";
   subSurfaceColor[0] = "1 0.2 0.2 1";
   subSurfaceRolloff[0] = "0.2";
   materialTag0 = "GG_Waterfall";
};

singleton Material(mat_scrollingwater)
{
   mapTo = "scrollingwater_indoors";
   diffuseMap[0] = "scrollingwater_indoors.dds";
   diffuseColor[0] = "1 1 1 1";
   specular[0] = "1 1 1 1";
   specularPower[0] = "8";
   translucent = "1";
   translucentBlendOp = "LerpAlpha";
   alphaRef = "1";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -1.1";
   scrollSpeed[0] = "0.5";
   animFlags[1] = "0x00000001";
   scrollDir[1] = "0 -1";
   scrollSpeed[1] = "0.5";
   emissive[0] = "1";
   subSurfaceColor[0] = "1 0.2 0.2 1";
   subSurfaceRolloff[0] = "0.2";
   materialTag0 = "GG_Waterfall";
};
