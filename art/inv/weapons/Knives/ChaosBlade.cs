
singleton TSShapeConstructor(ChaosBladeDts)
{
   baseShape = "./ChaosBlade.dts";
};

function ChaosBladeDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000705868 0.180429 1.19594e-005 0.577314 -0.577367 0.57737 2.09437", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
