
singleton TSShapeConstructor(LiberatorLHDts)
{
   baseShape = "./LiberatorLH.dts";
};

function LiberatorLHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.00631267 -0.174975 0.0136007 0.655411 0.145482 -0.741128 0.266417", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000803068 0.303308 7.02185e-005 -0.992427 -0.0868518 -0.0868676 1.5781", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
