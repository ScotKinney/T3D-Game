
singleton TSShapeConstructor(sharktoothDae)
{
   baseShape = "./sharktooth.dae";
   upAxis = "Z_AXIS";
   unit = "0.1";
   loadLights = "0";
   adjustCenter = "1";
};



function sharktoothDae::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00420066 -2.08378e-009 -0.00309512 -4.71635e-008 -1 -5.62264e-008 1.39626", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
