
singleton TSShapeConstructor(ShieldSquareDts)
{
   baseShape = "./ShieldSquare.dts";
};

function ShieldSquareDts::onLoad(%this)
{
   %this.addNode("mountPoint", "", "-0.180213 0.0325593 -0.041389 0.826127 -0.395851 -0.401019 0.536627", "1");
   %this.addNode("damageStart", "", "0.439116 0.0175998 0.0242336 1 0 0 0", "1");
   %this.addNode("damageEnd", "damageStart", "-0.429461 0 -0.0322862 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00359878 0.0288784 -0.0123998 0.999995 0 -0.00307412 1.56706", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.renameObject("ColBox", "Col");
}
