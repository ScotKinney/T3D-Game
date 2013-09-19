
singleton TSShapeConstructor(EmeraldDae)
{
   baseShape = "./emerald.dae";
   upAxis = "X_AXIS";
   unit = "20";
   adjustCenter = "1";
   loadLights = "0";
};

function EmeraldDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "5.52358e-005 0.000416279 0.000393551 -1 0 -0.000829053 1.57684", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
