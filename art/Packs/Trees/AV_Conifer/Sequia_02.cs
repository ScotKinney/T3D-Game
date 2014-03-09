
singleton TSShapeConstructor(Sequia_02DAE)
{
   baseShape = "./Sequia_02.DAE";
   loadLights = "0";
};

function Sequia_02DAE::onLoad(%this)
{
   %this.addImposter("128", "12", "0", "0", "512", "1", "0");
}
