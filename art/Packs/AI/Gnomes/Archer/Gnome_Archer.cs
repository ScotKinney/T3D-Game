
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
   %this.addSequence("./CrossbowRun.dsq", "Run", "0", "25", "1", "0");
   %this.setSequenceCyclic("Run", "1");
   %this.addTrigger("Run", "39", "1");
   %this.addTrigger("Run", "20", "2");
   %this.addSequence("./CrossbowSprint.dsq", "Sprint", "0", "25", "1", "0");
   %this.setSequenceCyclic("Sprint", "1");
   %this.addTrigger("Sprint", "17", "1");
   %this.addTrigger("Sprint", "7", "2");
   %this.addSequence("./CrossbowBack.dsq", "Back", "0", "22", "1", "0");
   %this.setSequenceCyclic("Back", "1");
   %this.addTrigger("Back", "7", "1");
   %this.addTrigger("Back", "18", "2");
   %this.addSequence("./CrossbowJump.dsq", "StandJump", "0", "22", "1", "0");
   %this.addSequence("./CrossbowStrafeLeft.dsq", "StrafeLeft", "0", "22", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addSequence("./CrossbowStrafeRight.dsq", "StrafeRight", "0", "22", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addSequence("./CrossbowReloadFire.dsq", "Attack1", "0", "22", "1", "0");
   %this.addSequence("./CrossbowFire.dsq", "Attack2", "0", "22", "1", "0");
   %this.addSequence("./CrossbowRunningJump.dsq", "RunningJump", "0", "22", "1", "0");
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
   %this.addTrigger("Attack1", "19", "3");
   %this.addTrigger("Attack2", "11", "3");
}
