

new CubemapData(KapSkyDarkClouds)
{
   cubeFace[0] = "art/packs/worlds/kardia/skies/DcloudRight.jpg";
   cubeFace[1] = "art/packs/worlds/kardia/skies/DcloudLeft.jpg";
   cubeFace[2] = "art/packs/worlds/kardia/skies/DcloudBack.jpg";
   cubeFace[3] = "art/packs/worlds/kardia/skies/DcloudFront.jpg";
   cubeFace[4] = "art/packs/worlds/kardia/skies/DcloudUp.jpg";
   cubeFace[5] = "art/packs/worlds/kardia/skies/DcloudDown.jpg";
};

singleton Material(KapSkysDarkCloud)
{
   mapTo = "DarkSkyBox";
   cubemap = "KapSkyDarkClouds";
   materialTag0 = "KapSkys";
};

