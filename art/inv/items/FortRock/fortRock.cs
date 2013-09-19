
singleton TSShapeConstructor(fortRockDts)
{
   baseShape = "./fortRock.dts";
};

function fortRockDts::onLoad(%this)
{
   %this.addNode("mount0", "fortRock1", "0 0 0 0 0 1 0", "0");
   %this.removeDetailLevel("-1");
   %this.removeNode("col-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "fortRock", "8", "60", "12.766", "64", "0", "0", "0");
}
