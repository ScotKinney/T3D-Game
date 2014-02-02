
singleton TSShapeConstructor(ElvenBowDts)
{
   baseShape = "./ElvenBow.dts";
};

function ElvenBowDts::onLoad(%this)
{
   %this.addSequence("./FireBow.dsq", "FireBow", "0", "49", "1", "0");
   %this.setNodeParent("Body", "");
   %this.removeNode("Root");
   %this.setNodeTransform("mountPoint", "0.0111654 0.00326181 0.00894045 0.351278 0.7802 -0.517583 0.35493", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.303079 -0.0412716 -0.0260575 0.576149 0.57646 0.579436 4.18745", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
