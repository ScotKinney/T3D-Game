singleton Material(mat_pool1)
{
   mapTo = "pool1";
   diffuseColor[0] = "0.788235 0.784314 0.764706 1";
   specular[0] = "1 1 1 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepGrass1Sound";
   materialTag0 = "SkyCity";
};

singleton Material(mat_pool2)
{
   mapTo = "pool2";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.788235 0.890196 0.905882 1";
};

singleton Material(mat_stairs)
{
   mapTo = "stairs";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   diffuseColor[0] = "0.698039 0.690196 0.670588 1";
   customFootstepSound = "FootStepMetal1Sound";
   materialTag0 = "SkyCity";
};

singleton Material(mat_stairs2)
{
   mapTo = "stairs2";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.8 0.792157 0.74902 1";
   detailDistance = "500";
   detailSize = "4";
   diffuseSize = "128";
   detailStrength = "0.5";
};

singleton Material(mat_walk2)
{
   mapTo = "walk2";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   diffuseColor[0] = "0.8 0.792 0.749 1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "SkyCity";
   detailDistance = "500";
   detailSize = "4";
   diffuseSize = "128";
   detailStrength = "0.5";
};

singleton Material(mat_walk2)
{
   mapTo = "walk2";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.909804 0.909804 0.854902 1";
};

singleton Material(mat_default2)
{
   mapTo = "default2";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepWood1Sound";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.176471 0.176471 0.176471 1";
};


////////////////////////////////FutureCity Materials


singleton Material(mat_DownTownE)
{
   mapTo = "DownTownE";
   diffuseMap[0] = "DownTownE";
   specular[0] = "0.835294 0.835294 0.835294 1";
   specularPower[0] = "54";
   translucent = "0";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   normalMap[0] = "DownTownE_NRM.dds";
   doubleSided = "1";
   customFootstepSound = "FootStepMetal1Sound";
};

