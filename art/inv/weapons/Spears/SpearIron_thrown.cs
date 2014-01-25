
singleton TSShapeConstructor(SpearIron_thrownDts)
{
   baseShape = "./SpearIron_thrown.dts";
};

function SpearIron_thrownDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0182914 0.121506 0.0243668 0 0 1 3.26888", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0193834 0.0571004 -0.000914738 0.55215 -0.5774 0.601448 2.09432", "0");
   %this.addCollisionDetail("-1", "Box", "IronSpear_Thrown", "4", "30", "30", "32", "30", "30", "30");
}
