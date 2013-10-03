
singleton TSShapeConstructor(ParasaurolophusDts)
{
   baseShape = "./parasaurolophus.dts";
};

function ParasaurolophusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_run.dsq", "run", "0", "880");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_sprint.dsq", "sprint", "0", "40");
   %this.setSequenceCyclic("sprint", "1");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_back.dsq", "back", "0", "20");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_side.dsq", "side", "0", "20");
   %this.setSequenceCyclic("side", "1");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_attack3.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_damage1.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_damage2.dsq", "damage2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death4", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death5", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death6", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death7", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death8", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death9", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death10", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Parasaurolophus/parasaurolophus_death.dsq", "death11", "0", "20");
   %this.addTrigger("run", "25", "2");
   %this.addTrigger("run", "8", "1");
   %this.addTrigger("sprint", "5", "1");
   %this.addTrigger("sprint", "14", "2");
   %this.addTrigger("back", "0", "1");
   %this.addTrigger("back", "12", "2");
   %this.addTrigger("side", "3", "1");
   %this.addTrigger("side", "13", "2");
}
