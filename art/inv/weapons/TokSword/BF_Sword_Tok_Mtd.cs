
singleton TSShapeConstructor(BF_Sword_Tok_MtdDts)
{
   baseShape = "./BF_Sword_Tok_Mtd.dts";
};

function BF_Sword_Tok_MtdDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Sword_Tok700", "-0.00648113 -0.0673447 -0.142879 1 0 0 0", "1");
}
