
singleton TSShapeConstructor(SP_LayeredRock1Dts)
{
   baseShape = "./SP_LayeredRock1.dts";
};

function SP_LayeredRock1Dts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
