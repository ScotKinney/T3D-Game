
singleton TSShapeConstructor(Axe_ADts)
{
   baseShape = "./Axe_A.dts";
};

function Axe_ADts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Axe_A", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "-0.0154956 -0.137653 0.018104 1 0 0 0", "1");
}
