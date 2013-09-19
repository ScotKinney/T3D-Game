singleton TSShapeConstructor(RedheadDts)
{
   baseShape = "./redhead.dts";
};

function RedheadDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-7.61408e-005 -0.48717 0.0265567 0.577612 0.577287 -0.577152 4.1887", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
