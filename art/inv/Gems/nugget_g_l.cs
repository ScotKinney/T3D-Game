
singleton TSShapeConstructor(Nugget_g_lDae)
{
   baseShape = "./nugget_g_l.dae";
};

function Nugget_g_lDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "Convex Hulls", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
