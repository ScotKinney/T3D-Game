
singleton TSShapeConstructor(Canopytree_two_lightDAE)
{
   baseShape = "./canopytree_two_light.DAE";
};

function Canopytree_two_lightDAE::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1500");
   %this.setDetailLevelSize("175", "800");
   %this.addImposter("1", "4", "0", "0", "512", "0", "0");
}
