
singleton TSShapeConstructor(SwordfishDts)
{
   baseShape = "./swordfish.dts";
};

function SwordfishDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000168093 -1.49793 0.0600366 0.577632 0.577341 -0.577078 4.18878", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
