
singleton TSShapeConstructor(SpearStone_thrownDts)
{
   baseShape = "./SpearStone_thrown.dts";
};

function SpearStone_thrownDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "0.0331258 0.0806015 0.0197852 0 0 1 3.10947", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0166171 -0.0354684 0.0163739 -0.999552 0 0.0299196 1.57207", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
