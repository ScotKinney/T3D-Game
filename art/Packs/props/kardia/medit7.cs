
singleton TSShapeConstructor(Medit7Dts)
{
   baseShape = "./medit7.dts";
};

function Medit7Dts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("32", "200");
}
