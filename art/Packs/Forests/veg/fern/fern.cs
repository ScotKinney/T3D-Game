
singleton TSShapeConstructor(FernDAE)
{
   baseShape = "./fern.DAE";
   loadLights = "0";
};

function FernDAE::onLoad(%this)
{
   %this.addImposter("10", "24", "0", "0", "256", "0", "0");
}
