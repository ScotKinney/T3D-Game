singleton TSShapeConstructor(ImpalaDts)
{
   baseShape = "./Impala.dts";
};

function ImpalaDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Impala/Impala_IdleA.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Impala/Impala_Walk.dsq", "walk", "0", "88");
   %this.addSequence("art/Packs/AI/Impala/Impala_walk.dsq", "run2", "0", "35");
   %this.addSequence("art/Packs/AI/Impala/Impala_Attack.dsq", "attack", "0", "12");
   %this.addSequence("art/Packs/AI/Impala/Impala_Agressive.dsq", "Aggressive", "0", "12");
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addTrigger("walk", "20", "1");
   %this.addTrigger("walk", "22", "2");
   %this.addTrigger("walk", "17", "2");
   %this.addTrigger("walk", "4", "1");
   %this.addTrigger("walk", "31", "1");
   %this.addTrigger("walk", "2", "1");
   %this.addTrigger("walk", "35", "1");
   %this.addTrigger("run2", "0", "1");
   %this.addTrigger("run2", "4", "2");
   %this.addTrigger("run2", "7", "1");
   %this.addTrigger("run2", "11", "2");
   %this.addSequence("art/Packs/AI/Impala/Death.dsq", "Death1", "0", "199");
   %this.addSequence("art/Packs/AI/Impala/Damage1.dsq", "Damage1", "0", "88");
}
