
singleton TSShapeConstructor(ChestDts)
{
   baseShape = "./chest.dts";
};

function ChestDts::onLoad(%this)
{
   %this.addNode("Col-1", "Chest", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setBounds("-0.27446 -0.465473 0 0.274459 0.465473 0.535324");
   %this.setNodeTransform("Chest", "0 0 0 1 0 0 0", "1");
}
