
singleton TSShapeConstructor(Cedar_01_medium_aDae)
{
   baseShape = "./cedar_01_medium_a.dae";
   loadLights = "0";
};

function Cedar_01_medium_aDae::onLoad(%this)
{
   %this.addImposter("24", "6", "0", "0", "128", "1", "0");
}
