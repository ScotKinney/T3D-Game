
singleton Material(GroundCover2)
{
   mapTo = "GroundCover2";
   diffuseMap[0] = "groundcover_diffuse_transparency.png";
   translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "130";
   materialTag0 = "GroundCover";
   translucent = "1";
   translucentZWrite = "1";
   //normalMap[0] = "groundcover_normals.dds";
   //specularMap[0] = "groundcover_specular.dds";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
};

new Material(grass142)
{
   mapTo = "grass142";
   diffuseMap[0] = "grass142";
   translucentZWrite = true;
   translucent = true;
   translucentBlendOp = None;
   alphaTest = true;  // default value
   alphaRef = 150;   // alpha less than 128 in brightness (255 is max) will not be rendered
   materialTag0 = "GroundCover";
};

new Material(material_cattails003)
{
   mapTo = "cattails003";
   diffuseMap[0] = "cattails003";
   translucentZWrite = true;
   translucent = true;
   translucentBlendOp = None;
   alphaTest = true;  // default value
   alphaRef = 150;   // alpha less than 128 in brightness (255 is max) will not be rendered
   materialTag0 = "GroundCover";
};

new Material(material_L_Kelp_001)
{
   mapTo = "L_Kelp_001";
   diffuseMap[0] = "L_Kelp_001";
   translucentZWrite = true;
   translucent = true;
   translucentBlendOp = None;
   alphaTest = true;  // default value
   alphaRef = 150;   // alpha less than 128 in brightness (255 is max) will not be rendered
   materialTag0 = "GroundCover";
};

singleton Material(mat_rivergrass)
{
   mapTo = "rivergrass";
   diffuseMap[0] = "rivergrass_diffuse_transparency.dds";
   translucent = "1";
   alphaTest = "1"; 
   translucentZWrite = "0";
   castShadows = "0";
   translucentBlendOp = "None";
   materialTag0 = "trees";
   useAnisotropic[0] = "1";
   alphaRef = "40";
   useAnisotropic[0] = "1";
   materialTag0 = "GroundCover";
};
