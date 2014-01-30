
singleton TSShapeConstructor(WidowMakerDts)
{
   baseShape = "./WidowMaker.dts";
};

function WidowMakerDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0171214 -0.0080216 0.0154147 1 0 0 0.0813422", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.00768112 0.524288 0.00019285 -0.999993 0 0.00375294 1.5712", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
