
singleton TSShapeConstructor(QuikSilverDts)
{
   baseShape = "./QuikSilver.dts";
};

function QuikSilverDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-9.09971e-005 0.171434 -0.000282212 0.999999 0 -0.00107355 1.57166", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
