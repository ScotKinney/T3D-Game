
singleton Material(mat_DeerhideEdge)
{
   mapTo = "black";
   diffuseMap[0] = "art/shapes/items/DeerHide/transparent.png";
   translucentBlendOp = "LerpAlpha";
   alphaRef = "0";
   castShadows = "0";
   translucent = "1";
};

singleton Material(mat_Deerhide)
{
   mapTo = "deerhide";
   diffuseMap[0] = "art/shapes/items/DeerHide/deerhide.png";
   castShadows = "0";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0";
};

singleton Material(matDeerHideTrans)
{
   mapTo = "transparent";
   diffuseMap[0] = "art/shapes/items/deerhide/transparent";
   translucent = "1";
};
