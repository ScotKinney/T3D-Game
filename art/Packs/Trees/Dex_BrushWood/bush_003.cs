
singleton TSShapeConstructor(Bush_003Dts)
{
   baseShape = "./bush_003.dts";
};

function Bush_003Dts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "128", "0", "0");
   %this.setDetailLevelSize("32", "100");
}
