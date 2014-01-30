
singleton TSShapeConstructor(ReaverDts)
{
   baseShape = "./Reaver.dts";
};

function ReaverDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0028114 0.382598 -0.127917 -0.165382 -0.171815 0.971148 1.59672", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("Root", "0 0 0 1 0 0 0", "1");
   %this.setNodeTransform("mountPoint", "0.0228441 -0.00248235 0.0206305 0 -1 0 1.53617", "1");
}
