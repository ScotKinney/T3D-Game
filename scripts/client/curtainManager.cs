// Materials and functions needed for the Gui and HUD curtains.
singleton Material(GuiCurtain_Mat)
{
   mapTo = "GuiCurtain";
   diffuseMap[0] = "#GuiCurtain";

   translucent = true;
   translucentBlendOp = "LerpAlpha";
   translucentZWrite = true;
   emissive[0] = "1";
   castShadows = "0";
};

singleton Material(HUDCurtain_Mat)
{
   mapTo = "HUDCurtain";
   diffuseMap[0] = "#HUDCurtain";

   translucent = true;
   translucentBlendOp = "LerpAlpha";
   translucentZWrite = true;
   emissive[0] = "1";
   castShadows = "0";
};
