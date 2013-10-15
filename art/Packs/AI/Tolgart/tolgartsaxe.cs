
singleton TSShapeConstructor(tolgartsaxeDts)
{
   baseShape = "./tolgartsaxe.dts";
};

function tolgartsaxeDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
