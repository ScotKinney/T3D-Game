
singleton TSShapeConstructor(ShieldHeaterADts)
{
   baseShape = "./ShieldHeaterA.dts";
};

function ShieldHeaterADts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "9.40684e-005 -0.0560442 0.0564536 0.584363 0.56039 0.586926 4.16316", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.31213 -0.486346 -0.0108481 0.310971 0.372202 0.128681");
   %this.renameObject("ColBox", "Col");
   %this.addNode("mountPoint", "", "-0.121237 0.0913674 -0.0348143 0.773775 -0.592234 0.224791 0.67009", "1");
   %this.addNode("damageStart", "", "0.260561 -0.169147 0 1 0 0 0", "1");
   %this.addNode("damageEnd", "damageStart", "-0.295626 0.256786 0 1 0 0 0", "1");
}
