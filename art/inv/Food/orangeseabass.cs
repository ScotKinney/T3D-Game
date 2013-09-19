
singleton TSShapeConstructor(OrangeSeaBassDts)
{
   baseShape = "./OrangeSeaBass.dts";
};

function OrangeSeaBassDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00020803 -0.508463 0.0265688 -0.0870512 -0.0868065 0.992415 1.57862", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
