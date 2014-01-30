
singleton TSShapeConstructor(EqualizerLHDts)
{
   baseShape = "./EqualizerLH.dts";
};

function EqualizerLHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0102071 -0.21006 0.01 0.834541 -0.0775923 -0.545454 0.346062", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0796819 0.318514 -4.96512e-006 0.644417 -0.540679 0.540734 1.9968", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
