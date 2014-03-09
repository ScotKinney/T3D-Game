
singleton TSShapeConstructor(Medhouse6Dts)
{
   baseShape = "./medhouse6.dts";
};

function Medhouse6Dts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
