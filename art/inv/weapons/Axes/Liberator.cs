
singleton TSShapeConstructor(LiberatorDts)
{
   baseShape = "./Liberator.dts";
};

function LiberatorDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0139919 -0.21006 0.020397 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000803038 0.303308 -7.02154e-005 0.992427 -0.0868518 0.0868677 1.5781", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
