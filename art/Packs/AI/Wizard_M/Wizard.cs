
singleton TSShapeConstructor(WizardDts)
{
   baseShape = "./Wizard.dts";
};

function WizardDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Wizard_M/TheWizard2_CombatModeA.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Wizard_M/TheWizard2_Walk.dsq", "Walk", "0", "-1");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("art/Packs/AI/Wizard_M/TheWizard2_Run.dsq", "Run2", "0", "21");
   %this.setSequenceCyclic("Run2", "1");
   %this.addSequence("art/Packs/AI/Wizard_M/TheWizard2_Dying.dsq", "death1", "0", "23");
   %this.addSequence("art/Packs/AI/Wizard_M/Staff_StraightDown.dsq", "attack1", "0", "23");
   %this.addSequence("art/Packs/AI/Wizard_M/Staff_SwingRight.dsq", "attack2", "0", "23");
   %this.addSequence("art/Packs/AI/Wizard_M/TheWizard2_TakingHit.dsq", "Damage1", "0", "23");
   %this.addSequence("art/Packs/AI/Wizard_M/TheWizard2_SpellCastD.dsq", "CastSpell1", "0", "23");
   %this.renameNode("staff", "mount0");
   %this.addTrigger("Walk", "36", "1");
   %this.addTrigger("Walk", "11", "2");
   %this.addTrigger("Run2", "18", "1");
   %this.addTrigger("Run2", "7", "2");
   %this.setSequenceGroundSpeed("Walk", "0 1.9 0");
   %this.setSequenceGroundSpeed("Run2", "0 4 0");
}
