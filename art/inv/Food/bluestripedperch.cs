
singleton TSShapeConstructor(BluestripedperchDts)
{
   baseShape = "./bluestripedperch.dts";
};

function BluestripedperchDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000191193 -0.492987 0.0312487 -0.577294 -0.577284 0.577473 2.09449", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
