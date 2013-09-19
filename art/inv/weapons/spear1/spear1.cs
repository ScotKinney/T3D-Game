
singleton TSShapeConstructor(Spear1Dts)
{
   baseShape = "./spear1.dts";
};

function Spear1Dts::onLoad(%this)
{
   %this.removeNode("Col9");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000606383 0.488355 -0.021705 0.585815 0.577138 -0.568975 4.18847", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("mountpoint", "weapon100", "0.0274185 0.419316 -0.00279551 0.167139 -0.968319 -0.185536 1.46807", "1");
}
