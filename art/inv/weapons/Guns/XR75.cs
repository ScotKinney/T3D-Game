
singleton TSShapeConstructor(XR75Dae)
{
   baseShape = "./XR75.dts";
   loadLights = "0";
};

function XR75Dae::onLoad(%this)
{
   %this.setNodeTransform("mountpoint", "0.0115576 -0.0308713 -0.170109 -0.42251 -0.749862 -0.509109 1.96044", "1");
   %this.removeDetailLevel("-1");
   %this.removeNode("Col-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "gun", "4", "30", "30", "32", "30", "30", "30");
}
