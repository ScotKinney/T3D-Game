
singleton TSShapeConstructor(SpearIron_meleeDts)
{
   baseShape = "./SpearIron_melee.dts";
};

function SpearIron_meleeDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0207565 0 0.0208239 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0108665 0.285447 -9.91654e-005 0.583469 -0.577351 0.571166 2.09439", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
