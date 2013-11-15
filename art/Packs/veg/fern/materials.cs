//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(fern_material)
{
   diffuseMap[0] = "fern_diffuse_transparency.dds";
   normalMap[0] = "fern_normal.dds";
   mapTo = "fern";

   pixelSpecular = 0;
   specular = "1 1 0.85 0.25";
   specularPower = 10;
      
   translucent = true;
   translucentBlendOp = None;
   translucentZWrite = true;
   alphaTest = true;
   alphaRef = 84;

   forestWindEnabled = 1; 
   specularMap[0] = "fern_specular.dds";
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Veg_Fern";
};

//--- Fern_Vert_01.DAE MATERIALS BEGIN ---
singleton Material(Fern_Vert_01_Fern01)
{
	mapTo = "Fern01";

	diffuseMap[0] = "fern_image2.dds";

	diffuseColor[0] = "0.972549 0.752941 0.172549 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "1";

	doubleSided = 1;
	translucent = 0;
	translucentBlendOp = "LerpAlpha";
   alphaTest = "1";
   alphaRef = "110";
   useAnisotropic[0] = "1";
   normalMap[0] = "fern_image3_NRM.dds";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.701961 0.811765 0.027451 1";
};

//--- Fern_Vert_01.DAE MATERIALS END ---
singleton Material(Fern_Vert_02_TextureFern02)
{
   mapTo = "TextureFern02";
   diffuseMap[0] = "fern_image3.dds";
   specular[0] = "0.992157 0.992157 0.992157 1";
   specularPower[0] = "1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.996078 0.996078 0.992157 1";
   normalMap[0] = "fern_image3_NRM.dds";
   specularMap[0] = "fern_image3_SPEC.dds";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.45098 0.439216 0.352941 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "140";
   subSurfaceRolloff[0] = "5";
};

