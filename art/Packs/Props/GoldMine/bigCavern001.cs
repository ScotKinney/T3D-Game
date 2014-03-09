
singleton TSShapeConstructor(BigCavern001Dts)
{
   baseShape = "./bigCavern001.dts";
};

function BigCavern001Dts::onLoad(%this)
{
   %this.setDetailLevelSize("100", "1000");
   %this.setDetailLevelSize("30", "500");
}
