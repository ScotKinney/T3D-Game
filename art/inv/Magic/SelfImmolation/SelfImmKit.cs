
singleton TSShapeConstructor(SelfImmKitDae)
{
   baseShape = "./SelfImmKit.dae";
};

function SelfImmKitDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "kitBody", "4", "30", "30", "32", "30", "30", "30");
}
