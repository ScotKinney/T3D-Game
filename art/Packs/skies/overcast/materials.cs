

//////////////////////////////////////////////////

new CubemapData(OvercastCube)
{
   cubeFace[0] = "art/Packs/skies/overcast/OCastRight.jpg";
   cubeFace[1] = "art/Packs/skies/overcast/OCastLeft.jpg";
   cubeFace[2] = "art/Packs/skies/overcast/OCastBack.jpg";
   cubeFace[3] = "art/Packs/skies/overcast/OCastFront.jpg";
   cubeFace[4] = "art/Packs/skies/overcast/OCastUp.jpg";
   cubeFace[5] = "art/Packs/skies/overcast/OCastDown.jpg";
};

singleton Material(OvercastSky)
{
   mapTo = "OCastSkyBox";
   cubemap = "OvercastCube";
   useAnisotropic[0] = "1";
   materialTag0 = "ValSky";
   rotPivotOffset[0] = "-0.24 0";
};