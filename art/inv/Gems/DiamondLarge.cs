
singleton TSShapeConstructor(DiamondLargeDae)
{
   baseShape = "./DiamondLarge.dae";
   unit = "0.002";
   loadLights = "0";
};

function DiamondLargeDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0443994 -0.0644035 0.189332 -0.37783 -0.738318 -0.558687 1.12664", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
