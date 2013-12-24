
singleton TSShapeConstructor(Tree_001_cDts)
{
   baseShape = "./tree_001_c.dts";
};

function Tree_001_cDts::onLoad(%this)
{
   %this.addImposter("1", "4", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("700", "1200");
   %this.setDetailLevelSize("300", "700");
   %this.setDetailLevelSize("100", "300");
   %this.setDetailLevelSize("1", "100");
}
