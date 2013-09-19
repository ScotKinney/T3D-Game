
singleton TSShapeConstructor(Medhouse12Dts)
{
   baseShape = "./medhouse12.dts";
};

function Medhouse12Dts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
