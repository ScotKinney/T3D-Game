new CubemapData(OvercastCube)
{
   cubeFace[0] = "./OCastRight.jpg";
   cubeFace[1] = "./OCastLeft.jpg";
   cubeFace[2] = "./OCastBack.jpg";
   cubeFace[3] = "./OCastFront.jpg";
   cubeFace[4] = "./OCastUp.jpg";
   cubeFace[5] = "./OCastDown.jpg";
};

singleton Material(OvercastSky)
{
   cubemap = "OvercastCube";
   materialTag0 = "SkyBoxes";
   rotPivotOffset[0] = "-0.24 0";
};