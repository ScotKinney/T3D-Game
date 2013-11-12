
singleton TSShapeConstructor(SnowWolfDts)
{
   baseShape = "./SnowWolf.dts";
};

function SnowWolfDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_IdleA_Howl_.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_Walk.dsq", "run", "0", "188");
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_Run.dsq", "sprintFullForward", "0", "87");
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_Death.dsq", "death", "0", "11");
}
