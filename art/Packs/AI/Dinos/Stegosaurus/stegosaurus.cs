
singleton TSShapeConstructor(StegosaurusDts)
{
   baseShape = "./stegosaurus.dts";
};

function StegosaurusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_run.dsq", "run", "0", "880");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_sprint.dsq", "sprint", "0", "40");
   %this.setSequenceCyclic("sprint", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_back.dsq", "back", "0", "20");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_side.dsq", "side", "0", "20");
   %this.setSequenceCyclic("side", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_attack3.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_damage1.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_damage2.dsq", "damage2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_death.dsq", "death1", "0", "20");
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
