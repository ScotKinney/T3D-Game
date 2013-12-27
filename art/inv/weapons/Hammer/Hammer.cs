
singleton TSShapeConstructor(HammerDts)
{
   baseShape = "./Hammer.dts";
};

function HammerDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Hammer0", "0.0222844 -0.206579 0.0922772 -0.202521 -0.969956 -0.134798 1.20325", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Hammer", "4", "30", "30", "32", "30", "30", "30");
}
