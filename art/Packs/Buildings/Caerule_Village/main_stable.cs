
singleton TSShapeConstructor(Main_stableDts)
{
   baseShape = "./main_stable.dts";
};

function Main_stableDts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "512", "0", "0");
}
