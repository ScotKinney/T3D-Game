
singleton TSShapeConstructor(SpearSP_thrownDts)
{
   baseShape = "./SpearSP_thrown.dts";
};

function SpearSP_thrownDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00271145 0.154206 -0.000217648 0.575663 -0.577286 0.579096 2.09449", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
