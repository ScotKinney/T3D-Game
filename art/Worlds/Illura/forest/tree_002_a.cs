
singleton TSShapeConstructor(Tree_002_aDts)
{
   baseShape = "./tree_002_a.dts";
};

function Tree_002_aDts::onLoad(%this)
{
   %this.addImposter("1", "4", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("700", "1000");
   %this.setDetailLevelSize("300", "700");
   %this.setDetailLevelSize("100", "300");
   %this.setDetailLevelSize("1", "100");
}
