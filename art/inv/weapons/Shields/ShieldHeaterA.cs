

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
   %this.setNodeTransform("mountPoint", "-0.12862 0.0870573 -0.0817021 -0.08952 -0.299845 0.949779 0.454574", "1");
}
