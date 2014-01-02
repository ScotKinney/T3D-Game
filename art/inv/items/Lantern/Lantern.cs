
singleton TSShapeConstructor(LanternDts)
{
   baseShape = "./Lantern.dts";
};

function LanternDts::onLoad(%this)
{
   %this.addCollisionDetail("-1", "26-DOP", "Lantern", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("Root", "0 0 0.25311 0 1 0 1.56717", "1");
   %this.removeNode("Col0");
   %this.removeMesh("Col 0");
   %this.removeMesh("ColConvex -1");
   %this.setNodeTransform("Lantern0", "1.81099e-008 0 0.279908 0 1 0 1.56717", "1");
   %this.addNode("Col-1", "Root", "4.18004e-009 0 0.263955 0 1 0 3.14389", "1");
   %this.addCollisionDetail("-1", "26-DOP", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setObjectNode("ColConvex", "");
   %this.setBounds("-0.105761 -0.0917291 -0.106603 0.101632 0.0878909 0.255785");
}
