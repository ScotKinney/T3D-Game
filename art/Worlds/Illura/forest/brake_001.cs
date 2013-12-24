
singleton TSShapeConstructor(Brake_001Dts)
{
   baseShape = "./brake_001.dts";
};

function Brake_001Dts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "128", "0", "0");
   %this.setDetailLevelSize("32", "100");
}
