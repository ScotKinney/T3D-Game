
singleton TSShapeConstructor(CompsognathusDts)
{
   baseShape = "./compsognathus.dts";
};

function CompsognathusDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_root.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_run.dsq", "Walk", "0", "-1");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_sprint.dsq", "Run2", "0", "-1");
   %this.setSequenceCyclic("Run2", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_back.dsq", "Walk_Back", "0", "-1");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_side.dsq", "Strafe_Left", "0", "-1");
   %this.setSequenceCyclic("Strafe_Left", "1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_attack1.dsq", "attack1", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_attack2.dsq", "attack2", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_attack3.dsq", "attack3", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_damage1.dsq", "damage1", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_damage2.dsq", "damage2", "0", "-1");
   %this.addSequence("art/Packs/AI/Dinos/Compsognathus/compsognathus_death.dsq", "death1", "0", "-1");
   %this.addTrigger("Walk", "21", "1");
   %this.addTrigger("Walk", "39", "2");
   %this.addTrigger("Run2", "11", "1");
   %this.addTrigger("Run2", "20", "2");
   %this.addTrigger("Walk_Back", "2", "1");
   %this.addTrigger("Walk_Back", "12", "2");
   %this.addTrigger("Strafe_Left", "10", "1");
   %this.addTrigger("Strafe_Left", "20", "2");
}
