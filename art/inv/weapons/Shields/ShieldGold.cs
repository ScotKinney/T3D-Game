
singleton TSShapeConstructor(ShieldGoldDts)
{
   baseShape = "./ShieldGold.dts";
};

function ShieldGoldDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.135473 0.0175273 -0.116746 0.94532 -0.184331 -0.269056 0.310616", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.0181583 -0.0199644 0.0278904 0.793487 -0.447519 0.412438 1.82282", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
