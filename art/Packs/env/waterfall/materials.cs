//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

//--- waterfall_suds.DAE MATERIALS BEGIN ---
singleton Material(waterfall_suds_scrollingwater)
{
	mapTo = "scrollingwater";

	diffuseMap[0] = "scrollingwater.dds";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "1 1 1 1";
	specularPower[0] = "8";

	doubleSided = false;
	translucent = "1";
	translucentBlendOp = "LerpAlpha";
   alphaRef = "1";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -1.1";
   scrollSpeed[0] = "0.5";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
   animFlags[1] = "0x00000001";
   scrollDir[1] = "0 -1";
   scrollSpeed[1] = "0.5";
   emissive[0] = "0";
   emissive[1] = "0";
   subSurfaceColor[0] = "1 0.2 0.2 1";
   subSurfaceRolloff[0] = "0.2";
   castShadows = "0";
   materialTag0 = "Waterfall";
};

//--- waterfall_suds.DAE MATERIALS END ---


singleton Material(waterfall_suds_scrollingwater_indoors)
{
	mapTo = "scrollingwater_indoors";

	diffuseMap[0] = "scrollingwater_indoors.dds";
	normalMap[0] = "";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "1 1 1 1";
	specularPower[0] = "8";

	doubleSided = false;
	translucent = "1";
	translucentBlendOp = "LerpAlpha";
   alphaRef = "1";
   animFlags[0] = "0x00000001";
   scrollDir[0] = "0 -1.1";
   scrollSpeed[0] = "0.5";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
   animFlags[1] = "0x00000001";
   scrollDir[1] = "0 -1";
   scrollSpeed[1] = "0.5";
   emissive[0] = "1";
   emissive[1] = "1";
   subSurfaceColor[0] = "1 0.2 0.2 1";
   subSurfaceRolloff[0] = "0.2";
   castShadows = "0";
   materialTag0 = "Waterfall";
};

