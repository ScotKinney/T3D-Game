
singleton TSShapeConstructor(MK4_FanPalm1DAE)
{
   baseShape = "./MK4_FanPalm1.DAE";
   unit = "0.1";
   loadLights = "0";
   lodType = "TrailingNumber";
};

function MK4_FanPalm1DAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
