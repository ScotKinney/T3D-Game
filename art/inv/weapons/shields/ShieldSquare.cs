
singleton TSShapeConstructor(ShieldSquareDts)
{
   baseShape = "./ShieldSquare.dts";
};

function ShieldSquareDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00279604 0.0330318 -0.017866 0.999986 0 -0.0053359 1.57016", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.renameObject("ColBox", "Col");
   %this.addNode("mountPoint", "", "-0.180213 0.0325593 -0.0295113 -0.0994555 -0.675968 -0.730189 0.41037", "1");
   %this.addNode("damageStart", "", "0.401515 0.0175998 -0.0322862 1 0 0 0", "1");
   %this.setNodeParent("ShieldSquare0", "");
   %this.addNode("damageEnd", "damageStart", "-0.404261 0 -0.0322862 1 0 0 0", "1");
}
