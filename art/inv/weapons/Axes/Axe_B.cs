
singleton TSShapeConstructor(Axe_BDts)
{
   baseShape = "./Axe_B.dts";
};

function Axe_BDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0557773 0.22296 3.4629e-006 -0.644416 -0.540679 -0.540735 1.9968", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
