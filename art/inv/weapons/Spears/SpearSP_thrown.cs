
singleton TSShapeConstructor(SpearSP_thrownDts)
{
   baseShape = "./SpearSP_thrown.dts";
};

function SpearSP_thrownDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0263023 0.110604 0.0218483 0 0 1 3.17138", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00231636 -0.154206 -0.000202856 0.579032 -0.577414 0.575599 2.0943", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
