
singleton TSShapeConstructor(Tree_001_bCDts)
{
   baseShape = "./tree_001_bC.dts";
};

function Tree_001_bCDts::onLoad(%this)
{
   %this.setDetailLevelSize("700", "1200");
   %this.setDetailLevelSize("100", "700");
   %this.setDetailLevelSize("99", "100");
   %this.addImposter("99", "4", "0", "0", "256", "0", "0");
}
