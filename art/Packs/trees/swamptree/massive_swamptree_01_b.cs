
singleton TSShapeConstructor(Massive_swamptree_01_bDae)
{
   baseShape = "./massive_swamptree_01_b.dae";
   loadLights = "0";
};

function Massive_swamptree_01_bDae::onLoad(%this)
{
   %this.addImposter("24", "12", "0", "0", "512", "1", "0");
}
