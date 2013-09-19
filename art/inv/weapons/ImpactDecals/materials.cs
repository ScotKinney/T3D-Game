
singleton Material(DECAL_scorch)
{
   diffuseMap[0] = "art/inv/weapons/ImpactDecals/scorch_Decal";
   normalMap[0] = "art/inv/weapons/ImpactDecals/scorch_decal.png";
   translucent = "1";
   alphaTest = "1"; //<-- LINE CHANGED   
   alphaRef = "53";   
   translucentZWrite = "0"; //<-- LINE CHANGED   
   castShadows = "0"; //<-- LINE ADDED   
   translucentBlendOp = "None"; //<-- LINE ADDED
   materialTag0 = "decal";
   mapTo = "scorch_Decal";
};

singleton Material(DECAL_RocketEXP)
{
 
   diffuseMap[0] = "rBlast";
   normalMap[0] = "rBlast";
   translucent = "1";
   alphaTest = "1"; //<-- LINE CHANGED   
   alphaRef = "50";   
   translucentZWrite = "0"; //<-- LINE CHANGED   
   castShadows = "0"; //<-- LINE ADDED   
   translucentBlendOp = "None"; //<-- LINE ADDED
};

