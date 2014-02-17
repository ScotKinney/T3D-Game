
singleton TSShapeConstructor(TRexDts)
{
   baseShape = "./TRex.dts";
};

function TRexDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_run.dsq", "Walk", "0", "40");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_sprint.dsq", "Run2", "0", "40");
   %this.setSequenceCyclic("Run2", "1");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_back.dsq", "Walk_Back", "0", "20");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_side.dsq", "Strafe_Left", "0", "20");
   %this.setSequenceCyclic("Strafe_Left", "1");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_attack3.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_damage1.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_damage2.dsq", "damage2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/TRex/TRex_death.dsq", "death1", "0", "20");
   %this.addTrigger("Walk", "25", "2");
   %this.addTrigger("Walk", "8", "1");
   %this.addTrigger("Run2", "5", "1");
   %this.addTrigger("Run2", "14", "2");
   %this.addTrigger("Walk_Back", "0", "1");
   %this.addTrigger("Walk_Back", "12", "2");
   %this.addTrigger("Strafe_Left", "3", "1");
   %this.addTrigger("Strafe_Left", "13", "2");
}
