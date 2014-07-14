
singleton TSShapeConstructor(SP_TowerRockDts)
{
   baseShape = "./SP_TowerRock.dts";
};

function SP_TowerRockDts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "128", "0", "0");
}
