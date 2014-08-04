singleton TSShapeConstructor(KuduAntelopeDts)
{
   baseShape = "./KuduAntelope.dts";
};

function KuduAntelopeDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/KuduAntelope/KuduAntelope_IdleA.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/KuduAntelope/KuduAntelope_Aggresive.dsq", "Attack1", "0", "12");
   %this.addSequence("art/Packs/AI/KuduAntelope/KuduAntelope_Attack.dsq", "Attack2", "0", "12");
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addSequence("art/Packs/AI/KuduAntelope/KuduAntelope_Walk.dsq", "Walk", "0", "35");
   %this.addTrigger("Walk", "9", "1");
   %this.addTrigger("Walk", "18", "2");
   %this.addTrigger("Walk", "26", "1");
   %this.addTrigger("Walk", "34", "2");
   %this.addSequence("art/Packs/AI/KuduAntelope/KuduAntelope_Run.dsq", "Run2", "0", "-1");
   %this.addTrigger("Run2", "1", "1");
   %this.addTrigger("Run2", "2", "2");
   %this.addTrigger("Run2", "4", "1");
   %this.addTrigger("Run2", "5", "2");
   %this.addSequence("art/Packs/AI/KuduAntelope/Damage1.dsq", "Damage1", "0", "-1");
   %this.addSequence("art/Packs/AI/KuduAntelope/Death.dsq", "Death1", "0", "60");
}
