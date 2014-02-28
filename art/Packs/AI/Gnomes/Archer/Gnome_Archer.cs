
singleton TSShapeConstructor(Gnome_ArcherDts)
{
   baseShape = "./Gnome_Archer.dts";
};

function Gnome_ArcherDts::onLoad(%this)
{
   %this.setNodeTransform("GA_sword01", "0.264061 -0.019973 0.566995 0.719155 -0.666956 -0.194897 2.62997", "1");
   %this.renameNode("GA_Sword01", "mount0");
   %this.addSequence("./CrossbowRoot.dsq", "Root", "0", "49", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./CrossbowRun.dsq", "Walk", "0", "-1", "1", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("./CrossbowSprint.dsq", "Run2", "0", "25", "1", "0");
   %this.setSequenceCyclic("Run2", "1");
   %this.addSequence("./CrossbowBack.dsq", "Walk_Back", "0", "22", "1", "0");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addTrigger("Walk_Back", "7", "1");
   %this.addTrigger("Walk_Back", "18", "2");
   %this.addSequence("./CrossbowJump.dsq", "Stand_Jump", "0", "22", "1", "0");
   %this.addSequence("./CrossbowStrafeLeft.dsq", "StrafeLeft", "0", "22", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addSequence("./CrossbowStrafeRight.dsq", "StrafeRight", "0", "22", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addSequence("./CrossbowReloadFire.dsq", "Attack1", "0", "-1", "1", "0");
   %this.addSequence("./CrossbowFire.dsq", "Attack2", "0", "-1", "1", "0");
   %this.addSequence("./CrossbowRunningJump.dsq", "Move_Jump", "0", "22", "1", "0");
   %this.addSequence("./Falling.dsq", "Fall", "0", "25", "1", "0");
   %this.addSequence("./CrossbowTracking.dsq", "Tracking", "0", "17", "1", "0");
   %this.addSequence("./DamageFromBack.dsq", "DamageFromBack", "0", "22", "1", "0");
   %this.addSequence("./DamageHeadFront.dsq", "Damage1", "0", "22", "1", "0");
   %this.addSequence("./DamageHeadLeft.dsq", "Damage2", "0", "22", "1", "0");
   %this.addSequence("./DamageHeadRight.dsq", "Damage3", "0", "22", "1", "0");
   %this.addSequence("./CrossbowDeath1.dsq", "Death1", "0", "17", "1", "0");
   %this.addSequence("./CrossbowDeath2.dsq", "Death2", "0", "17", "1", "0");
   %this.addSequence("./CrossbowDeath3.dsq", "Death3", "0", "17", "1", "0");
   %this.addSequence("./CrossbowDeath4.dsq", "Death4", "0", "17", "1", "0");
   %this.addSequence("./Swimming.dsq", "Swim_Root", "0", "-1", "1", "0");
   %this.addSequence("./Swimming.dsq", "Swim_Forward", "0", "-1", "1", "0");
   %this.addSequence("./Swimming.dsq", "Swim_Left", "0", "-1", "1", "0");
   %this.addSequence("./Swimming.dsq", "Swim_Surface", "0", "-1", "1", "0");
   %this.addTrigger("Attack1", "110", "3");
   %this.addTrigger("Attack2", "18", "3");
   %this.addImposter("0", "64", "0", "0", "256", "0", "0");
   %this.setSequenceGroundSpeed("Walk", "0 1.25 0");
   %this.setSequenceGroundSpeed("run2", "0 2.5 0");
   %this.setSequenceCyclic("Swim_Root", "1");
   %this.setSequenceCyclic("Swim_Forward", "1");
   %this.setSequenceCyclic("Swim_Left", "1");
   %this.setSequenceCyclic("Swim_Surface", "1");
   %this.addTrigger("Walk", "6", "1");
   %this.addTrigger("Walk", "25", "2");
   %this.addTrigger("Run2", "18", "1");
   %this.addTrigger("Run2", "8", "2");
}
