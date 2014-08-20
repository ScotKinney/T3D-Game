
singleton Material(HoverCraft_Skirt)
{
   mapTo = "Skirt";
   diffuseColor[0] = "0.3 0.3 0.3 1";
   specular[0] = "0.23 0.23 0.23 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
};

singleton Material(HoverCraft_Windows)
{
   mapTo = "Windows";
   diffuseColor[0] = "0.239216 0.239216 0.239216 1";
   specular[0] = "0 0.517451 0.91 1";
   specularPower[0] = "128";
   translucentBlendOp = "LerpAlpha";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   translucent = "1";
   alphaRef = "0";
};

singleton Material(HoverCraft_Chassis)
{
   mapTo = "Chassis";
   diffuseColor[0] = "0.984314 0.984314 0.980392 1";
   specular[0] = "0.870588 0.870588 0.870588 1";
   specularPower[0] = "36";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "Miscellaneous";
};
