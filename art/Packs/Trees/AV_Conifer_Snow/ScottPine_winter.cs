
singleton TSShapeConstructor(ScottPine_winterDAE2)
{
   baseShape = "./ScottPine_winter.DAE";
   loadLights = "0";
};

function ScottPine_winterDAE2::onLoad(%this)
{
   %this.removeImposter();
}
