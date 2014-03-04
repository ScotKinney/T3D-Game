
singleton TSShapeConstructor(MrN_CaptainsChestDts)
{
   baseShape = "./MrN_CaptainsChest.dts";
};

function MrN_CaptainsChestDts::onLoad(%this)
{
   %this.addSequence("./OpenCaptChest.dsq", "OpenCaptChest", "0", "-1", "1", "0");
}
