
singleton TSShapeConstructor(Canopytree_two_darkDAE)
{
   baseShape = "./canopytree_two_dark.DAE";
};

function Canopytree_two_darkDAE::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1500");
   %this.setDetailLevelSize("175", "800");
   %this.addImposter("1", "4", "0", "0", "512", "0", "0");
}
