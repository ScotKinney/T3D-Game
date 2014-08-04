singleton TSShapeConstructor(GiraffeDts)
{
   baseShape = "./Giraffe.dts";
};

function GiraffeDts::onLoad(%this)
{
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addSequence("art/Packs/AI/Giraffe/Idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Giraffe/Giraffe_Attack.dsq", "Attack", "0", "-1");
   %this.addSequence("art/Packs/AI/Giraffe/Giraffe_Death.dsq", "Death1", "0", "-1");
   %this.addSequence("art/Packs/AI/Giraffe/Walk.dsq", "Walk", "0", "-1");
   %this.addSequence("art/Packs/AI/Giraffe/Damage1.dsq", "Damage1", "0", "-1");
   %this.addTrigger("Walk", "10", "1");
   %this.addTrigger("Walk", "17", "2");
   %this.addTrigger("Walk", "23", "1");
   %this.addTrigger("Walk", "29", "2");
   %this.addTrigger("Walk", "35", "1");
   %this.addTrigger("Walk", "45", "2");
   %this.addTrigger("Walk", "49", "1");
   %this.addTrigger("Walk", "59", "2");
   %this.setSequenceCyclic("Walk", "1");
   %this.setSequenceCyclic("root", "1");
}
