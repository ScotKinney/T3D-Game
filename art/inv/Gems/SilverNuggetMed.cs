
singleton TSShapeConstructor(SilverNuggetMedDts)
{
   baseShape = "./SilverNuggetMed.dts";
};

function SilverNuggetMedDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColSphere-1", "Col-1", "-0.0421067 -0.0142914 0.198 1 0 0 0", "0");
   %this.addCollisionDetail("-1", "Sphere", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
