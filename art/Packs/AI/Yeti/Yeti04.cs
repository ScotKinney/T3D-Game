
singleton TSShapeConstructor(Yeti04Dts)
{
   baseShape = "./Yeti04.dts";
};

function Yeti04Dts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Yeti/yeti_idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "run", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "back", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_run.dsq", "side", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_death01.dsq", "death1", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_death02.dsq", "death2", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_attack02.dsq", "lightrecoil", "0", "-1");
   %this.addSequence("art/Packs/AI/Yeti/yeti_attack02.dsq", "attack", 0, -1);
   %this.setSequenceCyclic("attack", false);
   %this.addTrigger("run", "9", "1");
   %this.addTrigger("run", "19", "2");
   %this.addTrigger("attack", "14", "3");
}

