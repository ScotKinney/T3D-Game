
singleton TSShapeConstructor(Brake_002Dts)
{
   baseShape = "./brake_002.dts";
};

function Brake_002Dts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "128", "0", "0");
   %this.setDetailLevelSize("32", "100");
}
