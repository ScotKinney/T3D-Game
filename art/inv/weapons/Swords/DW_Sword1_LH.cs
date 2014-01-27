
singleton TSShapeConstructor(DW_Sword1_LHDts)
{
   baseShape = "./DW_Sword1_LH.dts";
};

function DW_Sword1_LHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0167046 0.00300005 0.012 0 0 -1 0.169147", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00314757 0.4107 -0.000374271 -0.577787 -0.577603 -0.57666 2.09402", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
