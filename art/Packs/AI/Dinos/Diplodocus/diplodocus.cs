
singleton TSShapeConstructor(DiplodocusDts)
{
   baseShape = "./diplodocus.dts";
};

function DiplodocusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_run.dsq", "run", "0", "880");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_sprint.dsq", "sprint", "0", "40");
   %this.setSequenceCyclic("sprint", "1");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_back.dsq", "back", "0", "20");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_attack3.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_damage1.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_damage2.dsq", "damage2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Diplodocus/diplodocus_death.dsq", "death1", "0", "20");
   %this.addTrigger("run", "13", "1");
   %this.addTrigger("run", "20", "2");
   %this.addTrigger("run", "27", "1");
   %this.addTrigger("run", "34", "2");
   %this.addTrigger("run", "1", "1");
   %this.addTrigger("run", "7", "2");
   %this.addTrigger("sprint", "1", "1");
   %this.addTrigger("sprint", "11", "2");
   %this.addTrigger("back", "1", "1");
   %this.addTrigger("back", "11", "2");
   %this.addTrigger("side", "1", "1");
   %this.addTrigger("side", "11", "2");
}
