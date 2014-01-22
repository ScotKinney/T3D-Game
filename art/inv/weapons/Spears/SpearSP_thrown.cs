
singleton TSShapeConstructor(SpearSP_thrownDts)
{
   baseShape = "./SpearSP_thrown.dts";
};

function SpearSP_thrownDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0254736 -0.132819 0.0236149 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00231636 -0.154206 -0.000202856 0.579032 -0.577414 0.575599 2.0943", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
