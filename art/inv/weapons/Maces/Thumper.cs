
singleton TSShapeConstructor(ThumperDts)
{
   baseShape = "./Thumper.dts";
};

function ThumperDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00334405 0.196129 -0.0505199 -0.151971 -0.16836 0.97394 1.61702", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "0.0189069 -0.00103399 0 0 -1 0 1.56593", "1");
}
