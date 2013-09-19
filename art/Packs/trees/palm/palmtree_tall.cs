
singleton TSShapeConstructor(Palmtree_tallDAE)
{
   baseShape = "./palmtree_tall.DAE";
};

function Palmtree_tallDAE::onLoad(%this)
{
   %this.addImposter("1", "4", "0", "0", "512", "0", "0");
   %this.setDetailLevelSize("100", "200");
}
