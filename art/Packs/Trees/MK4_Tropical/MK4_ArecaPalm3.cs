
singleton TSShapeConstructor(MK4_ArecaPalm3DAE)
{
   baseShape = "./MK4_ArecaPalm3.DAE";
   unit = "0.254";
   loadLights = "0";
   lodType = "TrailingNumber";
};

function MK4_ArecaPalm3DAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
