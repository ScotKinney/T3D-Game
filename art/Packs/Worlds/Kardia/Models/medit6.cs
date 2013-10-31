
singleton TSShapeConstructor(Medit6Dts)
{
   baseShape = "./medit6.dts";
};

function Medit6Dts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("32", "200");
}
