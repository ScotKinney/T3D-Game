
singleton TSShapeConstructor(ReddevilDts)
{
   baseShape = "./reddevil.dts";
};

function ReddevilDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-3.00542e-005 -0.471998 0.0180632 -0.541005 -0.540549 0.644299 1.99702", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
