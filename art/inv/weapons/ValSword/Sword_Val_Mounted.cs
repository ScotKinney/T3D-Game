
singleton TSShapeConstructor(Sword_Val_MountedDts)
{
   baseShape = "./Sword_Val_Mounted.dts";
};

function Sword_Val_MountedDts::onLoad(%this)
{
   %this.addNode("mountPoint", "Sword_Val_Mounted700", "-0.0475521 0 0 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.088283 -0.153949 -0.50866 -0.472122 -0.546001 0.692086 1.98786", "0");
   %this.setNodeTransform("Root", "0 0 0 1 0 0 0", "1");
}
