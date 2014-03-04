
singleton TSShapeConstructor(MrN_SmChestDts)
{
   baseShape = "./MrN_SmChest.dts";
};

function MrN_SmChestDts::onLoad(%this)
{
   %this.addSequence("./OpenSmChest.dsq", "OpenSmChest", "0", "-1", "1", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000709919 -0.0010501 0.469815 0.573099 0.577245 0.581675 4.18863", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
