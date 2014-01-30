
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
   %this.setNodeTransform("mountPoint", "0.000460333 -0.0650185 0.018 0 -1 0 0.124688", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addCollisionDetail("-1", "26-DOP", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
