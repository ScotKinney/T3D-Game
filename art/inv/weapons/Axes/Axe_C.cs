
singleton TSShapeConstructor(Axe_CDts)
{
   baseShape = "./Axe_C.dts";
};

function Axe_CDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00056212 0.212316 -4.9155e-005 0.992427 -0.0868518 0.0868677 1.5781", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
