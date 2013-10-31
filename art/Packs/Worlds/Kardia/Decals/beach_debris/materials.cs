//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(DECAL_beachdebris01)
{
   diffuseMap[0] = "beachdebris_01_diffuse_transparency.dds";
   normalMap[0] = "beachdebris_01_normals.dds";


   translucent = 1;
   translucentBlendOp = LerpAlpha;
   translucentZWrite = 1;
   alphaTest = 0;
   alphaRef = 1;
   mapTo = "sedimentary.png";

   materialTag0 = "decal";
   specularPower[0] = "91";
   pixelSpecular[0] = "1";

   useAnisotropic[0] = true;
   vertColor[0] = "1";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
};
