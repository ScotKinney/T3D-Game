
singleton TSShapeConstructor(GrenadeDts)
{
   baseShape = "./grenade.dts";
};

function GrenadeDts::onLoad(%this)
{
   %this.renameNode("Col-1", "GrenadeCol-1");
   %this.addNode("mountpoint", "Bomb0", "-0.0282049 -0.0843535 0.060096 -1 0 0 1.49068", "1");
}
