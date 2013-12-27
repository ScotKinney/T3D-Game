
singleton TSShapeConstructor(Axe_CDts)
{
   baseShape = "./Axe_C.dts";
};

function Axe_CDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Axe_C", "4", "30", "30", "32", "30", "30", "30");
}
