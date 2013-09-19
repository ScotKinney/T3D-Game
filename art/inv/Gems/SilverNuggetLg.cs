
singleton TSShapeConstructor(SilverNuggetLgDts)
{
   baseShape = "./SilverNuggetLg.dts";
};

function SilverNuggetLgDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColSphere-1", "Col-1", "0 -0.02975 0.29755 1 0 0 0", "0");
   %this.addCollisionDetail("-1", "Sphere", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.removeSequence("Untitled");
}
