
singleton TSShapeConstructor(ShieldTargeADts)
{
   baseShape = "./ShieldTargeA.dts";
};

function ShieldTargeADts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "4.00503e-006 -4.5805e-006 0.0232566 -0.889426 -0.323383 -0.323023 1.68876", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.451553 -0.4515 -0.0717407 0.451553 0.4515 0.118407");
   %this.renameObject("ColBox", "Col");
   %this.setNodeTransform("mountPoint", "-0.168 0.00542435 -0.0373314 0.375936 -0.391299 -0.839974 0.500315", "1");
}
