
singleton TSShapeConstructor(RainbowtroutDts)
{
   baseShape = "./rainbowtrout.dts";
};

function RainbowtroutDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-1.03015e-005 -0.488673 0.0352843 -0.0874275 -0.0868344 0.992379 1.5783", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
