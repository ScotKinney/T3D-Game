
singleton TSShapeConstructor(AnnihilatorLHDts)
{
   baseShape = "./AnnihilatorLH.dts";
};

function AnnihilatorLHDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0147985 -0.464781 0.0147469 0.672863 0.0708609 -0.736365 0.291299", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.000118027 0.108369 -3.84449e-005 0.577168 -0.577324 0.577559 2.09443", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
