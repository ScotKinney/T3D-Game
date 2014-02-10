
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
   %this.setNodeTransform("mountPoint", "-0.179348 -0.00464887 -0.0699513 0.405737 -0.334027 -0.850767 0.253267", "1");
}
