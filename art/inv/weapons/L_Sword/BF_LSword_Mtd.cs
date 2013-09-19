
singleton TSShapeConstructor(BF_LSword_MtdDts)
{
   baseShape = "./BF_LSword_Mtd.dts";
};

function BF_LSword_MtdDts::onLoad(%this)
{
   %this.addNode("mountpoint", "LongSword0", "0.0415205 0.0234219 -0.00333365 1 0 0 0", "1");
}
