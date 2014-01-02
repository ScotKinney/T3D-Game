singleton Material(LightnBolt)
{
   mapTo = "BoltMat";
   diffuseMap[0] = "art/particles/LightningBolt/LightningBolt.jpg";
   glow[0] = "1";
};

singleton Material(LightningBolt_BoltMat)
{
   mapTo = "BoltMat";
   diffuseColor[0] = "0.8 0.8 0.8 1";
   specular[0] = "0.5 0.5 0.5 1";
   specularPower[0] = "128";
   doubleSided = "1";
   translucentBlendOp = "None";
   glow[0] = "1";
};

singleton Material(LighnBolt)
{
   mapTo = "BoltMat";
   diffuseMap[0] = "art/particles/LightningBolt/LightningBolt.jpg";
   glow[0] = "1";
   materialTag0 = "Miscellaneous";
};
