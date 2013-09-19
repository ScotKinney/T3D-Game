
singleton TSShapeConstructor(RhandDts)
{
   baseShape = "./rhand.dts";
};

function RhandDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-2.30859e-006 0.00320001 0.0547445 1 0 -1.15848e-005 1.57079", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
