singleton CubemapData( PangaeaSkyBox )
{
   cubeFace[0] = "3TD_SkyRight";
   cubeFace[1] = "3TD_SkyLeft";
   cubeFace[2] = "3TD_SkyRear";
   cubeFace[3] = "3TD_SkyFront";
   cubeFace[4] = "3TD_SkyUp";
   cubeFace[5] = "3TD_SkyDown";
};

singleton Material( PangaeaSky )
{
   cubemap = PangaeaSkyBox;
   materialTag0 = "SkyBoxes";
};
