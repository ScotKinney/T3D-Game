
singleton TSShapeConstructor(TigerSharkDts)
{
   baseShape = "./TigerShark.dts";
};

function TigerSharkDts::onLoad(%this)
{
   %this.removeSequence("idle");
   %this.removeSequence("resurect");
   %this.renameSequence("swimidle", "root");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death1", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death2", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death3", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death4", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death5", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death6", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death7", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death8", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death9", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death10", "0", "10");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death11", "0", "10");
   %this.setBounds("-0.447049 -1.18249 -0.0891012 0.447054 1.09681 0.655819");
}
