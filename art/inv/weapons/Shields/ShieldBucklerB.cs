
singleton TSShapeConstructor(ShieldBucklerBDts)
{
   baseShape = "./ShieldBucklerB.dts";
};

function ShieldBucklerBDts::onLoad(%this)
{
   %this.setBounds("-0.265179 -0.266729 0.000655361 0.266219 0.264667 0.156412");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000196075 -0.00120696 0.0779114 -0.833431 -0.388513 -0.393002 1.75231", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.renameObject("ColBox", "Col");
   %this.setNodeTransform("mountPoint", "0.0414769 -0.000547513 -0.0726718 -0.026696 -0.16035 0.986699 1.49061", "1");
}
