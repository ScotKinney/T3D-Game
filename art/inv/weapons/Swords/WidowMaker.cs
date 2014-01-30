
singleton TSShapeConstructor(WidowMakerDts)
{
   baseShape = "./WidowMaker.dts";
};

function WidowMakerDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00427702 0.524384 0.000205737 0.575103 -0.577505 0.579435 2.09416", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "-0.0171214 -0.0080216 0.0154147 1 0 0 0.0813422", "1");
}
