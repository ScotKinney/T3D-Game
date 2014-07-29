
singleton TSShapeConstructor(XR75Dae)
{
   baseShape = "./XR75.dts";
};



function XR75Dae::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0272707 -0.0612657 0.020419 0.0392453 -0.243051 0.969219 0.332421", "1");
   %this.setNodeParent("muzzlePoint", "mountPoint");
   %this.setNodeTransform("muzzlePoint", "0.55881 0.0955059 -0.000239389 0.000752113 -0.00784583 0.999969 1.55921", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.295279 0.1492 -0.00012078 -0.992444 -0.0869292 -0.0865968 1.57721", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
