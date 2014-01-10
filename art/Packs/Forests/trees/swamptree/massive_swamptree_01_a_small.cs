
singleton TSShapeConstructor(Massive_swamptree_01_a_smallDae)
{
   baseShape = "./massive_swamptree_01_a_small.dae";
   loadLights = "0";
};

function Massive_swamptree_01_a_smallDae::onLoad(%this)
{
   %this.addImposter("24", "12", "0", "0", "512", "1", "0");
}
