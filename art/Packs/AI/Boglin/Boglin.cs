
singleton TSShapeConstructor(BoglinDts)
{
   baseShape = "./Boglin.dts";
};

function BoglinDts::onLoad(%this)
{
   %this.renameNode("Bip01_Rhand_Weapon", "mount0");
   %this.renameNode("Bip01_shield_mount", "mount2");
   %this.addSequence("./Boglin_root.dsq", "Plain_Root", "0", "-1", "1", "0");
   %this.addSequence("./Boglin_RootCombat.dsq", "Root", "0", "58", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.setSequenceCyclic("Plain_Root", "1");
   %this.addSequence("./Boglin_Run.dsq", "Walk", "0", "50", "1", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addTrigger("Walk", "25", "1");
   %this.addTrigger("Walk", "10", "2");
   %this.addSequence("./Boglin_Sprint.dsq", "Run2", "0", "35", "1", "0");
   %this.setSequenceCyclic("Run2", "1");
   %this.addTrigger("Run2", "0", "1");
   %this.addTrigger("Run2", "12", "2");
   %this.addSequence("./Boglin_Jump.dsq", "Stand_Jump", "0", "22", "1", "0");
   %this.addSequence("./Boglin_RunJump.dsq", "Move_Jump", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Anger.dsq", "Anger", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Block1.dsq", "Shield_Block1", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Block2.dsq", "Shield_Block2", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Block3.dsq", "Sword_Block1", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Block4.dsq", "Sword_Block2", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Block5.dsq", "Sword_Block3", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Damage1.dsq", "Damage1", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Damage2.dsq", "Damage2", "0", "22", "1", "0");
   %this.addSequence("./Boglin_ClubSwing1.dsq", "Attack1", "0", "22", "1", "0");
   %this.addSequence("./Boglin_ClubSwing2.dsq", "Attack2", "0", "22", "1", "0");
   %this.addSequence("./Boglin_ClubSwing3.dsq", "Attack3", "0", "22", "1", "0");
   %this.addSequence("./Boglin_ClubSwing4.dsq", "Attack4", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Duck.dsq", "Duck", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Looking.dsq", "Looking", "0", "22", "1", "0");
   %this.setSequenceCyclic("Looking", "1");
   %this.addSequence("./Boglin_Stretching.dsq", "Stretching", "0", "50", "1", "0");
   %this.addSequence("./Boglin_Talking.dsq", "Talking", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Tracking.dsq", "Tracking", "0", "22", "1", "0");
   %this.addSequence("./Boglin_Death.dsq", "Death1", "0", "22", "1", "0");
   %this.addSequence("./Boglin_StrafeLeft.dsq", "Strafe_Left", "0", "35", "1", "0");
   %this.setSequenceCyclic("Strafe_Left", "1");
   %this.addTrigger("Strafe_Left", "13", "1");
   %this.addTrigger("Strafe_Left", "18", "2");
   %this.addSequence("./Boglin_StepLeft.dsq", "Side_Left", "0", "35", "1", "0");
   %this.setSequenceCyclic("Side_Left", "1");
   %this.addTrigger("Side_Left", "10", "1");
   %this.addTrigger("Side_Left", "20", "2");
   %this.addSequence("./Boglin_StepRight.dsq", "Side_Right", "0", "20", "1", "0");
   %this.setSequenceCyclic("Side_Right", "1");
   %this.addTrigger("Side_Right", "12", "2");
   %this.addTrigger("Side_Right", "20", "1");
   %this.addSequence("./Boglin_StrafeRight.dsq", "Strafe_Right", "0", "35", "1", "0");
   %this.setSequenceCyclic("Strafe_Right", "1");
   %this.addTrigger("Strafe_Right", "11", "1");
   %this.addTrigger("Strafe_Right", "17", "2");
   %this.setSequenceGroundSpeed("Walk", "0 0.9 0"); //try at maximum forward speed to start.
   %this.setSequenceGroundSpeed("run2", "0 1.95 0"); //adjust by watching the AI run
}
