

singleton TSShapeConstructor(BluebarracudaDts)
{
   baseShape = "./bluebarracuda.dts";
};

function BluebarracudaDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "6.39053e-005 -0.500094 0.0332884 -0.0927856 -0.0868375 0.991892 1.57827", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
