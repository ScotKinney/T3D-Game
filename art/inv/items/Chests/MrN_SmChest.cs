
singleton TSShapeConstructor(MrN_SmChestDts)
{
   baseShape = "./MrN_SmChest.dts";
};

function MrN_SmChestDts::onLoad(%this)
{
   %this.addSequence("./OpenSmChest.dsq", "OpenSmChest", "0", "-1", "1", "0");
}
