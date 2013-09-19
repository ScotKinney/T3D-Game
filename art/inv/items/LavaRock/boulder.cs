
singleton TSShapeConstructor(BoulderDts)
{
   baseShape = "./boulder.dts";
};

function BoulderDts::onLoad(%this)
{
   %this.addNode("mount0", "boulder1", "0 0 0 0 0 1 0", "0");
   %this.removeDetailLevel("-1");
   %this.removeNode("col-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "boulder", "8", "60", "12.766", "64", "0", "0", "0");
}
