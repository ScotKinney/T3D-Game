
singleton TSShapeConstructor(Medit9Dts)
{
   baseShape = "./medit9.dts";
};

function Medit9Dts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("32", "200");
}
