
singleton TSShapeConstructor(SpearIron_thrownDts)
{
   baseShape = "./SpearIron_thrown.dts";
};

function SpearIron_thrownDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0222864 0 0.0243668 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0219866 -0.0571003 0.000852941 0.999089 0 -0.0426858 1.57092", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
