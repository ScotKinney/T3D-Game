new CubemapData( AmberSeries1Cubemap )
{
   cubeFace[0] = "./Left";
   cubeFace[1] = "./Right";
   cubeFace[2] = "./Back";
   cubeFace[3] = "./Front";
   cubeFace[4] = "./Up";
   cubeFace[5] = "./Down";
};

singleton Material( AmberSeries1Mat )
{
   cubemap = AmberSeries1Cubemap;
   materialTag0 = "SkyBoxes";
};
