
singleton TSShapeConstructor(FlexDecapitatorDts)
{
   baseShape = "./FlexDecapitator.dts";
};

function FlexDecapitatorDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "2.09548e-009 0.150343 0.1575 0.0171908 0 0.999852 1.57209", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
