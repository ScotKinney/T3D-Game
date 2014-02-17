
singleton TSShapeConstructor(GTDts)
{
   baseShape = "./GT.dts";
};

function GTDts::onLoad(%this)
{
   %this.addSequence("./GT_CombatRoot.dsq", "Root", "0", "50", "1", "0");
   %this.setSequenceCyclic("Root", "1");   
   %this.addSequence("./GT_Run.dsq", "Walk", "0", "22", "1", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("./GT_Back.dsq", "Walk_Back", "0", "22", "1", "0");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addSequence("./GT_CombatSprint.dsq", "Run2", "0", "19", "1", "0");
   %this.setSequenceCyclic("Run2", "1");
   %this.addSequence("./GT_StrafeLeft.dsq", "StrafeLeft", "0", "19", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addSequence("./GT_StrafeRight.dsq", "StrafeRight", "0", "19", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addSequence("./GT_JumpStanding.dsq", "Stand_Jump", "0", "19", "1", "0");
   %this.addSequence("./GT_JumpRunning.dsq", "Move_Jump", "0", "19", "1", "0");
   %this.addSequence("./GT_Swim.dsq", "Swim", "0", "19", "1", "0");
   %this.setSequenceCyclic("Swim", "1");
   %this.addSequence("./GT_Fall.dsq", "Fall", "0", "19", "1", "0");
   %this.setSequenceCyclic("Fall", "1");
   %this.addSequence("./GT_Damagefromback.dsq", "Damagefromback", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage1.dsq", "Damage1", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage2.dsq", "Damage2", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage3.dsq", "Damage3", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage4.dsq", "Damage4", "0", "19", "1", "0");
   %this.addSequence("./GT_DamageKnockedBack.dsq", "DamageKnockedBack", "0", "19", "1", "0");
   %this.addSequence("./GT_DamageKnockedFore.dsq", "DamageKnockedFore", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing1.dsq", "SwordSwing1", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing2.dsq", "SwordSwing2", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing3.dsq", "SwordSwing3", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing4.dsq", "SwordSwing4", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing5.dsq", "SwordSwing5", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing6.dsq", "SwordSwing6", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing7.dsq", "SwordSwing7", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing8.dsq", "SwordSwing8", "0", "19", "1", "0");
   %this.addSequence("./GT_SwordSwing9.dsq", "SwordSwing9", "0", "19", "1", "0");
   %this.addSequence("./GT_Death1.dsq", "Death1", "0", "19", "1", "0");
   %this.addSequence("./GT_Death2.dsq", "Death2", "0", "19", "1", "0");
   %this.addSequence("./GT_Death3.dsq", "Death3", "0", "19", "1", "0");
   %this.addSequence("./GT_Death4.dsq", "Death4", "0", "17", "1", "0");
   %this.addTrigger("Walk", "39", "1");
   %this.addTrigger("Walk", "20", "2");
   %this.addTrigger("Run2", "17", "1");
   %this.addTrigger("Run2", "7", "2");
   %this.addTrigger("Walk_Back", "7", "1");
   %this.addTrigger("Walk_Back", "18", "2");
}
