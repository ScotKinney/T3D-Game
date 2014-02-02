
singleton TSShapeConstructor(HeatNailDts)
{
   baseShape = "./HeatNail.dts";
};

function HeatNailDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00031917 0.207594 8.0744e-005 0.575377 -0.577653 0.579015 2.09394", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
