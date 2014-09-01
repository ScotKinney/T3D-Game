//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------



//CANOPY TREE: UNIVERSAL BARK

singleton Material(mat_canopytree_bark_lodhi)
{
	mapTo = "canopytree_bark_lodhi";
	diffuseMap[0] = "canopytree_bark_diffuse.dds";
	normalMap[0] = "canopytree_bark_normal.dds";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;
	pixelSpecular[0] = 0;
	translucentBlendOp = "None";
        forestWindEnabled = 1;
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
};

singleton Material(mat_canopytree_barkflat_lodhi)
{
	mapTo = "canopytree_barkflat_lodhi";
	diffuseMap[0] = "canopytree_bark_diffuse.dds";
	normalMap[0] = "canopytree_bark_normal.dds";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;
	pixelSpecular[0] = 0;
	translucentBlendOp = "None";
        forestWindEnabled = 1;
        detailScale[0] = "6 6";
        detailNormalMapStrength[0] = "1.5";
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
};

//CANOPY TREE: UNIVERSAL EXTRAS

singleton Material(mat_canopytree_extras_lodhi)
{
	mapTo = "canopytree_extras_lodhi";
	diffuseMap[0] = "canopytree_extras_diffuse_transparency.dds";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 49;
	pixelSpecular[0] = 0;
	translucent = true;
	translucentBlendOp = "LerpAlpha";
        alphaTest = "1";
        alphaRef = "26";
        forestWindEnabled = 1;
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
   castShadows = "0";
};

//CANOPY TREE: NORMAL FOLIAGE

singleton Material(mat_canopytree_lodlo)
{
	mapTo = "canopytree_lodlo";

	diffuseMap[0] = "canopytree_diffuse_transparency.dds";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	translucent = true;
	translucentBlendOp = "LerpAlpha";
        alphaTest = "1";
        alphaRef = "107";
        forestWindEnabled = 1;
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
};

singleton Material(mat_canopytree_fronds_lodhi)
{
	mapTo = "canopytree_fronds_lodhi";
	diffuseMap[0] = "canopytree_fronds_diffuse_transparency.dds";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "19";
	pixelSpecular[0] = 0;
	translucent = true;
	translucentBlendOp = "LerpAlpha";
        alphaTest = "0";
        alphaRef = "94";
        forestWindEnabled = 1;
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
   castShadows = "0";
};

//CANOPY TREE: LIGHT FOLIAGE

singleton Material(mat_canopytree_light_fronds_lodhi)
{
	mapTo = "canopytree_light_fronds_lodhi";

	diffuseMap[0] = "canopytree_fronds_light_diffuse_transparency.dds";
	normalMap[0] = "canopytree_fronds_normal.dds";
	specularMap[0] = "canopytree_fronds_specular.dds";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	translucent = true;
	translucentBlendOp = "None";
        alphaTest = "1";
        alphaRef = "110";
        forestWindEnabled = 1;
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
};

singleton Material(mat_canopytree_light_lodlo)
{
	mapTo = "canopytree_light_lodlo";
	diffuseMap[0] = "canopytree_light_diffuse_transparency.dds";
	normalMap[0] = "canopytree_normal.dds";
	specularMap[0] = "canopytree_specular.dds";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 1;
	pixelSpecular[0] = 0;
	translucent = true;
	translucentBlendOp = "None";
        alphaTest = "1";
        alphaRef = "107";
        forestWindEnabled = 1;
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
};

//CANOPY TREE: DARK FOLIAGE

singleton Material(mat_canopytree_two_dark_fronds_lodhi)
{
	mapTo = "canopytree_dark_fronds_lodhi";
	diffuseMap[0] = "canopytree_fronds_diffuse_transparency";
	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = "10";
	pixelSpecular[0] = 0;
	translucent = true;
	translucentBlendOp = "LerpAlpha";
        alphaTest = "0";
        alphaRef = "1";
        forestWindEnabled = 1;
        materialTag0 = "Trees";
        useAnisotropic[0] = "1";
   castShadows = "0";
};

singleton Material(mat_canopytree_two_dark_lodlo)
{
   mapTo = "canopytree_dark_lodlo";
   diffuseMap[0] = "canopytree_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "61";
   translucent = "1";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   alphaTest = "1";
   alphaRef = "40";
   forestWindEnabled = "1";
   materialTag0 = "Trees";
   castShadows = "0";
};


/////////////Color Effects


singleton Material(canopytree_three_ColorEffectR166G229B229_material)
{
   mapTo = "ColorEffectR166G229B229-material";
   diffuseColor[0] = "0.65098 0.898039 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_three_ColorEffectR135G6B6_material)
{
   mapTo = "ColorEffectR135G6B6-material";
   diffuseColor[0] = "0.529412 0.0235294 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_three_ColorEffectR166G229B229_material)
{
   mapTo = "ColorEffectR166G229B229-material";
   diffuseColor[0] = "0.65098 0.898039 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
   materialTag0 = "Trees";
};

singleton Material(canopytree_three_ColorEffectR135G6B6_material)
{
   mapTo = "ColorEffectR135G6B6-material";
   diffuseColor[0] = "0.529412 0.0235294 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(canopytree_two_ColorEffectR225G88B199_material)
{
   mapTo = "ColorEffectR225G88B199-material";
   diffuseColor[0] = "0.882353 0.345098 0.780392 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrub_one_ColorEffectR224G86B86_material)
{
   mapTo = "ColorEffectR224G86B86-material";
   diffuseColor[0] = "0.878431 0.337255 0.337255 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
