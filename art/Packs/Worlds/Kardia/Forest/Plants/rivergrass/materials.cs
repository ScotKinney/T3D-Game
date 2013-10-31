//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

singleton Material(rivergrass_material)
{
	mapTo = "rivergrass";

	diffuseMap[0] = "rivergrass_diffuse_transparency.dds";
	normalMap[0] = "rivergrass_normal.dds";
	specularMap[0] = "rivergrass_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 13;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   pixelSpecular[0] = "0";
   alphaTest = "1";
   alphaRef = "114";
   materialTag0 = "Vegetation";
   materialTag1 = "Vegetation";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
};



