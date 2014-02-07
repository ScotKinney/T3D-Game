
singleton TSShapeConstructor(ElvenBowDts)
{
   baseShape = "./ElvenBow.dts";
};

function ElvenBowDts::onLoad(%this)
{
   %this.addSequence("./FireBow.dsq", "FireBow", "0", "49", "1", "0");
   %this.setNodeParent("Body", "");
   %this.removeNode("Root");
   %this.setNodeTransform("mountPoint", "0.023025 0.00326181 0.0933101 0.347694 0.782662 -0.516284 0.350068", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.300667 -0.0383872 0.0236038 -0.999996 0 0.00297619 1.57337", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("muzzlepoint", "Body", "0.010376 0.0755281 0.00894045 0 0 -1 1.5792", "1");
}
