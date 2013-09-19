
singleton TSShapeConstructor(BoglinToesDts)
{
   baseShape = "./BoglinToes.dts";
};

function BoglinToesDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "1.82487e-007 6.43009e-010 0.186407 3.44735e-009 0 1 1.57079", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
