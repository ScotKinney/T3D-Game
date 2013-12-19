
singleton TSShapeConstructor(GnomeKingDts)
{
   baseShape = "./GnomeKing.dts";
};

function GnomeKingDts::onLoad(%this)
{
   %this.addSequence("./GK_Root.dsq", "Root", "0", "39", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./GK_CombatRun.dsq", "Run", "0", "74", "1", "0");
   %this.setSequenceCyclic("Run", "1");
   %this.addSequence("./GK_CombatSprint.dsq", "Sprint", "0", "39", "1", "0");
   %this.setSequenceCyclic("Sprint", "1");
   %this.addSequence("./GK_Back.dsq", "Back", "0", "21", "1", "0");
   %this.setSequenceCyclic("Back", "1");
   %this.addSequence("./GK_WalkLeft.dsq", "StrafeLeft", "0", "21", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addTrigger("StrafeLeft", "4", "1");
   %this.addTrigger("StrafeLeft", "18", "2");
   %this.addSequence("./GK_WalkRight.dsq", "StrafeRight", "0", "21", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addTrigger("StrafeRight", "13", "1");
   %this.addTrigger("StrafeRight", "7", "2");
   %this.addSequence("./GK_JumpStanding.dsq", "JumpStanding", "0", "21", "1", "0");
   %this.addSequence("./GK_JumpRunning.dsq", "JumpRunning", "0", "21", "1", "0");
   %this.addSequence("./GK_Swimming.dsq", "Swim", "0", "21", "1", "0");
   %this.setSequenceCyclic("Swim", "1");
   %this.addSequence("./GK_Damage1.dsq", "Damage1", "0", "21", "1", "0");
   %this.addSequence("./GK_Damage2.dsq", "Damage2", "0", "21", "1", "0");
   %this.addSequence("./GK_Damage3.dsq", "Damage3", "0", "21", "1", "0");
   %this.addSequence("./GK_DamageFromBack.dsq", "DamageFromBack", "0", "21", "1", "0");
   %this.addSequence("./GK_DamageKnockedBack.dsq", "DamageKnockedBack", "0", "21", "1", "0");
   %this.addSequence("./GK_DamageKnockedFore.dsq", "DamageKnockedFore", "0", "21", "1", "0");
   %this.addSequence("./GK_Attack1.dsq", "Attack1", "0", "21", "1", "0");
   %this.addSequence("./GK_Attack2.dsq", "Attack2", "0", "21", "1", "0");
   %this.addSequence("./GK_Attack3.dsq", "Attack3", "0", "21", "1", "0");
   %this.addSequence("./GK_Attack4.dsq", "Attack4", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell1.dsq", "CastSpell1", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell2.dsq", "CastSpell2", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell3.dsq", "CastSpell3", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell4.dsq", "CastSpell4", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell5.dsq", "CastSpell5", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell6.dsq", "CastSpell6", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell7.dsq", "CastSpell7", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell8.dsq", "CastSpell8", "0", "21", "1", "0");
   %this.addSequence("./GK_CastSpell9.dsq", "CastSpell9", "0", "21", "1", "0");
   %this.addSequence("./GK_Fall.dsq", "Fall", "0", "21", "1", "0");
   %this.setSequenceCyclic("Fall", "1");
   %this.addSequence("./GK_MakePotion.dsq", "MakePotion", "0", "21", "1", "0");
   %this.setSequenceCyclic("MakePotion", "1");
   %this.addSequence("./GK_Pointing.dsq", "T_1", "0", "21", "1", "0");
   %this.addSequence("./GK_Death1.dsq", "Death1", "0", "21", "1", "0");
   %this.addSequence("./GK_Death2.dsq", "Death2", "0", "17", "1", "0");
   %this.addSequence("./GK_Death3.dsq", "Death3", "0", "17", "1", "0");
   %this.addSequence("./GK_Death4.dsq", "Death4", "0", "17", "1", "0");
   %this.addTrigger("Run", "39", "1");
   %this.addTrigger("Run", "20", "2");
   %this.addTrigger("Sprint", "17", "1");
   %this.addTrigger("Sprint", "7", "2");
   %this.addTrigger("Back", "7", "1");
   %this.addTrigger("Back", "18", "2");
   %this.renameNode("GP_staff", "mount0");
   %this.addSequence("./GK_CombatmodeB.dsq", "CombatRoot", "0", "74", "1", "0");
   %this.setSequenceCyclic("CombatRoot", "1");
}
