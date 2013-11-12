
singleton TSShapeConstructor(IceBallDts)
{
   baseShape = "./IceBall.dts";
};

function IceBallDts::onLoad(%this)
{
   %this.addNode("muzzlepoint", "", "0 0 0 0 0 1 0", "0");
}
