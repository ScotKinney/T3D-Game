
singleton TSShapeConstructor(ShieldSquareDts)
{
   baseShape = "./ShieldSquare.dts";
};

function ShieldSquareDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00359878 0.0288784 -0.0123998 0.999995 0 -0.00307412 1.56706", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.renameObject("ColBox", "Col");
   %this.setNodeTransform("mountPoint", "-0.18232 -0.0145774 -0.028 0.212733 -0.560887 -0.800094 0.474315", "1");
}
