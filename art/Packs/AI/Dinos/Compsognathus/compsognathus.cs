
singleton TSShapeConstructor(CompsognathusDts)
{
   baseShape = "./compsognathus.dts";
};

function CompsognathusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_run.dsq", "run", "0", "-1");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_sprint.dsq", "sprint", "0", "-1");
   %this.setSequenceCyclic("sprint", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_back.dsq", "back", "0", "-1");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_side.dsq", "side", "0", "-1");
   %this.setSequenceCyclic("side", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_attack1.dsq", "attack1", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_attack2.dsq", "attack2", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_attack3.dsq", "attack3", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_damage1.dsq", "damage1", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_damage2.dsq", "damage2", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death1", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death2", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death3", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death4", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death5", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death6", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death7", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death8", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death9", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death10", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death11", "0", "-1");
   %this.addTrigger("run", "21", "1");
   %this.addTrigger("run", "39", "2");
   %this.addTrigger("sprint", "11", "1");
   %this.addTrigger("sprint", "20", "2");
   %this.addTrigger("back", "2", "1");
   %this.addTrigger("back", "12", "2");
   %this.addTrigger("side", "10", "1");
   %this.addTrigger("side", "20", "2");
}
