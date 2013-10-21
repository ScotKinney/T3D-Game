
singleton TSShapeConstructor(QuetzalcoatlusDts)
{
   baseShape = "./quetzalcoatlus.dts";
};

function QuetzalcoatlusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_run.dsq", "run", "0", "401");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_sprint.dsq", "sprint", "0", "40");
   %this.setSequenceCyclic("sprint", "1");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_back.dsq", "back", "0", "20");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_side.dsq", "side", "0", "20");
   %this.setSequenceCyclic("side", "1");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_attack1.dsq", "attack1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_attack2.dsq", "attack2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_attack3.dsq", "attack3", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_damage1.dsq", "damage1", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_damage2.dsq", "damage2", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_takeoff.dsq", "takeoff", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_fly.dsq", "fly", "0", "20");
   %this.setSequenceCyclic("fly", "1");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_land.dsq", "land", "0", "20");
   %this.addSequence("art/Packs/AI/Dinos/Quetzalcoatlus/quetzalcoatlus_death.dsq", "death1", "0", "20");
   %this.addTrigger("run", "5", "1");
   %this.addTrigger("run", "29", "2");
   %this.addTrigger("sprint", "4", "1");
   %this.addTrigger("sprint", "14", "2");
   %this.addTrigger("back", "11", "1");
   %this.addTrigger("back", "20", "2");
   %this.addTrigger("attack2", "20", "1");
   %this.addTrigger("attack2", "20", "2");
}
