new CubemapData(SkyCity_CubeMap)
{
   cubeFace[0] = "art/packs/skyboxes/SkyCity/SkyBox_Right.jpg";
   cubeFace[1] = "art/packs/skyboxes/SkyCity/SkyBox_Left.jpg";
   cubeFace[2] = "art/packs/skyboxes/SkyCity/SkyBox_Back.jpg";
   cubeFace[3] = "art/packs/skyboxes/SkyCity/SkyBox_Front.jpg";
   cubeFace[4] = "art/packs/skyboxes/SkyCity/SkyBox_Up.jpg";
   cubeFace[5] = "art/packs/skyboxes/SkyCity/SkyBox_Down.jpg";
};

singleton Material(mat_SkyCitySky)
{
   cubemap = SkyCity_Cubemap;
   materialTag0 = "SkyBoxes";
};