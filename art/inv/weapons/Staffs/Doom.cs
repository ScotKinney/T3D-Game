
singleton TSShapeConstructor(DoomDts)
{
   baseShape = "./Doom.dts";
};

function DoomDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0201929 -0.00107536 0.0250942 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00327572 0.0220285 0.00236278 -0.999999 0 -0.00159536 1.57265", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
