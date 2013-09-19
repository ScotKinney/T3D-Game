
singleton TSShapeConstructor(Fp_mushroomGRN002Dts)
{
   baseShape = "./fp_mushroomGRN002.dts";
};

function Fp_mushroomGRN002Dts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.068103 -0.0358467 0.378691 -0.193493 -0.0550223 0.979558 2.01878", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
