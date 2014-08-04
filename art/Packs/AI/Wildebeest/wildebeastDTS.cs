singleton TSShapeConstructor(WildebeastDTSDts)
{
   baseShape = "./wildebeastDTS.dts";
};

function WildebeastDTSDts::onLoad(%this)
{
   %this.addNode("Eye", "Quadruped_Skeleton_Chest1", "-0.0023745 1.39468 1.61789 0.708008 -0.698714 0.102578 3.3956", "1");
   %this.addNode("mount0", "Quadruped_Skeleton_Chest1", "-0.00237472 1.1592 2.06835 0.709584 -0.697156 0.102296 3.39606", "1");
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addSequence("art/Packs/AI/Wildebeest/Idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Wildebeest/WildeBeastDTS_Aggresive.dsq", "Attack2", "0", "12");
   %this.addSequence("art/Packs/AI/Wildebeest/WildeBeastDTS_Attack.dsq", "Attack1", "0", "12");
   %this.addSequence("art/Packs/AI/Wildebeest/WildeBeastDTS_Walk.dsq", "Walk", "0", "35");
   %this.addTrigger("Walk", "10", "1");
   %this.addTrigger("Walk", "18", "2");
   %this.addTrigger("Walk", "26", "1");
   %this.addTrigger("Walk", "34", "2");
   %this.addSequence("art/Packs/AI/Wildebeest/WildeBeastDTS_Run.dsq", "Run2", "0", "12");
   %this.addTrigger("Run2", "3", "1");
   %this.addTrigger("Run2", "4", "2");
   %this.addTrigger("Run2", "5", "1");
   %this.addTrigger("Run2", "6", "2");
   %this.addSequence("art/Packs/AI/Wildebeest/Death.dsq", "Death1", "0", "598");
   %this.addSequence("art/Packs/AI/Wildebeest/Damage1.dsq", "Damage1", "0", "88");
   %this.setSequenceCyclic("root", "1");
}
