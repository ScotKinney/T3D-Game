//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(bigleaf_material)
{
   baseTex[0] = "";
   bumpTex[0] = "";
   mapTo = "bigleaf";

   pixelSpecular = 0;
   specular = "1 1 0.75 0.25";
   specularPower = 10;
      
   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   
   // NOTE: This would be nice to have!
   backlight = 1;
   backLightFactor = "0.9 1.0 0.2";

   forestWindEnabled = 1;   
   diffuseMap[0] = "bigleaf_diffuse_transparency.dds";
   normalMap[0] = "bigleaf_normals_specular.dds";
   materialTag0 = "Vegetation";
   specularMap[0] = "bigleaf_specular.dds";
   materialTag1 = "Vegetation";
};



