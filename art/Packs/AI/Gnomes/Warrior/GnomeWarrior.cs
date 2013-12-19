
singleton TSShapeConstructor(GnomeWarriorDts)
{
   baseShape = "./GnomeWarrior.dts";
};

function GnomeWarriorDts::onLoad(%this)
{
   %this.addSequence("./W_CombatRoot.dsq", "Root", "0", "35", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./W_CombatSprint.dsq", "Sprint", "0", "35", "1", "0");
   %this.setSequenceCyclic("Sprint", "1");
   %this.addSequence("./GW_Back.dsq", "Back", "0", "26", "1", "0");
   %this.setSequenceCyclic("Back", "1");
   %this.addSequence("./W_StrafeLeft.dsq", "StrafeLeft", "0", "26", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addSequence("./W_StrafeRight.dsq", "StrafeRight", "0", "26", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addSequence("./W_JumpStanding.dsq", "JumpStanding", "0", "26", "1", "0");
   %this.addSequence("./W_JumpRunning.dsq", "JumpRunning", "0", "26", "1", "0");
   %this.addSequence("./GW_Falling.dsq", "Fall", "0", "26", "1", "0");
   %this.setSequenceCyclic("Fall", "1");
   %this.addSequence("./W_CombatWalk.dsq", "Run", "0", "26", "1", "0");
   %this.setSequencePriority("Run", "1");
   %this.setSequenceCyclic("Run", "1");
   %this.addSequence("./GW_Swimming.dsq", "Swim", "0", "26", "1", "0");
   %this.setSequenceCyclic("Swim", "1");
   %this.addSequence("./W_BangingShield.dsq", "BangingShield", "0", "26", "1", "0");
   %this.setSequenceCyclic("BangingShield", "1");
   %this.addSequence("./W_Block1LH.dsq", "Block_LH1", "0", "19", "1", "0");
   %this.addSequence("./W_Block2LH.dsq", "Block_LH2", "0", "19", "1", "0");
   %this.addSequence("./W_Block1RH.dsq", "Block_RH1", "0", "19", "1", "0");
   %this.addSequence("./W_Block2RH.dsq", "Block_RH2", "0", "19", "1", "0");
   %this.addSequence("./W_Block3RH.dsq", "Block_RH3", "0", "19", "1", "0");
   %this.addSequence("./W_Damage1.dsq", "Damage1", "0", "19", "1", "0");
   %this.addSequence("./W_Damage2.dsq", "Damage2", "0", "19", "1", "0");
   %this.addSequence("./W_Damage3.dsq", "Damage3", "0", "19", "1", "0");
   %this.addSequence("./W_Damage4.dsq", "Damage4", "0", "19", "1", "0");
   %this.addSequence("./W_DamageFromBack.dsq", "DamgeFromBack", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing1.dsq", "Attack1", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing2.dsq", "Attack2", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing3.dsq", "Attack3", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing4.dsq", "Attack4", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing5.dsq", "Attack5", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing6.dsq", "Attack6", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing7.dsq", "Attack7", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing8.dsq", "Attack8", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing9.dsq", "Attack9", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing10.dsq", "Attack10", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing11.dsq", "Attack11", "0", "19", "1", "0");
   %this.addSequence("./W_SwordSwing12.dsq", "Attack12", "0", "19", "1", "0");
   %this.addSequence("./W_Death1.dsq", "Death1", "0", "19", "1", "0");
   %this.addSequence("./W_Death2.dsq", "Death2", "0", "19", "1", "0");
   %this.addSequence("./W_Death3.dsq", "Death3", "0", "19", "1", "0");
   %this.addSequence("./W_Death4.dsq", "Death4", "0", "17", "1", "0");
   %this.addTrigger("Back", "7", "1");
   %this.addTrigger("Back", "18", "2");
   %this.renameNode("GW_axe", "mount0");
   %this.renameNode("GW_shield", "mount2");
}
