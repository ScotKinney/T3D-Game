
singleton TSShapeConstructor(LongSwordDts)
{
   baseShape = "./LongSword.dts";
};

function LongSwordDts::onLoad(%this)
{
   %this.addNode("mountpoint", "LongSword0", "0.014448 -0.0366281 0.0146121 0 -1 0 1.51384", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "LongSword", "4", "30", "30", "32", "30", "30", "30");
}
