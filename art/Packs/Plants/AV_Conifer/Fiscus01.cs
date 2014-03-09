
singleton TSShapeConstructor(Fiscus01DAE)
{
   baseShape = "./Fiscus01.DAE";
   loadLights = "0";
};

function Fiscus01DAE::onLoad(%this)
{
   %this.addImposter("64", "24", "0", "0", "256", "1", "0");
}
