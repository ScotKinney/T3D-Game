
singleton TSShapeConstructor(CratesSimple0001stain4Dts)
{
   baseShape = "./CratesSimple0001stain4.dts";
};

function CratesSimple0001stain4Dts::onLoad(%this)
{
   %this.setBounds("-0.99669 -1.47668 -0.00390615 0.973356 1.46333 1.35613");
   %this.removeDetailLevel("-1");
   %this.removeNode("Col-1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0116702 -0.00667156 0.67612 0.576973 0.577349 0.577729 4.18879", "0");
   %this.addCollisionDetail("-1", "Box", "crateHIGH", "4", "30", "30", "32", "30", "30", "30");
}
