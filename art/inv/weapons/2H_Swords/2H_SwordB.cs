
singleton TSShapeConstructor(2H_SwordBDts)
{
   baseShape = "./2H_SwordB.dts";
};

function 2H_SwordBDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "4.06277e-006 0.771059 -1.77011e-005 -0.577349 -0.577362 -0.57734 2.09438", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
