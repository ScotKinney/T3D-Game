
singleton TSShapeConstructor(GT_EaterDts)
{
   baseShape = "./GT_Eater.dts";
};

function GT_EaterDts::onLoad(%this)
{
   %this.addSequence("./GT_Root_Eat.dsq", "Root", "0", "-1", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./GT_Run.dsq", "Run", "0", "36", "1", "0");
   %this.setSequenceCyclic("Run", "1");
   %this.addSequence("./GT_Back.dsq", "Back", "0", "36", "1", "0");
   %this.setSequenceCyclic("Back", "1");
   %this.addSequence("./GT_StrafeLeft.dsq", "StrafeLeft", "0", "34", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addSequence("./GT_StrafeRight.dsq", "StrafeRight", "0", "19", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addSequence("./GT_Damage1.dsq", "Damage1", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage2.dsq", "Damage2", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage4.dsq", "Damage4", "0", "17", "1", "0");
   %this.addSequence("./GT_Damagefromback.dsq", "DamageFromBack", "0", "17", "1", "0");
   %this.addSequence("./GT_DamageKnockedBack.dsq", "DamageKnockedBack", "0", "17", "1", "0");
   %this.removeSequence("Run");
   %this.removeSequence("Back");
   %this.removeSequence("StrafeLeft");
   %this.removeSequence("StrafeRight");
   %this.removeSequence("Damage1");
   %this.removeSequence("Damage2");
   %this.removeSequence("Damage4");
   %this.removeSequence("DamageFromBack");
   %this.removeSequence("DamageKnockedBack");
}
