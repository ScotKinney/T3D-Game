
singleton TSShapeConstructor(ParalyzerDts)
{
   baseShape = "./Paralyzer.dts";
};

function ParalyzerDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0154956 -0.137653 0.018104 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.116025 0.403656 5.20158e-005 0.577361 -0.577377 0.577313 2.09436", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
