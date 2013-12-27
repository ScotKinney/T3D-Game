
singleton TSShapeConstructor(Axe_ADts)
{
   baseShape = "./Axe_A.dts";
};

function Axe_ADts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Axe_A", "4", "30", "30", "32", "30", "30", "30");
}
