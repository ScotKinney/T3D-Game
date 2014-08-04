singleton TSShapeConstructor(ZebraDts)
{
   baseShape = "./Zebra.dts";
};

function ZebraDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Zebra/Idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/Zebra/Zebra_Walk.dsq", "Run2", "0", "11");
   %this.addSequence("art/Packs/AI/Zebra/Zebra_Attack.dsq", "Attack", "0", "11");
   %this.addSequence("art/Packs/AI/Zebra/Zebra_Walk.dsq", "Walk", "0", "33");
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addTrigger("Run2", "3", "1");
   %this.addTrigger("Run2", "6", "2");
   %this.addTrigger("Run2", "8", "1");
   %this.addTrigger("Run2", "11", "2");
   %this.addTrigger("Walk", "10", "1");
   %this.addTrigger("Walk", "17", "2");
   %this.addTrigger("Walk", "24", "1");
   %this.addTrigger("Walk", "32", "2");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Zebra/Death.dsq", "Death1", "0", "373");
   %this.addSequence("art/Packs/AI/Zebra/Damage1.dsq", "Damage1", "0", "88");
}
