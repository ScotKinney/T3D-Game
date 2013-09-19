
singleton TSShapeConstructor(ThawkDts)
{
   baseShape = "./thawk.dts";
};

function ThawkDts::onLoad(%this)
{
   %this.addNode("mountpoint", "TomaHawk700", "0.00592403 -0.000299354 0.0268336 -0.0761231 -0.99423 0.0755754 1.33565", "1");
   %this.addNode("ThawkCol-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00031319 0.216283 -0.106121 -0.174208 -0.168247 0.970229 1.61768", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
