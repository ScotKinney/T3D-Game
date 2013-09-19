
singleton TSShapeConstructor(Medallion7Dts)
{
   baseShape = "./medallion7.dts";
};

function Medallion7Dts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColSphere-1", "Col-1", "8.9407e-008 -0.0794008 0.51588 1 0 0 0", "0");
   %this.addCollisionDetail("-1", "Sphere", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
