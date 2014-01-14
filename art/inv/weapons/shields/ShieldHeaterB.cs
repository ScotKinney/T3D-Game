singleton TSShapeConstructor(ShieldHeaterBDts)
{
   baseShape = "./ShieldHeaterB.dts";
};

function ShieldHeaterBDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "9.40684e-005 -0.0560442 0.0564536 0.584363 0.56039 0.586926 4.16316", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.31213 -0.486346 -0.0108481 0.310971 0.372202 0.128681");
   %this.renameObject("ColBox", "Col");
   %this.addNode("mountPoint", "", "-0.121237 0.105601 -0.0687131 0.77457 -0.592033 0.222572 0.66628", "1");
   %this.addNode("damageStart", "", "0.231786 -0.169147 0 1 0 0 0", "1");
   %this.addNode("damageEnd", "damageStart", "-0.317426 0.28157 0 1 0 0 0", "1");
}
