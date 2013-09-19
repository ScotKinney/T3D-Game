
singleton TSShapeConstructor(HoDKeyDae)
{
   baseShape = "./HoDKey.dae";
   upAxis = "X_AXIS";
   unit = "1";
   adjustCenter = "1";
   loadLights = "0";
};

function HoDKeyDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColSphere-1", "Col-1", "0 1.49012e-008 -1.5134e-008 1 0 0 0", "0");
   %this.addCollisionDetail("-1", "Sphere", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
