

//////////////////////////////////////////////////

new CubemapData(KapSkyOvercast01)
{
   cubeFace[0] = "art/packs/skyboxes/dalriata/CastRight.jpg";
   cubeFace[1] = "art/packs/skyboxes/dalriata/CastLeft.jpg";
   cubeFace[2] = "art/packs/skyboxes/dalriata/CastBack.jpg";
   cubeFace[3] = "art/packs/skyboxes/dalriata/CastFront.jpg";
   cubeFace[4] = "art/packs/skyboxes/dalriata/CastUp.jpg";
   cubeFace[5] = "art/packs/skyboxes/dalriata/CastDown.jpg";
};

singleton Material(KapSkyOvercast1)
{
   mapTo = "OverCastSkyBox";
   cubemap = "KapSkyOvercast01";
   useAnisotropic[0] = "1";
   materialTag0 = "KapSkys";
   rotPivotOffset[0] = "-0.24 0";
};