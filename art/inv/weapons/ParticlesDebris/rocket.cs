
singleton TSShapeConstructor(RocketDts)
{
   baseShape = "./rocket.dts";
};

function RocketDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "3.51458e-005 -1.79312e-006 -0.000108119 -0.692754 -0.497542 0.522058 1.90603", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
