
singleton TSShapeConstructor(DeathDealerLHDts)
{
   baseShape = "./DeathDealerLH.dts";
};

function DeathDealerLHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.00351443 -0.04 0.0116521 0.793613 0.0067458 -0.608385 0.370456", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "1.33502e-005 0.459821 2.15675e-005 0.577304 -0.577376 0.577371 2.09436", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
