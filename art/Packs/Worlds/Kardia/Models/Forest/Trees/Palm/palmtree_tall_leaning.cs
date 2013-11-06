
singleton TSShapeConstructor(Palmtree_tall_leaningDAE)
{
   baseShape = "./palmtree_tall_leaning.DAE";
};

function Palmtree_tall_leaningDAE::onLoad(%this)
{
   %this.setDetailLevelSize("75", "200");
   %this.addImposter("1", "4", "0", "0", "512", "0", "0");
}
