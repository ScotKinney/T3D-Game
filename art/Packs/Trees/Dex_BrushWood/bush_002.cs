
singleton TSShapeConstructor(Bush_002Dts)
{
   baseShape = "./bush_002.dts";
};

function Bush_002Dts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("32", "200");
}
