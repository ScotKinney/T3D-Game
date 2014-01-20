
singleton TSShapeConstructor(TH_SwordADts)
{
   baseShape = "./TH_SwordA.dts";
};

function TH_SwordADts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColCapsule-1", "Col-1", "-0.000413163 0.751295 1.83338e-005 0.706827 0.000268679 0.707387 3.14101", "0");
   %this.addCollisionDetail("-1", "Capsule", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
