

singleton TSShapeConstructor(AllosaurusDts)
{
   baseShape = "./allosaurus.dts";
};

function AllosaurusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_run.dsq", "run", "0", "880");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_sprint.dsq", "sprint", "0", "40");
   %this.setSequenceCyclic("sprint", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_back.dsq", "back", "0", "20");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_surprised.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_turnLeft.dsq", "side", "0", "20");
   %this.setSequenceCyclic("side", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_headKick.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death4", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death5", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death6", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death7", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death8", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death9", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death10", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death11", "0", "20");
   %this.addTrigger("run", "25", "2");
   %this.addTrigger("run", "8", "1");
   %this.addTrigger("sprint", "5", "1");
   %this.addTrigger("sprint", "14", "2");
   %this.addTrigger("back", "0", "1");
   %this.addTrigger("back", "12", "2");
   %this.addTrigger("side", "3", "1");
   %this.addTrigger("side", "13", "2");
   %this.setNodeTransform("mount0", "0.00669013 8.10465 7.48938 0.0888265 -0.960658 0.263146 1.59531", "1");
   %this.setSequenceGroundSpeed("run", "0 8 0");
}
