
singleton TSShapeConstructor(TropicFern01DAE)
{
   baseShape = "./TropicFern01.DAE";
};

function TropicFern01DAE::onLoad(%this)
{
   %this.addImposter("0", "24", "0", "0", "256", "0", "0");
}
