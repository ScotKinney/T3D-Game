
singleton TSShapeConstructor(ShieldBucklerADts)
{
   baseShape = "./ShieldBucklerA.dts";
};

function ShieldBucklerADts::onLoad(%this)
{
   %this.setBounds("-0.265179 -0.266729 0.000655361 0.266219 0.264667 0.156412");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000196075 -0.00120696 0.0779114 -0.833431 -0.388513 -0.393002 1.75231", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.renameObject("ColBox", "Col");
   %this.setNodeTransform("mountPoint", "-6.49147e-005 -0.0107149 0.00936969 -0.328294 -0.258767 0.90844 1.4234", "1");
}
