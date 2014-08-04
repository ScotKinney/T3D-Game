singleton TSShapeConstructor(RhinoDts)
{
   baseShape = "./Rhino.dts";
};

function RhinoDts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.setDetailLevelSize("32", "64");
   %this.addNode("eye", "Quadruped_Skeleton_Chest1", "0.0452878 1.73558 0.899632 -0.678309 0.685056 -0.2657 2.60024", "1");
   %this.addNode("mount0", "Quadruped_Skeleton_Chest1", "0.0452878 1.35037 0.233558 -0.219333 0.915695 -0.336742 3.06064", "1");
   %this.addSequence("art/Packs/AI/Rhino/Idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Rhino/Rhino_walk.dsq", "walk", "0", "200");
   %this.addSequence("art/Packs/AI/Rhino/Rhino_run.dsq", "Run2", "0", "-1");
   %this.addSequence("art/Packs/AI/Rhino/Rhino_Attack.dsq", "Attack1", "0", "60");
   %this.setSequenceBlend("Attack1", "0", "", "0");
   %this.addTrigger("Walk", "8", "1");
   %this.addTrigger("Walk", "16", "2");
   %this.addTrigger("Walk", "24", "3");
   %this.addTrigger("Walk", "31", "4");
   %this.addSequence("art/Packs/AI/Rhino/Death.dsq", "Death1", "0", "13");
   %this.addSequence("art/Packs/AI/Rhino/Damage1.dsq", "Damage1", "0", "13");
}
