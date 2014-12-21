
singleton TSShapeConstructor(MK4_ArecaPalm1DAE)
{
   baseShape = "./MK4_ArecaPalm1.DAE";
   unit = "0.254";
   loadLights = "0";
   lodType = "TrailingNumber";
};


function MK4_ArecaPalm1DAE::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
