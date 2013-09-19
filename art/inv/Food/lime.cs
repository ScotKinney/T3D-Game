
singleton TSShapeConstructor(LimeDts)
{
   baseShape = "./lime.dts";
};

function LimeDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0934275 -0.0784732 -0.0697792 0.908092 -0.170942 0.382292 2.43884", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
