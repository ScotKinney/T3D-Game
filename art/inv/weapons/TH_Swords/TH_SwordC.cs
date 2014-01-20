
singleton TSShapeConstructor(TH_SwordCDts)
{
   baseShape = "./TH_SwordC.dts";
};

function TH_SwordCDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColCapsule-1", "Col-1", "5.79687e-005 0.745075 -0.000125931 0.707147 7.38402e-006 0.707067 3.14177", "0");
   %this.addCollisionDetail("-1", "Capsule", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
