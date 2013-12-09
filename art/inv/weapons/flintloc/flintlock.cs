
singleton TSShapeConstructor(FlintlockDts)
{
   baseShape = "./flintlock.dts";
};

function FlintlockDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.201321 0.145611 -0.0659504 0.281512 -0.626589 0.72673 2.92152", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
