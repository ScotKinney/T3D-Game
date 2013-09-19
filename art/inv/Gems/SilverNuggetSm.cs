
singleton TSShapeConstructor(SilverNuggetSmDts)
{
   baseShape = "./SilverNuggetSm.dts";
};

function SilverNuggetSmDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColSphere-1", "Col-1", "-0.0421067 -0.0142914 0.198 1 0 0 0", "0");
   %this.addCollisionDetail("-1", "Sphere", "SilverNuggetSm", "4", "30", "30", "32", "30", "30", "30");
}
