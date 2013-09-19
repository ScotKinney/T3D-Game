
singleton TSShapeConstructor(SpartanSword1_4Dts)
{
   baseShape = "./SpartanSword1_4.dts";
};

function SpartanSword1_4Dts::onLoad(%this)
{
   %this.addNode("mountpoint", "SpartanSword0", "0.0148381 0 0.0331602 0 -1 0 1.23637", "1");
}
