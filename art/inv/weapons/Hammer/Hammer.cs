
singleton TSShapeConstructor(HammerDts)
{
   baseShape = "./Hammer.dts";
};

function HammerDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0037894 0.00480407 0.159626 -0.321759 -0.323937 0.889683 1.68706", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("mountpoint", "Hammer0", "0.0222844 -0.206579 0.0922772 -0.202521 -0.969956 -0.134798 1.20325", "1");
}
