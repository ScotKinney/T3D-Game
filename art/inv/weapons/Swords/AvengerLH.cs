
singleton TSShapeConstructor(AvengerLHDts)
{
   baseShape = "./AvengerLH.dts";
};

function AvengerLHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.00816914 -0.371245 0.0165435 0.681087 0.208072 -0.702016 0.405228", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-9.33968e-005 0.187306 -6.17961e-005 -1 0 -0.000231165 1.57069", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
