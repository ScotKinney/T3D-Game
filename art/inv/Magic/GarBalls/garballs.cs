
singleton TSShapeConstructor(LavaRockDts)
{
   baseShape = "./LavaRock.dts";
};

function LavaRockDts::onLoad(%this)
{
   %this.setNodeParent("muzzlePoint", "");
}
