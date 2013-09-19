
singleton TSShapeConstructor(BananaDts)
{
   baseShape = "./banana.dts";
};

function BananaDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00234157 0.0232641 0.0392897 -0.633321 -0.565006 -0.52884 1.95636", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "1", "60", "0", "64", "69.1489", "62.766", "44.6809");
}
