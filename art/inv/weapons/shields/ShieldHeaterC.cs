

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
   %this.setNodeTransform("mountPoint", "-0.0956667 0.149333 -0.0433803 0.0950411 -0.764614 0.637443 0.399828", "1");
}
