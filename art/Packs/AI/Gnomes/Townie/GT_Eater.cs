
singleton TSShapeConstructor(GT_EaterDts)
{
   baseShape = "./GT_Eater.dts";
};

function GT_EaterDts::onLoad(%this)
{
   %this.addSequence("./GT_Root_Eat.dsq", "Root", "0", "-1", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./GT_Run.dsq", "Walk", "0", "36", "1", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("./GT_Back.dsq", "Walk_Back", "0", "36", "1", "0");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addSequence("./GT_StrafeLeft.dsq", "StrafeLeft", "0", "34", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addSequence("./GT_StrafeRight.dsq", "StrafeRight", "0", "19", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addSequence("./GT_Damage1.dsq", "Damage1", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage2.dsq", "Damage2", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage4.dsq", "Damage4", "0", "17", "1", "0");
   %this.addSequence("./GT_Damagefromback.dsq", "DamageFromBack", "0", "17", "1", "0");
   %this.addSequence("./GT_DamageKnockedBack.dsq", "DamageKnockedBack", "0", "17", "1", "0");
   %this.removeSequence("Walk");
   %this.removeSequence("Walk_Back");
   %this.removeSequence("StrafeLeft");
   %this.removeSequence("StrafeRight");
   %this.removeSequence("Damage1");
   %this.removeSequence("Damage2");
   %this.removeSequence("Damage4");
   %this.removeSequence("DamageFromBack");
   %this.removeSequence("DamageKnockedBack");
   %this.setSequenceGroundSpeed("Walk", "0 0.75 0");
   %this.setSequenceGroundSpeed("run2", "0 2 0");
}
