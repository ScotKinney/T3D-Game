
singleton TSShapeConstructor(DeathDealerDts)
{
   baseShape = "./DeathDealer.dts";
};

function DeathDealerDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0176452 -0.032 -0.00724764 0 1 0 3.26968", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "1.33502e-005 0.459821 2.15675e-005 0.577304 -0.577376 0.577371 2.09436", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
