
singleton TSShapeConstructor(MrN_BigChestDts)
{
   baseShape = "./MrN_BigChest.dts";
};

function MrN_BigChestDts::onLoad(%this)
{
   %this.addSequence("./OpenBigChest.dsq", "OpenBigChest", "0", "-1", "1", "0");
}
