
singleton TSShapeConstructor(StegosaurusDts)
{
   baseShape = "./stegosaurus.dts";
};

function StegosaurusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_run.dsq", "Walk", "0", "880");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_sprint.dsq", "Run2", "0", "40");
   %this.setSequenceCyclic("Run2", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_back.dsq", "Walk_Back", "0", "20");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_side.dsq", "Strafe_Left", "0", "20");
   %this.setSequenceCyclic("Strafe_Left", "1");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_attack3.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_damage1.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_damage2.dsq", "damage2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Stegosaurus/stegosaurus_death.dsq", "death1", "0", "20");
   %this.addTrigger("Walk", "13", "1");
   %this.addTrigger("Walk", "20", "2");
   %this.addTrigger("Walk", "27", "1");
   %this.addTrigger("Walk", "34", "2");
   %this.addTrigger("Walk", "1", "1");
   %this.addTrigger("Walk", "7", "2");
   %this.addTrigger("Run2", "1", "1");
   %this.addTrigger("Run2", "11", "2");
   %this.addTrigger("Walk_Back", "1", "1");
   %this.addTrigger("Walk_Back", "11", "2");
   %this.addTrigger("Strafe_Left", "1", "1");
   %this.addTrigger("Strafe_Left", "11", "2");
}
