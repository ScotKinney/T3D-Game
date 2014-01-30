
singleton TSShapeConstructor(HavokDts)
{
   baseShape = "./Havok.dts";
};

function HavokDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.00766904 -0.0483167 0.0239529 0 0 1 0.0551408", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.076504 -0.0184921 0.0154962 -0.20859 -0.68444 0.698593 2.6533", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
