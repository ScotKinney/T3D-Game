
singleton TSShapeConstructor(Canopytree_one_novinesDAE)
{
   baseShape = "./canopytree_one_novines.DAE";
   loadLights = "0";
};

function Canopytree_one_novinesDAE::onLoad(%this)
{
   %this.addImposter("1", "4", "0", "0", "512", "0", "0");
   %this.setDetailLevelSize("700", "1500");
   %this.setDetailLevelSize("200", "500");
}
