
singleton TSShapeConstructor(SpearStone_thrownDts)
{
   baseShape = "./SpearStone_thrown.dts";
};

function SpearStone_thrownDts::onLoad(%this)
{
   %this.setNodeTransform("mountPoint", "-0.0213386 0.0806015 0.0197852 1 0 0 0", "1");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.015666 0.0354723 0.0154075 -0.559586 -0.577841 -0.594107 2.09366", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
