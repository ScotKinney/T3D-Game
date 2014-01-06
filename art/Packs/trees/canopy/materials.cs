//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------



//CANOPY TREE: UNIVERSAL BARK

singleton Material(canopytree_bark_lodhi_material)
{
	mapTo = "canopytree_bark_lodhi";

	diffuseMap[0] = "canopytree_bark_diffuse.dds";
	normalMap[0] = "canopytree_bark_normal.dds";
	specularMap[0] = "canopytree_bark_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";

   forestWindEnabled = 1;
   detailNormalMap[0] = "canopytree_bark_detail_normal.dds";
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};



singleton Material(canopytree_barkflat_lodhi_material)
{
	mapTo = "canopytree_barkflat_lodhi";

	diffuseMap[0] = "canopytree_bark_diffuse.dds";
	normalMap[0] = "canopytree_bark_normal.dds";
	specularMap[0] = "canopytree_bark_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";

   forestWindEnabled = 1;
   detailNormalMap[0] = "canopytree_bark_detail_normal.dds";
   detailScale[0] = "6 6";
   detailNormalMapStrength[0] = "1.5";
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};


//CANOPY TREE: UNIVERSAL EXTRAS

singleton Material(canopytree_extras_lodhi_material)
{
	mapTo = "canopytree_extras_lodhi";

	diffuseMap[0] = "canopytree_extras_diffuse_transparency.dds";
	normalMap[0] = "canopytree_extras_normal.dds";
	specularMap[0] = "canopytree_extras_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 49;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = true;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "26";

   forestWindEnabled = 1;
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};


//CANOPY TREE: NORMAL FOLIAGE

singleton Material(canopytree_fronds_lodhi_material)
{
	mapTo = "canopytree_fronds_lodhi";

	diffuseMap[0] = "canopytree_fronds_diffuse_transparency.dds";
	normalMap[0] = "canopytree_fronds_normal.dds";
	specularMap[0] = "canopytree_fronds_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = true;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "110";

   forestWindEnabled = 1;
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};



singleton Material(canopytree_lodlo_material)
{
	mapTo = "canopytree_lodlo";

	diffuseMap[0] = "canopytree_diffuse_transparency.dds";
	normalMap[0] = "canopytree_normal.dds";
	specularMap[0] = "canopytree_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = true;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "107";

   forestWindEnabled = 1;
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};


//CANOPY TREE: LIGHT FOLIAGE

singleton Material(canopytree_light_fronds_lodhi_material)
{
	mapTo = "canopytree_light_fronds_lodhi";

	diffuseMap[0] = "canopytree_fronds_light_diffuse_transparency.dds";
	normalMap[0] = "canopytree_fronds_normal.dds";
	specularMap[0] = "canopytree_fronds_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = true;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "110";

   forestWindEnabled = 1;
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};



singleton Material(canopytree_light_lodlo_material)
{
	mapTo = "canopytree_light_lodlo";

	diffuseMap[0] = "canopytree_light_diffuse_transparency.dds";
	normalMap[0] = "canopytree_normal.dds";
	specularMap[0] = "canopytree_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = true;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "107";

   forestWindEnabled = 1;
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};




//CANOPY TREE: DARK FOLIAGE

singleton Material(canopytree_dark_fronds_lodhi_material)
{
	mapTo = "canopytree_dark_fronds_lodhi";

	diffuseMap[0] = "canopytree_fronds_dark_diffuse_transparency.dds";
	normalMap[0] = "canopytree_fronds_normal.dds";
	specularMap[0] = "canopytree_fronds_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = true;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "110";

   forestWindEnabled = 1;
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};



singleton Material(canopytree_dark_lodlo_material)
{
	mapTo = "canopytree_dark_lodlo";

	diffuseMap[0] = "canopytree_dark_diffuse_transparency.dds";
	normalMap[0] = "canopytree_normal.dds";
	specularMap[0] = "canopytree_specular.dds";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	emissive[0] = false;

	doubleSided = false;
	translucent = true;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "107";

   forestWindEnabled = 1;
   backLightFactor = "0.9 1.0 0.2";
   backlight = "1";
   materialTag0 = "Tree_Canopy";
};

singleton Material(canopytree_three_ColorEffectR166G229B229_material)
{
   mapTo = "ColorEffectR166G229B229-material";
   diffuseColor[0] = "0.65098 0.898039 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Tree_Canopy";
};

singleton Material(canopytree_three_ColorEffectR135G6B6_material)
{
   mapTo = "ColorEffectR135G6B6-material";
   diffuseColor[0] = "0.529412 0.0235294 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Tree_Canopy";
};

singleton Material(canopytree_two_canopytree_dark_fronds_lodhi)
{
   mapTo = "canopytree_dark_fronds_lodhi";
   diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};

