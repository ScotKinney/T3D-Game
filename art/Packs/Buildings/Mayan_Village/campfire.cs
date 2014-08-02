
singleton TSShapeConstructor(CampfireDts)
{
   baseShape = "./campfire.dts";
};

function CampfireDts::onLoad(%this)
{
   %this.addImposter("0", "4", "0", "0", "128", "0", "0");
}
