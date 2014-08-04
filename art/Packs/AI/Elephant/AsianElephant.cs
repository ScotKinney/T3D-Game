
singleton TSShapeConstructor(AsianElephantDts)
{
   baseShape = "./AsianElephant.dts";
};

function AsianElephantDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Elephant/AsianElephant_Idle.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Elephant/AsianElephant_Walk.dsq", "walk", "0", "178");
   %this.addSequence("art/Packs/AI/Elephant/AsianElephant_DrinkWater.dsq", "DrinkWater", "0", "178");
   %this.addSequence("art/Packs/AI/Elephant/AsianElephant_SprayWater.dsq", "SprayWater", "0", "116");
   %this.addSequence("art/Packs/AI/Elephant/AsianElephant_EatFrom_Tree.dsq", "EatFromTree", "0", "82");
   %this.addImposter("0", "6", "0", "0", "256", "1", "0");
   %this.addTrigger("walk", "21", "1");
   %this.addTrigger("walk", "59", "2");
   %this.addTrigger("walk", "30", "2");
   %this.addTrigger("walk", "43", "1");
   %this.addTrigger("walk", "80", "1");
   %this.addTrigger("walk", "90", "2");
   %this.addTrigger("walk", "105", "1");
   %this.addTrigger("walk", "121", "2");
   %this.addTrigger("walk", "139", "1");
   %this.addTrigger("walk", "148", "2");
   %this.addTrigger("walk", "163", "1");
   %this.addTrigger("walk", "178", "2");
   %this.addSequence("art/Packs/AI/Elephant/Damage1.dsq", "Damage1", "0", "88");
   %this.addSequence("art/Packs/AI/Elephant/Death1.dsq", "Death1", "0", "88");

}
