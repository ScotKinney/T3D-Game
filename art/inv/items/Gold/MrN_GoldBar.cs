
singleton TSShapeConstructor(MrN_GoldBarDts)
{
   baseShape = "./MrN_GoldBar.dts";
};

function MrN_GoldBarDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00169607 -0.000641923 0.0438958 0.999998 0 -0.00185815 1.57141", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
