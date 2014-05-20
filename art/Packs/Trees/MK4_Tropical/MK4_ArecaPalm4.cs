
singleton TSShapeConstructor(MK4_ArecaPalm4DAE)
{
   baseShape = "./MK4_ArecaPalm4.DAE";
   unit = "0.254";
   loadLights = "0";
   lodType = "TrailingNumber";
};

function MK4_ArecaPalm4DAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
