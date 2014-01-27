
singleton TSShapeConstructor(DW_Sword1_RHDts)
{
   baseShape = "./DW_Sword1_RH.dts";
};

function DW_Sword1_RHDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000359651 0.4107 0.000603917 0.577787 -0.577603 0.57666 2.09402", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "-0.0121422 0.00350005 0.014 1 0 0 0", "1");
}
