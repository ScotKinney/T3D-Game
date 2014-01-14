singleton TSShapeConstructor(ShieldHeaterCDts)
{
   baseShape = "./ShieldHeaterC.dts";
};

function ShieldHeaterCDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "9.40684e-005 -0.0560442 0.0564536 0.584363 0.56039 0.586926 4.16316", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.31213 -0.486346 -0.0108481 0.310971 0.372202 0.128681");
   %this.renameObject("ColBox", "Col");
   %this.addNode("mountPoint", "", "-0.121237 0.111123 -0.061401 0.77498 -0.591927 0.221423 0.664342", "1");
   %this.addNode("damageStart", "", "0.334257 -0.245655 0 1 0 0 0", "1");
   %this.addNode("damageEnd", "damageStart", "-0.350902 0.35582 0 1 0 0 0", "1");
}
