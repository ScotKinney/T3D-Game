
singleton TSShapeConstructor(BrooktroutDts)
{
   baseShape = "./brooktrout.dts";
};

function BrooktroutDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "6.63781e-005 -0.490297 0.0186603 -0.57693 -0.577364 0.577756 2.09437", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
