
singleton TSShapeConstructor(JackHammerDts)
{
   baseShape = "./JackHammer.dts";
};

function JackHammerDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00388598 0.18046 -0.00175762 0.00224193 0 0.999997 1.57071", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "0.0164902 -0.045204 0.0181829 0 -1 0 1.34449", "1");
}