singleton Material(mat_ElevatorGlass)
{
   mapTo = "ElevatorGlass";
   diffuseMap[0] = "ElevatorGlassPNG.png";
   specular[0] = "0.992157 0.992157 0.992157 1";
   specularPower[0] = "100";
   translucent = "1";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(mat_TileFlooringB)
{
   mapTo = "TileFlooringB";
   diffuseMap[0] = "TileFlooringB";
   specular[0] = "0.890196 0.890196 0.890196 1";
   specularPower[0] = "100";
   translucent = "0";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   customFootstepSound = "FootStepRock1Sound";
};

singleton Material(mat_FutureSignsD)
{
   mapTo = "FutureSignsD";
   diffuseMap[0] = "art/Packs/Buildings/SkyCity/FutureSignsD";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "0";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "0";
   alphaTest = "0";
   alphaRef = "1";
};

singleton Material(mat_FutureSignsD)
{
   mapTo = "FutureSignsD";
   diffuseMap[0] = "FutureSignsD";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "1";
};

singleton Material(mat_FrontSigns)
{
   mapTo = "FrontSigns";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "0";
};

singleton Material(mat_ClothingMall)
{
   mapTo = "ClothingMall";
   diffuseMap[0] = "ClothingMall";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "1";
   useAnisotropic[0] = "1";
};

singleton Material(mat_HighRiseF)
{
   mapTo = "HighRiseF";
   diffuseMap[0] = "HighRiseF";
   specular[0] = "0.972549 0.972549 0.972549 1";
   specularPower[0] = "56";
   translucent = "0";
   customFootstepSound = "FootStepMetal1Sound";
   normalMap[0] = "HighRiseF_NRM.dds";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
};

singleton Material(mat_HighRiseD)
{
   mapTo = "HighRiseD";
   specular[0] = "0.901961 0.901961 0.901961 1";
   specularPower[0] = "39";
   translucent = "0";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   customFootstepSound = "FootStepMetal1Sound";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.537255 0.537255 0.537255 1";
};

singleton Material(mat_A3D_Glass)
{
   mapTo = "A3D_Glass";
   diffuseMap[0] = "A3D_Glass";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "1";
   useAnisotropic[0] = "1";
};

singleton Material(mat_ElevatorGlass)
{
   mapTo = "ElevatorGlassNightTime";
   diffuseMap[0] = "ElevatorGlassPNG.png";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "1";
   useAnisotropic[0] = "1";
};

singleton Material(mat_cube1_copy4_auv)
{
   mapTo = "cube1_copy4_auv";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
   useAnisotropic[0] = "1";
   diffuseColor[0] = "0.713726 0.713726 0.713726 1";
};


singleton Material(RotationBillboard_VC_FutureSignsC)
{
   mapTo = "FutureSignsC";
   diffuseMap[0] = "FutureSignsC";
   specular[0] = "0 0 0 1";
   specularPower[0] = "100";
   translucent = "1";
};

/////////////////////////////Buildings

/////////////////////Bldg 1

singleton Material(SkyCity_b01b)
{
   mapTo = "b01b";
   diffuseColor[0] = "0.8627 0.8627 0.8627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b01c)
{
   mapTo = "b01c";
   diffuseColor[0] = "0.7137 0.1059 0.6627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b01w)
{
   mapTo = "b01w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

/////////////////////////////Bldg 2

singleton Material(SkyCity_b02b)
{
   mapTo = "b02b";
   diffuseColor[0] = "0.8627 0.8627 0.8627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b02w)
{
   mapTo = "b02w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////////////////Bldg 3

singleton Material(SkyCity_b03a)
{
   mapTo = "b03a";
   diffuseColor[0] = "0.8627 0.8627 0.8627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b03w)
{
   mapTo = "b03w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////Bldg 4

singleton Material(SkyCity_b04w)
{
   mapTo = "b04w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b04a)
{
   mapTo = "b04a";
   diffuseColor[0] = "0.8627 0.8627 0.8627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

////////////////Bldg 5

singleton Material(mat_b05a)
{
   mapTo = "Material_building05-0-b05a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.811765 0.811765 0.811765 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b06a)
{
   mapTo = "b06a";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   useAnisotropic[0] = "0";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.882353 0.882353 0.882353 1";
   specularPower[0] = "128";
};

//////////////////Bldg 6

singleton Material(SkyCity_b06a)
{
   mapTo = "b06a";
   diffuseColor[0] = "0.8627 0.8627 0.8627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b06w)
{
   mapTo = "b06w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////////Bldg 8


singleton Material(SkyCity_b08a)
{
   mapTo = "b08a";
   diffuseColor[0] = "0.8627 0.8627 0.8627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b08w)
{
   mapTo = "b08w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

//////////////////Bldg 9

singleton Material(SkyCity_b09a)
{
   mapTo = "b09a";
   diffuseColor[0] = "0.368627 0.368627 0.368627 1";
   specular[0] = "0.847059 0.847059 0.847059 1";
   specularPower[0] = "24";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
};

singleton Material(SkyCity_b09w)
{
   mapTo = "b09w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

/////////////////////Bldg 10

singleton Material(SkyCity_b10a)
{
   mapTo = "b10a";
   diffuseColor[0] = "0.9804 0.9804 0.9804 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b10w)
{
   mapTo = "b10w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////////Bldg 11

singleton Material(mat_b11a)
{
   mapTo = "Material_building11-0-b11a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.717647 0.831373 0.713726 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b11w)
{
   mapTo = "Material_building11-0-b11w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

///////////////////////Bldg 12

singleton Material(mat_b12a)
{
   mapTo = "Material_building12-0-b12a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b12w)
{
   mapTo = "Material_building12-0-b12w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

/////////////////Bldg 14

singleton Material(mat_b14a)
{
   mapTo = "Material_building14-0-b14a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b14w)
{
   mapTo = "Material_building14-0-b14w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.886275 0.772549 0.776471 1";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

///////////////////Bldg 15

singleton Material(mat_b15a)
{
   mapTo = "Material_building15-0-b15a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.309804 0.392157 0.494118 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   pixelSpecular[0] = "1";
};

singleton Material(SkyCity_b16a)
{
   mapTo = "b16a";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.756863 0.74902 0.690196 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   specularPower[0] = "128";
};

////////////////////////////Bldg 16

singleton Material(SkyCity_b16a)
{
   mapTo = "b16a";
   diffuseColor[0] = "0.8627 0.8627 0.8627 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
   useAnisotropic[0] = "1";
};

singleton Material(SkyCity_b16w)
{
   mapTo = "b16w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////Bldg 17

singleton Material(mat_b17a)
{
   mapTo = "Material_building17-0-b17a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.803922 0.803922 0.796079 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b17w)
{
   mapTo = "Material_building17-0-b17w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////Bldg 18

singleton Material(mat_b18w)
{
   mapTo = "Material_building18-0-b18w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   pixelSpecular[0] = "0";
   cubemap = "SkyCity_CubeMap";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b18a)
{
   mapTo = "Material_building18-0-b18a-fx";
   diffuseColor[0] = "0.6 0.6 0.6 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

/////////////////////Bldg 19

singleton Material(mat_b19a)
{
   mapTo = "Material_building19-0-b19a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.301961 0.384314 0.486275 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   pixelSpecular[0] = "1";
};

singleton Material(mat_b19w)
{
   mapTo = "Material_building19-0-b19w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   cubemap = "SkyCity_CubeMap";
   materialTag0 = "SkyCity";
};

/////////////////////Bldg 20

singleton Material(mat_b20a)
{
   mapTo = "Material_building20-0-b20a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   pixelSpecular[0] = "1";
};

singleton Material(mat_b20w)
{
   mapTo = "Material_building20-0-b20w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

/////////////////////Bldg 21

singleton Material(mat_b21a)
{
   mapTo = "Material_building21-0-b21a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.360784 0.360784 0.360784 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   pixelSpecular[0] = "1";
};

singleton Material(mat_b21w)
{
   mapTo = "Material_building21-0-b21w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

//////////////////////Bldg 22

singleton Material(mat_b22a)
{
   mapTo = "Material_building22-0-b22a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.619608 0.690196 0.796079 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b22w)
{
   mapTo = "Material_building22-0-b22w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

///////////////////////Bldg 23

singleton Material(mat_b23a)
{
   mapTo = "Material_building23-0-b23a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   diffuseColor[0] = "0.717647 0.831373 0.713726 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b23w)
{
   mapTo = "Material_building23-0-b23w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////Bldg 24

singleton Material(mat_24a)
{
   mapTo = "Material_building24-24a";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.333333 0.333333 0.333333 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(mat_b24w)
{
   mapTo = "Material_building24_24w";
   specular[0] = "0.35 0.35 0.35 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};
/////////////////////////Bldg 25

singleton Material(mat_b25a)
{
   mapTo = "Material_building25-0-b25a-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   pixelSpecular[0] = "1";
   translucentBlendOp = "None";
};

singleton Material(mat_b25w)
{
   mapTo = "Material_building25-0-b25w-fx";
   specular[0] = "0.35 0.35 0.35 1";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

////////////////////////Bldg 27

singleton Material(SkyCity_b27a)
{
   mapTo = "b27a";
   diffuseColor[0] = "0.341176 0.384314 0.376471 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b27w)
{
   mapTo = "b27w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

//////////////////Bldg 28

singleton Material(SkyCity_b28a)
{
   mapTo = "b28a";
   diffuseColor[0] = "0.992157 0.996078 0.992157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b28b)
{
   mapTo = "b28b";
   diffuseColor[0] = "0.309804 0.309804 0.309804 1";
   specular[0] = "0.835294 0.835294 0.835294 1";
   specularPower[0] = "24";
   translucentBlendOp = "None";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
};

singleton Material(SkyCity_b28w)
{
   mapTo = "b28w";
   diffuseColor[0] = "0.2157 0.2157 0.2157 1";
   specular[0] = "0.35 0.35 0.35 1";
   specularPower[0] = "128";
   translucentBlendOp = "None";
   useAnisotropic[0] = "1";
   cubemap = "SkyCity_Cubemap";
   materialTag0 = "SkyCity";
};

singleton Material(WholeCity_WallsOne_mat)
{
   mapTo = "WholeCity_WallsOne";
   diffuseColor[0] = "0.784314 0.784314 0.784314 1";
   useAnisotropic[0] = "1";
};

//////////////////////////////////////End







singleton Material(tower1_Material_ElavatorBody)
{
   mapTo = "Material_ElavatorBody";
   specular[0] = "0.607843 0.607843 0.607843 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.431373 0.431373 0.431373 1";
   specularPower[0] = "6";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   materialTag0 = "SkyCity";
   doubleSided = "1";
};

singleton Material(tower1_Material_ElevatorGlassPng)
{
   mapTo = "Material_ElevatorGlassPng";
   specular[0] = "0 0 0 1";
   translucentBlendOp = "LerpAlpha";
   diffuseMap[0] = "art/Packs/Buildings/SkyCity/ElevatorGlassPNG.png";
   useAnisotropic[0] = "1";
   translucent = "1";
   specularPower[0] = "39";
   doubleSided = "1";
};

singleton Material(tower1_Material_ElevatorBodyPng)
{
   mapTo = "Material_ElevatorBodyPng";
   specular[0] = "0.992157 0.992157 0.992157 1";
   translucentBlendOp = "None";
   diffuseColor[0] = "0.996078 0.996078 0.996078 1";
   specularPower[0] = "21";
   pixelSpecular[0] = "1";
   useAnisotropic[0] = "1";
   doubleSided = "1";
   detailDistance = "500";
   materialTag0 = "Miscellaneous";
   detailSize = "4";
   diffuseSize = "128";
   detailStrength = "0.5";
   diffuseMap[0] = "art/Packs/Buildings/SkyCity/HighRiseD.dds";
   normalMap[0] = "art/Packs/Buildings/SkyCity/HighRiseD_NRM.dds";
};
