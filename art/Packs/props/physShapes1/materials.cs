//-----------------------------------------------------------------------------
// Copyright (C) Sickhead Games, LLC
//-----------------------------------------------------------------------------

singleton Material(pallet_wood_material)
{
   mapTo = "pallet_wood";  
   baseTex[0] = "";
   bumpTex[0] = "";
   overlayTex[0] = "";

//   detailTex[0] = "crate_diffuse_transparency.png";
//   detailScale[0] = "11 16";
//   detailBumpMap[0] = true;

   pixelSpecular = 1;
   specular = "1 1 1 0";
   specularPower = 20;
   diffuseMap[0] = "crate_diffuse_transparency.dds";
   overlayMap[0] = "crate_diffuse_transparency.dds";
   normalMap[0] = "crate_normal_specular.dds";
   materialTag0 = "Prop";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   specularMap[0] = "crate_specular.dds";
   customFootstepSound = "FootStepWood1Sound";

};



//--- pier_piece_1_posts.DAE MATERIALS BEGIN ---
singleton Material(pier_piece_1_posts_pier_material)
{
	mapTo = "pier_material";

	diffuseMap[0] = "tex_pier_dif.dds";
	normalMap[0] = "tex_pier_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "61";
   materialTag0 = "Structure";
   backlight = "1";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   customFootstepSound = "FootStepWood1Sound";
};





//--- fence_post_base.DAE MATERIALS BEGIN ---
singleton Material(fence_post_base_tex_fence)
{
	mapTo = "tex_fence";

	diffuseMap[0] = "tex_fence_dif.dds";
	normalMap[0] = "tex_fence_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "1 1 1 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "100";
   materialTag0 = "Structure";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
};

//--- fence_post_base.DAE MATERIALS END ---

singleton Material(tex_shrine_material)
{
	mapTo = "tex_shrine";

	diffuseMap[0] = "tex_temple_ruins_dif.dds";
	normalMap[0] = "tex_temple_ruins_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   alphaTest = "1";
   alphaRef = "73";
   materialTag0 = "Structure";
   customFootstepSound = "FootStepRock1Sound";
};


singleton Material(tex_shrine_detail_material)
{
	mapTo = "tex_shrine_detail";

	diffuseMap[0] = "tex_temple_ruins_detail_dif.dds";
	normalMap[0] = "tex_temple_ruins_detail_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "1 1 1 1";
	specularPower[0] = 8;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "LerpAlpha";
   materialTag0 = "Structure";
   materialTag1 = "Vegetation";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
};

//--- shrine_bowl_A_unbk.DAE MATERIALS END ---


//--- bridge_base.DAE MATERIALS BEGIN ---
singleton Material(bridge_base_phys_tex_bridge)
{
	mapTo = "phys_tex_bridge";

	diffuseMap[0] = "phys_tex_bridge_dif.dds";
	normalMap[0] = "phys_tex_bridge_nrm.dds";
	specularMap[0] = "";

	diffuseColor[0] = "1 1 1 1";
	specular[0] = "0.9 0.9 0.9 1";
	specularPower[0] = 10;

	doubleSided = false;
	translucent = false;
	translucentBlendOp = "None";
   materialTag0 = "Structure";
   alphaTest = "1";
   alphaRef = "73";
   backLightFactor = "0.9 1.0 0.2";
   forestWindEnabled = "1";
   backlight = "1";
   customFootstepSound = "FootStepWood1Sound";
};

//--- bridge_base.DAE MATERIALS END ---


singleton Material(palletsmall_unbroken_ColorEffectR213G154B229_material)
{
   mapTo = "ColorEffectR213G154B229-material";
   diffuseColor[0] = "0.835294 0.603922 0.898039 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(palletsmall_unbroken_pallet_wood_material)
{
   mapTo = "pallet_wood_material";
   diffuseMap[0] = "crate_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(palletsmall_broken_ColorEffectR225G88B199_material)
{
   mapTo = "ColorEffectR225G88B199-material";
   diffuseColor[0] = "0.882353 0.345098 0.780392 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(crate_square_unbroken_ColorEffectR145G28B177_material)
{
   mapTo = "ColorEffectR145G28B177-material";
   diffuseColor[0] = "0.568627 0.109804 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(pallet_unbroken_ColorEffectR143G225B87_material)
{
   mapTo = "ColorEffectR143G225B87-material";
   diffuseColor[0] = "0.560784 0.882353 0.341177 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(target_unbroken_ColorEffectR113G134B6_material)
{
   mapTo = "ColorEffectR113G134B6-material";
   diffuseColor[0] = "0.443137 0.52549 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};


singleton Material(pier_piece_t_unbroken_ColorEffectR135G110B8_material)
{
   mapTo = "ColorEffectR135G110B8-material";
   diffuseColor[0] = "0.529412 0.431373 0.0313726 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(pier_piece_busted_unbroken_ColorEffectR108G8B136_material)
{
   mapTo = "ColorEffectR108G8B136-material";
   diffuseColor[0] = "0.423529 0.0313726 0.533333 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};


singleton Material(shrine_column_C_base_ColorEffectR177G88B27_material)
{
   mapTo = "ColorEffectR177G88B27-material";
   diffuseColor[0] = "0.694118 0.345098 0.105882 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_D_unbk_ColorEffectR86G86B86_material)
{
   mapTo = "ColorEffectR86G86B86-material";
   diffuseColor[0] = "0.337255 0.337255 0.337255 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_D_unbk_ColorEffectR224G86B86_material)
{
   mapTo = "ColorEffectR224G86B86-material";
   diffuseColor[0] = "0.878431 0.337255 0.337255 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_E_unbk_ColorEffectR113G135B6_material)
{
   mapTo = "ColorEffectR113G135B6-material";
   diffuseColor[0] = "0.443137 0.529412 0.0235294 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_E_unbk_ColorEffectR141G7B58_material)
{
   mapTo = "ColorEffectR141G7B58-material";
   diffuseColor[0] = "0.552941 0.027451 0.227451 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_C_bk_ColorEffectR28G149B177_material)
{
   mapTo = "ColorEffectR28G149B177-material";
   diffuseColor[0] = "0.109804 0.584314 0.694118 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};


singleton Material(shrine_column_A_bk_ColorEffectR87G225B87_material)
{
   mapTo = "ColorEffectR87G225B87-material";
   diffuseColor[0] = "0.341177 0.882353 0.341177 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_A_bk_ColorEffectR148G177B27_material)
{
   mapTo = "ColorEffectR148G177B27-material";
   diffuseColor[0] = "0.580392 0.694118 0.105882 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_A_bk_ColorEffectR138G8B110_material)
{
   mapTo = "ColorEffectR138G8B110-material";
   diffuseColor[0] = "0.541176 0.0313726 0.431373 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(shrine_column_C_bk_ColorEffectR177G148B27_material)
{
   mapTo = "ColorEffectR177G148B27-material";
   diffuseColor[0] = "0.694118 0.580392 0.105882 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};

singleton Material(target_unbroken_pier_wood)
{
   mapTo = "pier_wood";
   diffuseMap[0] = "pier_diffuse_transparency";
   specular[0] = "0.9 0.9 0.9 1";
   specularPower[0] = "10";
   translucentBlendOp = "None";
};
