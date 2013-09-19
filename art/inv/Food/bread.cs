
singleton TSShapeConstructor(BreadDae)
{
   baseShape = "./bread.dae";
   unit = "0.03";
   adjustCenter = "1";
   loadLights = "0";
};


function BreadDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColCapsule-1", "Col-1", "-1.19632e-007 -1.72077e-005 -1.85035e-006 0.707075 0.707059 0.0106332 3.1203", "0");
   %this.addCollisionDetail("-1", "Capsule", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.renameObject("ColCapsule", "BreadColCapsule");
}
