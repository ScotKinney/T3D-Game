
singleton TSShapeConstructor(SnowWolfDts)
{
   baseShape = "./SnowWolf.dts";
};

function SnowWolfDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_IdleA_Howl_.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_Walk.dsq", "Walk", "0", "-1");
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_Run.dsq", "Run2", "0", "-1");
   %this.addSequence("art/Packs/AI/SnowWolf/SnowWolf_Death.dsq", "death1", "0", "11");
   %this.setSequenceGroundSpeed("Walk", "0 5 0");
   %this.setSequenceGroundSpeed("Run2", "0 2 0");
}
