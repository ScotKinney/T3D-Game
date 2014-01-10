
singleton TSShapeConstructor(BigleafDae)
{
   baseShape = "./bigleaf.dae";
};

function BigleafDae::onLoad(%this)
{
   %this.addImposter("10", "24", "0", "0", "256", "0", "0");
}
