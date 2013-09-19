
singleton TSShapeConstructor(LhandDts)
{
   baseShape = "./lhand.dts";
};

function LhandDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-2.29408e-006 0.00320001 0.0547445 0.577357 -0.577351 0.577343 2.09439", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
