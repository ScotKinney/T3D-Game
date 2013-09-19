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

