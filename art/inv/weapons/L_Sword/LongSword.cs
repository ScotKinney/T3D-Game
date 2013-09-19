
singleton TSShapeConstructor(LongSwordDts)
{
   baseShape = "./LongSword.dts";
};

function LongSwordDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00161492 0.500248 0.10889 -0.0967892 -0.0864925 0.99154 1.58225", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.addNode("mountpoint", "LongSword0", "0.014448 -0.0366281 0.0146121 0 -1 0 1.51384", "1");
}
