
singleton TSShapeConstructor(LanternDts)
{
   baseShape = "./Lantern.dts";
};

function LanternDts::onLoad(%this)
{
   %this.addCollisionDetail("-1", "26-DOP", "Lantern", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("Root", "0 0 0.25311 0 1 0 1.56723", "1");
   %this.removeNode("Col0");
   %this.removeMesh("Col 0");
   %this.removeMesh("ColConvex -1");
   %this.setNodeTransform("Lantern0", "1.81099e-008 0 0.279908 0 1 0 1.56717", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Lantern", "4", "30", "30", "32", "30", "30", "30");
}
