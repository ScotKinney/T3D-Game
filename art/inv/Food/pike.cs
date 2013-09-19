
singleton TSShapeConstructor(PikeDts)
{
   baseShape = "./pike.dts";
};

function PikeDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000822354 -0.456983 0.00681461 0.582975 0.577337 -0.571683 4.18877", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
