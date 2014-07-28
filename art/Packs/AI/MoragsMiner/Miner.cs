
singleton TSShapeConstructor(MinerDts)
{
   baseShape = "./Miner.dts";
};

function MinerDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Idle.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Run.dsq", "walk", "0", "337");
   %this.setSequenceCyclic("run", "1");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Back.dsq", "back", "0", "51");
   %this.setSequenceCyclic("back", "1");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_SprintFull_Forward.dsq", "sprintFull_Forward", "0", "51");
   %this.setSequenceCyclic("sprintFull_Forward", "1");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Death1.dsq", "death1", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Death2.dsq", "death2", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Death3.dsq", "death3", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_BoringMe.dsq", "BoringMe", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Explain.dsq", "Explain", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_GoodLuckSalute.dsq", "GoodLuckSalute", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_LetMeThink.dsq", "LetMeThink", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_ListenToMe.dsq", "ListenToMe", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_NoNoNo.dsq", "NoNoNo", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_NotAChance.dsq", "NotAChance", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_Shrug.dsq", "Shrug", "0", "33");
   %this.addSequence("art/Packs/AI/MoragsMiner/Miner_WhatDoUWant.dsq", "WhatDoYouWant", "0", "33");
}
