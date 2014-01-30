
singleton TSShapeConstructor(SoulReaverLHDts)
{
   baseShape = "./SoulReaverLH.dts";
};

function SoulReaverLHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0112895 -0.368124 0.02349 0.821875 -0.000420941 -0.569668 0.290201", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00026261 0.140911 -0.000178171 0.577026 -0.577282 0.577742 2.0945", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
