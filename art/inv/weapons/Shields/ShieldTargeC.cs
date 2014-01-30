
singleton TSShapeConstructor(ShieldTargeCDts)
{
   baseShape = "./ShieldTargeC.dts";
};

function ShieldTargeCDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "4.00503e-006 -4.5805e-006 0.0232566 -0.889426 -0.323383 -0.323023 1.68876", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.451553 -0.4515 -0.0717407 0.451553 0.4515 0.118407");
   %this.renameObject("ColBox", "Col");
   %this.setNodeTransform("mountPoint", "-0.158 0.0339915 -0.0806917 0.0606789 -0.583336 -0.809961 0.45144", "1");
}
