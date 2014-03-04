
singleton TSShapeConstructor(Yeti03Dts)
{
   baseShape = "./Yeti03.dts";
};

function Yeti03Dts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Yeti/yeti_idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_walk.dsq", "Walk", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "Run2", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "Walk_Back", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "Strafe_Left", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_death01.dsq", "death1", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_death02.dsq", "death2", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_attack02.dsq", "lightrecoil", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_attack02.dsq", "attack", 0, -1);
   %this.setSequenceCyclic("attack", false);
   %this.addTrigger("Walk", "20", "1");
   %this.addTrigger("Walk", "6", "2");
   %this.addTrigger("Run2", "12", "1");
   %this.addTrigger("Run2", "3", "2");
   %this.addTrigger("attack", "14", "3");
   %this.setSequenceGroundSpeed("Walk", "0 3.5 0");
   %this.setSequenceGroundSpeed("Run2", "0 5 0");
}
