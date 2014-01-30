
singleton TSShapeConstructor(EqualizerDts)
{
   baseShape = "./Equalizer.dts";
};

function EqualizerDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.00959858 -0.122482 0.0116965 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0796818 0.318514 4.94429e-006 -0.644416 -0.540679 -0.540735 1.9968", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
