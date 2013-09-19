
singleton TSShapeConstructor(Scimitar_BF_MtdDts)
{
   baseShape = "./Scimitar_BF_Mtd.dts";
};

function Scimitar_BF_MtdDts::onLoad(%this)
{
   %this.addNode("mountpoint", "Scimitar700", "0.037494 0.134049 0 1 0 0 0", "1");
}
