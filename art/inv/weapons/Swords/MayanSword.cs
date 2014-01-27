
singleton TSShapeConstructor(MayanSwordDts)
{
   baseShape = "./MayanSword.dts";
};

function MayanSwordDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000262667 0.140911 0.000178169 0.577026 0.577282 0.577742 4.18869", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "-0.0167959 -0.368124 0 1 0 0 0", "1");
}
