
singleton TSShapeConstructor(Win_DryPine01DAE)
{
   baseShape = "./Win_DryPine01.DAE";
   loadLights = "0";
};

function Win_DryPine01DAE::onLoad(%this)
{
   %this.addImposter("1", "12", "0", "0", "512", "1", "0");
}
