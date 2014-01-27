
singleton TSShapeConstructor(VikingSwordDts)
{
   baseShape = "./VikingSword.dts";
};

function VikingSwordDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0151558 -0.447023 0.0156544 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000118067 0.108369 3.85947e-005 0.577168 0.577324 0.577559 4.18875", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
