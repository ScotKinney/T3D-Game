//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(deadbush)
{
   diffuseMap[0] = "deadbush_diffuse_transparency.dds";
   normalMap[0] = "deadbush_normals.dds";
   mapTo = "deadbush";
      
   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;

   specularPower[0] = "54";
   pixelSpecular[0] = "0";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
   materialTag0 = "Veg_DeadBush";
};


singleton Material(deadbush)
{
   mapTo = "deadbush";
   diffuseMap[0] = "art/Packs/veg/deadbush/deadbush_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "67";
};

singleton Material(deadbush)
{
   mapTo = "deadbush";
   diffuseMap[0] = "art/Packs/veg/deadbush/deadbush_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/veg/deadbush/deadbush_normals.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/veg/deadbush/deadbush_specular.dds";
   alphaTest = "1";
   alphaRef = "46";
   showFootprints = "0";
};
