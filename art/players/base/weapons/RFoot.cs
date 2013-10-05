
singleton TSShapeConstructor(RFootDts)
{
   baseShape = "./RFoot.dts";
};

function RFootDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.01246 0.0872019 0.0665068 1 0 -6.00524e-009 1.57079", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
