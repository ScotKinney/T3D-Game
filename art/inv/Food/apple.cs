
singleton TSShapeConstructor(AppleDts)
{
   baseShape = "./apple.dts";
};

function AppleDts::onLoad(%this)
{
   %this.setBounds("-0.121258 -0.119209 0.00518732 0.114171 0.118212 0.215284");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00432401 -0.00259968 0.108929 -0.731434 -0.472361 -0.491812 1.77017", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
