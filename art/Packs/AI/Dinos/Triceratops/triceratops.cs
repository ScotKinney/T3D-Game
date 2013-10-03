
singleton TSShapeConstructor(TriceratopsDts)
{
   baseShape = "./triceratops.dts";
};

function TriceratopsDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_run.dsq", "run", "0", "880");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_sprint.dsq", "sprint", "0", "40");
   %this.setSequenceCyclic("sprint", "1");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_back.dsq", "back", "0", "20");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_side.dsq", "side", "0", "20");
   %this.setSequenceCyclic("side", "1");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_attack3.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_damage1.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_damage2.dsq", "damage2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death4", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death5", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death6", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death7", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death8", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death9", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death10", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Triceratops/triceratops_death.dsq", "death11", "0", "20");
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
