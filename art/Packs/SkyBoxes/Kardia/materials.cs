new CubemapData(KardSkyCubemap)
{
   cubeFace[0] = "./Kard_Right";
   cubeFace[1] = "./Kard_Left";
   cubeFace[2] = "./Kard_Back";
   cubeFace[3] = "./Kard_Front";
   cubeFace[4] = "./Kard_Up";
   cubeFace[5] = "./Kard_Down";
};

singleton Material(KardSky)
{ 
   mapTo = "KardSkyCubemap";   
   cubemap = "KardSkyCubemap";
   materialTag0 = "SkyBoxes";
};