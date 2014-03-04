
singleton TSShapeConstructor(MrN_BigChestDts)
{
   baseShape = "./MrN_BigChest.dts";
};

function MrN_BigChestDts::onLoad(%this)
{
   %this.addSequence("./OpenBigChest.dsq", "OpenBigChest", "0", "-1", "1", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.00059961 0.011078 0.513479 0.999987 0 -0.00509951 1.49268", "0");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
