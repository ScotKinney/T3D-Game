
singleton TSShapeConstructor(AvengerDts)
{
   baseShape = "./Avenger.dts";
};

function AvengerDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "9.34284e-005 0.187306 6.18942e-005 1 0 0.000231254 1.57069", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "-0.0220733 -0.371245 0.017325 1 0 0 0", "1");
}
