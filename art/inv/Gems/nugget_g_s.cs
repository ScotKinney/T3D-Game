
singleton TSShapeConstructor(Nugget_g_sDae)
{
   baseShape = "./nugget_g_s.dae";
   upAxis = "Z_AXIS";
   loadLights = "0";
};

function Nugget_g_sDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0140677 0.269405 0.00443183 -0.414197 -0.3639 -0.834277 1.81626", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
