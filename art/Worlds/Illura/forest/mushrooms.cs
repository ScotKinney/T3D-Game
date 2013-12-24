
singleton TSShapeConstructor(MushroomsDts)
{
   baseShape = "./mushrooms.dts";
};

function MushroomsDts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
   %this.setDetailLevelSize("32", "100");
}
