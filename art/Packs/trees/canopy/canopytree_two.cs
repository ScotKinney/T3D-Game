
singleton TSShapeConstructor(Canopytree_twoDAE)
{
   baseShape = "./canopytree_two.DAE";
};

function Canopytree_twoDAE::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1500");
   %this.setDetailLevelSize("175", "600");
   %this.addImposter("1", "4", "0", "0", "512", "0", "0");
}
