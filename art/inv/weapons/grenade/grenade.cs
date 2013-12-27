
singleton TSShapeConstructor(GrenadeDts)
{
   baseShape = "./grenade.dts";
};

function GrenadeDts::onLoad(%this)
{
   %this.renameNode("Col-1", "GrenadeCol-1");
   %this.addNode("mountpoint", "Bomb0", "-0.0282049 -0.0843535 0.060096 -1 0 0 1.49068", "1");
   %this.removeDetailLevel("-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Bomb", "4", "30", "30", "32", "30", "30", "30");
}
