
singleton TSShapeConstructor(GT_TalkerDts)
{
   baseShape = "./GT_Talker.dts";
};

function GT_TalkerDts::onLoad(%this)
{
   %this.addSequence("./GT_Root_Drink.dsq", "Root", "0", "-1", "1", "0");
   %this.addSequence("./GT_T_BeCarefulNow.dsq", "T_BeCarefulNow", "0", "601", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.addSequence("./GT_T_IWarnedYou.dsq", "T_IWarnedYou", "0", "60", "1", "0");
   %this.addSequence("./GT_T_LongTalk.dsq", "T_LongTalk", "0", "60", "1", "0");
   %this.removeDetailLevel("1500");
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
   %this.addSequence("./GT_Run.dsq", "Walk", "0", "22", "1", "0");
   %this.setSequenceCyclic("Walk", "1");
   %this.addSequence("./GT_Back.dsq", "Walk_Back", "0", "22", "1", "0");
   %this.setSequenceCyclic("Walk_Back", "1");
   %this.addSequence("./GT_StrafeLeft.dsq", "StrafeLeft", "0", "19", "1", "0");
   %this.setSequenceCyclic("StrafeLeft", "1");
   %this.addSequence("./GT_StrafeRight.dsq", "StrafeRight", "0", "19", "1", "0");
   %this.setSequenceCyclic("StrafeRight", "1");
   %this.addSequence("./GT_Damage1.dsq", "Damage1", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage2.dsq", "Damage2", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage3.dsq", "Damage3", "0", "19", "1", "0");
   %this.addSequence("./GT_Damage4.dsq", "Damage4", "0", "19", "1", "0");
   %this.addSequence("./GT_Death1.dsq", "Death1", "0", "19", "1", "0");
   %this.addSequence("./GT_Death2.dsq", "Death2", "0", "19", "1", "0");
   %this.addSequence("./GT_Death3.dsq", "Death3", "0", "19", "1", "0");
   %this.addSequence("./GT_Death4.dsq", "Death4", "0", "17", "1", "0");
}
