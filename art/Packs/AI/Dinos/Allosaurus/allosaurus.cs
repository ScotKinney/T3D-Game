

singleton TSShapeConstructor(AllosaurusDts)
{
   baseShape = "./allosaurus.dts";
};

function AllosaurusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_run.dsq", "Walk", "0", "880");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_back.dsq", "Walk_Back", "0", "20");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_surprised.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_turnLeft.dsq", "Strafe_Left", "0", "20");
   %this.setSequenceCyclic("Strafe_Left", "1");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_headKick.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_death.dsq", "death1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Allosaurus/allosaurus_sprint.dsq", "run2", "0", "40");
   %this.setSequenceCyclic("run2", "1");
   %this.addTrigger("Walk", "27", "1");
   %this.addTrigger("Walk", "7", "2");
   %this.addTrigger("run2", "13", "1");
   %this.addTrigger("run2", "4", "2");
   %this.addTrigger("Walk_Back", "6", "1");
   %this.addTrigger("Walk_Back", "15", "2");
   %this.addTrigger("Strafe_Left", "3", "1");
   %this.addTrigger("Strafe_Left", "13", "2");
   %this.setNodeTransform("mount0", "0.00669013 8.10465 7.48938 0.0888265 -0.960658 0.263146 1.59531", "1");
   //%this.setSequenceGroundSpeed("Walk", "0 5.48 0"); // d/s
   //%this.setSequenceGroundSpeed("run2", "0 23.23 0");
   %this.setSequenceGroundSpeed("Walk", "0 7.305 0");  // d
   %this.setSequenceGroundSpeed("run2", "0 7.744 0");
}
