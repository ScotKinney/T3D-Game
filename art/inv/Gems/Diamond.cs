
singleton TSShapeConstructor(DiamondDae)
{
   baseShape = "./Diamond.dae";
   unit = "0.001";
   loadLights = "0";
};

function DiamondDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0221997 -0.0322017 0.0946659 -0.37783 -0.738318 -0.558687 1.12664", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
