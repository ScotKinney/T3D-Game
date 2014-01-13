
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
   %this.addNode("damageStart", "", "0.262083 0 0.0165776 0 0 1 3.14", "1");
   %this.addNode("damageEnd", "damageStart", "-0.260136 3.25963e-009 0.0165776 1 0 0 0", "1");
   %this.addNode("mountPoint", "", "0 0 0.00889583 0.0389911 -0.747189 -0.663467 0.538718", "1");
}