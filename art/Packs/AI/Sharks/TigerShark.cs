
singleton TSShapeConstructor(TigerSharkDts)
{
   baseShape = "./TigerShark.dts";
};

function TigerSharkDts::onLoad(%this)
{
   %this.removeSequence("idle");
   %this.removeSequence("resurect");
   %this.removeSequence("Death");
   %this.removeSequence("Attack1");
   %this.renameSequence("swimidle", "root");
   %this.renameSequence("swim", "walk");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_death.dsq", "death1", "0", "-1");
   %this.addSequence("art/Packs/AI/Sharks/TigerShark_attack1.dsq", "attack1", "0", "-1");
   %this.setSequenceCyclic("attack1", false);
   %this.setBounds("-0.447049 -1.18249 -0.0891012 0.447054 1.09681 0.655819");
}
