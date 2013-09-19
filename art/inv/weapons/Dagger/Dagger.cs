
singleton TSShapeConstructor(DaggerDts)
{
   baseShape = "./Dagger.dts";
};

function DaggerDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Dagger0", "-0.0469086 0.379665 0.049362 -0.706685 -0.00521888 0.707509 3.14849", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00394956 0.209478 0.0139523 0.610528 -0.581587 0.537599 2.08805", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
