singleton CubemapData( PangaeaSkyBox )
{
   cubeFace[0] = "./3TD_SkyRight.jpg";
   cubeFace[1] = "./3TD_SkyLeft.jpg";
   cubeFace[2] = "./3TD_SkyRear.jpg";
   cubeFace[3] = "./3TD_SkyFront.jpg";
   cubeFace[4] = "./3TD_SkyUp.jpg";
   cubeFace[5] = "./3TD_SkyDown.png";
};

singleton Material( PangaeaSky )
{
   cubemap = PangaeaSkyBox;
   materialTag0 = "SkyBoxes";
};
