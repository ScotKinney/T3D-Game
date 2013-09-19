
singleton TSShapeConstructor(HamDts)
{
   baseShape = "./Ham.dts";
};

function HamDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "1.2639e-008 3.98215e-006 0.205722 -0.00108142 -0.999999 0.00113008 1.5708", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
