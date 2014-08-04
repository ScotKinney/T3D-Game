
singleton TSShapeConstructor(GemsbockAntelopeDts)
{
   baseShape = "./GemsbockAntelope.dts";
};

function GemsbockAntelopeDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/GemsbockAntelope/Idle.dsq", "root", "0", "-1");
   %this.addSequence("art/Packs/AI/GemsbockAntelope/GemsbockAntelope_Walk.dsq", "Walk", "0", "35");
   %this.addSequence("art/Packs/AI/GemsbockAntelope/GemsbockAntelope_Trot.dsq", "Trot", "0", "35");
   %this.addSequence("art/Packs/AI/GemsbockAntelope/GemsbockAntelope_Run.dsq", "run2", "0", "17");
   %this.addSequence("art/Packs/AI/GemsbockAntelope/GemsbockAntelope_Attack.dsq", "Attack1", "0", "12");
   %this.addSequence("art/Packs/AI/GemsbockAntelope/GemsbockAntelope_Aggresive.dsq", "Attack2", "0", "12");
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addTrigger("Run2", "4", "1");
   %this.addTrigger("Run2", "7", "2");
   %this.addTrigger("Run2", "3", "1");
   %this.addTrigger("Run2", "6", "2");
   %this.addTrigger("walk", "10", "1");
   %this.addTrigger("walk", "18", "2");
   %this.addTrigger("walk", "27", "1");
   %this.addTrigger("walk", "35", "2");
   %this.addSequence("art/Packs/AI/GemsbockAntelope/Damage1.dsq", "Damage1", "0", "-1");
   %this.addSequence("art/Packs/AI/GemsbockAntelope/Death1.dsq", "Death1", "0", "-1");
}
