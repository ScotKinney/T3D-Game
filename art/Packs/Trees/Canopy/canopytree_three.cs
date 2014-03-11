
singleton TSShapeConstructor(Canopytree_threeDAE)
{
   baseShape = "./canopytree_three.DAE";
};

function Canopytree_threeDAE::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1500");
   %this.setDetailLevelSize("200", "500");
   %this.addImposter("1", "4", "0", "0", "512", "0", "0");
}
