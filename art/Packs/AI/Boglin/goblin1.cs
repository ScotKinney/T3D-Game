singleton TSShapeConstructor(Goblin1Dae)
{
   baseShape = "./goblin1.dae";
};         


function Goblin1Dae::onLoad(%this)
{
   %this.setNodeTransform("mount0", "0.41753 1.16691 1.915 0.15669 -0.447978 0.880207 2.24562", "1");
   %this.addSequence("./goblin_idle.dsq", "root", "0", "-1");
   %this.addSequence("./goblin_run.dsq", "run", "0", "-1");
   %this.addSequence("./goblin_backward.dsq", "back", "0", "-1");
   %this.addSequence("./goblin_strafeleft.dsq", "side", "0", "-1");
   %this.addSequence("./goblin_jump.dsq", "jump", "0", "-1");
   %this.addSequence("./goblin_attack01.dsq", "sword_Swing", "0", "-1");
   %this.addSequence("./goblin_attack02.dsq", "sword_Thrust", "0", "-1");
   %this.addSequence("./goblin_death01.dsq", "death1", "0", "-1");
   %this.addSequence("./goblin_death02.dsq", "death2", "0", "-1");
   %this.addTrigger("Run", "10", "1");
   %this.addTrigger("Run", "6", "2");
   %this.setSequenceCyclic("Sword_Swing", "0");
   %this.setSequenceCyclic("sword_Thrust", "0");
}
