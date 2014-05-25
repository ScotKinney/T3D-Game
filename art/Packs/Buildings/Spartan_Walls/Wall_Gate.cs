
singleton TSShapeConstructor(Wall_GateDts)
{
   baseShape = "./Wall_Gate.dts";
};

function Wall_GateDts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
