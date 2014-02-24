
singleton TSShapeConstructor(Medit8Dts)
{
   baseShape = "./medit8.dts";
};

function Medit8Dts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("32", "200");
}
