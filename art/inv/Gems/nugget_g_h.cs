
singleton TSShapeConstructor(Nugget_g_hDae)
{
   baseShape = "./nugget_g_h.dae";
   upAxis = "Y_AXIS";
   loadLights = "0";
};

function Nugget_g_hDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
