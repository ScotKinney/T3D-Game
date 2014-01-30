
singleton TSShapeConstructor(FuryDts)
{
   baseShape = "./Fury.dts";
};

function FuryDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.00331638 -0.0813145 0.0195134 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0339779 0.203979 0.00472852 -0.92126 -0.328649 0.208012 1.6727", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