singleton Material(canopytree_two_canopytree_extras_lodhi)
{
   mapTo = "canopytree_extras_lodhi";
   diffuseMap[0] = "canopytree_extras_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_canopytree_dark_lodlo)
{
   mapTo = "canopytree_dark_lodlo";
   diffuseMap[0] = "canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};


singleton Material(canopytree_two_canopytree_barkflat_lodhi)
{
   mapTo = "canopytree_barkflat_lodhi";
   diffuseMap[0] = "canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_bark_lodhi)
{
   mapTo = "canopytree_bark_lodhi";
   diffuseMap[0] = "canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_fronds_lodhi)
{
   mapTo = "canopytree_fronds_lodhi";
   diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_extras_lodhi)
{
   mapTo = "canopytree_extras_lodhi";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_extras_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/trees/canopy/canopytree_extras_normal_specular.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/trees/canopy/canopytree_extras_specular.dds";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "33";
   showFootprints = "0";
};

singleton Material(shrub_one_canopytree_bark_lodhi)
{
   mapTo = "canopytree_bark_lodhi";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/trees/canopy/canopytree_bark_normal_specular.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/trees/canopy/canopytree_bark_specular.dds";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};

singleton Material(shrub_one_canopytree_fronds_lodhi)
{
   mapTo = "canopytree_fronds_lodhi";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/trees/canopy/canopytree_fronds_normal_specular.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/trees/canopy/canopytree_fronds_specular.dds";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "73";
   showFootprints = "0";
};

singleton Material(canopytree_two_canopytree_dark_fronds_lodhi)
{
   mapTo = "canopytree_dark_fronds_lodhi";
   diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};

singleton Material(canopytree_two_canopytree_dark_lodlo)
{
   mapTo = "canopytree_dark_lodlo";
   diffuseMap[0] = "canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};

singleton Material(canopytree_two_ColorEffectR225G88B199_material)
{
   mapTo = "ColorEffectR225G88B199-material";
   diffuseColor[0] = "0.882353 0.345098 0.780392 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_canopytree_barkflat_lodhi)
{
   mapTo = "canopytree_barkflat_lodhi";
   diffuseMap[0] = "canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_one_novines_canopytree_lodlo)
{
   mapTo = "canopytree_lodlo";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "1";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "100";
   showFootprints = "0";
};

singleton Material(shrub_one_canopytree_extras_lodhi)
{
   mapTo = "canopytree_extras_lodhi";
   diffuseMap[0] = "canopytree_extras_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_bark_lodhi)
{
   mapTo = "canopytree_bark_lodhi";
   diffuseMap[0] = "canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_fronds_lodhi)
{
   mapTo = "canopytree_fronds_lodhi";
   diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_canopytree_dark_fronds_lodhi)
{
   mapTo = "canopytree_dark_fronds_lodhi";
   diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};

singleton Material(canopytree_two_canopytree_dark_lodlo)
{
   mapTo = "canopytree_dark_lodlo";
   diffuseMap[0] = "canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};

singleton Material(canopytree_two_ColorEffectR225G88B199_material)
{
   mapTo = "ColorEffectR225G88B199-material";
   diffuseColor[0] = "0.882353 0.345098 0.780392 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_canopytree_barkflat_lodhi)
{
   mapTo = "canopytree_barkflat_lodhi";
   diffuseMap[0] = "canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_one_novines_canopytree_lodlo)
{
   mapTo = "canopytree_lodlo";
   diffuseMap[0] = "canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_extras_lodhi)
{
   mapTo = "canopytree_extras_lodhi";
   diffuseMap[0] = "canopytree_extras_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_bark_lodhi)
{
   mapTo = "canopytree_bark_lodhi";
   diffuseMap[0] = "canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_canopytree_fronds_lodhi)
{
   mapTo = "canopytree_fronds_lodhi";
   diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_canopytree_dark_fronds_lodhi)
{
   mapTo = "canopytree_dark_fronds_lodhi";
   diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};

singleton Material(canopytree_two_canopytree_dark_lodlo)
{
   mapTo = "canopytree_dark_lodlo";
   diffuseMap[0] = "canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "1";
};

singleton Material(canopytree_two_ColorEffectR225G88B199_material)
{
   mapTo = "ColorEffectR225G88B199-material";
   diffuseColor[0] = "0.882353 0.345098 0.780392 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_canopytree_barkflat_lodhi)
{
   mapTo = "canopytree_barkflat_lodhi";
   diffuseMap[0] = "canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_one_novines_canopytree_lodlo)
{
   mapTo = "canopytree_lodlo";
   diffuseMap[0] = "canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_canopytree_dark_fronds_lodhi)
{
   mapTo = "canopytree_dark_fronds_lodhi";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_fronds_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucent = "0";
   normalMap[0] = "art/Packs/trees/canopy/canopytree_fronds_normal_specular.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/trees/canopy/canopytree_fronds_specular.dds";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "127";
   showFootprints = "0";
};

singleton Material(canopytree_two_canopytree_extras_lodhi)
{
   mapTo = "canopytree_extras_lodhi";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_extras_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/trees/canopy/canopytree_extras_normal_specular.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/trees/canopy/canopytree_extras_specular.dds";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "26";
   showFootprints = "0";
};

singleton Material(canopytree_two_canopytree_dark_lodlo)
{
   mapTo = "canopytree_dark_lodlo";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucent = "0";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "73";
   showFootprints = "0";
};


singleton Material(canopytree_two_canopytree_barkflat_lodhi)
{
   mapTo = "canopytree_barkflat_lodhi";
   diffuseMap[0] = "art/packs/Trees/Canopy/canopytree_bark_diffuse";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   normalMap[0] = "art/Packs/trees/canopy/canopytree_bark_normal.dds";
   pixelSpecular[0] = "1";
   specularMap[0] = "art/Packs/trees/canopy/canopytree_bark_specular.dds";
   useAnisotropic[0] = "1";
   showFootprints = "0";
};
