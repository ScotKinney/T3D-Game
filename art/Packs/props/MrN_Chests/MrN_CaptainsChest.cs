
singleton TSShapeConstructor(MrN_CaptainsChestDts)
{
   baseShape = "./MrN_CaptainsChest.dts";
};

function MrN_CaptainsChestDts::onLoad(%this)
{
   %this.addSequence("./OpenCaptChest.dsq", "OpenCaptChest", "0", "-1", "1", "0");
   %this.addNode("Col-1", "", "0 0 0 0 0 1 0", "0");
   %this.addNode("ColBox-1", "Col-1", "-0.0023947 -0.0348901 0.474234 0.590777 -0.574095 0.566919 2.10319", "1");
   %this.addCollisionDetail("-1", "Box", "Bounds", "4", "30", "30", "32", "30", "30", "30");
}
