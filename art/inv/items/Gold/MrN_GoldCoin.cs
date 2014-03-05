
singleton TSShapeConstructor(MrN_GoldCoinDts)
{
   baseShape = "./MrN_GoldCoin.dts";
};

function MrN_GoldCoinDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000901733 0.00295884 0.00675958 -0.773579 -0.44792 -0.448267 1.82195", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
