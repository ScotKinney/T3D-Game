
singleton TSShapeConstructor(GreenGillDts)
{
   baseShape = "./GreenGill.dts";
};

function GreenGillDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000773518 -0.491065 0.0425762 -0.539226 -0.540694 0.645666 1.99677", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
