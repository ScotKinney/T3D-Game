
singleton TSShapeConstructor(Canopytree_threeDAE)
{
   baseShape = "./canopytree_three.DAE";
   loadLights = "0";
};

function Canopytree_threeDAE::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1500");
   %this.setDetailLevelSize("200", "500");
   %this.addImposter("1", "24", "0", "0", "512", "0", "0");
}
