
singleton TSShapeConstructor(Tree_001_aDts)
{
   baseShape = "./tree_001_a.dts";
};

function Tree_001_aDts::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1200");
   %this.setDetailLevelSize("300", "700");
   %this.setDetailLevelSize("100", "500");
   %this.addImposter("100", "4", "0", "0", "256", "0", "0");
}
