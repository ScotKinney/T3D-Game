
singleton TSShapeConstructor(ShotDae)
{
   baseShape = "./shot.dae";
   adjustCenter = "1";
   loadLights = "0";
};

function ShotDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColSphere-1", "Col-1", "-0.000165 0 -7.99999e-005 1 0 0 0", "0");
   %this.addCollisionDetail("-1", "Sphere", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
