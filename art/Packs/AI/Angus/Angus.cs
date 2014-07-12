
singleton TSShapeConstructor(AngusDts)
{
   baseShape = "./Angus.dts";
};

function AngusDts::onLoad(%this)
{
   %this.addSequence("art/packs/ai/angus/villager_Wait.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/packs/ai/angus/villager_walk.dsq", "run", "0", "110");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/packs/ai/angus/villager_Jump.dsq", "jump", "0", "36");
   %this.addSequence("art/packs/ai/angus/villager_Laugh.dsq", "Laugh", "0", "36");
   %this.addSequence("art/packs/ai/angus/villager_Boxing.dsq", "PunchRight", "0", "35");
   %this.addSequence("art/packs/ai/angus/villager_bye.dsq", "Wave", "0", "35");
   %this.addSequence("art/packs/ai/angus/villager_Salute.dsq", "Bow", "0", "22");
   %this.addSequence("art/packs/ai/angus/villager_Sure.dsq", "AgreeNod", "0", "36");
   %this.addSequence("art/packs/ai/angus/villager_talk.dsq", "Describe", "0", "36");
   %this.addNode("eye", "Bip01_Head", "0.130023 -1.29157 129.839 0.601309 -0.5999 -0.527775 2.19856", "1");
}
