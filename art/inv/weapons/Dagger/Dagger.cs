
singleton TSShapeConstructor(DaggerDts)
{
   baseShape = "./Dagger.dts";
};

function DaggerDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Dagger0", "-0.0469086 0.379665 0.049362 -0.706685 -0.00521888 0.707509 3.14849", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Dagger", "4", "30", "30", "32", "30", "30", "30");
}
