
singleton TSShapeConstructor(Axe_BDts)
{
   baseShape = "./Axe_B.dts";
};

function Axe_BDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Axe_B", "4", "30", "30", "32", "30", "30", "30");
}
