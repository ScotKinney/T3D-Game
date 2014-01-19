
singleton TSShapeConstructor(2H_SwordCDts)
{
   baseShape = "./2H_SwordC.dts";
};

function 2H_SwordCDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "5.79687e-005 0.745075 -0.000125931 -0.57739 -0.577402 -0.577259 2.09432", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
