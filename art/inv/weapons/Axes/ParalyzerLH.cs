
singleton TSShapeConstructor(ParalyzerLHDts)
{
   baseShape = "./ParalyzerLH.dts";
};

function ParalyzerLHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.00715223 -0.137653 0.0229874 0.746277 -0.0441872 -0.664167 0.305548", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.116025 0.403656 -5.20033e-005 -0.577361 -0.577377 -0.577312 2.09436", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
