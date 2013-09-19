
singleton TSShapeConstructor(SlingDartDts)
{
   baseShape = "./SlingDart.dts";
};

function SlingDartDts::onLoad(%this)
{
   %this.addNode("mountpoint", "SlingDart0", "0.00886304 -0.133388 0.023131 0 0 1 3.05532", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00149718 0.00832118 0.00477777 1 0 -0.000603273 1.57041", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
