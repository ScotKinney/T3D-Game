
singleton TSShapeConstructor(DiamondMedDae)
{
   baseShape = "./DiamondMed.dae";
   unit = "0.0015";
   loadLights = "0";
};

function DiamondMedDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0332995 -0.0483026 0.141999 -0.37783 -0.738318 -0.558687 1.12664", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
