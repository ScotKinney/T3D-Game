new CubemapData(DarkSky2Cubemap)
{
   cubeFace[0] = "./DcloudRight.jpg";
   cubeFace[1] = "./DcloudLeft.jpg";
   cubeFace[2] = "./DcloudBack.jpg";
   cubeFace[3] = "./DcloudFront.jpg";
   cubeFace[4] = "./DcloudUp.jpg";
   cubeFace[5] = "./DcloudDown.jpg";
};

singleton Material(DarkSky2)
{ 
   cubemap = "DarkSky2Cubemap";
   materialTag0 = "SkyBoxes";
};