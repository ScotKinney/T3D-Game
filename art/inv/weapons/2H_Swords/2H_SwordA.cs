
singleton TSShapeConstructor(2H_SwordADts)
{
   baseShape = "./2H_SwordA.dts";
};

function 2H_SwordADts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000413163 0.751295 1.83338e-005 0.576899 0.577338 0.577814 4.18877", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
