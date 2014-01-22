
singleton TSShapeConstructor(SpearStone_meleeDts)
{
   baseShape = "./SpearStone_melee.dts";
};

function SpearStone_meleeDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0128276 0.12865 0.0194058 0.999872 0 -0.0159788 1.56888", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "-0.03191 -0.125054 0.0237805 1 0 0 0", "1");
}
