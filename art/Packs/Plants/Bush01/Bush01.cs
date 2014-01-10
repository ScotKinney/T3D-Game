
singleton TSShapeConstructor(Bush01DAE)
{
   baseShape = "./Bush01.DAE";
   loadLights = "0";
};

function Bush01DAE::onLoad(%this)
{
   %this.addImposter("0", "12", "0", "0", "512", "1", "0");
}
