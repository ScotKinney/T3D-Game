
singleton TSShapeConstructor(Medit9NewDts)
{
   baseShape = "./medit9New.dts";
};

function Medit9NewDts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "0", "0");
   %this.setDetailLevelSize("32", "200");
}
