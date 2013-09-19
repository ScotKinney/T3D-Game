
singleton TSShapeConstructor(LongSword_MountedDts)
{
   baseShape = "./LongSword_Mounted.dts";
};

function LongSword_MountedDts::onLoad(%this)
{
   %this.addNode("mountpoint", "LongSword700", "0.0253301 0.0400686 0.0146285 1 0 0 0", "1");
}
