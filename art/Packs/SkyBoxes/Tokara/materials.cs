new CubemapData(KapSkyDarkClouds)
{
   cubeFace[0] = "SumRight.jpg";
   cubeFace[1] = "SumLeft.jpg";
   cubeFace[2] = "SumBack.jpg";
   cubeFace[3] = "SumFront.jpg";
   cubeFace[4] = "SumUp.jpg";
   cubeFace[5] = "SumDown.jpg";
};

singleton Material(KapSkysDarkCloud)
{
   mapTo = "DarkSkyBox";
   cubemap = "KapSkyDarkClouds";
   materialTag0 = "KapSkys";
};

