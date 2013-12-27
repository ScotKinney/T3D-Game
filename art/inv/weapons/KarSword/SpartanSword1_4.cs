
singleton TSShapeConstructor(SpartanSword1_4Dts)
{
   baseShape = "./SpartanSword1_4.dts";
};

function SpartanSword1_4Dts::onLoad(%this)
{
   %this.addNode("mountpoint", "SpartanSword0", "0.0148381 0 0.0331602 0 -1 0 1.23637", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "SpartanSword", "4", "30", "30", "32", "30", "30", "30");
}
