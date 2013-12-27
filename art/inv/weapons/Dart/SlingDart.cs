
singleton TSShapeConstructor(SlingDartDts)
{
   baseShape = "./SlingDart.dts";
};

function SlingDartDts::onLoad(%this)
{
   %this.addNode("mountpoint", "SlingDart0", "0.00886304 -0.133388 0.023131 0 0 1 3.05532", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "SlingDart", "4", "30", "30", "32", "30", "30", "30");
}
