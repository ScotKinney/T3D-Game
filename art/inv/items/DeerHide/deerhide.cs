
singleton TSShapeConstructor(DeerhideDts)
{
   baseShape = "./deerhide.dts";
};

function DeerhideDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "1.40963e-011 -1.49013e-010 0.00250002 1 0 -5.63849e-009 1.5708", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
