

singleton TSShapeConstructor(FishingpoleDts)
{
   baseShape = "./fishingpole.dts";
};

function FishingpoleDts::onLoad(%this)
{
   %this.addNode("mountpoint", "fishpole0", "-0.0479481 -0.0474421 0.0212333 0 0 1 0.295075", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.22463 1.33793 0.00156571 0.643947 -0.505377 0.574391 1.89124", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
