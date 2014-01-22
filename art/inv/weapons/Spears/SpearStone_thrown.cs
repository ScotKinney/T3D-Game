
singleton TSShapeConstructor(SpearStone_thrownDts)
{
   baseShape = "./SpearStone_thrown.dts";
};

function SpearStone_thrownDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0166166 -0.0354687 0.0163734 -0.999553 0 0.0299074 1.57207", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
