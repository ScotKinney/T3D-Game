
singleton TSShapeConstructor(Meat_rollDts)
{
   baseShape = "./meat_roll.dts";
};

function Meat_rollDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00564751 0.0063276 0.154414 0.253249 -0.172149 0.951961 1.59478", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "1", "60", "0", "64", "69.1489", "62.766", "44.6809");
   %this.setBounds("-0.148765 -0.27529 -0.00292565 0.150421 0.283743 0.297908");
}
