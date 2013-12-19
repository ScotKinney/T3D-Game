
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
}
