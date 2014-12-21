
singleton TSShapeConstructor(MK4_ArecaPalm2DAE)
{
   baseShape = "./MK4_ArecaPalm2.DAE";
   unit = "0.254";
   lodType = "TrailingNumber";
   loadLights = "0";
};

function MK4_ArecaPalm2DAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
