
singleton TSShapeConstructor(Wall_MainDts)
{
   baseShape = "./Wall_Main.dts";
};

function Wall_MainDts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
