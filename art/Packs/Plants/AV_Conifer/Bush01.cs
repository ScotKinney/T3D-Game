
singleton TSShapeConstructor(Bush01DAE)
{
   baseShape = "./Bush01.DAE";
   loadLights = "0";
};

function Bush01DAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "0", "0");
}
