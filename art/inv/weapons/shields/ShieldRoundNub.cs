
singleton TSShapeConstructor(ShieldRoundNubDts)
{
   baseShape = "./ShieldRoundNub.dts";
};

function ShieldRoundNubDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000479038 -0.00134276 0.0309693 -0.649994 -0.53541 -0.539299 2.0057", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.517436 -0.517709 -0.117766 0.516141 0.515867 0.179429");
   %this.setNodeTransform("damageStart", "0.476 0.00322226 0.0467677 0 0 -1 1.56096", "1");
   %this.setNodeTransform("mountPoint", "-0.235343 0.00279304 -0.0287958 0.318469 -0.398308 -0.860191 0.46307", "1");
}
