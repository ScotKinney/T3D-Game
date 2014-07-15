
singleton TSShapeConstructor(FantasybridgeDts)
{
   baseShape = "./fantasybridge.dts";
};

function FantasybridgeDts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
