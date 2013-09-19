
singleton TSShapeConstructor(LanternDts)
{
   baseShape = "./Lantern.dts";
};

function LanternDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.205172 -3.79552e-008 -0.00922357 0.58764 0.547963 0.595328 4.14415", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
