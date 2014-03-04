
singleton TSShapeConstructor(MrN_CasketChestDts)
{
   baseShape = "./MrN_CasketChest.dts";
};

function MrN_CasketChestDts::onLoad(%this)
{
   %this.addSequence("./OpenCasketChest.dsq", "OpenCasketChest", "0", "-1", "1", "0");
}
