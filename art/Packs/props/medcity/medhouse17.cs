
singleton TSShapeConstructor(Medhouse17Dts)
{
   baseShape = "./medhouse17.dts";
};

function Medhouse17Dts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
