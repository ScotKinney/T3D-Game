//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(bigleaf_material)
{
   mapTo = "bigleaf";

   pixelSpecular = "1";
   specular = "1 1 0.75 0.25";
   specularPower = "11";
      
   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;
   
   // NOTE: This would be nice to have!
   backlight = 1;
   backLightFactor = "0.9 1.0 0.2";

   forestWindEnabled = 1;   
   diffuseMap[0] = "art/Packs/worlds/kardia/Models/Forest/Plants/bigleaf/bigleaf_diffuse_transparency.dds";
   normalMap[0] = "art/Packs/worlds/kardia/Models/Forest/Plants/bigleaf/bigleaf_normals_specular.dds";
   materialTag0 = "Vegetation";
   specularMap[0] = "art/Packs/worlds/kardia/Models/Forest/Plants/bigleaf/bigleaf_specular.dds";
   materialTag1 = "Vegetation";
   specularStrength[0] = "2.84314";
   useAnisotropic[0] = "1";
};




singleton Material(bigleaf_ColorEffectR227G153B153_material)
{
   mapTo = "ColorEffectR227G153B153-material";
   diffuseColor[0] = "0.890196 0.6 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(bigleaf)
{
   mapTo = "bigleaf";
   diffuseMap[0] = "art/Packs/plants/bigleaf/bigleaf_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/Plants/bigleaf/bigleaf_normals.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/Plants/bigleaf/bigleaf_specular.dds";
   alphaTest = "1";
   alphaRef = "134";
   showFootprints = "0";
};

singleton Material(bigleaf_ColorEffectR227G153B153_material)
{
   mapTo = "ColorEffectR227G153B153-material";
   diffuseColor[0] = "0.890196 0.6 0.6 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
