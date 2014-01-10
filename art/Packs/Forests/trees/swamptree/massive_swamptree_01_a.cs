
singleton TSShapeConstructor(Massive_swamptree_01_aDae)
{
   baseShape = "./massive_swamptree_01_a.dae";
   loadLights = "0";
};

function Massive_swamptree_01_aDae::onLoad(%this)
{
   %this.addImposter("24", "12", "0", "0", "512", "1", "0");
}
