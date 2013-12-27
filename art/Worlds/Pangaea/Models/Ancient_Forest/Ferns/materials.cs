//--- Fern_Vert_01.DAE MATERIALS BEGIN ---
singleton Material(Fern_Vert_01_Fern01)
{
	mapTo = "Fern01";

	diffuseMap[0] = "fern_image2.dds";

	diffuseColor[0] = "0.909804 0.615686 0.00784314 1";
	specular[0] = "0.529412 0.588235 0.176471 1";
	specularPower[0] = "1";

	doubleSided = 1;
	translucent = 0;
	translucentBlendOp = "LerpAlpha";
   alphaTest = "1";
   alphaRef = "110";
   useAnisotropic[0] = "1";
   normalMap[0] = "fern_image3_NRM.dds";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.411765 0.47451 0.0196078 1";
   specularStrength[0] = "0.490196";
   pixelSpecular[0] = "0";
};

//--- Fern_Vert_01.DAE MATERIALS END ---


singleton Material(Fern_Vert_02_TextureFern02)
{
   mapTo = "TextureFern02";
   diffuseMap[0] = "fern_image3.dds";
   specular[0] = "0.992157 0.992157 0.992157 1";
   specularPower[0] = "1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.756863 0.568627 0.25098 1";
   normalMap[0] = "fern_image3_NRM.dds";
   subSurface[0] = "1";
   subSurfaceColor[0] = "0.309804 0.431373 0.0313726 1";
   doubleSided = "1";
   alphaTest = "1";
   alphaRef = "140";
   subSurfaceRolloff[0] = "5";
   useAnisotropic[0] = "1";
};
