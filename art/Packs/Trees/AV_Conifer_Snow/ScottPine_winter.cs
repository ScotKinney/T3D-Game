
singleton TSShapeConstructor(ScottPine_winterDAE2)
{
   baseShape = "./ScottPine_winter.DAE";
   loadLights = "0";
};

function ScottPine_winterDAE2::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
