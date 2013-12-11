
singleton TSShapeConstructor(FlintlockDts)
{
   baseShape = "./flintlock.dts";
};

function Flintlock2Dts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.000460333 -0.0501952 0.0137627 -0.715205 0.521948 0.464814 0.35656", "1");
}



function FlintlockDts::onLoad(%this)
{
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "0.198042 0.0611065 0.00526378 -0.142156 0.769875 -0.622161 3.41144", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
   %this.setNodeTransform("mountPoint", "0.000460333 -0.0650185 0.018 0 1 0 0.135849", "1");
}
