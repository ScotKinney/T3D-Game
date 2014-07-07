
singleton TSShapeConstructor(Bush_001Dts)
{
   baseShape = "./bush_001.dts";
};

function Bush_001Dts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "128", "0", "0");
   %this.setDetailLevelSize("32", "200");
}
