

singleton TSShapeConstructor(MudfishDts)
{
   baseShape = "./mudfish.dts";
};

function MudfishDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.000322091 -0.477403 -0.0166646 0.0155774 0 0.999879 1.57084", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
