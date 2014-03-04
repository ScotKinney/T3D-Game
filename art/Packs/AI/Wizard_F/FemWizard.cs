
singleton TSShapeConstructor(FemWizardDts)
{
   baseShape = "./FemWizard.dts";
};

function FemWizardDts::onLoad(%this)
{
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_Combat_Mode_C.dsq", "root", "0", "-1");
   %this.setSequenceCyclic("root", "1");
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_Walk.dsq", "Walk", "0", "-1");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_Run.dsq", "Run2", "0", "22");
   %this.setSequenceCyclic("Run2", "1");
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_StraightDownHit.dsq", "attack1", "0", "25");
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_SwingRight.dsq", "attack2", "0", "25");
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_Magic_Helix_Spell.dsq", "CastSpell1", "0", "25");
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_TakingHit.dsq", "Damage1", "0", "25");
   %this.addNode("mount0", "Bip01_R_Finger1", "0.810356 -0.0746008 1.60582 0.0052615 0.999652 0.0258351 3.11594", "1");
   %this.addSequence("art/Packs/AI/Wizard_F/FemWizard_Dying.dsq", "death1", "0", "25");
   %this.addTrigger("Walk", "36", "1");
   %this.addTrigger("Walk", "12", "2");
   %this.addTrigger("Walk", "87", "1");
   %this.addTrigger("Walk", "61", "2");
   %this.addTrigger("Run2", "19", "1");
   %this.addTrigger("Run2", "7", "2");
   %this.setSequenceGroundSpeed("Walk", "0 3.8 0");
   %this.setSequenceGroundSpeed("Run2", "0 4 0");
}
