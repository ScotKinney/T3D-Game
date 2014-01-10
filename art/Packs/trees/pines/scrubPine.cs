
singleton TSShapeConstructor(ScrubPineDAE)
{
   baseShape = "./scrubPine.DAE";
   loadLights = "0";
};

function ScrubPineDAE::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
