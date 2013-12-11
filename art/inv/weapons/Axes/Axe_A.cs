
singleton TSShapeConstructor(Axe_ADts)
{
   baseShape = "./Axe_A.dts";
};

function Axe_ADts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0812177 0.282559 3.64109e-005 0.577361 -0.577377 0.577313 2.09436", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
