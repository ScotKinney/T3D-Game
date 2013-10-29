
singleton Material(mat_DeerhideEdge)
{
   mapTo = "black";
   diffuseMap[0] = "art/inv/items/DeerHide/transparent";
   translucentBlendOp = "LerpAlpha";
   alphaRef = "0";
   castShadows = "0";
   translucent = "1";
};

singleton Material(mat_Deerhide)
{
   mapTo = "deerhide";
   diffuseMap[0] = "art/inv/items/DeerHide/deerhide";
   castShadows = "0";
   translucent = "1";
   alphaTest = "1";
   alphaRef = "0";
};

