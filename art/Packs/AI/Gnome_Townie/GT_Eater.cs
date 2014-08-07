
singleton TSShapeConstructor(GT_EaterDts)
{
   baseShape = "./GT_Eater.dts";
};

function GT_EaterDts::onLoad(%this)
{
   %this.addSequence("./GT_Root_Eat.dsq", "Root", "0", "-1", "1", "0");
   %this.setSequenceCyclic("Root", "1");
   %this.removeDetailLevel("1500");
   %this.addImposter("0", "4", "0", "0", "256", "0", "0");
}
