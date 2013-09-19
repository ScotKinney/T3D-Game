
singleton TSShapeConstructor(LemonDts)
{
   baseShape = "./lemon.dts";
};

function LemonDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0095317 0.0155706 0.107325 -0.823908 -0.149682 -0.546599 1.05788", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "1", "60", "0", "64", "69.1489", "62.766", "44.6809");
}
