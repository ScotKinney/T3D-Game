
singleton TSShapeConstructor(SpearIron_thrownDts)
{
   baseShape = "./SpearIron_thrown.dts";
};

function SpearIron_thrownDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0193846 0.0571004 -0.00091458 0.552155 -0.577399 0.601443 2.09432", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "-0.0222864 0 0.0243668 1 0 0 0", "1");
}
