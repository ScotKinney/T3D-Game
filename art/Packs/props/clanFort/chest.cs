
singleton TSShapeConstructor(ChestDts)
{
   baseShape = "./chest.dts";
};

function ChestDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000380538 0.00255984 0.266987 -0.999985 0 0.00546 1.60093", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
