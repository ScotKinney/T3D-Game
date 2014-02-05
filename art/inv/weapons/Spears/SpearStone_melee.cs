
singleton TSShapeConstructor(SpearStone_meleeDts)
{
   baseShape = "./SpearStone_melee.dts";
};

function SpearStone_meleeDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.016981 -0.125054 0.0237805 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0221594 0.0420466 0.0433918 0.576732 -0.578175 0.577142 2.09316", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeParent("StoneSpear_trans300", "");
   %this.setNodeParent("StoneSpear_dif300", "");
}
