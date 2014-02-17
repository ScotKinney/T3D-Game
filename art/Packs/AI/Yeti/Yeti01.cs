
singleton TSShapeConstructor(Yeti01Dts)
{
   baseShape = "./Yeti01.dts";
};

function Yeti01Dts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Yeti/yeti_idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "Walk", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "Walk_Back", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "Strafe_Left", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_death01.dsq", "death1", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_death02.dsq", "death2", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_attack02.dsq", "lightrecoil", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_attack02.dsq", "attack", 0, -1);
   %this.setSequenceCyclic("attack", false);
   %this.addTrigger("Walk", "9", "1");
   %this.addTrigger("Walk", "19", "2");
   %this.addTrigger("attack", "14", "3");
}
